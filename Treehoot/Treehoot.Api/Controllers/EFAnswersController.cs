using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Treehoot.Application.Data;
using Treehoot.Application.Services;
using Treehoot.Domain.Models;
using Treehoot.Domain.DTOs;
using Treehoot.Api.Maping;

namespace Treehoot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfAnswersController : ControllerBase
    {
        private readonly EfAnswerService _efAnswerService;
        private readonly TreehootApiContext _context;

        public EfAnswersController(EfAnswerService efAnswerService, TreehootApiContext context)
        {
            _efAnswerService = efAnswerService;
            _context = context;

        }

        [HttpGet("{answerId}")]
        public ActionResult<AnswerDto> Get(int answerId)
        {
            var request = _efAnswerService.GetAnswer(answerId);
            return Ok(request.ToResponse());
        }
        
        [HttpGet("questionId/{questionId}")]
        public ActionResult<List<AnswerDto>> GetByQuestionId(int questionId)
        {
            var request = _efAnswerService.GetQuestionAnswers(questionId);
            return Ok(request.ToResponse());
        }

        [HttpPost]
        public async Task<ActionResult<AnswerDto>> CreateAnswer(AnswerDto answerDto)
        {
            var answer = answerDto.ToModel();
            _context.Answer.Add(answer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("PostAnswer", new { id = answer.Id }, answer);
        }
    }
}
