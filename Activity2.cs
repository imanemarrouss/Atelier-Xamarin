using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace atelierXamarin
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {
        private EditText todoEditText;
        private Button addButton;
        private ListView todoListView;
        private ListView doneListView;
        private ArrayAdapter<string> todoAdapter;
        private ArrayAdapter<string> doneAdapter;
        private List<string> todoList;
        private List<string> doneList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout2);

            // Initialize UI elements
            todoEditText = FindViewById<EditText>(Resource.Id.todoEditText);
            addButton = FindViewById<Button>(Resource.Id.addButton);
            todoListView = FindViewById<ListView>(Resource.Id.todoListView);
            doneListView = FindViewById<ListView>(Resource.Id.doneListView);

            // Initialize lists and adapters
            todoList = new List<string>();
            doneList = new List<string>();
            todoAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, todoList);
            doneAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemChecked, doneList);

            // Set adapters to ListViews
            todoListView.Adapter = todoAdapter;
            doneListView.Adapter = doneAdapter;

            // Handle add button click
            addButton.Click += AddButton_Click;

            // Handle item click for moving tasks to "Done"
            todoListView.ItemClick += TodoListView_ItemClick;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Get text from EditText
            string todoItem = todoEditText.Text.Trim();

            // Get selected priority
            RadioButton highPriorityRadioButton = FindViewById<RadioButton>(Resource.Id.highPriorityRadioButton);
            RadioButton mediumPriorityRadioButton = FindViewById<RadioButton>(Resource.Id.mediumPriorityRadioButton);
            RadioButton lowPriorityRadioButton = FindViewById<RadioButton>(Resource.Id.lowPriorityRadioButton);

            string priority;
            if (highPriorityRadioButton.Checked)
                priority = "High";
            else if (mediumPriorityRadioButton.Checked)
                priority = "Medium";
            else
                priority = "Low";

            // Add the item to the "To-Do" list and update the adapter
            if (!string.IsNullOrEmpty(todoItem))
            {
                todoList.Add(todoItem + " (" + priority + ")");
                todoAdapter.Add(todoItem + " (" + priority + ")");
                todoEditText.Text = ""; // Clear EditText
            }
            else
            {
                Toast.MakeText(this, "Please enter a task.", ToastLength.Short).Show();
            }
        }


        private void TodoListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // Move the task from "To-Do" list to "Done" list and update the adapters
            string task = todoList[e.Position];
            todoList.RemoveAt(e.Position);
            todoAdapter.Remove(task); // Remove task from adapter
            doneList.Add(task);
            doneAdapter.Add(task); // Add task to "Done" adapter
        }
    }
}
