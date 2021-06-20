using DevExpress.XtraBars.Docking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestForParkingCloud
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
            private int i = 1;
        private List<DockPanel> list=new List<DockPanel>();
        public Form1()
        {
            InitializeComponent();
            // Handling the QueryControl event that will populate all automatically generated Documents
            this.tabbedView1.QueryControl += tabbedView1_QueryControl;
        }

        // Assigning a required content for each auto generated Document
        void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {

            if (e.Document == modbusHelperCurrent1Document)
                e.Control = new TestForParkingCloud.modbusHelperCurrent1(0);
            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }

        private void modbus추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modbusHelper = new modbusHelperCurrent1(i) { Text = $"모드버스{i}" };
            i = i + 1;
            modbusHelper.Dock = DockStyle.Fill;

            DockPanel panel1 = dockManager1.AddPanel(DockingStyle.Left);
            list.Add(panel1);
            panel1.Width = 360;
            panel1.ControlContainer.Controls.Add(modbusHelper);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            foreach(var panel in list)
            {
                try
                {
                    panel.Close();
                }
                catch { }

            }
        }
    }
}
