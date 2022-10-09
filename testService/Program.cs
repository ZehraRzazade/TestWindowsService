using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace testService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {

                x.Service<TestService>(s =>
                {
                    s.ConstructUsing(testService => new TestService());
                    s.WhenStarted(testService => testService.Start());
                    s.WhenStopped(testService => testService.Stop());

                });
                x.RunAsLocalSystem();
                x.SetServiceName("TestService");
                x.SetDisplayName(" Test Service");
                x.SetDescription("This service is for test");
            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());   
            Environment.ExitCode = exitCodeValue;
        }
    }
}
