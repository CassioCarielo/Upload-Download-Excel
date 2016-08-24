using System.Web;
using System.Web.Mvc;
using OpenXMLExcel.Models;

namespace OpenXMLExcel.Controllers
{
    public class HomeController : Controller
    {
        private const string SessionExcelData = "SessionExcelData";

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase excelFile)
        {
            if (excelFile == null)
            {
                ExcelDados dataErro = new ExcelDados();
                dataErro.Status = new ExcelStatus { Message = "Arquivo em branco." };
                return View("Index", dataErro.Status);
            }
            var data = (new ExcelLeitura()).ReadExcel(excelFile);
            Session[SessionExcelData] = data;

            return View("Index", data.Status);
        }

        public ActionResult DownloadFile()
        {
            var data = (ExcelDados)Session[SessionExcelData];
            if (data == null)
            {
                ViewData["RedirectUrl"] = Url.Action("Index");
                return View("Index");
            }

            var file = (new ExcelGravacao()).GenerateExcel(data);
            Response.AddHeader("Content-Disposition", "attachment; filename=ExcelFile.xlsx");
            return new FileContentResult(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
