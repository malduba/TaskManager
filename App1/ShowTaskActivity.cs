using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections;

namespace App1
{
    [Activity(Label = "ShowTaskActivity")]
    public class ShowTaskActivity : AppCompatActivity,View.IOnClickListener
    {
        ListView taskList;
        List<string> items=new List<string>();
        Button mainTask;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.actvity_show_task);

            mainTask = (Button)FindViewById(Resource.Id.backmain);
            mainTask.Tag = 1;
            mainTask.SetOnClickListener(this);

            taskList = (ListView)FindViewById(Resource.Id.taskList);
            List<UserTask> userTasks = JsonConvert.DeserializeObject<List<UserTask>>(Intent.GetStringExtra("userTasks"));
            foreach (UserTask task in userTasks)
            {
                string input = task.TaskName + "\t" + task.TaskDesc + "\t      " + task.TaskDue;
                items.Add(input);
            }
            ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items.ToArray());
            taskList.Adapter = arrayAdapter;   

            // Create your application here
        }
        public void OnClick(View v)
        {
            if (Convert.ToUInt32(v.Tag.ToString()) == 1)
            {
                var mainActivity = new Intent(this, typeof(MainActivity));
                StartActivity(mainActivity);
            }
        }
    }
}
