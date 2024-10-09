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

        [HttpPost(Name = "AddClass")]
        public async Task<ActionResult<Class>> Post(Class newClass)
        {
            var addedClass = await _classRepository.AddClassAsync(newClass);
            return addedClass; 
        }

        [HttpPut(Name = "UpdateClass")]
        public async Task<ActionResult<int>> Put(Class updatedClass)
        {
            return await _classRepository.UpdateClassAsync(updatedClass);
        }

        [HttpDelete(Name = "DeleteClass")]
        public async Task<ActionResult<int>> Delete(int classId)
        {
            return await _classRepository.DeleteClassAsync(classId);
        }
    }
}
