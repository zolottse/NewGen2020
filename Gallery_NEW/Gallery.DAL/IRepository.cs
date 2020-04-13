﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.DAL
{
    public interface IRepository
    {
        Task<bool> IsUserExistAsync(string username, string password);

        Task RegisterUserToDatabase(string username, string password);

        int GetUserId(string userName);

        string GetUserName(int id);
    }
}
