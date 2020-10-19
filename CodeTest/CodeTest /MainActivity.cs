
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using CodeTest.Helper;
using CodeTest.Model;
using Android.App;
using Person = CodeTest.Model.Person;
using System.Text.RegularExpressions;
using Android.Content;

namespace CodeTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //string[] items;
     
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            db = new Database();
            db.createDatabase();
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            //Event  
            btnAdd.Click += delegate
            {
                var intent = new Intent(this, typeof(CreateActivity));
                StartActivity(intent);
                
            };
            
            }
                
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}