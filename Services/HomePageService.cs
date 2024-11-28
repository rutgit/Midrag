using DataRepository;
using Entities;

namespace Services
{
    public class HomePageService : IHomePageService
    {
        private readonly IHomePageRepository _homePageRepository;
        public HomePageService(IHomePageRepository homePageRepository)
        {
            _homePageRepository = homePageRepository;
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
           return _homePageRepository.GetCategoriesAsync();
        }

        public Task<List<Field>> GetFieldsAsync()
        {
            return _homePageRepository.GetFieldsAsync();
        }
        public Task<bool> FieldExistsAsync(int fieldId)
        {
            return _homePageRepository.FieldExistsAsync(fieldId);
        }

        public Task<int> GetTotalFeedbacksForField(int fieldId)
        {
            return _homePageRepository.GetTotalFeedbacksForField(fieldId);
        }
    }
}
