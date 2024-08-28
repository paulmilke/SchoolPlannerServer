using Microsoft.AspNetCore.Mvc;
using SchoolPlanner.Data.Interfaces;
using SchoolPlanner.Data.Models; 

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
        public async Task<IEnumerable<Term>> Get()
        {
            return await _termRepository.GetAllTermsAsync(); 
        }

        [HttpPost(Name = "CreateNewTerm")]
        public async Task<bool> Post([FromBody]Term term)
        {
            return await _termRepository.AddNewTermAsync(term);
        }
    }
}
