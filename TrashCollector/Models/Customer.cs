using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "LogIn ID")]
        public string Login { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Zip is Required")]
        [RegularExpression(@"^(?!00000)[0-9]{5,5}$", ErrorMessage = "error Message")]
        public int ZipCode { get; set; }
        public enum Weekday { Sunday = 1, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }
        public Weekday PickupDay { get; set; }
        public int AccountBalance { get; set; }
        //@Html.TextBoxFor(m => m.StartDate, "{0:MM/dd/yyyy}", new { @class = "form-control default-date-picker" }) might be handy
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string NextPickup { get; set; }
    }
}