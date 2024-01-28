namespace UdemySignalRProject.DTO.Dtos
{
    public class UpdateContactDto
    {
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAdress { get; set; }
        public string FooterDescription { get; set; }
    }
}
