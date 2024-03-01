namespace UdemySignalRProject.DTO.Dtos
{
    public class UpdateDiscountDto
    {
        public int DiscountId { get; set; }
        public string Title { get; set; }
        public string Amaount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

    }
}
