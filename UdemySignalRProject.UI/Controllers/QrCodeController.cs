using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace UdemySignalRProject.UI.Controllers
{
    public class QrCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQrCode = new QRCodeGenerator();

                QRCodeGenerator.QRCode squareCode = createQrCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap image = squareCode.GetGraphic(10))
                {

                    image.Save(memoryStream, ImageFormat.Png);
                    ViewBag.OrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}
