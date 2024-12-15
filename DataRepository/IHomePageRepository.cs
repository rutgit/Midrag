using Entities;
using Microsoft.Extensions.Logging;

namespace DataRepository
{
    public interface IHomePageRepository
    {
        public Task<List<Category>> GetCategoriesAsync();
        public Task<List<Field>> GetFieldsAsync();
        public Task<bool> FieldExistsAsync(int fieldId);
        public Task<int> GetTotalFeedbacksForField(int fieldId);

    }
}