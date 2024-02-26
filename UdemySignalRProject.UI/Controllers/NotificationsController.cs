using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.Enums;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly INotificationApiService _notificationApiService;
        private readonly IDataProtector _dataProtector;

        public NotificationsController(INotificationApiService notificationApiService, IDataProtectionProvider dataProtector)
        {
            _notificationApiService = notificationApiService;
            _dataProtector = dataProtector.CreateProtector("NotificationsController");
        }
        public void GetTrueFalseSelectList()
        {
            ViewBag.TFList = new SelectList(Enum.GetValues(typeof(TFEnum)));
        }
        public async Task<IActionResult> Index()
        {
            var response = await _notificationApiService.GetListAsync("Notifications");
            response.ForEach(x => { x.DataProtect = _dataProtector.Protect(x.NotificationId.ToString()); });

            return View(response);
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            GetTrueFalseSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {

            var responseMessage = await _notificationApiService.CrateAsync(createNotificationDto, "Notifications");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }
            GetTrueFalseSelectList();
            return View();

        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            var response = await _notificationApiService.DeleteAsync(dataUnprodected, "Notifications");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));
            var responseData = await _notificationApiService.UpdateGetByIdAsync(dataUnprodected, "Notifications");
            GetTrueFalseSelectList();
            return View(responseData);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateNotificationDto updateNotificationDto)
        {
            var responseMessage = await _notificationApiService.UpdateAsync(updateNotificationDto, "Notifications");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }
            GetTrueFalseSelectList();
            return View();

        }
        public async Task<IActionResult> NotificationStatusChangeToTrue(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            await _notificationApiService.NotificationChangeTrue("Notifications", "NotificationChangeTrue", dataUnprodected);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> NotificationStatusChangeToFalse(string id)
        {
            var dataUnprodected = int.Parse(_dataProtector.Unprotect(id));

            await _notificationApiService.NotificationChangeFalse("Notifications", "NotificationChangeFalse", dataUnprodected);
            return RedirectToAction("Index");

        }
    }
}
