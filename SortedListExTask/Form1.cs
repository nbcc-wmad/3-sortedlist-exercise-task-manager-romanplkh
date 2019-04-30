using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    Dictionary<string, string> myTasks = new Dictionary<string, string>();


    private void TaskSelectedDisplay( )
    {
      if(lstTasks.SelectedIndex != -1)
      {
        //string key = lstTasks.SelectedItem.ToString();
        // lblTaskDetails.Text = myTasks [key];

        string val = myTasks[lstTasks.SelectedItem.ToString()];
        lblTaskDetails.Text = val;
      }
      else
      {
        lblTaskDetails.ResetText();
      } 
    }

    private void RemoveTask(string key )
    {
      myTasks.Remove(key);   
      lstTasks.Items.Remove( lstTasks.SelectedItem );
    }

    private void AddTask(string task, Dictionary <string, string> taskCollection )
    {
      taskCollection.Add( dtpTaskDate.Value.ToShortDateString(), task );
      DisplayTaskInList();
      txtTask.Clear();
    }

    private void DisplayTaskInList( )
    {      
        lstTasks.Items.Add( myTasks.Keys.ElementAt(myTasks.Count-1));   
    }

    private void btnAddTask_Click( object sender, EventArgs e )
    {
      if (isTaskAndDateValid())
      {
        AddTask( txtTask.Text, myTasks );
      }
    }

    private bool isTaskAndDateValid()
    {

      if(txtTask.Text == "")
      {
        MessageBox.Show( "You must enter a task", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error );
        return false;
      }


      if (myTasks.ContainsKey( dtpTaskDate.Value.ToShortDateString()))
      {
        MessageBox.Show( "Only one task per date is allowed", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error );
        return false;
      }

      return true;
    }


    private void btnRemoveTask_Click( object sender, EventArgs e )
    {
      if(lstTasks.SelectedIndex > -1)
      {
        RemoveTask( lstTasks.SelectedItem.ToString() );
      }
      else
      {
        MessageBox.Show( "Please select an item", "Abort Operation", MessageBoxButtons.OK, MessageBoxIcon.Error );
      }
    }

    private void  PrintItems()
    {

      string msg = "";
      foreach(KeyValuePair<string, string> task in myTasks)
      {
        msg += $"{task.Key} {task.Value} \n";
      }

      MessageBox.Show( msg );
    }

    private void btnPrintAll_Click( object sender, EventArgs e )
    {
      if(lstTasks.Items.Count > 0)
      {
        PrintItems();
      }
      else
      {
        MessageBox.Show( "No items to print", "Abort operation", MessageBoxButtons.OK, MessageBoxIcon.Error );
      }

    }

    private void lstTasks_SelectedValueChanged( object sender, EventArgs e )
    {
      TaskSelectedDisplay();
    }
  }
}
