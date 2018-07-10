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
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime ScheduledPickup { get; set; }
        public bool PickupCompleted { get; set; }
        public bool ServicePaidFor { get; set; }
    }
}