using Microsoft.AspNetCore.Mvc;
using SchoolPlanner.Data.Interfaces;
using SchoolPlanner.Data.Models; 

namespace SchoolPlanner.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController
    {
        private readonly IClassRepository _classRepository; 

        public ClassController(IClassRepository classrepository)
        {
            _classRepository = classrepository; 
        }

        [HttpGet(Name = "GetClasses")]
        public async Task<IEnumerable<Class>> Get(int termID)
        {
            var classes = await _classRepository.GetClassesAsync(termID);
            return classes; 
        }
    }
}
