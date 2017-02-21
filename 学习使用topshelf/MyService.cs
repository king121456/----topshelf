using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;
namespace 学习使用topshelf
{
    public class MyService:ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            return true;
        }
        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}
