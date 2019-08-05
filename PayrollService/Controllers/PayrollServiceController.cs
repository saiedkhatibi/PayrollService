using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PayrollService.Models;
using PayrollService.Utility;

namespace PayrollService.Controllers
{
    public class PayrollServiceController : ApiController
    {
        PayrollService.Server.PayrollService _payrollService;
        PayrollServiceContext _payrollServiceContext;
        public PayrollServiceController( 
            PayrollService.Server.PayrollService payrollService,
            PayrollService.Models.PayrollServiceContext payrollServiceContext
            )
        {
            _payrollService = payrollService;
            _payrollServiceContext = payrollServiceContext;
        }
        
        // GET: api/PayrollService/5
        [ResponseType( typeof( PayrollResponse ) )]
        public async Task<IHttpActionResult> GetTaxRole( PayrollCalculateInput payrollCalculateInput )
        {
            PayrollResponse payrollResponse = await Middle.Payroll.GetPayroll( _payrollServiceContext, _payrollService, payrollCalculateInput );

            return Ok(payrollResponse);
        }
    }
}