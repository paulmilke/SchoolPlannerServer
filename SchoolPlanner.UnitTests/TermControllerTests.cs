using Moq;
using SchoolPlanner.Data.Interfaces;
using SchoolPlanner.Api.Controllers;
using SchoolPlanner.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace SchoolPlanner.UnitTests
{
    public class TermControllerTests
    {

        private readonly Mock<ITermRepository> _mockTermRepository;
        private readonly TermController _termController; 


        public TermControllerTests()
        {
            _mockTermRepository = new Mock<ITermRepository>();
            _termController = new TermController(_mockTermRepository.Object);
        }

        //Tests against the terms controller for returning a list of terms. 
        [Fact]
        public async Task GetTerms_ShouldReturnOkResult()
        {
            //Arrange
            var mockTerms = new List<Term>
            {
                new Term {TermId = 1, TermName = "Test Term 1", StartDate = new DateTime(), EndDate = new DateTime().AddMonths(6)},
                new Term {TermId = 1, TermName = "Test Term 2", StartDate = new DateTime().AddMonths(3), EndDate = new DateTime().AddMonths(6)}
            };

            _mockTermRepository.Setup(service => service.GetAllTermsAsync()).ReturnsAsync(mockTerms);

            //Act
            var result = await _termController.Get(null);

            //Assert
            var okresult = Assert.IsType<OkObjectResult>(result); 
            var terms = Assert.IsType<List<Term>>(okresult.Value);
            Assert.Equal(mockTerms.Count, terms.Count);
        }
    }
}