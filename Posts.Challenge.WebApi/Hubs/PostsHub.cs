using Microsoft.AspNetCore.SignalR;

namespace Posts.Challenge.WebApi.Hubs
{
    public sealed class PostsHub : Hub<IPostHubProvider>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId} entrou");
        }

        public async Task ReceiveMessage(string user, string title, string content)
        {
            await Clients.All.ReceiveMessage(user, title, content);
        }
    }

    public interface IPostHubProvider
    {
        Task ReceiveMessage(string user, string title, string content);

        Task ReceiveMessage(string message);
    }

}
