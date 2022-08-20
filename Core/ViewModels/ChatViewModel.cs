using Core.Entities;

namespace Core.ViewModels
{
    public class ChatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ChatType Type { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
