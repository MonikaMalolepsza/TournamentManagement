using System;
using TournamentManagement.Model;


namespace TournamentManagement.ControllerNS
{
    public class Controller
    {

        #region Attributes

        private Team _team;
        private Player _player;
        private Referee _referee;
        private Trainer _trainer;
        private Physio _physio;

        #endregion

        #region Properties

        public Physio Physio
        {
            get => _physio;
            set => _physio = value;
        }

        public Trainer Trainer
        {
            get => _trainer;
            set => _trainer = value;
        }

        public Team Team
        {
            get => _team;
            set => _team = value;
        }

        public Player Player
        {
            get => _player;
            set => _player = value;
        }

        public Referee Referee
        {
            get => _referee;
            set => _referee = value;
        }

        #endregion

        #region Constructors

        public Controller()
        {
            Team = new Team();
            Player = new Player();
            Physio = new Physio();
            Trainer = new Trainer();
            Referee = new Referee();
        }

        public Controller(Team team, Trainer trainer, Referee referee, Player player, Physio physio)
        {
            Team = team;
            Player = player;
            Physio = physio;
            Trainer = trainer;
            Referee = referee;
        }

        #endregion

        #region Methods

        public void Test()
        {
            Player s = new Player("Jens", 70.5, true);
            Trainer t = new Trainer("Thomas", 50);
            Physio p = new Physio("Monika", 2);
            Team m = new Team("FC Koeln");
            m.NewMember(s);
            m.NewMember(t);
            m.NewMember(p);

        }

        #endregion
    }
}
