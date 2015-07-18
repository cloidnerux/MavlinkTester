namespace MavlinkTester {
	partial class Form1 {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.valueTrackBar1 = new Hebeler.UI.ValueTrackBar();
			this.SerialPortComboBox = new System.Windows.Forms.ComboBox();
			this.ConnectButton = new System.Windows.Forms.Button();
			this.CommunicationPort = new System.IO.Ports.SerialPort(this.components);
			this.DataTextBox = new System.Windows.Forms.RichTextBox();
			this.GpsFixCheckBox = new System.Windows.Forms.CheckBox();
			this.BatteryValueTrackBar = new Hebeler.UI.ValueTrackBar();
			this.SuspendLayout();
			// 
			// valueTrackBar1
			// 
			this.valueTrackBar1.Location = new System.Drawing.Point(258, 12);
			this.valueTrackBar1.Maximum = 10;
			this.valueTrackBar1.Minimum = 0;
			this.valueTrackBar1.Name = "valueTrackBar1";
			this.valueTrackBar1.Size = new System.Drawing.Size(150, 56);
			this.valueTrackBar1.TabIndex = 0;
			this.valueTrackBar1.TickFreqeuncy = 1;
			this.valueTrackBar1.Value = 0;
			this.valueTrackBar1.ValueText = "GPS-Satelliten";
			this.valueTrackBar1.ValueChanged += new System.EventHandler(this.valueTrackBar1_ValueChanged);
			// 
			// SerialPortComboBox
			// 
			this.SerialPortComboBox.FormattingEnabled = true;
			this.SerialPortComboBox.Location = new System.Drawing.Point(12, 12);
			this.SerialPortComboBox.Name = "SerialPortComboBox";
			this.SerialPortComboBox.Size = new System.Drawing.Size(82, 21);
			this.SerialPortComboBox.TabIndex = 1;
			this.SerialPortComboBox.DropDown += new System.EventHandler(this.SerialPortComboBox_DropDown);
			// 
			// ConnectButton
			// 
			this.ConnectButton.Location = new System.Drawing.Point(101, 12);
			this.ConnectButton.Name = "ConnectButton";
			this.ConnectButton.Size = new System.Drawing.Size(75, 23);
			this.ConnectButton.TabIndex = 2;
			this.ConnectButton.Text = "Connect";
			this.ConnectButton.UseVisualStyleBackColor = true;
			this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
			// 
			// CommunicationPort
			// 
			this.CommunicationPort.BaudRate = 57600;
			// 
			// DataTextBox
			// 
			this.DataTextBox.Location = new System.Drawing.Point(12, 41);
			this.DataTextBox.Name = "DataTextBox";
			this.DataTextBox.Size = new System.Drawing.Size(167, 183);
			this.DataTextBox.TabIndex = 3;
			this.DataTextBox.Text = "";
			// 
			// GpsFixCheckBox
			// 
			this.GpsFixCheckBox.AutoSize = true;
			this.GpsFixCheckBox.Location = new System.Drawing.Point(258, 75);
			this.GpsFixCheckBox.Name = "GpsFixCheckBox";
			this.GpsFixCheckBox.Size = new System.Drawing.Size(64, 17);
			this.GpsFixCheckBox.TabIndex = 4;
			this.GpsFixCheckBox.Text = "GPS Fix";
			this.GpsFixCheckBox.ThreeState = true;
			this.GpsFixCheckBox.UseVisualStyleBackColor = true;
			this.GpsFixCheckBox.CheckedChanged += new System.EventHandler(this.GpsFixCheckBox_CheckedChanged);
			// 
			// BatteryValueTrackBar
			// 
			this.BatteryValueTrackBar.DisplayEyponent = -1;
			this.BatteryValueTrackBar.DisplayUnit = "V";
			this.BatteryValueTrackBar.Location = new System.Drawing.Point(258, 99);
			this.BatteryValueTrackBar.Maximum = 168;
			this.BatteryValueTrackBar.Minimum = 130;
			this.BatteryValueTrackBar.Name = "BatteryValueTrackBar";
			this.BatteryValueTrackBar.Size = new System.Drawing.Size(150, 56);
			this.BatteryValueTrackBar.TabIndex = 5;
			this.BatteryValueTrackBar.TickFreqeuncy = 5;
			this.BatteryValueTrackBar.Value = 130;
			this.BatteryValueTrackBar.ValueText = "Batteriespannung";
			this.BatteryValueTrackBar.ValueChanged += new System.EventHandler(this.BatteryValueTrackBar_ValueChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 262);
			this.Controls.Add(this.BatteryValueTrackBar);
			this.Controls.Add(this.GpsFixCheckBox);
			this.Controls.Add(this.DataTextBox);
			this.Controls.Add(this.ConnectButton);
			this.Controls.Add(this.SerialPortComboBox);
			this.Controls.Add(this.valueTrackBar1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Hebeler.UI.ValueTrackBar valueTrackBar1;
		private System.Windows.Forms.ComboBox SerialPortComboBox;
		private System.Windows.Forms.Button ConnectButton;
		private System.IO.Ports.SerialPort CommunicationPort;
		private System.Windows.Forms.RichTextBox DataTextBox;
		private System.Windows.Forms.CheckBox GpsFixCheckBox;
		private Hebeler.UI.ValueTrackBar BatteryValueTrackBar;
	}
}

