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
* Andrew Terwilliger 4/2/2020      *
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
        private void Form1_Load(object sender, EventArgs e)
        {
            cbxCategory.Items.Add("Work");
            cbxCategory.Items.Add("School");
            cbxCategory.Items.Add("Personal");
            cbxCategory.SelectedIndex = 0;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string newItem = txtToDo.Text.Trim();
            string category = cbxCategory.SelectedItem.ToString();
            bool urgent = chkUrgent.Checked;

            Task newTask = new Task(newItem, category, urgent);

            if (!string.IsNullOrEmpty(newTask.details))
            {
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

        public string GetTask()
        {
            string task = $"{category} | {details} - Created At {created}";
            if (urgent) task += " URGENT!";

            return task;
        }

    }
}
