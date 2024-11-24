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

        //This get method will return either a single Term or all Terms depending on if the request included a term id or not. 
        [HttpGet(Name = "GetTermTest")]
        public async Task<IActionResult> Get([FromQuery] int? termId)
        {
            if (termId.HasValue)
            {
                try
                {
                    var term = await _termRepository.FindTermAsync(termId.Value);
                    if (term == null)
                    {
                        return NotFound();
                    }
                    return Ok(term);
                }
                catch
                {
                    return BadRequest(); 
                }

            }
            else
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

        [HttpDelete(Name = "DeleteTerm")]
        public async Task<ActionResult<int>> Delete(int termId)
        {
            try
            {
                var response = await _termRepository.DeleteTermAsync(termId);
                if(response != null)
                return Ok(response);
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
