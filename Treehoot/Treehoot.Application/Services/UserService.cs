using Microsoft.EntityFrameworkCore;
using Treehoot.Application.Data;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;


namespace Treehoot.Application.Services
{
    public class UserService : IUserService
    {
        private readonly TreehootApiContext _treehootApiContext;

        public UserService(TreehootApiContext treehootApiContext)
        {
            _treehootApiContext = treehootApiContext;
        }

        public async Task<KeyValuePair<string?, string>> LogIn(string email, string password)
        {
            var user = await _treehootApiContext.User
                                                .FirstOrDefaultAsync(user => user.Email == email);
            if (user == null || user.Password != password)
            {
                return new KeyValuePair<string?, string>(null, "Username or password incorrect");
            }
            
            return new KeyValuePair<string?, string>(user.Username, "Login successful");
        }

        public async Task<KeyValuePair<bool, string>> Register(string email, string username, string password)
        {
            var userId = Guid.NewGuid();
            _treehootApiContext.User.Add(new User() { Id = userId, 
                                                            Username = username, 
                                                            Email = email, 
                                                            Password = password });
            await _treehootApiContext.SaveChangesAsync();
            var newUser = await _treehootApiContext.User.FirstOrDefaultAsync(user => user.Id == userId);
            
            return newUser == null ? new KeyValuePair<bool, string>(false, "Unexpectedly couldn't create new user (problem with Database)") 
                                   : new KeyValuePair<bool, string>(true, "Registration successful");
        }
    }
}
