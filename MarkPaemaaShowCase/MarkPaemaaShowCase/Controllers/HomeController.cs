using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkPaemaaShowCase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What is this website all about?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How you can contact me:";

            return View();
        }

        public FileResult Download(String resumeType)
        {
            switch (resumeType)
            {
                case "DevPDF":
                    return File("~/App_Data/Downloads/Candidate Senior Software Developer - Mark Paemaa.pdf", 
                        System.Net.Mime.MediaTypeNames.Application.Pdf, "Candidate Senior Software Developer - Mark Paemaa.pdf");
                case "TeamLeaderPDF":
                    return File("~/App_Data/Downloads/Candidate Software Team Lead - Mark Paemaa.pdf", 
                        System.Net.Mime.MediaTypeNames.Application.Pdf, "Candidate Software Team Lead - Mark Paemaa.pdf");
                case "DevDocx":
                    return File("~/App_Data/Downloads/Candidate Senior Software Developer - Mark Paemaa.docx", 
                        System.Net.Mime.MediaTypeNames.Application.Octet, "Candidate Senior Software Developer - Mark Paemaa.docx");
                case "TeamLeaderDocx":
                    return File("~/App_Data/Downloads/Candidate Software Team Lead - Mark Paemaa.docx", 
                        System.Net.Mime.MediaTypeNames.Application.Pdf, "Candidate Software Team Lead - Mark Paemaa.docx");
                default:
                    return File("~/App_Data/Downloads/Candidate Senior Software Developer - Mark Paemaa.pdf",
                        System.Net.Mime.MediaTypeNames.Application.Pdf, "Candidate Senior Software Developer - Mark Paemaa.pdf");
            }
        }
    }
}