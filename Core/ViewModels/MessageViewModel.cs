namespace Core.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SentAt { get; set; }
        public ChatViewModel? Chat { get; set; }
        public UserViewModel? Sender { get; set; }
    }
}
