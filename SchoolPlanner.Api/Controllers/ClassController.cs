using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolPlanner.Data.Interfaces;
using SchoolPlanner.Data.Models;
using System.Net; 

namespace SchoolPlanner.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : Controller
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository classrepository)
        {
            _classRepository = classrepository;
        }

        [HttpGet("{classId:int}", Name = "GetSingleClass" )]
        public async Task<IActionResult> GetSingleClass(int classId)
        {
            try
            {
                var singleClass = await _classRepository.GetSingleClassAsync(classId);
                if (singleClass == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(singleClass);
                }
            }
            catch
            {
                return BadRequest(); 
            }

        }

        [HttpGet(Name = "GetClasses")]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses(int termID)
        {
            try
            {
                if (termID <= 0) 
                    return BadRequest("Invalid Term ID");
                
                var classes = await _classRepository.GetClassesAsync(termID);

                if(classes == null || !classes.Any())
                    return NotFound($"No classes found for Term ID: {termID}.");

                return Ok(classes);
            }
            catch
            {
                //Add Logging
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request");
            }

        }

        [HttpPost(Name = "AddClass")]
        public async Task<ActionResult<Class>> Post(Class newClass)
        {
            try
            {
                if (newClass == null)
                    return BadRequest("Invalid Class Object"); 

                var addedClass = await _classRepository.AddClassAsync(newClass);
                return CreatedAtRoute("GetClasses", new { termID = addedClass.TermId }, addedClass);
            }
            catch
            {
                //Add Logging
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while processing your request");
            }

        }

        [HttpPut(Name = "UpdateClass")]
        public async Task<ActionResult<int>> Put(Class updatedClass)
        {
            try
            {
                if (updatedClass == null)
                    return BadRequest("Invalid class object");

                var upClass = await _classRepository.UpdateClassAsync(updatedClass);

                return Ok(upClass);
            }
            catch
            {
                //Add Logging
                return StatusCode(StatusCodes.Status500InternalServerError, "There was an issue processing your request");
            }

        }

        [HttpDelete(Name = "DeleteClass")]
        public async Task<ActionResult<int>> Delete(int classId)
        {
            try
            {
                if (classId <= 0)
                    return BadRequest("Invalid Class ID");

                var result = await _classRepository.DeleteClassAsync(classId);

                if (result == 1)
                    return StatusCode(StatusCodes.Status204NoContent);

                else
                    return NotFound("There was an issue processing your request"); 
            }
            catch
            {
                //Add Logging
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a server error processing your request");
            }
        }
    }
}
