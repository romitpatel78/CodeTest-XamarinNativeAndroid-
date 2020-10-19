using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace CodeTest.Model
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtDepartment { get; set; }
        public TextView txtEmail { get; set; }
    }
    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Person> listPerson;
        public ListViewAdapter(Activity activity, List<Person> listPerson)
        {
            this.activity = activity;
            this.listPerson = listPerson;
        }
        public override int Count
        {
            get { return listPerson.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return listPerson[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view, parent, false);
            var txtName = view.FindViewById<TextView>(Resource.Id.txtView_Name);
            var txtPassword = view.FindViewById<TextView>(Resource.Id.txtView_PassWord);
            var txtEmail = view.FindViewById<TextView>(Resource.Id.txtView_Email);
            txtName.Text = listPerson[position].Name;
            txtEmail.Text = listPerson[position].Email;
            txtPassword.Text = listPerson[position].Password;
            return view;
        }
    }
}
