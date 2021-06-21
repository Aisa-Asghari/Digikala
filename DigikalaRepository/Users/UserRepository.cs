using DigikalaDataAccess;
using DigikalaDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DigikalaRepository.Users
{
    public class UserRepository : IUserRepository
    {
        public User Login(string Username, string Password)
        {
            using (var db = new DigikalaDB())
            {
                var item = db.Users.Where(x => x.UserName == Username && x.UserPassword == Password).FirstOrDefault();
                item.LasstLogin = DateTime.Now;
                item.LoginCount++;
                db.Users.Update(item);
                db.SaveChanges();
                return item;
            }
        }

        public void Register(string Username, string Password)
        {
            Username.Trim();
            Password.Trim();
            using (var db = new DigikalaDB())
            {
                var item = db.Users.Where(x => x.UserName == Username && x.UserType == 1).FirstOrDefault();
                if (item == null)
                {
                    var user = new User
                    {
                        UserName = Username,
                        UserPassword = Password,
                        LasstLogin = DateTime.Now,
                        LoginCount = 1,
                        UserType = 1,
                        FirstLogin = DateTime.Now
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                else return;
            }
        }
        public void RegisterSeller(string Username, string Password)
        {
            Username.Trim();
            Password.Trim();
            using (var db = new DigikalaDB())
            {
                var item = db.Users.Where(x => x.UserName == Username && x.UserType == 0).FirstOrDefault();

                var user = new User
                {
                    UserName = Username,
                    UserPassword = Password,
                    LasstLogin = DateTime.Now,
                    LoginCount = 1,
                    UserType = 0,
                    FirstLogin = DateTime.Now
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public List<User> GetUser(string username)
        {
            using (var db = new DigikalaDB())
            {
                return db.Users.Where(x => x.UserName.Equals(username)).ToList();
            }
        }

        public void ChangePassword(User user)
        {
            using (var db = new DigikalaDB())
            {
                var item = db.Users.Where(x => x.UserName == user.UserName).FirstOrDefault();
                item.UserPassword = user.UserPassword;
                db.SaveChanges();
            }
        }
    }
}