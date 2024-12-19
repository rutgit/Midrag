using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Midrag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageService _homePageService;
        private readonly ILogger<HomePageController> _logger;
        public HomePageController(IHomePageService homePageService, ILogger<HomePageController> logger)
        {
            _homePageService = homePageService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a list of all categories from the database.
        /// </summary>
        /// <returns>A list of categories. Returns a 404 status if no categories are found, or a 500 status if an error occurs.</returns>
        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            try
            {
                var categories = await _homePageService.GetCategoriesAsync();
                if (categories == null || categories.Count == 0)
                {
                    return NotFound("No categories found.");
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories.");
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        /// <summary>
        /// Retrieves a list of all fields from the database.
        /// </summary>
        /// <returns>A list of fields. Returns a 404 status if no fields are found, or a 500 status if an error occurs.</returns>
        [HttpGet("fields")]
        public async Task<ActionResult<List<Field>>> GetFields()
        {
            try
            {
                var fields = await _homePageService.GetFieldsAsync();
                if (fields == null || fields.Count == 0)
                {
                    return NotFound("Can't get.");//insteadof- No Fields found.
                }

                return Ok(fields); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the list of fields.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves the total number of feedbacks for a specific field identified by its fieldId.
        /// </summary>
        /// <param name="fieldId">The ID of the field for which total feedbacks are being retrieved.</param>
        /// <returns>The total number of feedbacks for the specified field. Returns a 500 status if an error occurs.</returns>
        [HttpGet("fields/{fieldId}/feedbacks")]
        public async Task<ActionResult<int?>> GetTotalFeedbacksForField(int fieldId)
        {
            try
            {
                var fieldExists = await _homePageService.FieldExistsAsync(fieldId);
                if (!fieldExists)
                {
                    return NotFound($"Field with ID {fieldId} not found.");//זה בטוח לכתוב ככה ?
                }
                var totalFeedbacks = await _homePageService.GetTotalFeedbacksForField(fieldId);
                return Ok(totalFeedbacks); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting total feedbacks for fieldId {FieldId}", fieldId);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
