using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3Pagination.Models
{
    internal class PaginatedDataViewModel<TModel>
    {

        public int TotalRows { get; set; }
        public IEnumerable<TModel> Rows { get; set; }


    }
}
