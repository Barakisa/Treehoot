﻿using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;
using Treehoot.Domain.DTOs;
using System.Net;
using Treehoot.Application.Data;

namespace Treehoot.Application.IServices;

public interface IQuizService
{
    Quiz GetQuiz(int quizId);
    List<Quiz> GetQuizes();
    QuizFull GetQuizFull(int quizId);
    QuizResult CreateAndValidateQuiz(QuizPostRequest quiz);
}
