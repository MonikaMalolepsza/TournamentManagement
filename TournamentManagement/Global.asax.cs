using System.Web;
using TournamentManagement.ControllerNS;

namespace TournamentManagement
{
    public class Global : HttpApplication
    {
        private static Controller _controller;

        public static Controller Controller { get => _controller; set => _controller = value; }

        protected void Application_Start()
        {
            Controller = new Controller();
        }
    }
}
