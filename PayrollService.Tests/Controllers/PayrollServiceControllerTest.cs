using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollService.Controllers;
using PayrollService.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PayrollService.Tests.Controllers
{
    [TestClass]
    public class PayrollServiceControllerTest
    {
        [TestMethod]
        public void GetTaxRoleForGermanyWithRate40_10( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "DE",
                HourlyRate = 10,
                HoursWorked = 40
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.IsNotNull( payrollResponse );
            Assert.AreEqual( payrollResponse.Message, "true" );
            Assert.AreEqual( payrollResponse.NetSalary, 292 );
            Assert.AreEqual( payrollResponse.TaxesDeductions, 108 );
            Assert.AreEqual( payrollResponse.GrossSalary, 400 );
        }
        [TestMethod]
        public void GetTaxRoleForGermanyWithRate40_100( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "DE",
                HourlyRate = 100,
                HoursWorked = 40
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.IsNotNull( payrollResponse );
            Assert.AreEqual( payrollResponse.Message, "true" );
            Assert.AreEqual( payrollResponse.NetSalary, 2668 );
            Assert.AreEqual( payrollResponse.TaxesDeductions, 1332 );
            Assert.AreEqual( payrollResponse.GrossSalary, 4000 );
        }
        [TestMethod]
        public void GetTaxRoleForSpainWithRate40_10( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "SP",
                HourlyRate = 10,
                HoursWorked = 40
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.IsNotNull( payrollResponse );
            Assert.AreEqual( payrollResponse.Message, "true" );
            Assert.AreEqual( payrollResponse.NetSalary, 284 );
            Assert.AreEqual( payrollResponse.TaxesDeductions, 116 );
            Assert.AreEqual( payrollResponse.GrossSalary, 400 );
        }
        [TestMethod]
        public void GetTaxRoleForSpainWithRate50_20( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "SP",
                HourlyRate = 20,
                HoursWorked = 50
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.IsNotNull( payrollResponse );
            Assert.AreEqual( payrollResponse.Message, "true" );
            Assert.AreEqual( payrollResponse.NetSalary, 650 );
            Assert.AreEqual( payrollResponse.TaxesDeductions, 350 );
            Assert.AreEqual( payrollResponse.GrossSalary, 1000 );
        }
        
        [TestMethod]
        public void GetTaxRoleForSpainWithRate50_100( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "SP",
                HourlyRate = 100,
                HoursWorked = 50
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.IsNotNull( payrollResponse );
            Assert.AreEqual( payrollResponse.Message, "true" );
            Assert.AreEqual( payrollResponse.NetSalary, 2590 );
            Assert.AreEqual( payrollResponse.TaxesDeductions, 2410 );
            Assert.AreEqual( payrollResponse.GrossSalary, 5000 );
        }
        [TestMethod]
        public void TaxRollNotFound( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "IR",
                HourlyRate = 100,
                HoursWorked = 50
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.IsNotNull( payrollResponse );
            Assert.AreEqual( payrollResponse.Message, "Tax Role Not Found" );
        }
        [TestMethod]
        public void CountryNotFoundException( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "TR",
                HourlyRate = 40,
                HoursWorked = 100
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            Assert.IsNotNull( iHttpActionResult.Result );
            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.AreEqual( payrollResponse.Message, "Country Code is not exists..." );
        }
        [TestMethod]
        public void NotValidDataException0_100( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "DE",
                HourlyRate = 0,
                HoursWorked = 100
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            Assert.IsNotNull( iHttpActionResult.Result );
            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.AreEqual( payrollResponse.Message, "Data is not valid" );
        }
        [TestMethod]
        public void NotValidDataException40_0( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "DE",
                HourlyRate = 40,
                HoursWorked = 0
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            Assert.IsNotNull( iHttpActionResult.Result );
            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.AreEqual( payrollResponse.Message, "Data is not valid" );
        }
        [TestMethod]
        public void NotValidDataException0_0( )
        {
            PayrollService.Server.PayrollService payrollService = new Server.PayrollService( );
            PayrollService.Models.PayrollServiceContext payrollServiceContext = new Models.PayrollServiceContext( );
            PayrollServiceController payrollServiceController = new PayrollServiceController( payrollService, payrollServiceContext );
            Utility.PayrollCalculateInput payrollCalculateInput = new Utility.PayrollCalculateInput( )
            {
                CountryCode = "DE",
                HourlyRate = 0,
                HoursWorked = 0
            };
            Task<IHttpActionResult> iHttpActionResult = payrollServiceController.GetTaxRole( payrollCalculateInput );

            Assert.IsNotNull( iHttpActionResult.Result );
            PayrollResponse payrollResponse = ( ( System.Web.Http.Results.OkNegotiatedContentResult<PayrollService.Utility.PayrollResponse> )iHttpActionResult.Result ).Content as PayrollResponse;

            Assert.AreEqual( payrollResponse.Message, "Data is not valid" );
        }
    }
}
