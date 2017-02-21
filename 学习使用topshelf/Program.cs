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
            #region 官方案例
            //HostFactory.Run(r =>
            //    {
            //        r.StartAutomatically();
            //        HostFactory.Run(x =>
            //        {
            //            x.Service<TownCrier>(s =>
            //            {
            //                s.ConstructUsing(name => new TownCrier());
            //                s.WhenStarted(tc => tc.Start());
            //                s.WhenStopped(tc => tc.Stop());
            //            });
            //            x.RunAsLocalSystem();

            //            x.SetDescription("Sample Topshelf Host");
            //            x.SetDisplayName("Stuff");
            //            x.SetServiceName("Stuff");
            //            x.SetInstanceName("MyService$Test");
            //        });
            //    }); 
            #endregion
            #region 服务基础
            HostFactory.New(r =>
            {
                #region HostConfigurator设置
                //设置服务名称
                r.SetServiceName("HouHanBin");
                //服务的描述信息
                r.SetDescription("This is a Service!");
                //指定服务的显示名称，默认为服务名称
                r.SetDisplayName("HouHanBinService");
                //指定实例名称
                r.SetInstanceName("MyServices"); 
                #endregion
                #region Service配置
                //简单服务
                r.Service<MyService>();
                #endregion
            });
            #endregion
            #region 服务复苏
            //HostFactory.New(x =>
            //{
            //    x.EnableServiceRecovery(r =>
            //    {
            //        //you can have up to three of these
            //        r.RestartComputer(5, "message");
            //        r.RestartService(0);
            //        //the last one will act for all subsequent failures
            //        r.RunProgram(7, "ping baidu.com");

            //        //should this be true for crashed or non-zero exits
            //        //r.OnCrashOnly();

            //        //number of days until the error count resets
            //        r.SetResetPeriod(1);
            //    });
            //});
            #endregion
            
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
