using DataRepository;
using Entities;

namespace Services
{
    public class HomePageService : IHomePageService
    {
        private readonly IHomePageRepository _homePageRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageService"/> class.
        /// </summary>
        /// <param name="homePageRepository">The home page repository.</param>
        public HomePageService(IHomePageRepository homePageRepository)
        {
            _homePageRepository = homePageRepository ?? throw new ArgumentNullException(nameof(homePageRepository));
        }
        /// <summary>
        /// Gets the list of categories asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of categories.</returns>
        public Task<List<Category>> GetCategoriesAsync()
        {
           return _homePageRepository.GetCategoriesAsync();
        }
        /// <summary>
        /// Gets the list of fields asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of fields.</returns>
        public Task<List<Field>> GetFieldsAsync()
        {
            return _homePageRepository.GetFieldsAsync();
        }
        /// <summary>
        /// Checks if a field exists asynchronously.
        /// </summary>
        /// <param name="fieldId">The field identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the field exists.</returns>
        public Task<bool> FieldExistsAsync(int fieldId)
        {
            return _homePageRepository.FieldExistsAsync(fieldId);
        }
        /// <summary>
        /// Gets the total feedbacks for a field asynchronously.
        /// </summary>
        /// <param name="fieldId">The field identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the total number of feedbacks for the field.</returns>
        public Task<int?> GetTotalFeedbacksForField(int fieldId)
        {
            return _homePageRepository.GetTotalFeedbacksForField(fieldId);
        }
    }
}
