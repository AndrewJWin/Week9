using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**********************************\
*                                  *
* Andrew Terwilliger 4/14/2020     *
* Minneapolis College              *
* ITEC 2505-60 C# Programming      *
*                                  *
\**********************************/

namespace ToDoList
{
    public partial class TodoForm : Form
    {
        public TodoForm()
        {
            InitializeComponent();
        }

        // Here we add the category items to their list and set the selected index to the first item.
        private void Form1_Load(object sender, EventArgs e)
        {
            cbxCategory.Items.Add("Personal");
            cbxCategory.Items.Add("School");
            cbxCategory.Items.Add("Work");
            cbxCategory.SelectedIndex = 0;
        }

        // AddTask button method, takes the inputed information and builds the ToDo object and adds it to the list.
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string newItem = txtToDo.Text.Trim();
            string category = cbxCategory.SelectedItem.ToString();
            bool urgent = chkUrgent.Checked;

            // Here we build the Task, using the variables to build.
            Task newTask = new Task(newItem, category, urgent);

            // If the details are empty, we need to stop.
            if (!string.IsNullOrEmpty(newTask.details))
            {
                // Here we using the GetTask method to build a string to add to the list.
                string addingTask = newTask.GetTask();

                if (itemsIsInList(clsToDo.Items, addingTask))
                {
                    MessageBox.Show("You already added that item.", "Error");
                }
                else
                {
                    clsToDo.Items.Add(addingTask);
                    txtToDo.Text = "";
                }
            }
        }

        // RemoveItem method, take the selected item and "remove" it. Simply moving it to another field.
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            List<String> doneItems = new List<string>();


            if (clsToDo.CheckedItems.Count.Equals(0))
            {
                MessageBox.Show("Nothing is selected to remove.", "Error");
            } else
            {
                foreach (string Task in clsToDo.CheckedItems)
                {
                    doneItems.Add(Task);
                }
                foreach (string item in doneItems)
                {
                    clsToDo.Items.Remove(item);
                    lstDone.Items.Add(item);
                }
            }
        }

        // Simply checks if it's the same regardless of capitalization.
        private bool itemsIsInList(CheckedListBox.ObjectCollection items, string newItem)
        {
            foreach (string item in items)
            {
                if (item.ToUpper() == newItem.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
    }

    /*
     * This is the Task Class, this can be utilized multiple times to create tasks.
     * 
     * Using the same-name constructor and providing Details, Category and Urgency bool.
     * It will generate a Task with the information provided and a new created DateTime.
     */
    public class Task
    {
        public string details = string.Empty;
        public string category = string.Empty;
        public bool urgent = false;
        public DateTime created = DateTime.Now;

        public Task(string Details, string Category, bool Urgent)
        {
            details = Details;
            category = Category;
            urgent = Urgent;
        }

        // This method within the class builds the task string to be utilized within the ToDo List.
        public string GetTask()
        {
            string task = $"{category} | {details} - Created At {created}";
            if (urgent) task += " URGENT!";

            return task;
        }

    }
}
