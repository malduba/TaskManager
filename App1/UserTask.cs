using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class UserTask
    {
        private string _taskName;
        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }

        private string _taskDesc;
        public string TaskDesc
        {
            get { return _taskDesc; }
            set { _taskDesc = value; }
        }

        private string _taskDue;
        public string TaskDue
        {
            get { return _taskDue; }
            set { _taskDue = value; }
        }

    }
}