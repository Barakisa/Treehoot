using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treehoot.Domain.Interfaces;

namespace Treehoot.Domain.Models
{
    public class Playground : IPlayground
    {
        private Dictionary<int, Guid> HostedQuizes = new();
        private const int CodeMin = 1;
        private const int CodeMax = 999999;

        public int AddHostedQuiz(Guid quizId)
        {
            var quizCode = GenerateQuizCode();
            HostedQuizes.Add(quizCode, quizId);

            return quizCode;
        }

        public bool RemoveHostedQuiz(int quizCode)
        {
            return HostedQuizes.Remove(quizCode);
        }

        public Dictionary<int, Guid> GetAllHostedQuizes()
        {
            return new Dictionary<int, Guid>(HostedQuizes);
        }

        public Guid GetHostedQuizGuidByCode(int code)
        {
            return new Guid(HostedQuizes[code].ToString());
        }

        public bool IsHosted(int code)
        {
            return HostedQuizes.ContainsKey(code);
        }

        public bool IsHosted(Guid id)
        {
            return HostedQuizes.ContainsValue(id);
        }

        private int GenerateQuizCode()
        {
            var generator = new Random();
            var newCode = generator.Next(CodeMin, CodeMax);
            //ensures the key is new
            while (HostedQuizes.ContainsKey(newCode))
            {
                newCode = generator.Next(CodeMin, CodeMax);
            }

            return newCode;
        }
    }
}
