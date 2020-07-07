using System.Linq;
using System.Collections.Generic;
using newprojet.models;

namespace newprojet.Repositories
{
  public static class UserRepository
  {

    public static User Get(string username, string password)
    {
      var users = new List<User>();

      users.Add( new User {Id = 1, Username = "batman", Password="123", Role="manager"});
      users.Add( new User {Id = 2, Username = "robin", Password="123", Role="employee"});

      return users.Where( x => x.Username.ToLower() == username && x.Password == password).FirstOrDefault();
    }
  }
}