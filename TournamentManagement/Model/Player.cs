using System;
using MySql.Data.MySqlClient;

namespace TournamentManagement.Model
{
    public class Player : Participant
    {
        #region Attributes

        private double _speed;
        private bool _active;
        private string _surname;

        #endregion

        #region Properties

        public double Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        public bool Active
        {
            get => _active;
            set => _active = value;
        }

        #endregion

        #region Constructors

        public Player()
        {
            this.Speed = 0;
        }

        public Player(string name) : base(name)
        {
            this.Speed = 0;
        }

        public Player(string name, double speed, bool active) : base(name)
        {
            this.Speed = speed;
            this.Active = active;
        }

        #endregion

        #region Methods

        public bool IsActive()
        {
            return this.Active;
        }

        public void SwitchActive()
        {
            this.Active = !this.Active;
        }

        public override string GiveInfo()
        {
            return base.GiveInfo() + $"{Surname}" + ", " + $"Speed: {Speed}" + ", " + $"{(Active ? "Ja" : "Nein")}";
        }

        //        public override void save()
        //        {
        //            // connection to the dockerized mysql, look into the docker file to see/change the credentials and exposed port.
        //
        //            MySqlConnection connection = new MySqlConnection();
        //            connection.ConnectionString = "Server=127.0.0.1;Port=3307;Database=tournament;Uid=root;Pwd=example";
        //
        //            try
        //            {
        //                connection.Open();
        //                string query = "";
        //                MySqlCommand command = new MySqlCommand(query, connection);
        //                MySqlDataReader reader = command.ExecuteReader();
        //
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine("Something went wrong. " + e); ;
        //            }
        //        }
        public override void save()
        {
            // connection to the dockerized mysql, look into the docker file to see/change the credentials and exposed port.

            /*
             * TODO: make an admin user, don't use root!
             * TODO 2: fetch the ids first to find the player to update.
             * TODO 3: will name be saved to the participant table every time? Bad model? Teilnehmer should save the name?
             */

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = "Server=127.0.0.1;Port=3307;Database=tournament;Uid=root;Pwd=example";

            string updateSpieler = $"UPDATE player SET surname='{Surname}', speed='{Speed}', active='{Active}', WHERE id='{Id}'";
            string updateName = $"UPDATE participant SET name='{Name}', WHERE id='{Id}'";

            connection.Open();
            //Transaction, because more tables need an update.
            MySqlTransaction transaction = connection.BeginTransaction();

            MySqlCommand command = new MySqlCommand
            {
                Connection = connection,
                Transaction = transaction
            };

            try
            {
                command.CommandText = updateSpieler;
                command.ExecuteNonQuery();
                command.CommandText = updateName;
                command.ExecuteNonQuery();
                transaction.Commit();
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
