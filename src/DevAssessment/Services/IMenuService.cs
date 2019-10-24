using DevAssessment.Models;
using System.Collections.Generic;

namespace DevAssessment.Services
{
    public interface IMenuService
    {
        IEnumerable<Item> MenuItems { get; set; }
    }
}
