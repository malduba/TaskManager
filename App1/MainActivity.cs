using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace App1
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
	public class MainActivity : AppCompatActivity, View.IOnClickListener
	{
        Button addTask,showTasks; 
        List<UserTask> userTasks;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);
            
            try
            {
                userTasks = JsonConvert.DeserializeObject<List<UserTask>>(Intent.GetStringExtra("userTasks"));
            }
            catch(Exception ex)
            {
                userTasks = null;
            }
            

            addTask = (Button)FindViewById(Resource.Id.addTask);
            addTask.Tag = 1;
            addTask.SetOnClickListener(this);

            showTasks = (Button)FindViewById(Resource.Id.showTasks);
            showTasks.Tag = 2;
            showTasks.SetOnClickListener(this);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

			FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
		}
        public void OnClick(View v)
        {
            //Toast t;
            //t = Toast.MakeText(v.Context, v.Tag.ToString(), ToastLength.Long);
            //t.Show();

            if(Convert.ToUInt32(v.Tag.ToString()) == 1) 
            {
                var addTaskactivity = new Intent(this, typeof(AddTaskActivity));
                StartActivity(addTaskactivity);
            }

            if (Convert.ToUInt32(v.Tag.ToString()) == 2)
            {
                if (userTasks != null)
                {
                    var showActivity = new Intent(this, typeof(ShowTaskActivity));
                    if (userTasks.Count > 0)
                    {
                        showActivity.PutExtra("userTasks", JsonConvert.SerializeObject(userTasks));
                        StartActivity(showActivity);
                    }
                    else
                    {
                        Toast t = Toast.MakeText(v.Context, "Please add tasks", ToastLength.Long);
                        t.Show();
                    }
                }
                else
                {
                    Toast t = Toast.MakeText(v.Context, "Please add tasks", ToastLength.Long);
                    t.Show();
                }
            
            }

           
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.addTask)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

       
    }
}

