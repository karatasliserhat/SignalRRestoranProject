namespace UdemySignalRProject.UI.Dtos
{
    public class ResultBasketDto : GetBasketDto
    {
        public string MenuTableName { get; set; }
        public string ProductName { get; set; }
        public string DataProtect { get; set; }

        public decimal BasketTotalPrice { get { return TotalPrice * Count; } }
    }
}
