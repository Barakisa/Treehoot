using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices
{
    public interface IUserService
    {
        public Task<KeyValuePair<string?, string>> LogIn(string username, string password);
        public Task<KeyValuePair<bool, string>> Register(string email, string username, string password);
    }
}
