﻿using Microsoft.AspNet.SignalR;

namespace ScottyTestsWebHarness
{
    public class MyHub : Hub
    {
        public void Send( string message)
        {
            Clients.All.addMessage( message);
        }

        public void startRun()
        {
            
       }

    }
}

