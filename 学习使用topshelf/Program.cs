using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;
using System.Timers;
using System.IO;
using System.Configuration;
namespace 学习使用topshelf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //HostFactory.Run(r =>
            //{
            //    HostFactory.Run(x =>                               
            //    {
            //        x.Service<TownCrier>(s =>                      
            //        {
            //            s.ConstructUsing(name => new TownCrier()); 
            //            s.WhenStarted(tc => tc.Start());           
            //            s.WhenStopped(tc => tc.Stop());            
            //        });
            //        x.RunAsLocalSystem();                          

            //        x.SetDescription("Sample Topshelf Host");      
            //        x.SetDisplayName("Stuff");                     
            //        x.SetServiceName("Stuff");                     
            //    });       
            //});
            HostFactory.Run(x =>
            {
                x.RunAsLocalSystem();
                x.StartAutomatically();
                //x.StartManually();
                 x.Service<TownCrier>(s =>                      
                {
                    s.ConstructUsing(name => new TownCrier()); 
                    s.WhenStarted(tc => tc.Start());           
                    s.WhenStopped(tc => tc.Stop());            
                });
                x.SetServiceName("HouHanBin");
                x.SetDisplayName("HouHanBin");
                x.SetDescription("HouHanBin");

            });
        }
    }

    public class TownCrier
    {
        private static readonly string filePath = ConfigurationManager.AppSettings["File"].ToString();
        readonly Timer _timer;
        public TownCrier()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => 
                {
                    if (File.Exists(filePath))
                    {
                        using (StreamWriter sw = File.AppendText(filePath))
                        {
                            sw.WriteLine(DateTime.Now.ToString());
                        }
                    }
                    else
                    { 
                        
                    }
                };
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
}
