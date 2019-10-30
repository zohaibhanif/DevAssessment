using System.Collections.Generic;

namespace DevAssessment.Models
{
    public class ArticleResponse : ResponseBase
    {
        public List<Article> Articles { get; set; }
    }
}
