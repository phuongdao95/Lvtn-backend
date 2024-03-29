﻿using Microsoft.AspNetCore.SignalR;

namespace lvtn_backend.Hubs
{
    public class TaskBoardHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            var context = Context.GetHttpContext();

            if (context == null)
            {
                return base.OnConnectedAsync();
            }

            var userIdClaim = context.User.Claims.Where(claim => claim.Type == "user_id").Single();

            Groups.AddToGroupAsync(
                Context.ConnectionId,
                userIdClaim.Value);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var context = Context.GetHttpContext();

            if (context == null)
            {
                return base.OnDisconnectedAsync(exception);
            }

            var userIdClaim = context.User.Claims.Where(claim => claim.Type == "user_id").Single();

            Groups.RemoveFromGroupAsync(
                Context.ConnectionId,
                userIdClaim.Value);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
