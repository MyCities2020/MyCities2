using MyCities2API.Models;
using System.Collections.Generic;


namespace MyCities2API.Services
{
   public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUser(string id="", string partitionkey="");

        public User AddUser(User item);

        public User UpdateUser(User item);

        public void DeleteUser(string id, string PartitionKey = "");

        public User GetUserByEmail(string email);

    
    }
}
