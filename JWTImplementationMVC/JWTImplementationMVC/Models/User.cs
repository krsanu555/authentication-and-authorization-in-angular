using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWTImplementationMVC.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public string[] Roles { get; set; }
    }
    public class UserRepository
    {
        public List<User> TestUsers;
        public UserRepository()
        {
            TestUsers = new List<User>();
            TestUsers.Add(new User() { UserName = "Admin", Password = "Admin", Roles = new string[1] { "admin"} });
            TestUsers.Add(new User() { UserName = "Teacher", Password = "Teacher", Roles = new string[1] { "teacher" } });
            TestUsers.Add(new User() { UserName = "Student", Password = "Student", Roles = new string[1] { "student" } });

        }
        public User GetUser(string username,string password)
        {
            try
            {
                return TestUsers.First(user => user.UserName.Equals(username) &&user.Password.Equals(password));
            }
            catch
            {
                return null;
            }
        }
    }

    }