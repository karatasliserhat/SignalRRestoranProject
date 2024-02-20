using Microsoft.AspNetCore.SignalR;
using System.Net.WebSockets;
using UdemySignalRProject.BusinessLayer.Abstract;

namespace UdemySignalRProject.API.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
        }

        public async Task SendCategory()
        {
            var value = _categoryService.TCategoryCount();
            var activeValue = _categoryService.TActiveCategoryCount();
            var passiveValue = _categoryService.TPassiveCategoryCount();


            await Clients.All.SendAsync("ReceiveCategoryCount", value);
            await Clients.All.SendAsync("ReceiveCategoryActiveCount", activeValue);
            await Clients.All.SendAsync("ReceiveCategoryPassiveCount", passiveValue);
        }

        public async Task SendProduct()
        {
            var value = _productService.TProductCount();
            var hambugerProductCount = _productService.TProductCountByCategoryNameHamburger();
            var drinkProductCount = _productService.TProductCountByCategoryNameDrink();
            var productPriceAvg = _productService.TProductPriceAvg();
            var productPriceMin = _productService.TProductMinPrice();
            var productPriceMax = _productService.TProductMaxPrice();
            var productPriceAvgHamburger = _productService.TProductAvgByCategoryNameHamburger();


            await Clients.All.SendAsync("ReceiveProductCount", value);
            await Clients.All.SendAsync("ReceiveHamburgerProductCount", hambugerProductCount);
            await Clients.All.SendAsync("ReceiveDrinkProductCount", drinkProductCount);
            await Clients.All.SendAsync("ReceiveProductPriceAvg", productPriceAvg.ToString("0.00") + "₺");
            await Clients.All.SendAsync("ReceiveProductPriceMin", productPriceMin);
            await Clients.All.SendAsync("ReceiveProductPriceMax", productPriceMax);
            await Clients.All.SendAsync("ReceiveProductPriceAvgHamburger", productPriceAvgHamburger.ToString("0.00") + "₺");
        }

        public async Task SendOrder()
        {
            var totalOrderCount = _orderService.TTotalOrderCount();
            var activeOrderCount = _orderService.TActiveOrderCount();
            var lastOrderPrice = _orderService.TLastOrderPrice();
            var dateNowTotalPrice = _orderService.TDateNowTotalPrice();

            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00") + "₺");
            await Clients.All.SendAsync("ReceiveDateNowTotalPrice", dateNowTotalPrice.ToString("0.00") + "₺");
        }

        public async Task SendMoneyCases()
        {
            var totalAmaount = _moneyCaseService.TGetMoneyCaseTotalAmaount();

            await Clients.All.SendAsync("ReceiveMoneyCaseTotalAmaount", totalAmaount.ToString("0.00") + "₺");
        }

        public async Task SendMenuTables()
        {
            var menuTableCount = _menuTableService.TMenuTableCount();

            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTableCount);
        }
    }
}
