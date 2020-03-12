using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorCodesAndCategoriesWF.Models;

namespace ErrorCodesAndCategoriesWF.Models
{
    public interface IModel
    {
        List<Category> Categories { get; set; }
        Task ExecuteTasksAsync();
    }
}
