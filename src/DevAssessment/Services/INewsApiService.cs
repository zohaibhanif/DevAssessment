using DevAssessment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public interface INewsApiService
    {
        Task<List<Source>> GetNewsSourceListAsync();
        Task<List<Article>> GetArticleListAsync(string category);
    }
}
