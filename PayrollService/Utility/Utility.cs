using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollService.Utility
{
    public class Utility
    {
    }
    public class JsonResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
    public class PayrollResponse
    {
        public PayrollResponse( )
        {

        }
        public PayrollResponse( string countryCode, double grossSalary, double taxesDeductions, double netSalary, string message )
        {
            CountryCode = countryCode;
            GrossSalary = grossSalary;
            TaxesDeductions = taxesDeductions;
            NetSalary = netSalary;
            Message = message;
        }
        public string CountryCode { get; set; }
        public double GrossSalary { get; set; }
        public double TaxesDeductions { get; set; }
        public double NetSalary { get; set; }
        public string Message { get; set; }
    }
    public class PayrollCalculateInput
    {
        public float HoursWorked { get; set; }
        public float HourlyRate { get; set; }
        public string CountryCode { get; set; }
    }
}