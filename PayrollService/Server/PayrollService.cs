using PayrollService.Models;
using PayrollService.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollService.Server
{
    public class PayrollService
    {
        public static double GetPayrollResponse( List<Models.TaxRole> taxRoles, PayrollCalculateInput payrollCalculateInput, out double taxesDeductions )
        {
            double grossSalary = payrollCalculateInput.HourlyRate * payrollCalculateInput.HoursWorked;
            taxesDeductions = 0;

            foreach( TaxRole taxRole in taxRoles.OrderBy( i => i.MinSalary ).ToList( ) )
            {
                if( taxRole.MaxSalary == 0 && taxRole.MinSalary == 0 )
                {
                    taxesDeductions += grossSalary * taxRole.TaxPercent / 100;
                    continue;
                }
                if( 
                    (grossSalary > taxRole.MinSalary && grossSalary <= taxRole.MaxSalary ) || 
                    ( grossSalary > taxRole.MinSalary && taxRole.MaxSalary == 0 ) 
                  )
                {
                    taxesDeductions += ( grossSalary - taxRole.MinSalary ) * taxRole.TaxPercent / 100;
                    continue;
                }
                else if( grossSalary > taxRole.MaxSalary && taxRole.MaxSalary != 0 )
                {
                    taxesDeductions += ( taxRole.MaxSalary - taxRole.MinSalary ) * taxRole.TaxPercent / 100;
                }
            }
            return grossSalary;
        }
    }
}