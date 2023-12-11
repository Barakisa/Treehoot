using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treehoot.Domain.Models
{
    public class Playground
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

        public KeyValuePair<bool, Guid?> GetHostedQuizGuidByCode(int code)
        {
            if (HostedQuizes.ContainsKey(code))
            {
                return new KeyValuePair<bool, Guid?>(true, HostedQuizes[code]);
            }

            return new KeyValuePair<bool, Guid?>(false, null);
        }

        public int GenerateQuizCode()
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

        private bool IsActuallyNew(int maybeNewCode)
        {
            return HostedQuizes.ContainsKey(maybeNewCode);
        }

    }
}
