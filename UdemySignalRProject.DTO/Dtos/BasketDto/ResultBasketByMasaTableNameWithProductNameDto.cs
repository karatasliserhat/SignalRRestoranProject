using UdemySignalRProject.DTO.Dtos;

namespace UdemySignalRProject.DTO.BasketDto
{
    public class ResultBasketByMasaTableNameWithProductNameDto:ResultBasketDto
    {
        public string MenuTableName { get; set; }
        public string ProductName { get; set; }
    }
}
