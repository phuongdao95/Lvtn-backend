using Microsoft.AspNetCore.SignalR;

namespace lvtn_backend.Hubs
{
    public class TaskBoardHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
