using System;
namespace TournamentManagement.Model
{
    public class Trainer : Participant
    {

            #region Attributes

            private int _age;


            #endregion

            #region Properties

            public int Age
            {
                get => _age;
                set => _age = value;
            }

            #endregion

            #region Constructors

            public Trainer()
            {
                this.Age = 0;
            }

            public Trainer(string name) : base(name)
            {
                this.Age = 0;

            }

            public Trainer(string name, int age) : base(name)
            {
                this.Age = age;
            }

            #endregion

            #region Methods

            public int HowOld()
            {
                return this.Age;
            }

            public override string GiveInfo()
            {
                return base.GiveInfo() + ", " + $"Age: {Age}";
            }

            #endregion
        }
    
}
