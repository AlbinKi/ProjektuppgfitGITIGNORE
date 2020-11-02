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
        private readonly string path = $@"DAL\{typeof(T).Name}.json";

        /// <summary>
        /// Hämtar alla objekt i en lista av förvald typ
        /// </summary>
        /// <returns></returns>
        ///
        public List<T> Load()
        {
          if (!File.Exists(path))
            {
                var fs = File.Create(path);
                fs.Close();
            }
            StreamReader sr = new StreamReader(path);

            string jsonString = sr.ReadToEnd();
            sr.Close();
            try
            {
                var entities = JsonSerializer.Deserialize<List<T>>(jsonString);
                return entities;
            }
            catch (JsonException)
            {
                return new List<T>();
            }     
        }

        /// <summary>
        /// Sparar en entitet
        /// </summary>
        /// <param name="entity"></param>
        public void Save(T entity)
        {
            var entities = Load();
            entities.Add(entity);

            StreamWriter sw = new StreamWriter(path);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,

            };

            var jsonString = JsonSerializer.Serialize(entities, options);

            sw.Write(jsonString);
            sw.Close();

        }
    }
}
