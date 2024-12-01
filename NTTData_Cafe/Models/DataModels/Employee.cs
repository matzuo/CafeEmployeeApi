﻿using System.ComponentModel.DataAnnotations;

namespace NTTData_Cafe.Models.DataModels
{
    public class Employee
    {
        [Key]
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public Guid? CafeId { get; set; }

        public Cafe Cafe { get; set; }
  }
}
