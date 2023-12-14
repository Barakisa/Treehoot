using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Treehoot.Application.Data;
using Treehoot.Domain.Models;


namespace Treehoot.Application.Services
{
    internal class UserService
    {
        private readonly TreehootApiContext _treehootApiContext;

        public UserService(TreehootApiContext treehootApiContext)
        {
            _treehootApiContext = treehootApiContext;
        }

        public async Task<User> LogIn(string username, string password)
        {
            var user = await _treehootApiContext.User
                                                .FirstOrDefaultAsync(user => (user.Email == username) ||
                                                                    (user.Name == username))
            if (user == null || user.Password != password)
            {
                return new User();
            }
            else
            {
                return user;
            }
        }

        public async Task<User> Register(string username, string password)
        {
            var userId = new Guid();
            _treehootApiContext.User.Add(new User() { Id = userId, 
                                                            Name = username, 
                                                            Email = username, 
                                                            Password = password });
            await _treehootApiContext.SaveChangesAsync();
            var newUser = await _treehootApiContext.User.FirstOrDefaultAsync(user => user.Id == userId);
            
            if (newUser == null)
            {
                return new User();
            }

            return newUser;
        }
    }
}
