using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.Models.Paging
{
    public class PagingModel
    {
        public int pageSize { get; set; } = 10;
        public int pageNumber { get; set; } = 1;
    }
}
