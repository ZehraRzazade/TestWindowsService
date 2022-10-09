using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace testService
{
    public class TestService
    {
        private readonly Timer _timer;
       

        public TestService()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += Timer_Ellapsed;
        }

        private void Timer_Ellapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Users\User\Desktop\New folder\hello.txt", lines);
        }
        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }
}
