using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/message")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;
        private readonly IMapper<IEnumerable<Message>, IEnumerable<MessageViewModel>> messagesMapper;

        public MessageController(
            IMessageService messageService,
            IMapper<IEnumerable<Message>, IEnumerable<MessageViewModel>> messagesMapper)
        {
            this.messageService = messageService;
            this.messagesMapper = messagesMapper;
        }

        [HttpGet("{chatId}/{skip}/{take}")]
        public async Task<IEnumerable<MessageViewModel>> GetMessagesForChat(
            [FromRoute]int chatId, 
            [FromRoute]int skip, 
            [FromRoute]int take)
        {
            var messages = await messageService.GetMessagesForChat(chatId, skip, take);

            var mappedMessages = messagesMapper.Map(messages);
            return mappedMessages.ToList();
        }
    }
}
