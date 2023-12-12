using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treehoot.Domain.Interfaces;

public interface IPlayground
{
    public int AddHostedQuiz(Guid quizId);
    public bool RemoveHostedQuiz(int quizCode);
    public Dictionary<int, Guid> GetAllHostedQuizes();
    public Guid GetHostedQuizGuidByCode(int code);
    public bool IsHosted(int code);
    public bool IsHosted(Guid id);


}

