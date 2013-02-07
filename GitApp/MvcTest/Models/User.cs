using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcTest.Models
{
    public class User
    {
        [Remote("UserExist","Home")]
        public string UserName { set; get; }
        public string Password { set; get; }

        public static List<User> GetAllUser()
        {
            List<User> listUser = new List<User>();
            listUser.Add(new User()
            {
                UserName = "Ballck",
                Password = "123456"
            });

            listUser.Add(new User()
            {
                UserName = "Kahn",
                Password = "123456"
            });

            listUser.Add(new User()
            {
                UserName = "Muller",
                Password = "123456"
            });
            return listUser;
        }
        public static User GetUser(string UserName)
        {
            List<User> users = GetAllUser();
            return users.First(t => t.UserName == UserName);
        }

        public static User GetDefaultUser()
        {
            List<User> users = GetAllUser();
            return users.First(x => true);
        }
    }
}