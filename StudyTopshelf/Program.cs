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
                //这是回滚的代码
                r.SetServiceName("MyService");
                r.SetDescription("MyService");
                r.SetDisplayName("MyService");
                r.SetInstanceName("MyService");
                //r.Service<MyService>(sc =>
                //{
                //    sc.ConstructUsing(() => new MyService());

                //    // the start and stop methods for the service
                //    sc.WhenStarted(s => s.Start());
                //    sc.WhenStopped(s => s.Stop());

                //    // optional pause/continue methods if used
                //    sc.WhenPaused(s => s.Pause());
                //    sc.WhenContinued(s => s.Continue());

                //    // optional, when shutdown is supported
                //    sc.WhenShutdown(s => s.Shutdown());
                //});
            });
        }
    }
}
