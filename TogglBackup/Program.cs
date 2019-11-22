using CommandLine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Toggl;
using Toggl.QueryObjects;

namespace TogglBackup
{
    partial class Program
    {

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(o => Backup(o));
        }

        static void Backup(Options options)
        {
            var timeEntryService = new Toggl.Services.TimeEntryService(options.ApiKey);
            var prams = new TimeEntryParams
            {
                StartDate = options.StartDate,
                EndDate = options.EndDate,
            };
            Console.WriteLine("Options");
            Console.WriteLine(JsonConvert.SerializeObject(options, Formatting.Indented));
            var output = new List<TimeEntry>();
            var cont = true;
            while (cont)
            {
                List<TimeEntry> entries;
                try
                {
                    entries = timeEntryService.List(prams);
                }
                catch (WebException e)
                {
                    Console.WriteLine($"{e.Message}. Make sure your API key is correct");
                    return;
                }
                output.AddRange(entries);
                if (entries.Count == 1000)
                {
                    Console.WriteLine("More than 1k");
                    TimeEntry lastEntry = entries.Last();
                    Console.WriteLine($"Last entry {lastEntry.Stop}");
                    var newdate = DateTime.Parse(lastEntry.Stop);
                    prams.StartDate = newdate;
                }
                else
                {
                    cont = false;
                }
            }
            var distinct = output.Distinct(new TimeEntryComparer());
            Console.WriteLine($"Found {distinct.Count()} entires");
            File.WriteAllText($"{Directory.GetCurrentDirectory()}/{options.OutputFileName}", JsonConvert.SerializeObject(distinct, Formatting.Indented));
        }
    }
}
