
namespace TestForParkingCloud
{
    partial class modbusHelperCurrent1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_Console = new System.Windows.Forms.TextBox();
            this.radioGroup_CyclicRead = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Tbo_IP = new DevExpress.XtraEditors.TextEdit();
            this.Btn_StartConnectionCycle = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup_Logging = new DevExpress.XtraEditors.RadioGroup();
            this.Tbo_MessageCycle = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.Tbo_ConnectionCycle = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Tbo_Address = new System.Windows.Forms.TextBox();
            this.timer_CyclicMessage = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_CyclicRead.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbo_IP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_Logging.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Console
            // 
            this.textBox_Console.Location = new System.Drawing.Point(28, 143);
            this.textBox_Console.Multiline = true;
            this.textBox_Console.Name = "textBox_Console";
            this.textBox_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Console.Size = new System.Drawing.Size(309, 202);
            this.textBox_Console.TabIndex = 2;
            // 
            // radioGroup_CyclicRead
            // 
            this.radioGroup_CyclicRead.EditValue = true;
            this.radioGroup_CyclicRead.Location = new System.Drawing.Point(125, 70);
            this.radioGroup_CyclicRead.Name = "radioGroup_CyclicRead";
            this.radioGroup_CyclicRead.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Stop Message Cycle"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Start Message Cycle")});
            this.radioGroup_CyclicRead.Size = new System.Drawing.Size(148, 67);
            this.radioGroup_CyclicRead.TabIndex = 5;
            this.radioGroup_CyclicRead.SelectedIndexChanged += new System.EventHandler(this.radioGroup_CyclicRead_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "IP:Port";
            // 
            // Tbo_IP
            // 
            this.Tbo_IP.EditValue = "127.0.0.1:502";
            this.Tbo_IP.Location = new System.Drawing.Point(48, 10);
            this.Tbo_IP.Name = "Tbo_IP";
            this.Tbo_IP.Size = new System.Drawing.Size(124, 20);
            this.Tbo_IP.TabIndex = 9;
            // 
            // Btn_StartConnectionCycle
            // 
            this.Btn_StartConnectionCycle.Location = new System.Drawing.Point(9, 37);
            this.Btn_StartConnectionCycle.Name = "Btn_StartConnectionCycle";
            this.Btn_StartConnectionCycle.Size = new System.Drawing.Size(124, 23);
            this.Btn_StartConnectionCycle.TabIndex = 10;
            this.Btn_StartConnectionCycle.Text = "Start";
            this.Btn_StartConnectionCycle.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // radioGroup_Logging
            // 
            this.radioGroup_Logging.EditValue = false;
            this.radioGroup_Logging.Location = new System.Drawing.Point(4, 70);
            this.radioGroup_Logging.Name = "radioGroup_Logging";
            this.radioGroup_Logging.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Stop Logging"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Start Logging")});
            this.radioGroup_Logging.Size = new System.Drawing.Size(115, 67);
            this.radioGroup_Logging.TabIndex = 11;
            this.radioGroup_Logging.SelectedIndexChanged += new System.EventHandler(this.radioGroup_Logging_SelectedIndexChanged);
            // 
            // Tbo_MessageCycle
            // 
            this.Tbo_MessageCycle.Location = new System.Drawing.Point(294, 10);
            this.Tbo_MessageCycle.Name = "Tbo_MessageCycle";
            this.Tbo_MessageCycle.Size = new System.Drawing.Size(68, 22);
            this.Tbo_MessageCycle.TabIndex = 17;
            this.Tbo_MessageCycle.Text = "20";
            this.Tbo_MessageCycle.TextChanged += new System.EventHandler(this.Tbo_MessageCycle_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(178, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(107, 14);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "message cycle (ms)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(164, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(121, 14);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "connection cycle (ms)";
            // 
            // Tbo_ConnectionCycle
            // 
            this.Tbo_ConnectionCycle.Location = new System.Drawing.Point(294, 38);
            this.Tbo_ConnectionCycle.Name = "Tbo_ConnectionCycle";
            this.Tbo_ConnectionCycle.Size = new System.Drawing.Size(68, 22);
            this.Tbo_ConnectionCycle.TabIndex = 19;
            this.Tbo_ConnectionCycle.Text = "3000";
            this.Tbo_ConnectionCycle.TextChanged += new System.EventHandler(this.Tbo_ConnectionCycle_TextChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(293, 77);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 14);
            this.labelControl4.TabIndex = 22;
            this.labelControl4.Text = "Address";
            // 
            // Tbo_Address
            // 
            this.Tbo_Address.Location = new System.Drawing.Point(279, 97);
            this.Tbo_Address.Name = "Tbo_Address";
            this.Tbo_Address.Size = new System.Drawing.Size(68, 22);
            this.Tbo_Address.TabIndex = 21;
            this.Tbo_Address.TextChanged += new System.EventHandler(this.Tbo_Address_TextChanged);
            // 
            // timer_CyclicMessage
            // 
            this.timer_CyclicMessage.Interval = 3000;
            // 
            // modbusHelperCurrent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.Tbo_Address);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.Tbo_ConnectionCycle);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Tbo_MessageCycle);
            this.Controls.Add(this.radioGroup_Logging);
            this.Controls.Add(this.Btn_StartConnectionCycle);
            this.Controls.Add(this.Tbo_IP);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.radioGroup_CyclicRead);
            this.Controls.Add(this.textBox_Console);
            this.Name = "modbusHelperCurrent1";
            this.Size = new System.Drawing.Size(365, 429);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_CyclicRead.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbo_IP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_Logging.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Console;
        private DevExpress.XtraEditors.RadioGroup radioGroup_CyclicRead;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit Tbo_IP;
        private DevExpress.XtraEditors.SimpleButton Btn_StartConnectionCycle;
        private DevExpress.XtraEditors.RadioGroup radioGroup_Logging;
        private System.Windows.Forms.TextBox Tbo_MessageCycle;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox Tbo_ConnectionCycle;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox Tbo_Address;
        private System.Windows.Forms.Timer timer_CyclicMessage;
    }
}
