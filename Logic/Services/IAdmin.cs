using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    public interface IAdmin
    {

        List<Mechanic> AvailableMechanics(Errand x);

        void AddMechanic(string x, string y, DateTime z);

        void AddSkill(Mechanic x, string y);

        void AddUser(User x);


        //public void ChangeMechanic()
        //{

        //}

        //public void AddMechanicSkill()
        //{

        //}

        //public void RemoveMechanicSkill()
        //{

        //}

        //public void AddUser() //Måste kopplas till en mekaniker.
        //{

        //}

        //public void RemoveUser()
        //{

        //}

        //public void AddErrand()
        //{

        //}

    }
}
