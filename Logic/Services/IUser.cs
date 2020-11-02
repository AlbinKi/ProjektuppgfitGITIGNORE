using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    public interface IUser
    {

        void AddSkill(Mechanic mechanic, string skill);

        void RemoveSkill();

        void EndErrand();

    }
}
