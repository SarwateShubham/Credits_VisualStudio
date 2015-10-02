using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote_control_AUV
{
    public partial class Mission_Control : Form
    {
        public Mission_Control()
        {
            InitializeComponent();
        }
        public SerialPort SerialPort1 = new SerialPort();
        private void Mission_Control_Load(object sender, EventArgs e)
        {
            SerialPort1.PortName = "COM5";
            SerialPort1.BaudRate = 9600;
            SerialPort1.DataBits = 8;
            SerialPort1.Parity = Parity.None;
            SerialPort1.StopBits = StopBits.One;
            SerialPort1.Handshake = Handshake.None;
            SerialPort1.Encoding = Encoding.Default;

        }
        private void Mission_Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                SerialPort1.Open();
                SerialPort1.Write("r");
                SerialPort1.Close();
                Right.BackColor = Color.Gray;
            }
            else if (e.KeyCode == Keys.Left)
            {
                SerialPort1.Open();
                SerialPort1.Write("l");
                SerialPort1.Close();
                Left.BackColor = Color.Gray;
            }
            else if (e.KeyCode == Keys.Down)
            {
                SerialPort1.Open();
                SerialPort1.Write("s");
                SerialPort1.Close();
                Stop.BackColor = Color.Gray;
            }
            else if (e.KeyCode == Keys.Up)
            {
                SerialPort1.Open();
                SerialPort1.Write("f");
                SerialPort1.Close();
                Fwd.BackColor = Color.Gray;
            }
            else if (e.KeyCode == Keys.Space)
            {
                SerialPort1.Open();
                SerialPort1.Write("d");
                SerialPort1.Close();
                Low.BackColor = Color.Gray;
            }
            else if (e.KeyCode == Keys.Q)
            {
                SerialPort1.Open();
                SerialPort1.Write("q");
                SerialPort1.Close();
                High.BackColor = Color.Gray;
            }
            else if (e.KeyCode == Keys.A)
            {
                SerialPort1.Open();
                SerialPort1.Write("a");
                SerialPort1.Close();
                Low.BackColor = Color.Gray;
            }
        }
    }
}
