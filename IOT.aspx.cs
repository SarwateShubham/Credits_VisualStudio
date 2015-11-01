using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Ports;


public partial class Homer : System.Web.UI.Page
{
    public int a;
    SerialPort SerialPort1 = new SerialPort();
    protected void Page_Load(object sender, EventArgs e)
    {
        SerialPort1.PortName = "COM16";
        SerialPort1.BaudRate = 9600;
        SerialPort1.DataBits = 8;
        SerialPort1.Parity = Parity.None;
        SerialPort1.StopBits = StopBits.One;
        SerialPort1.Handshake = Handshake.None;
        SerialPort1.Encoding = System.Text.Encoding.Default;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SerialPort1.Open();
        SerialPort1.Write("1");

        SerialPort1.Close();
        a = 1;
        if (a == 1)
            Label1.Text = "Lamp is ON";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SerialPort1.Open();
        SerialPort1.Write("2");
        a = 2;
            if (a == 2)
            Label1.Text = "Lamp is OFF";
        SerialPort1.Close();
    }
}