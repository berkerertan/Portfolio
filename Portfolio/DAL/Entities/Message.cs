namespace Portfolio.DAL.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public int NameSurname { get; set; }
        public int Subject { get; set; }
        public int Email { get; set; }
        public int MessageDetail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
