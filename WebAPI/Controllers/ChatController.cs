using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/chat")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IChatService service;
        private readonly IMapper<Chat, ChatViewModel> chatMapper;
        private readonly IMapper<IEnumerable<Chat>, IEnumerable<ChatViewModel>> chatsMapper;
        private readonly IMapper<ChatCreateViewModel, Chat> chatCreateMapper;

        public ChatController(
            IChatService service, 
            IMapper<Chat, ChatViewModel> chatMapper,
            IMapper<IEnumerable<Chat>, IEnumerable<ChatViewModel>> chatsMapper,
            IMapper<ChatCreateViewModel, Chat> chatCreateMapper)
        {
            this.service = service;
            this.chatMapper = chatMapper;
            this.chatsMapper = chatsMapper;
            this.chatCreateMapper = chatCreateMapper;
        }

        [HttpGet]
        public async Task<List<ChatViewModel>> GetAllChats()
        {
            var chats = await service.GetAllChatsAsync();

            return chatsMapper.Map(chats).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ChatViewModel> GetChatById([FromRoute]int id)
        {
            Chat chat = await service.GetChatById(id);
            
            return chatMapper.Map(chat);
        }

        [HttpGet("forUser{userId}")]
        public async Task<IEnumerable<ChatViewModel>> GetChatsForUser([FromRoute] int userId)
        {
            var chats = await service.GetChatsForUser(userId);
            return chatsMapper.Map(chats);
        }

        [HttpPost]
        public async Task<IActionResult> AddChat([FromBody] ChatCreateViewModel chat)
        {
            await service.AddChatAsync(chatCreateMapper.Map(chat));
            return NoContent();
        }
    }
}
