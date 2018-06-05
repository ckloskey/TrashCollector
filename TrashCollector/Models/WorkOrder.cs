using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class WorkOrder
    {
        [Key]
        public int Id { get; set; }
        //cust foreign key
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        //public Date??
        //public DayOfWeek??
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ScheduledPickup { get; set; }
        public bool PickupCompleted { get; set; }
        public bool ServicePaidFor { get; set; }
        //employee foreign key
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}