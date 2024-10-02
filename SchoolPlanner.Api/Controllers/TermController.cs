using Microsoft.AspNetCore.Mvc;
using SchoolPlanner.Data.Interfaces;
using SchoolPlanner.Data.Models;
using System.Net;

namespace SchoolPlanner.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TermController : Controller
    {
        private readonly ITermRepository _termRepository; 

        public TermController(ITermRepository termRepository) { 
            _termRepository = termRepository;
        }

        [HttpGet(Name = "GetTermTest")]
        public async Task<ActionResult<IEnumerable<Term>>> Get()
        {
            try
            {
                var terms = await _termRepository.GetAllTermsAsync();
                return Ok(terms);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred while fetching terms. {ex}");
            }

        }

        [HttpPost(Name = "CreateNewTerm")]
        public async Task<ActionResult<Term>> Post([FromBody]Term term)
        {
            try
            {
                var newTerm =  await _termRepository.AddNewTermAsync(term);
                return Ok(newTerm);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut(Name = "UpdateTerm")]
        public async Task<ActionResult<Term>> Put([FromBody]Term updatedTerm)
        {
            try
            {
                var updated = await _termRepository.UpdateExistingTermAsync(updatedTerm);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
