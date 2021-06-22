using DigikalaDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigikalaRepository.Users
{
    public interface IUserRepository
    {
        User Login(string Username, string Password);
        //forget, change
        void Register(string Username, string Password);
        void RegisterSeller(string Username, string Password);
        User GetUser(User user);
        void ChangePassword(User user);
    }
}
