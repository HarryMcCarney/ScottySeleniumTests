using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace ScottyTestsWebHarness
{
    
        public class Startup
        {
            public void Configuration(Owin.IAppBuilder app)
            {
                var config = new HubConfiguration { EnableJSONP = true, EnableDetailedErrors = true };
                app.UseCors(CorsOptions.AllowAll);
                app.MapSignalR(config);
                app.UseNancy();
            }
        }
    }

