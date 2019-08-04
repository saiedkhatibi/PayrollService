using PayrollService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollService.Server
{
    public class CountryServer
    {
        public static Country Get( PayrollServiceContext _payrollServiceContext, PayrollService _payrollService, string code )
        {
            Country country = null;
            if( _payrollServiceContext.Countries.Any( i => i.Code == code ) )
                country = _payrollServiceContext.Countries.FirstOrDefault( i => i.Code == code );

            return country;
        }
    }
}