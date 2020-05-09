using MyCities2API.Models;
using MyCities2API.Services;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace AutoShop_Shared.Services
{
    public class JsonFileRepository<T> : IRepository<T>
    {
        public void DeleteItem(string id, string PartitionKey = "")
        {
            throw new System.NotImplementedException();
        }

        public T GetItem(string id, string partitionKey)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Retourne des items venant d'un fichier JSON
        /// </summary>
        /// <param name="filepath">Chemin du fichier JSON</param>
        /// <returns>List du Type généric T</returns>
        public List<T> GetItems(AppSettings settings)
        {
            string result = "";
            if (typeof(T) == typeof(Batiment))
            {
                result = System.IO.File.ReadAllText(settings.FilePath + settings.BadgesFileName);
            }
            if (typeof(T) == typeof(User))
            {
                result = System.IO.File.ReadAllText(settings.FilePath + settings.UsersFileName);
            }

            //Transformer le contenu en Objet c# => Desérialiser
            List<T> items = JsonConvert.DeserializeObject<List<T>>(result);

            //Retourner le résultat
            return items;
        }

        //public List<Batiment> GetItems(int id)
        //{
        //    //throw new System.NotImplementedException();
        //    return id;
        //}

        //public List<Batiment> GetItems(string id)
        //{
        //    throw new System.NotImplementedException();
        //}

        public T InsertItem(T item)
        {   
          throw new System.NotImplementedException();
        }

        public T UpdateItem(T item)
        {
       
            throw new System.NotImplementedException();
       
        
        }
    }
}
