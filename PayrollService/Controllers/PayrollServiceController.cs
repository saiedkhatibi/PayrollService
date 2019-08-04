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
        private PayrollServiceContext db = new PayrollServiceContext();

        // GET: api/PayrollService
        public IQueryable<TaxRole> GetTaxRoles()
        {
            return db.TaxRoles;
        }

        // GET: api/PayrollService/5
        [ResponseType( typeof( PayrollResponse ) )]
        public async Task<IHttpActionResult> GetTaxRole( PayrollCalculateInput payrollCalculateInput )
        {
            PayrollResponse payrollResponse = await Middle.Payroll.GetPayroll( _payrollServiceContext, _payrollService, payrollCalculateInput );

            return Ok(payrollResponse);
        }

        // GET: api/PayrollService/5
        [ResponseType(typeof(TaxRole))]
        public async Task<IHttpActionResult> GetTaxRole(int id)
        {
            TaxRole taxRole = await db.TaxRoles.FindAsync(id);
            if (taxRole == null)
            {
                return NotFound();
            }

            return Ok(taxRole);
        }

        // PUT: api/PayrollService/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTaxRole(int id, TaxRole taxRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taxRole.Id)
            {
                return BadRequest();
            }

            db.Entry(taxRole).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PayrollService
        [ResponseType(typeof(TaxRole))]
        public async Task<IHttpActionResult> PostTaxRole(TaxRole taxRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaxRoles.Add(taxRole);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = taxRole.Id }, taxRole);
        }

        // DELETE: api/PayrollService/5
        [ResponseType(typeof(TaxRole))]
        public async Task<IHttpActionResult> DeleteTaxRole(int id)
        {
            TaxRole taxRole = await db.TaxRoles.FindAsync(id);
            if (taxRole == null)
            {
                return NotFound();
            }

            db.TaxRoles.Remove(taxRole);
            await db.SaveChangesAsync();

            return Ok(taxRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaxRoleExists(int id)
        {
            return db.TaxRoles.Count(e => e.Id == id) > 0;
        }
    }
}