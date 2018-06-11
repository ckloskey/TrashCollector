using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class CustomerListViewModel
    {
        public IEnumerable<DayOfWeek> DayOfWeek { get; set; }
        public IEnumerable<Customer> Customer { get; set; }
    }
}