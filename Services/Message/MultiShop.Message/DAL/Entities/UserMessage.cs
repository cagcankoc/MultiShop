namespace MultiShop.Message.DAL.Entities
{
    public class UserMessage
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public bool IsRead { get; set; }
        public DateTime Date { get; set; }
    }
}
