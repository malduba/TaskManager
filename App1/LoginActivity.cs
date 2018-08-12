using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;

namespace App1
{
    [Activity(Label = "Login", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class LoginActivity : AppCompatActivity, View.IOnClickListener
    {
        // set edittexts
        EditText userNameEditText;
        EditText passwordEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            // associate withe design 
            userNameEditText = (EditText)FindViewById(Resource.Id.username);
            passwordEditText = (EditText)FindViewById(Resource.Id.password);

            Button btnLogin = (Button)FindViewById(Resource.Id.btn_signIn);
            btnLogin.SetOnClickListener(this);
        }
        public void Userlogin(View v)
        {

        }
        public void OnClick(View v)
        {
            string uname = userNameEditText.Text; //"user";
            string upass = passwordEditText.Text;  // "123456";
            string umsg = "";
            var activity = new Intent(this, typeof(MainActivity));
            Toast t;

            // chaeck values 
            if (uname.Trim().Length == 0 || upass.Trim().Length == 0)
            {
                umsg = "enter username and password";
                t = Toast.MakeText(v.Context, umsg, ToastLength.Long);
                t.Show();
            }
            else if (!(uname.Trim().Equals("user")) || !(upass.Trim().Equals("123456")))
            {
                t = Toast.MakeText(v.Context, umsg, ToastLength.Long);
                t.Show();
                umsg = "Invalid login: check username and password: " + uname + " " + upass;
            }
            else
                StartActivity(activity);  
           
        }
    }

}
