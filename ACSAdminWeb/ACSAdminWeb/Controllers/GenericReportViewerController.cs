using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

namespace CR_With_MVC.Controllers
{
    public class GenericReportViewerController : Controller
    {
        //
        // GET: /GenericReportViewer/

        public ActionResult Index()
        {
            return View();
        }
        
        public void ShowGenericRpt()
        {
            try
            {
                bool isValid = true;

                string strReportName = System.Web.HttpContext.Current.Session["ReportName"].ToString();     // Setting ReportName
                string strFromDate = System.Web.HttpContext.Current.Session["rptFromDate"].ToString();      // Setting FromDate 
                string strToDate = System.Web.HttpContext.Current.Session["rptToDate"].ToString();          // Setting ToDate
                string strYear = System.Web.HttpContext.Current.Session["rptYear"].ToString();              // Setting Year
                string strType = System.Web.HttpContext.Current.Session["rptType"].ToString();              // Setting Type
                string strSelectType = System.Web.HttpContext.Current.Session["rptSelectType"].ToString();  // Setting Type

                var rptSource = System.Web.HttpContext.Current.Session["rptSource"];

                if (string.IsNullOrEmpty(strReportName))
                {
                    isValid = false;
                }

                if (isValid)
                {
                    //CrystalReportViewer crViewer = new CrystalReportViewer();
                    ReportDocument rd = new ReportDocument();
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Rpts//" + strReportName;
                    rd.Load(strRptPath);
                    if (rptSource != null && rptSource.GetType().ToString() != "System.String")
                        rd.SetDataSource(rptSource);
                    if (!string.IsNullOrEmpty(strFromDate) && !string.IsNullOrEmpty(strToDate))
                        rd.SummaryInfo.ReportTitle = Convert.ToDateTime(strFromDate).ToString("MMMM d, yyyy") + " To " + Convert.ToDateTime(strToDate).ToString("MMMM d, yyyy");
                    if (!string.IsNullOrEmpty(strYear) && strSelectType == "1")
                    {
                        rd.SummaryInfo.ReportTitle = "REPORTS OF YEAR - " + strYear;
                    }
                    // Clear all sessions value
                    Session["ReportName"] = null;
                    Session["rptFromDate"] = null;
                    Session["rptToDate"] = null;
                    Session["rptSource"] = null;
                    Session["rptYear"] = null;
                    Session["rptType"] = null;
                    Session["rptSelectType"] = null;
                    Session["rptEmployeeId"] = null;

                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
                    //crViewer.ReportSource = rd;
                }
                else
                {
                    Response.Write("<H2>Nothing Found; No Report name found</H2>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        public void ShowGenericLeaveRpt()
        {
            try
            {
                bool isValid = true;

                string strReportName = System.Web.HttpContext.Current.Session["ReportName"].ToString();     // Setting ReportName
                
                var rptSource = System.Web.HttpContext.Current.Session["rptSource"];

                if (string.IsNullOrEmpty(strReportName))
                {
                    isValid = false;
                }

                if (isValid)
                {
                    ReportDocument rd = new ReportDocument();
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Rpts//" + strReportName;
                    rd.Load(strRptPath);
                    if (rptSource != null && rptSource.GetType().ToString() != "System.String")
                        rd.SetDataSource(rptSource);

                    // Clear all sessions value
                    Session["ReportName"] = null;
                    Session["rptSource"] = null;
                    Session["rptEmployeeId"] = null;

                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
                }
                else
                {
                    Response.Write("<H2>Nothing Found; No Report name found</H2>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
