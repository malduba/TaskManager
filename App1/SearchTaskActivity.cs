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

namespace App1
{
    [Activity(Label = "SearchTaskActivity")]
    public class SearchTaskActivity : AppCompatActivity, View.IOnClickListener
    {
        Button searchTxtBtn, vackMainBtn;
        ListView taskList;
        List<string> items = new List<string>();
        List<UserTask> userTasks;
        EditText searchText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_search_task);

            searchText = (EditText)FindViewById(Resource.Id.searchText);

            searchTxtBtn = (Button)FindViewById(Resource.Id.searchButton);
            searchTxtBtn.Tag = 1;
            searchTxtBtn.SetOnClickListener(this);

            vackMainBtn = (Button)FindViewById(Resource.Id.backMainBtn);
            vackMainBtn.Tag = 2;
            vackMainBtn.SetOnClickListener(this);

            taskList = (ListView)FindViewById(Resource.Id.taskList);
            userTasks = JsonConvert.DeserializeObject<List<UserTask>>(Intent.GetStringExtra("userTasks"));
           


            // Create your application here
        }
        public void OnClick(View v)
        {
            if (Convert.ToUInt32(v.Tag.ToString()) == 1)
            {
                string sText = searchText.Text;
                if (sText.Trim().Length == 0)
                {
                    Toast t = Toast.MakeText(v.Context, "Please enter search text", ToastLength.Long);
                    t.Show();
                }
                else
                {
                    int resCount = 0; 
                    foreach (UserTask task in userTasks)
                    {
                        if(task.TaskName.ToLower().Contains(sText) || task.TaskDesc.ToLower().Contains(sText))
                        {
                            string input = task.TaskName + "\t" + task.TaskDesc + "\t      " + task.TaskDue;
                            items.Add(input);
                            resCount++;
                        }
                        
                    }
                    if (resCount == 0)
                    {
                        Toast t = Toast.MakeText(v.Context, "search text not found", ToastLength.Long);
                        t.Show();
                    }
                    else
                    {
                        ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items.ToArray());
                        taskList.Adapter = arrayAdapter;
                    }
                }
            }

            if (Convert.ToUInt32(v.Tag.ToString()) == 2)
            {
                if (userTasks != null)
                {
                    var mainActivity = new Intent(this, typeof(MainActivity));
                    StartActivity(mainActivity);
                }

            }


        }

    }
}