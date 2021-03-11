using System;
namespace TournamentManagement.Model
{
    public abstract class Participant
    {

        #region Attributes

        private string _name;
        private int _id;


        #endregion

        #region Properties

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }


        #endregion

        #region Constructors

        public Participant()
        {
            Name = "";
        }

        public Participant(string name)
        {
            Name = name;
        }

        #endregion

        #region Methods

        public virtual string GiveInfo()
        {
            return this.Name;
            // Console.WriteLine(this.Name);
        }

        public virtual void save()
        {

        }

        #endregion
   
    }
}
  
