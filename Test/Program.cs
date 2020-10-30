using System;
using System.Collections.Generic;
using GUI;
using Logic;
using Logic.Entities;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Mechanic mechanic = new Mechanic();

            List<string> skills = new List<string>();

            mechanic.AddSkill(skills);
            mechanic.AddSkill(skills);
            mechanic.AddSkill(skills);
            admin.AddMechanicSkill(skills);
            admin.AddMechanicSkill(skills);
            Console.WriteLine();
            mechanic.RemoveSkill(skills);
            admin.RemoveMechanicSkill(skills);

            Console.WriteLine();
            foreach (var skill in skills)
            {
                Console.WriteLine(skill);
            }



        }
    }
}
