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
            StreamReader sr = new StreamReader(path);

            string jsonString = sr.ReadToEnd();
            var entity = JsonSerializer.Deserialize<T>(jsonString);
            sr.Close();

            return entity;
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
            StreamWriter sw = new StreamWriter(path);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,

            };

            var jsonString = JsonSerializer.Serialize(users, options);

            sw.Write(jsonString);
            sw.Close();
        }

      

    }
}
