﻿using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;
using System.Net;
using Treehoot.Application.Data;

namespace Treehoot.Application.IServices;

public interface IQuizService
{
    Quiz GetQuiz(int quizId);
    List<Quiz> GetQuizes();
    QuizFull GetQuizFull(int quizId);
    PostResult CreateAndValidateQuiz(Quiz quiz);
}
