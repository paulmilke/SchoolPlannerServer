using Microsoft.AspNetCore.Mvc;
using SchoolPlanner.Data.Interfaces;
using SchoolPlanner.Data.Models;


namespace SchoolPlanner.Api.Controllers
{


    [Route("[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly IAssessmentRepository _assessmentRepository;

        public AssessmentController(IAssessmentRepository assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
        }

        [HttpGet(Name = "GetClassAssessments")]
        public async Task<IActionResult> GetAssessments(int classId)
        {
            try
            {
                var assessments = await _assessmentRepository.GetAssessmentsAsync(classId);
                return assessments == null ? NotFound() : Ok(assessments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{assessmentId:int}", Name = "GetSingleAssessment")]
        public async Task<IActionResult> GetSingleAssessment(int assessmentId)
        {
            try
            {
                var assessment = await _assessmentRepository.GetSingleAssessmentAsync(assessmentId);
                return assessment == null ? NotFound() : Ok(assessment); 

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message); 
            }
 
        }

        [HttpPut(Name = "UpdateAssessment")]
        public async Task<IActionResult> UpdateAssessment(Assessment updatedAssessment)
        {
            try
            {
                var updated = await _assessmentRepository.UpdateAssessmentAsync(updatedAssessment);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }

        }

        [HttpPost(Name = "AddAssessment")]
        public async Task<IActionResult> AddAssessment(Assessment newAssessment)
        {
            try
            {
                var added = await _assessmentRepository.AddAssessmentAsync(newAssessment);
                return Ok(added);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }

        }

        [HttpDelete(Name = "DeleteAssessment")]
        public async Task<IActionResult> DeleteAssessment(int assessmentId)
        {
            try
            {
                var deleted = await _assessmentRepository.DeleteAssessmentAsync(assessmentId);
                return deleted == 0 ? NotFound() : Ok(deleted); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }

        }
    }
}