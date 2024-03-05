using Microsoft.AspNetCore.Mvc;
using MimeKit;
using UdemySignalRProject.UI.Dtos;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace UdemySignalRProject.UI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailBoxAdress = new MailboxAddress("SignalR Rezervasyon", "serhatkaratasli790@gmail.com");
            mimeMessage.From.Add(mailBoxAdress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("serhatkaratasli790@gmail.com", "yfzu lynk dxjk nmqa");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return RedirectToAction("Index", "Booking");
        }
    }
}
