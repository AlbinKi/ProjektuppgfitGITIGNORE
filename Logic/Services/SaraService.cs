using System;
using System.Collections.Generic;
using System.Text;


namespace Logic.Services
    {
        class SaraService
        {
            public void AddMechanicSkill(List<string> skill)
            {
                while (true)
                {
                   Console.Write("Ange kompetens att lägga till på bilmekaniker: ");
                   string addmechanicskill = Console.ReadLine().ToLower();

                    if (addmechanicskill == "breaks" || addmechanicskill == "engine" || addmechanicskill == "body" ||
                        addmechanicskill == "windshields" || addmechanicskill == "tire")
                    {
                        skill.Add(addmechanicskill);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig kompetens. Försök igen.");
                    }
                }

            }

            public void RemoveMechanicSkill(List<string> skills)
            {
                while (true)
                {
                    Console.Write("Ange kompetens att ta bort på bilmekaniker: ");
                    string removemechanicskill = Console.ReadLine().ToLower();

                    if (removemechanicskill == "breaks" || removemechanicskill == "engine" || removemechanicskill == "body" ||
                        removemechanicskill == "windshields" || removemechanicskill == "tire")
                    {
                        skills.Remove(removemechanicskill);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig kompetens. Försök igen.");
                    }
                }
            }
            //------------------------------------------------------------------------------------------------------------------------//
            public void AddSkill(List<string> skill)
            {
                while (true)
                {
                    Console.Write("Ange kompetens att lägga till: ");
                    string addskill = Console.ReadLine().ToLower();

                    if (addskill == "breaks" || addskill == "engine" || addskill == "body" ||
                        addskill == "windshields" || addskill == "tire")
                    {
                        skill.Add(addskill);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig kompetens. Försök igen.");
                    }
                }
            }

            public void RemoveSkill(List<string> skill)
            {
                while (true)
                {
                    Console.Write("Ange kompetens att ta bort: ");
                    string removeskill = Console.ReadLine().ToLower();

                    if (removeskill == "breaks" || removeskill == "engine" || removeskill == "body" ||
                        removeskill == "windshields" || removeskill == "tire")
                    {
                        skill.Remove(removeskill);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig kompetens. Försök igen.");
                    }
                }
            }
        }
    }


