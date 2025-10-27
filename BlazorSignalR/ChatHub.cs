using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    // Send a message to all connected clients
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}