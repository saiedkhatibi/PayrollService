using PayrollService.Models;
using PayrollService.Server;
using PayrollService.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PayrollService.Middle
{
    public class Payroll
    {
        static PayrollServiceContext _payrollServiceContext;
        public Payroll( PayrollServiceContext payrollServiceContext )
        {
            _payrollServiceContext = payrollServiceContext;
        }
        public static async Task<PayrollResponse> GetPayroll( PayrollServiceContext _payrollServiceContext, Server.PayrollService _payrollService, PayrollCalculateInput payrollCalculateInput )
        {
            PayrollResponse payrollResponse = new PayrollResponse( );
            
            Country country = CountryServer.Get( _payrollServiceContext, _payrollService, payrollCalculateInput.CountryCode );
            List<TaxRole> taxRoles = new List<TaxRole>( );
            if( country != null )
            {
                taxRoles = await _payrollServiceContext.TaxRoles.Where( i => i.CountryId == country.Id ).ToListAsync( );
                double taxesDeductions = 0;
                if( payrollCalculateInput.HourlyRate <= 0 || payrollCalculateInput.HoursWorked <= 0 )
                {
                    payrollResponse.Message = "Data is not valid";
                    return payrollResponse;
                }
                double grossSalary = Server.PayrollService.GetPayrollResponse( taxRoles, payrollCalculateInput, out taxesDeductions );
                if( taxesDeductions == 0 )
                {
                    payrollResponse.Message = "Tax Role Not Found";
                    return payrollResponse;
                }
                payrollResponse.CountryCode = payrollCalculateInput.CountryCode = country.Code;
                payrollResponse.GrossSalary = grossSalary;
                payrollResponse.NetSalary = grossSalary - taxesDeductions;
                payrollResponse.TaxesDeductions = taxesDeductions;
                payrollResponse.Message = "true";
            }
            else
                payrollResponse.Message = "Country Code is not exists...";

            return payrollResponse;


        }
    }
}