using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using TournamentManagement.ControllerNS;
using TournamentManagement.Model;

namespace TournamentManagement
{

    public partial class Default : System.Web.UI.Page
    {
        private Controller _contr;
        private List<Player> _player;

        public List<Player> Player { get => _player; set => _player = value; }
        public Controller Contr { get => _contr; set => _contr = value; }

        public Default() : base()
        {
            Player = new List<Player>();
            //Player = Global.Controller.Players;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Contr = Global.Controller;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // perform action
            Player = Contr.Players;
        }

    }
}
