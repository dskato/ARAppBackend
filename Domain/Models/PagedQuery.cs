using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PagedQuery
    {
        public int Page { set; get; }

        public int Results { set; get; }

        public string? FilterBy { set; get; }

        public string? Filter { set; get; }
    }
}
