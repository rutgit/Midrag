using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IHomePageService
    {
        public Task<List<Category>> GetCategoriesAsync();
        public Task<List<Field>> GetFieldsAsync();
        public Task<bool> FieldExistsAsync(int fieldId);
        public Task<int> GetTotalFeedbacksForField(int fieldId);
    }
}
