using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollService.Models
{
    public class TaxRole
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountryId { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
        public float TaxPercent { get; set; }
    }
}