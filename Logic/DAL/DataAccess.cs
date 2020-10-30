using Logic.Entities;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Logic.DAL
{
    public class DataAccess<T>
    {
        //Path == T:s beteckning. Exempelvis DataAccess<User> gör så att pathen blir Dal\User.Json
        private string path = $@"DAL\{typeof(T).Name}.json";


        /// <summary>
        /// Hämtar alla objekt i en lista av förvald typ
        /// </summary>
        /// <returns></returns>
        /// 
        public T GetEntities()
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======
         
>>>>>>> parent of dd3800b... Merge pull request #1 from AlbinKi/Albin-V1
=======
         
>>>>>>> parent of 6b91630... nya saker
            StreamReader sr = new StreamReader(path);

            string jsonString = sr.ReadToEnd();
            var entity = JsonSerializer.Deserialize<T>(jsonString);
            sr.Close();

            return entity;
<<<<<<< HEAD
<<<<<<< HEAD
        }

        public void AddEntity(T listclass)
        {
            StreamWriter sw = new StreamWriter(path);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,

            };

            var jsonString = JsonSerializer.Serialize(listclass, options);

            sw.Write(jsonString);
            sw.Close();
        }

        /// <summary>
        /// Overloadar addentity metoden om det inte finns några users i databasen.
        /// </summary>
        /// <param name="users"></param>
        private void AddEntity(List<User> users)
        {
            StreamWriter sw = new StreamWriter(path);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,

            };

            var jsonString = JsonSerializer.Serialize(users, options);

            sw.Write(jsonString);
            sw.Close();
        }  
        private void AddEntity(List<Mechanic> users)
        {
=======
        }

        public void AddEntity(T listclass)
        {
           
>>>>>>> parent of dd3800b... Merge pull request #1 from AlbinKi/Albin-V1
=======
        }

        public void AddEntity(T listclass)
        {
           
>>>>>>> parent of 6b91630... nya saker
            StreamWriter sw = new StreamWriter(path);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,

            };

<<<<<<< HEAD
<<<<<<< HEAD
            var jsonString = JsonSerializer.Serialize(users, options);
=======
            var jsonString = JsonSerializer.Serialize(listclass, options);
>>>>>>> parent of dd3800b... Merge pull request #1 from AlbinKi/Albin-V1
=======
            var jsonString = JsonSerializer.Serialize(listclass, options);
>>>>>>> parent of 6b91630... nya saker

            sw.Write(jsonString);
            sw.Close();
        }

      

    }
}
