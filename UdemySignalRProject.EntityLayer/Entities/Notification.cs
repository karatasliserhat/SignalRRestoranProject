namespace UdemySignalRProject.EntityLayer.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

    }
}
