using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string item, int id) : base($"{item} with ID: {id} was not found.")
        {
        }
        public NotFoundException(string item, string parent, int id) : base($"The {parent} with ID: {id} has no {item}.")
        {
        }
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
