namespace Core.Entities
{
    public enum ChatType
    {
        Private, Group
    }

    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ChatType Type { get; set; }
        public IEnumerable<UserChat>? UserChats { get; set; }
        public IEnumerable<Message>? Messages { get; set; }
    }
}
