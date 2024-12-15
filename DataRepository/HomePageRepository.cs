using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.Extensions.Logging;

namespace DataRepository
{
    public class HomePageRepository : IHomePageRepository
    {
        private readonly MidragContext _midragContext;
        private readonly ILogger<MidragContext> _logger;

        public HomePageRepository(MidragContext midragContext, ILogger<MidragContext> logger)
        {
            this._midragContext = midragContext; // ?? throw new ArgumentNullException(nameof(midragContext));
            _logger = logger;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                return await _midragContext.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the list of fields.");
                return new List<Category>();
            }
        }

        public async Task<List<Field>> GetFieldsAsync()
        {
            try
            {
                return await _midragContext.Fields.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the list of fields.");
                return new List<Field>();
            }
        }

        public async Task<bool> FieldExistsAsync(int fieldId)
        {
            try
            {
                return await _midragContext.Fields.AnyAsync(f => f.Id == fieldId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking if field with ID {FieldId} exists.", fieldId);
                return false;
            }
        }

        public async Task<int> GetTotalFeedbacksForField(int fieldId)
        {
            try
            {
                var totalFeedbacks = await _midragContext.ProviderInFields
                    .Where(p => p.FieldId == fieldId)
                    .SumAsync(p => p.NumOfRanks);

                return totalFeedbacks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting total feedbacks for fieldId {FieldId}", fieldId);
                return 0; 
            }
        }
    }
}
