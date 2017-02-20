using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;
namespace StudyTopshelf
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
