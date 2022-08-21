namespace Core.ViewModels
{
    public class MessageCreateViewModel
    {
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
        public DateTime SentAt { get; set; }
        public string ChatName { get; set; }
    }
}
