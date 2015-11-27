using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Globalization;
using System.IO.Ports;
using System.Diagnostics;

namespace Anna
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
       
        int time = 0;
        int j = 0;

        SpeechRecognizer a = new SpeechRecognizer();
        SpeechRecognitionEngine b = new SpeechRecognitionEngine();
        SpeechSynthesizer c = new SpeechSynthesizer();
        SerialPort SerialPort1 = new SerialPort();

       

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPort1.PortName = "COM"+textBox2.Text;


            Choices slist = new Choices();
            slist.Add(new string[] { "Study Mode","I am done","Party" ,"Lets Work","Wake me up tomorrow","Anna","Yes Sir?"});
            
            Grammar gr = new Grammar(new GrammarBuilder(slist));
            b.RequestRecognizerUpdate();
            
            b.LoadGrammar(gr);
            b.SpeechRecognized +=b_SpeechRecognized;
            b.SetInputToDefaultAudioDevice();
            b.RecognizeAsync(RecognizeMode.Multiple);
            c.GetInstalledVoices();
            
        }



        private void b_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            if (e.Result.Text == "Anna" && j == 0)
            {
                c.SpeakAsync("Yes Sir?");
                j = 1;
            }
            if (j==1)
            {               
                if (e.Result.Text == "Study Mode")		//Opens the study folder and turns the study lamp on
                {
                    SerialPort1.Open();
                    
                    SerialPort1.Write("1");
                    j = 0;
                    SerialPort1.Close();
                    Process.Start(@"C:\Users\Owner\Desktop\2-1");

                }

                else if (e.Result.Text == "I am done")		//Turns off the lamp if it is on
                {
                    SerialPort1.Open();
                    SerialPort1.Write("2");

                    SerialPort1.Close();
                    j = 0;
                }

                else if (e.Result.Text == "Party")		//Plays a particular song playlist
                {
                    SerialPort1.Open();
                    SerialPort1.Write("3");
                    j = 0;
                    SerialPort1.Close();
                    Process.Start(@"C:\Users\Owner\Music\Playlists\Party.wpl");
                }
                else if (e.Result.Text == "Lets Work")		//Project mode!
                {
                    SerialPort1.Open();
                    SerialPort1.Write("1");
                    j = 0;
                    SerialPort1.Close();
                    Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                    Process.Start(@"C:\Users\Projects");
                }
               
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)		//Initialize the Form
        {
            SerialPort1.PortName = "COM15";
            SerialPort1.BaudRate = 9600;
            SerialPort1.DataBits = 8;
            SerialPort1.Parity = Parity.None;
            SerialPort1.StopBits = StopBits.One;
            SerialPort1.Handshake = Handshake.None;
            SerialPort1.Encoding = System.Text.Encoding.Default;
           Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
          
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show("Speech recognized: " + e.Result.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (DateTime.Now.Second==time+8)
            {
                Process.Start(@"C:\Users\Owner\Music\Playlists\Party.wpl");
                timer1.Stop();
            }
            
        }
    }
}

