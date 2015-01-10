using Microsoft.AspNet.SignalR;
using ScottyTestsWebHarness;

namespace ExpawayMatching.App
{
    public class WebOutput 
    {
        public void Write(string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.addMessage(message);

        }

        public void ShowButton()
        {
            throw new System.NotImplementedException();
        }

        public void ShowButton(string Id)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.showResultsButton(Id);
            
        }


    }
}
