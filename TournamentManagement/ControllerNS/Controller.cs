using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TournamentManagement.Model;


namespace TournamentManagement.ControllerNS
{
    public class Controller
    {

        #region Attributes

        private List<Team> _teams;
        private List<Player> _players;
        private List<Referee> _referees;
        private List<Trainer> _trainers;
        private List<Physio> _physios;

        #endregion

        #region Properties

        public List<Team> Teams { get => _teams; set => _teams = value; }
        public List<Player> Players { get => _players; set => _players = value; }
        public List<Referee> Referees { get => _referees; set => _referees = value; }
        public List<Trainer> Trainers { get => _trainers; set => _trainers = value; }
        public List<Physio> Physios { get => _physios; set => _physios = value; }

        #endregion

        #region Constructors

        public Controller()
        {
            Teams = new List<Team>();
            Players = new List<Player>();
            Physios = new List<Physio>();
            Trainers = new List<Trainer>();
            Referees = new List<Referee>();
        }

        public Controller(List<Team> teams, List<Trainer> trainers, List<Referee> referees, List<Player> players, List<Physio> physios)
        {
            Teams = teams;
            Players = players;
            Physios = physios;
            Trainers = trainers;
            Referees = referees;
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

        public void InitData()
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = "Server=127.0.0.1;Port=3307;Database=tournament;Uid=root;Pwd=example";

            string selectIdsPlayer = "SELECT id FROM player";

            MySqlCommand cmd = new MySqlCommand(selectIdsPlayer, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Player p = new Player();
                    Participant.Id(reader.GetInt64("ID"));
                    Teilnehmer.Add(fs);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion
    }
}
