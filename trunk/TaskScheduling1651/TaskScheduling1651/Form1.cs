using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskScheduling1651
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaskScheduler.Instance.AllTasks.Clear();
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(4, 70));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(2, 60));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(4, 50));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(3, 40));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(1, 30));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(4, 20));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(6, 10));

            AllTasks.DataSource = null;
            TaskScheduler.Instance.AllTasks.Sort();
            for (int i = 0; i < TaskScheduler.Instance.AllTasks.Count; i++)
            {
                TaskScheduler.Instance.AllTasks[i].Index = i + 1;
            }
            AllTasks.DataSource = TaskScheduler.Instance.AllTasks;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaskScheduler.Instance.AllTasks.Clear();
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(4, 80 - 70));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(2, 80 - 60));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(4, 80 - 50));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(3, 80 - 40));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(1, 80 - 30));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(4, 80 - 20));
            TaskScheduler.Instance.AllTasks.Add(new UnitTask(6, 80 - 10));

            AllTasks.DataSource = null;
            TaskScheduler.Instance.AllTasks.Sort();
            for (int i = 0; i < TaskScheduler.Instance.AllTasks.Count; i++)
            {
                TaskScheduler.Instance.AllTasks[i].Index = i + 1;
            }
            AllTasks.DataSource = TaskScheduler.Instance.AllTasks;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OptimalOrder.DataSource = null;
            OptimalOrder.DataSource = TaskSchedulingFunctions.GreedyTaskListWithSwaping(TaskScheduler.Instance.AllTasks); 
        }
    }
}
