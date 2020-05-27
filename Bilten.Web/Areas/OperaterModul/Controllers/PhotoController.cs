using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace Bilten.Web.Areas.OperaterModul.Controllers
{
    [Area("OperaterModul")]
    public class PhotoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //public ActionResult Capture()
        //{
        //    //var stream = Request.InputStream;
        //    //string dump;

        //    //using (var reader = new StreamReader(stream))
        //    //{
        //    //    dump = reader.ReadToEnd();

        //    //    DateTime nm = DateTime.Now;
        //    //    string date = nm.ToString("yyyymmddMMss");

        //    //    var path = Server.MapPath("~/WebImages/" + date + "test.jpg");

        //    //    System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));

        //    //    ViewData["path"] = date + "test.jpg";

        //    //    Session["val"] = date + "test.jpg";
        //    //}

        //    //return View("Index");
        //}

        private byte[] String_To_Bytes2(string strInput)
        {
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];
            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }
            return bytes;
        }

    }

}