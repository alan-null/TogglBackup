using CommandLine;
using System;

namespace TogglBackup
{
    partial class Program
    {
        public class Options
        {
            [Option('a', "api", Required = true, HelpText = "API key for Toggl service.")]
            public string ApiKey { get; set; }
            [Option('s', "startDate", Required = true, HelpText = "Start date for crawler")]
            public DateTime StartDate { get; set; }
            [Option('e', "endDate", Required = true, HelpText = "End date for crawler")]
            public DateTime EndDate { get; set; }
            [Option('o', "outputFile", Required = false, HelpText = "Name of the output file", Default = "out.json")]
            public string OutputFileName { get; set; }
        }
    }
}
