
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
using CodeTest.Helper;
using CodeTest.Model;
using Person = CodeTest.Model.Person;

namespace CodeTest
{
    [Activity(Label = "ListActivity")]
    public class ListActivity : Activity
    {
        ListView lstViewData;
        List<Person> listSource = new List<Person>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShowDetails);
            db = new Database();
            db.createDatabase();
            // Create your application here
            lstViewData = FindViewById<ListView>(Resource.Id.listView);
            var edtName = FindViewById<EditText>(Resource.Id.edtName);
            var edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            var edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            var btnBack = FindViewById<Button>(Resource.Id.btnBack);
            LoadData();
            btnBack.Click += delegate
            {
                var intent = new Intent(this, typeof(CreateActivity));
                StartActivity(intent);
            };
                lstViewData.ItemClick += (s, e) =>
            {
                //Set Backround for selected item  
                for (int i = 0; i < lstViewData.Count; i++)
                {
                    if (e.Position == i)
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Black);
                    else
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
                //Binding Data  
                var txtName = e.View.FindViewById<TextView>(Resource.Id.txtView_Name);
                var txtPassword = e.View.FindViewById<TextView>(Resource.Id.txtView_PassWord);
                var txtEmail = e.View.FindViewById<TextView>(Resource.Id.txtView_Email);
                edtEmail.Text = txtName.Text;
                edtName.Tag = e.Id;
                edtPassword.Text = txtPassword.Text;
                edtEmail.Text = txtEmail.Text;
            };

        }
        private void LoadData()
        {
            listSource = db.selectTable();
            var adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }
    }
}


