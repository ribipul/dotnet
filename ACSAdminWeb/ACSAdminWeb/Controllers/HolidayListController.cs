using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACSAdminWeb.Models;

namespace ACSAdminWeb.Controllers
{
    public class HolidayListController : Controller
    {
        //
        // GET: /HolidayList/
        //private SearchHoliday searchHoliday = new SearchHoliday("", "", "", "");
        UpdateGroupViewModel groupModel = new UpdateGroupViewModel();
        const int pageSize = 20;

        [HttpGet]
        public ActionResult Index(int page = 1, string fromDate = "", string toDate = "", string EmployeeGroup = "")
        {
            if (Request.IsAuthenticated)
            {
                string strSearch = "";
                string strGroup = "";

                if (EmployeeGroup == "")
                {
                    strSearch = "";
                    strGroup = "";
                }
                else
                {
                    if (EmployeeGroup=="General Holiday")
                    {
                        strSearch = EmployeeGroup;
                        strGroup = "All";
                    }
                    else
                    {
                        strSearch = EmployeeGroup.Substring(10, EmployeeGroup.Length - 11);
                        strGroup = EmployeeGroup.Substring(7, 1);
                    }
                }

                SearchHoliday searchHoliday = new SearchHoliday(fromDate, toDate, strGroup, strSearch);

                ViewBag.TotalPages = (int)Math.Ceiling((double)searchHoliday.HolidayLists.Count() / pageSize);

                searchHoliday.HolidayLists = searchHoliday.HolidayLists
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                ViewBag.CurrentPage = page;
                ViewBag.PageSize = pageSize;

                //if (fromDate == "")
                //{
                //    ViewBag.FromDate = DateTime.Now.ToShortDateString();
                //}
                //else
                //{
                //    ViewBag.FromDate = fromDate;
                //}

                //if (toDate == "")
                //{
                //    ViewBag.ToDate = DateTime.Now.ToShortDateString();
                //}
                //else
                //{
                //    ViewBag.ToDate = toDate;
                //}

                //ViewBag.Search = EmployeeGroup;
                ViewBag.FromDate = fromDate;
                ViewBag.ToDate = toDate;

                var groups = groupModel.Groups;
                ViewBag.EmployeeGroup = new SelectList(groups, "EmployeeGroup", "EmployeeGroup");
                ViewBag.Search = EmployeeGroup;

                return View(searchHoliday.HolidayLists);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }
    }
}
