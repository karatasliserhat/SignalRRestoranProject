namespace UdemySignalRProject.UI.Dtos
{
    public class UpdateBasketDto
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int MenuTableId { get; set; }
    }
}
