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
    [Activity(Label = "AddTaskActivity")]
    public class AddTaskActivity : AppCompatActivity, DatePickerDialog.IOnDateSetListener, View.IOnClickListener
    {
        EditText taskName, taskDesc, taskDue;
        Button btin_addtask, btin_showtasks;
        DatePickerDialog datePickerListener;
        List<UserTask> userTasks;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_task);

            taskName = (EditText)FindViewById(Resource.Id.taskName);
            taskDesc = (EditText)FindViewById(Resource.Id.taskDesc);

            taskDue = (EditText)FindViewById(Resource.Id.taskDue);
            taskDue.SetOnClickListener(this);
            taskDue.Tag = 3;

            btin_addtask = (Button)FindViewById(Resource.Id.btin_addtask);
            btin_addtask.SetOnClickListener(this);
            btin_addtask.Tag = 1;

            btin_showtasks = (Button)FindViewById(Resource.Id.btin_showtasks);
            btin_showtasks.SetOnClickListener(this);
            btin_showtasks.Tag = 2;

            userTasks = new List<UserTask>();

        }
        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {

            taskDue.Text = dayOfMonth + " / " + (month + 1) + " / " + year;
        }

        public void OnClick(View v)
        {
            if (Convert.ToUInt32(v.Tag.ToString()) == 3)
            {
                datePickerListener = new DatePickerDialog(this, Android.Resource.Style.ThemeHoloLightDialogMinWidth);
                datePickerListener.SetOnDateSetListener(this);
                datePickerListener.Show();
            }
            if (Convert.ToUInt32(v.Tag.ToString()) == 1)
            {

                string tname, tdesc, tdue;
                tname = taskName.Text;
                tdesc = taskDesc.Text;
                tdue = taskDue.Text;

                if (tname.Trim().Length == 0 || tdesc.Trim().Length == 0 || tdue.Trim().Length == 0)
                {
                    string umsg = "Enter all task data..";
                    Toast t = Toast.MakeText(v.Context, umsg, ToastLength.Long);
                    t.Show();
                }
                else
                {
                    UserTask task = new UserTask();
                    task.TaskName = tname;
                    task.TaskDesc = tdesc;
                    task.TaskDue = tdue;
                    userTasks.Add(task);
                    string umsg = "Task added..";
                    Toast t = Toast.MakeText(v.Context, umsg, ToastLength.Long);
                    t.Show();
                    taskName.Text = "";
                    taskDesc.Text = "";
                    taskDue.Text = "";
                }
            }
            if (Convert.ToUInt32(v.Tag.ToString()) == 2)
            {
                var mainActivity = new Intent(this, typeof(MainActivity));
                if (userTasks.Count > 0)
                {
                    mainActivity.PutExtra("userTasks",JsonConvert.SerializeObject(userTasks));
                    StartActivity(mainActivity);
                }
                else
                {
                    Toast t = Toast.MakeText(v.Context, "Please add tasks", ToastLength.Long);
                    t.Show();
                }
            }
        }
    }
}

        // Create your application here
   