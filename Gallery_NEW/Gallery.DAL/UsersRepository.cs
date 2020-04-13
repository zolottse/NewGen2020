﻿using Gallery.DAL.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Gallery.DAL
{
    public class UsersRepository : IRepository
    {
        private readonly UserContext _ctx;

        public UsersRepository(UserContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        public async Task<bool> IsUserExistAsync(string username, string password)
        {
            return await _ctx.Users.AnyAsync(u => u.EMail == username.Trim().ToLower() &&
                                             u.Password == password.Trim());
        }

        public async Task RegisterUserToDatabase(string username, string password)
        {
            _ctx.Users.Add(new User { EMail = username, Password = password });
            _ctx.SaveChanges();
        }

        public int GetUserId(string userName)
        {
            return _ctx.Users.Where(u => u.EMail == userName).Select(u => u.Id).FirstOrDefault();
        }

        public string GetUserName(int id)
        {
            return _ctx.Users.Where(u => u.Id == id).Select(u => u.EMail).FirstOrDefault();
        }
    }
}
