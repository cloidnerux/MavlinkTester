using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using log4net;

namespace MavlinkTester {
	public partial class Form1 : Form {
		private static readonly ILog log = LogManager.GetLogger(typeof(Form1));

		private delegate void UpdateDataTextBoxDeleagte(byte[] s);

		public Form1() {
			log4net.Config.BasicConfigurator.Configure();
			InitializeComponent();
			CommunicationPort.DataReceived += CommunicationPort_DataReceived;
			seq = 0;
		}

		void CommunicationPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
			byte[] buffer = new byte[CommunicationPort.BytesToRead];
			CommunicationPort.Read(buffer, 0, CommunicationPort.BytesToRead);
			Invoke(new UpdateDataTextBoxDeleagte(UpdateDataTextBox), buffer);
		}

		void UpdateDataTextBox(byte[] s)
		{
			foreach(byte c in s) {
				DataTextBox.Text += "[" + c.ToString() + "] ";
			}
		}

		private void Form1_Load(object sender, EventArgs e) {
			SerialPortComboBox.Items.Clear();
			SerialPortComboBox.Items.AddRange(SerialPort.GetPortNames());
			SerialPortComboBox.SelectedItem = SerialPortComboBox.Items[0];
		}

		private void SerialPortComboBox_DropDown(object sender, EventArgs e) {
			var tmp = SerialPortComboBox.SelectedItem;
			SerialPortComboBox.Items.Clear();
			SerialPortComboBox.Items.AddRange(SerialPort.GetPortNames());
			if(SerialPort.GetPortNames().Contains(tmp))
			{
				SerialPortComboBox.SelectedItem = tmp;
			}
			else{
				SerialPortComboBox.SelectedItem = SerialPortComboBox.Items[0];
			}
		}

		private void ConnectButton_Click(object sender, EventArgs e) {
			try{
				if(ConnectButton.Text == "Connect")
				{
					CommunicationPort.PortName = SerialPortComboBox.SelectedItem as string;
					CommunicationPort.BaudRate = 57600;
					CommunicationPort.Open();
					log.Info("Open Com Port: " + CommunicationPort.PortName + " with baudrate " + CommunicationPort.BaudRate.ToString());
					ConnectButton.Text = "Disconnect";
				}
				else
				{
					if(CommunicationPort.IsOpen)
						CommunicationPort.Close();
					ConnectButton.Text = "Connect";
				}
			}
			catch(Exception ex)
			{
				log.Error("Could not connect!", ex);
			}

		}

		private int seq;

		private void valueTrackBar1_ValueChanged(object sender, EventArgs e) {
			if(!CommunicationPort.IsOpen)
				return;
			MavLink.Mavlink m = new MavLink.Mavlink();
			MavLink.MavlinkPacket p = new MavLink.MavlinkPacket();

			var tmp = new MavLink.Msg_gps_raw_int();
			if(GpsFixCheckBox.CheckState == CheckState.Unchecked)
					tmp.fix_type = 0;
			else if(GpsFixCheckBox.CheckState == CheckState.Indeterminate)
				tmp.fix_type = 2;
			else {
				tmp.fix_type = 3;
			}
			tmp.satellites_visible = (byte)valueTrackBar1.Value;

			p.ComponentId = (int)MavLink.MAV_COMPONENT.MAV_COMP_ID_GPS;
			p.SystemId = 1;
			p.SequenceNumber = (byte)seq++;
			p.TimeStamp = DateTime.Now;
			p.Message = tmp;

			byte[] buffer = m.Send(p);
			
			//tmp.Serialize(buffer, ref offset);
			log.Info("Send Message");
			log.Info(buffer);
			log.Info("Offset: " + buffer.Length.ToString());
			CommunicationPort.Write(buffer, 0, buffer.Length);
			CommunicationPort.Write("\r\n");
		}

		private void GpsFixCheckBox_CheckedChanged(object sender, EventArgs e) {
			if(!CommunicationPort.IsOpen)
				return;
			MavLink.Mavlink m = new MavLink.Mavlink();
			MavLink.MavlinkPacket p = new MavLink.MavlinkPacket();

			var tmp = new MavLink.Msg_gps_raw_int();
			if(GpsFixCheckBox.CheckState == CheckState.Unchecked)
				tmp.fix_type = 0;
			else if(GpsFixCheckBox.CheckState == CheckState.Indeterminate)
				tmp.fix_type = 2;
			else {
				tmp.fix_type = 3;
			}
			tmp.satellites_visible = (byte)valueTrackBar1.Value;

			p.ComponentId = (int)MavLink.MAV_COMPONENT.MAV_COMP_ID_GPS;
			p.SystemId = 1;
			p.SequenceNumber = (byte)seq++;
			p.TimeStamp = DateTime.Now;
			p.Message = tmp;

			byte[] buffer = m.Send(p);

			//tmp.Serialize(buffer, ref offset);
			log.Info("Send Message");
			log.Info(buffer);
			log.Info("Offset: " + buffer.Length.ToString());
			CommunicationPort.Write(buffer, 0, buffer.Length);
			CommunicationPort.Write("\r\n");
		}

		private void BatteryValueTrackBar_ValueChanged(object sender, EventArgs e) {
			if(!CommunicationPort.IsOpen)
				return;
			MavLink.Mavlink m = new MavLink.Mavlink();
			MavLink.MavlinkPacket p = new MavLink.MavlinkPacket();

			var tmp = new MavLink.Msg_sys_status();
			tmp.current_battery = 100;
			tmp.voltage_battery = (ushort)(BatteryValueTrackBar.Value * 100);
			
			p.ComponentId = (int)MavLink.MAV_COMPONENT.MAV_COMP_ID_SYSTEM_CONTROL;
			p.SystemId = 1;
			p.SequenceNumber = (byte)seq++;
			p.TimeStamp = DateTime.Now;
			p.Message = tmp;

			byte[] buffer = m.Send(p);

			//tmp.Serialize(buffer, ref offset);
			log.Info("Send Message");
			log.Info(buffer);
			log.Info("Offset: " + buffer.Length.ToString());
			CommunicationPort.Write(buffer, 0, buffer.Length);
			CommunicationPort.Write("\r\n");
		}
	}
}
