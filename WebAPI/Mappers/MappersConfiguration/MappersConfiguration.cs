using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Mappers.Configuration
{
    public static class MappersConfiguration
    {
        public static void AddCustomMappers(this IServiceCollection services)
        {
            services.AddScoped<IMapper<User, UserViewModel>, UserViewModelMapper>();
            services.AddScoped<IMapper<IEnumerable<User>, IEnumerable<UserViewModel>>, UsersViewModelMapper>();

            services.AddScoped<IMapper<Chat, ChatViewModel>, ChatViewModelMapper>();
            services.AddScoped<IMapper<IEnumerable<Chat>, IEnumerable<ChatViewModel>>, ChatsViewModelMapper>();
            services.AddScoped<IMapper<ChatCreateViewModel, Chat>, ChatCreateViewModelMapper>();

            services.AddScoped<IMapper<Message,MessageViewModel>, MessageViewModelMapper>();
            services.AddScoped<IMapper<IEnumerable<Message>, IEnumerable<MessageViewModel>>,MessagesViewModelMapper>();
            services.AddScoped<IMapper<MessageCreateViewModel, Message>, MessageCreateViewModelMapper>();
        }
    }
}
