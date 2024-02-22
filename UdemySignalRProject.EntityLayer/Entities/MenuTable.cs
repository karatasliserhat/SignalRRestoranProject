namespace UdemySignalRProject.EntityLayer.Entities
{
    public class MenuTable
    {
        public int MenuTableId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
