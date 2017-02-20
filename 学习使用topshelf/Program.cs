using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;
using System.Timers;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
namespace 学习使用topshelf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(r =>
            {
                HostFactory.Run(x =>
                {
                    x.Service<TownCrier>(s =>
                    {
                        s.ConstructUsing(name => new TownCrier());
                        s.WhenStarted(tc => tc.Start());
                        s.WhenStopped(tc => tc.Stop());
                    });
                    x.RunAsLocalSystem();

                    x.SetDescription("Sample Topshelf Host");
                    x.SetDisplayName("Stuff");
                    x.SetServiceName("Stuff");
                    x.SetInstanceName("MyService$Test");
                });
            });
            
            
        }
    }

    public class TownCrier
    {
        private static readonly string filePath = ConfigurationManager.AppSettings["File"].ToString();
        readonly System.Timers.Timer _timer;
        public TownCrier()
        {
            _timer = new System.Timers.Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => 
                {
                    if (DateTime.Now.Minute == 0&&DateTime.Now.Second==0)
                    {
                        DialogResult result=MessageBox.Show("弹出窗口", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                        }
                        else
                        {
                        }
                    }
                    //if (!File.Exists(filePath))
                    //{
                    //    using (StreamWriter sw = File.CreateText(filePath))
                    //    {
                    //        sw.WriteLine(DateTime.Now.ToString());
                    //    }
                    //}
                    //else
                    //{
                    //    using (StreamWriter sw = File.AppendText(filePath))
                    //    {
                    //        sw.WriteLine(DateTime.Now.ToString());
                    //        MessageBox.Show(DateTime.Now.ToString());
                    //    }
                    //}
                };
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }



    //方法学习
    //public class FunctionTest
    //{ 
    //   public static void Test1(this string aa)
    //   {
    //       Console.WriteLine(aa + "xxxx");
    //   }
    //}



}
