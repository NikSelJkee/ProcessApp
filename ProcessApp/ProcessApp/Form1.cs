using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;

namespace ProcessApp
{
    public partial class MainForm : Form
    {
        ServiceController[] services;
        public MainForm()
        {
            InitializeComponent();
            

            services = ServiceController.GetServices();

            foreach (var item in services)
                listBoxProcess.Items.Add("Process: " + item.ServiceName + " - Status: " + item.Status);
        }

        private void ButtonEnable_Click(object sender, EventArgs e)
        {
            if (listBoxProcess.SelectedItem == null)
                return;
            ServiceController ser = services[listBoxProcess.SelectedIndex];
            if (ser.Status == ServiceControllerStatus.Running)
            {
                MessageBox.Show("Процесс уже запущен!");
                return;
            }
            ser.Start();
            listBoxProcess.Items.Clear();
            services = ServiceController.GetServices();
            foreach (var item in services)
                listBoxProcess.Items.Add("Process: " + item.ServiceName + " - Status: " + item.Status);
            MessageBox.Show("Процесс запущен!");
        }

        private void ButtonDisable_Click(object sender, EventArgs e)
        {
            if (listBoxProcess.SelectedItem == null)
                return;
            ServiceController ser = services[listBoxProcess.SelectedIndex];
            if (ser.Status == ServiceControllerStatus.Stopped)
            {
                MessageBox.Show("Процесс уже остановлен!");
                return;
            }
            ser.Stop();
            listBoxProcess.Items.Clear();
            services = ServiceController.GetServices();
            foreach (var item in services)
                listBoxProcess.Items.Add("Process: " + item.ServiceName + " - Status: " + item.Status);
            MessageBox.Show("Процесс остановлен!");
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            services = ServiceController.GetServices();
            foreach (var item in services)
                listBoxProcess.Items.Add("Process: " + item.ServiceName + " - Status: " + item.Status);
        }
    }
}
