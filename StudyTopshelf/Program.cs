using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;
using log4net;
namespace StudyTopshelf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.New(r =>
            {
                r.SetServiceName("MyService");
                r.SetDescription("MyService");
                r.SetDisplayName("MyService");
                r.SetInstanceName("MyService");
                r.Service<MyService>();
            });
        }
    }
}
