using ContosoRenewableEnergyWindfarmMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper.Expressions;
using System.IO;
using System.Reflection;
using System.Text;
using System.Globalization;
using Microsoft.Extensions.FileProviders;

namespace ContosoRenewableEnergyWindfarmMonitoring.Data
{
    public class DbInitializer
    {
        public static void Initialize(WindFarmContext context)
        {
            context.Database.EnsureCreated();

            // Look for any windmills.
            if (!context.Windmills.Any())
            {
                // DB has been not been seeded
                var windmills = new Windmill[]
{
                new Windmill{Model="Windmaster1090",Manufacturer="SuperWind",DateOfLastMaintenance=DateTime.Parse("2005-09-01")},
};
                foreach (Windmill w in windmills)
                {
                    context.Windmills.Add(w);
                }
            }

            // Look for any samples.
            /* Commenting this out for now as we will not be doing the ML demo at Ignite
            if (!context.TurbineTelemetrySamples.Any())
            {
                // DB has not been seeded
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resourceName = "RawWindmillTelemetryData.csv";

                var embeddedProvider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());
                using (var stream = embeddedProvider.GetFileInfo("Data\\RawWindmillTelemetryData.csv").CreateReadStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        //TODO: The csvReader cant convert.
                        //Error: "Unable to cast object of type 'System.IO.StreamReader' to type 'CsvHelper.IParser'."
                        CsvReader csvReader = new CsvReader((IParser)reader);
                        //Skip the first row since it has a header row
                        var samples = csvReader.GetRecords<TurbineTelemetrySample>().ToArray().Skip<TurbineTelemetrySample>(1);
                        context.TurbineTelemetrySamples.AddRange(samples);
                    }
                }
            }
            */

            context.SaveChanges();
        }
    }
}



