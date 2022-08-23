namespace Core.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string SenderName { get; set; }
        public int SenderId { get; set; }
        public DateTime SentAt { get; set; }
        public int ChatId { get; set; }
        public UserViewModel? Sender { get; set; }
    }
}
