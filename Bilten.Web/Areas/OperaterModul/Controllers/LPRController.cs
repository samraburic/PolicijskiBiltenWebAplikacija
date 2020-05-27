//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Threading.Tasks;
//using Bilten.Data;
//using Bilten.Data.Models;
//using Bilten.Web.Areas.OperaterModul.ViewModels;
//using Bilten.Web.Helper;
//using Microsoft.AspNetCore.Mvc;
//using Ozeki.Camera;
//using Ozeki;
//using Ozeki.Media;
//using Ozeki.Vision;

//namespace Bilten.Web.Areas.OperaterModul.Controllers
//{
//    [Area("OperaterModul")]
//    public class LPRController : Controller
//    {
//        private OzekiCamera camera;
//        private MediaConnector _connector;
//        private CameraURLBuilderWF _myCameraUrlBuilder;
//        private ImageProcesserHandler _imageProcesserHandler;
//        private ILicensePlateRecognizer _licensePlateRecognizer;
//        private ILineDetector _lineDetector;
//        private DrawingImageProvider _originalImageProvider;
//        private DrawingImageProvider _processedImageProvider;

//        private readonly MojContext _context;

//        public LPRController(MojContext db)
//        {
//            _context = db;
//        }

//        public IActionResult Index()
//        {
//            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
//            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
//            if (korisnik == null || k.VrstaKorisnikaId != 2)
//            {
//                TempData["error_poruka"] = "Nemate pravo pristupa!";
//                return Redirect("/Autentifikacija/Index");
//            }

//            _myCameraUrlBuilder = new CameraURLBuilderWF();
//            _connector = new MediaConnector();
//            _originalImageProvider = new DrawingImageProvider();
//            _processedImageProvider = new DrawingImageProvider();

//            _licensePlateRecognizer = ImageProcesserFactory.CreateLicensePlateRecognizer();
//            //_licensePlateRecognizer.DetectionOccurred += _licensePlateRecognizer_DetectionOccurred;

//            _imageProcesserHandler = new ImageProcesserHandler();
//            _imageProcesserHandler.AddProcesser(_licensePlateRecognizer);
//            LPRtestVM model = new LPRtestVM(){
//            };

//            //camera


//            return View();
//        }

        
//    }
//}