using System;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace ReplyTestTaskBdd.Hooks
{
    [Binding]
    public class Hooks
    {
        public static IConfiguration? Configuration { get; set; }

        [BeforeTestRun]
        public static void CreateConfig()
        {
            Configuration ??= new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}