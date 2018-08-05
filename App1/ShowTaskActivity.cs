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
    public class ShowTaskActivity : AppCompatActivity
    {
        ListView taskList;
        List<string> items=new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.actvity_show_task);

            taskList = (ListView)FindViewById(Resource.Id.taskList);
            List<UserTask> userTasks = JsonConvert.DeserializeObject<List<UserTask>>(Intent.GetStringExtra("userTasks"));
            foreach (UserTask task in userTasks)
            {
                string input = task.TaskName + "            " + task.TaskDesc + "               " + task.TaskDue;
                items.Add(input);
            }
            ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items.ToArray());
            taskList.Adapter = arrayAdapter;   
            // Create your application here
        }
    }
}
