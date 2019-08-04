namespace PayrollService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PayrollService.Models.PayrollServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PayrollService.Models.PayrollServiceContext context)
        {
            context.Countries.AddOrUpdate( new Models.Country
            {
                Code = "DE",
                Title = "Deutschland"
            },
            new Models.Country
            {
                Code = "SP",
                Title = "Spain"
            },
            new Models.Country
            {
                Code = "IT",
                Title = "Italy"
            },
            new Models.Country
            {
                Code = "IR",
                Title = "Iran"
            } );
            context.SaveChanges( );
            context.TaxRoles.AddOrUpdate( new Models.TaxRole
            {
                Title = "Income Tax",
                CountryId = context.Countries.FirstOrDefault( i => i.Code == "SP").Id,
                MinSalary = 0,
                MaxSalary = 600,
                TaxPercent = 25
            },
            new Models.TaxRole
            {
                Title = "Income Tax",
                CountryId = context.Countries.FirstOrDefault( i => i.Code == "SP" ).Id,
                MinSalary = 601,
                MaxSalary = 0,
                TaxPercent = 40
            },
            new Models.TaxRole
            {
                Title = "Other Tax",
                CountryId = context.Countries.FirstOrDefault( i => i.Code == "SP" ).Id,
                MinSalary = 0,
                MaxSalary = 0,
                TaxPercent = 4
            },
            new Models.TaxRole
            {
                Title = "Income Tax",
                CountryId = context.Countries.FirstOrDefault( i => i.Code == "IT" ).Id,
                MaxSalary = 0,
                MinSalary = 0,
                TaxPercent = 25
            },
            new Models.TaxRole
            {
                Title = "INPS",
                CountryId = context.Countries.FirstOrDefault( i => i.Code == "IT" ).Id,
                MaxSalary = 0,
                MinSalary = 0,
                TaxPercent = 4
            },
            new Models.TaxRole
            {
                Title = "Income Tax",
                CountryId = context.Countries.FirstOrDefault( i => i.Code == "DE" ).Id,
                MaxSalary = 400,
                MinSalary = 0,
                TaxPercent = 25
            },
            new Models.TaxRole
            {
                Title = "Income Tax",
                CountryId = context.Countries.FirstOrDefault( i => i.Code == "DE" ).Id,
                MaxSalary = 0,
                MinSalary = 401,
                TaxPercent = 25
            },
            new Models.TaxRole
            {
                Title = "Other Tax",
                CountryId = context.Countries.FirstOrDefault( i => i.Code == "DE" ).Id,
                MaxSalary = 0,
                MinSalary = 0,
                TaxPercent = 2
            } );
        }
    }
}
