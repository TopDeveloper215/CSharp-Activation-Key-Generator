using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;


namespace RS232_NAS100_PLUS_v1_1
{
    
    
    public partial class Form1 : System.Windows.Forms.Form

    {
        private bool _Trial;
        bool isConnected = false;
        String[] ports;
        SerialPort port;
        static SerialPort serialPort1;

        public Form1(bool IsTrial)
        {
            InitializeComponent();
            getAvailableComPorts();
            _Trial = IsTrial;
            serialPort1 = new SerialPort();
            textBox6.Text = "Transmitter Disconnected";
            btnConnectCom.Enabled = true;
            btnDisconnect.Enabled = false;
            btnRead.Enabled = false;
            btnSetPower.Enabled = false;
            btnSetAudio.Enabled = false;
            btnSetFrequencyHi.Enabled = false;
            btnSetFrequencyLow.Enabled = false;
            btnHiBand.Enabled = false;
            btnLowBand.Enabled = false;
            btnSetPanel.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            comboBox2.Enabled = false;
        }



        //////////////////////  GET AVAILABLE PORTS  /////////////////////////////////////
        void getAvailableComPorts()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox3.Items.AddRange(ports);
        }

     

        //////////////////////  BUTTON CONNECT TRANSMITTER  /////////////////////////////////////
        private void btnConnectCom_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.Text == "")
                {
                    textBox6.Text = "Please Select Port";
                }
                else
                {
                    serialPort1.PortName = comboBox3.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.DataBits = 8;
                    serialPort1.Handshake = Handshake.None;
                    serialPort1.ReadTimeout = 1000;
                    serialPort1.WriteTimeout = 1000;
                    serialPort1.Open();

                    btnConnectCom.Enabled = false;
                    btnDisconnect.Enabled = true;
                    btnRead.Enabled = true;
                    btnSetPower.Enabled = true;
                    btnSetAudio.Enabled = true;
                    btnSetFrequencyHi.Enabled = false;
                    btnSetFrequencyLow.Enabled = false;
                    btnHiBand.Enabled = true;
                    btnLowBand.Enabled = true;
                    btnSetPanel.Enabled = true;
                    numericUpDown1.Enabled = true;
                    numericUpDown2.Enabled = true;
                    numericUpDown3.Enabled = false;
                    numericUpDown4.Enabled = false;
                    comboBox2.Enabled = true;
                    readParameters();
                }
            }
            catch(UnauthorizedAccessException)
            {
                textBox6.Text = "Unauthorized Access";
            }
        }

        //////////////////////  BUTTON SET POWER  /////////////////////////////////////
        private void btnSetPower_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= 10)

            {
             serialPort1.Write(String.Format("FP=0" + numericUpDown1.Text + ".0" + "\r"));
             textBox6.Text = "Last command: Set Power to " + numericUpDown1.Text + " Watts";
            }
            
            else
            {
             serialPort1.Write(String.Format("FP=00" + numericUpDown1.Text + ".0" + "\r"));
             textBox6.Text = "Last command: Set Power to " + numericUpDown1.Text + " Watts";
            }
                   
        }


        //////////////////////  BUTTON SET AUDIO  /////////////////////////////////////
        private void btnSetAudio_Click(object sender, EventArgs e)
        {
            if (numericUpDown2.Value >= 10)
            {
                serialPort1.Write(String.Format("AG=" + numericUpDown2.Text + "\r"));
                textBox6.Text = "Last command: Set Audio Gain to " + numericUpDown2.Text + " %";
            }
            else
            {
                serialPort1.Write(String.Format("AG=0" + numericUpDown2.Text + "\r"));
                textBox6.Text = "Last command: Set Audio Gain to " + numericUpDown2.Text + " %";
            }
        }




            //////////////////////  BUTTON LOCK/UNLOCK PANEL //////////////////////////////////
            private void btnLockPanel_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBox2.Text == "")
                {
                    textBox6.Text = "Please Select Lock or Unlock option";
                }

                else
                {
                    if (comboBox2.Text == "Lock")
                    {
                        serialPort1.Write("FD\r");
                        textBox6.Text = "Last command: Lock the front panel";
                    }

                    else
                    {
                        serialPort1.Write("FE\r");
                        textBox6.Text = "Last command: Unlock the front panel";
                    }
                    
                }
            }
                 catch (UnauthorizedAccessException)
                 {
                 textBox6.Text = "Unauthorized Access";
                 }
        }


        //////////////////////  BUTTON READ PARAMETERS  /////////////////////////////////////
        private void btnReadParameters_Click(object sender, EventArgs e)
        {
            readParameters();
        }


        //////////////////////  BUTTON Transmitter Disconnect //////////////////////////////////
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            textBox6.Text = "Transmitter Disconnected";
            btnConnectCom.Enabled = true;
            btnDisconnect.Enabled = false;
            btnRead.Enabled = false;
            btnSetPower.Enabled = false;
            btnSetAudio.Enabled = false;
            btnSetFrequencyHi.Enabled = false;
            btnSetFrequencyLow.Enabled = false;
            btnHiBand.Enabled = false;
            btnLowBand.Enabled = false;
            btnSetPanel.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            comboBox2.Enabled = false;
        }

        
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {        }
          

        private void textBox5_TextChanged(object sender, EventArgs e)
        {        }

        
        private void label1_Click(object sender, EventArgs e)
        {        }

        private void label2_Click(object sender, EventArgs e)
        {       }

        private void label3_Click_1(object sender, EventArgs e)
        {        }

        private void label5_Click(object sender, EventArgs e)
        {        }


        private void Form1_Load(object sender, EventArgs e)
        {        }


        //////////////////////  ROUTINE ASK transmitter's Parameters  ////////////////////////////////////////////
        ///
        void readParameters()
        {
            serialPort1.Close();
            serialPort1.ReadTimeout = 1000;
            serialPort1.WriteTimeout = 1000;
            serialPort1.Open();
           
           
            /////////////////////   ASK FORWARD POWER OUTPUT      ////////////////////////////////////////////  
            serialPort1.Write("FP?\r"); // STELNO ENTOLH NA ROTHSO THN ISXY TOY POMPOY
            textBox1.Text = "";         // KATHARIZO TO KOUTAKI GIA NA PAREI THN NEA TIMH  
            try
            {
                textBox1.Text = serialPort1.ReadLine();  // BAZO TO NOYMERO POY ESTEILE O POMPOS STO KOUTAKI 1
            }
            catch (TimeoutException)
            {
                textBox6.Text = "Timeout Exception";
            }
            ///////////////////////////////////////////////////////////


            //////////////////////  ASK REFLECTED POWER OUT /////////////////////////////////////
            serialPort1.Write("RP?\r");
            textBox2.Text = "";
            try
            {
                textBox2.Text = serialPort1.ReadLine();
            }
            catch (TimeoutException)
            {
                textBox6.Text = "Timeout Exception";
            }
            ///////////////////////////////////////////////////////////


            //////////////////////  ASK TEMPERATURE  /////////////////////////////////////
            serialPort1.Write("AT?\r");
            textBox3.Text = "";

            try
            {
                textBox3.Text = serialPort1.ReadLine();
            }
            catch (TimeoutException)
            {
                textBox6.Text = "Timeout Exception";
            }
            /////////////////////////////////////////////////////////////////////////////


            //////////////////////  ASK DEVIATION  /////////////////////////////////////
            serialPort1.Write("PD?\r");
            textBox4.Text = "";
            try
            {
                textBox4.Text = serialPort1.ReadLine();
            }
            catch (TimeoutException)
            {
                textBox6.Text = "Timeout Exception";
            }
            ///////////////////////////////////////////////////////////


            ///////////////////////  ASK AUDIO GAIN  ////////////////////////////////////
            serialPort1.Write("AG?\r");
            textBox5.Text = "";
            try
            {
                textBox5.Text = serialPort1.ReadLine();
            }
            catch (TimeoutException)
            {
                textBox6.Text = "Timeout Exception";
            }
            ////////////////////////////////////////////////////////////////////////////

             
            //////////////////////  ASK FREQUENCY  /////////////////////////////////////
            serialPort1.Write("CF?\r");
            textBox8.Text = "";
            try
            {
                textBox8.Text = serialPort1.ReadLine();
            }
            catch (TimeoutException)
            {
                textBox6.Text = "Timeout Exception";
            }
            ///////////////////////////////////////////////////////////////////////////

            if (textBox8.Text == "")
            {
                textBox6.Text = "Transmitter couldn't connect";
                serialPort1.Close();

                btnConnectCom.Enabled = true;
                btnDisconnect.Enabled = false;
                btnRead.Enabled = false;
                btnSetPower.Enabled = false;
                btnSetAudio.Enabled = false;
                btnSetFrequencyHi.Enabled = false;
                btnSetFrequencyLow.Enabled = false;
                btnHiBand.Enabled = false;
                btnLowBand.Enabled = false;
                btnSetPanel.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                comboBox2.Enabled = false;
            }
            else
            {
                textBox6.Text = "Last command: Read Transmitter's Parameters - Transmitter Connected";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        //////////////////////  BUTTON SET HIGH BAND  /////////////////////////////////////
        private void btnHiBand_Click(object sender, EventArgs e)
        {
            btnConnectCom.Enabled = false;
            btnDisconnect.Enabled = true;
            btnRead.Enabled = true;
            btnSetPower.Enabled = true;
            btnSetAudio.Enabled = true;
            btnSetFrequencyHi.Enabled = true;
            btnSetFrequencyLow.Enabled = false;
            btnHiBand.Enabled = false;
            btnLowBand.Enabled = true;
            btnSetPanel.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown4.Enabled = false;
            comboBox2.Enabled = true;
            textBox6.Text = "Set Frequency 151.450 MHz - 174.000 Mhz";
        }



        //////////////////////  BUTTON SET LOW BAND  /////////////////////////////////////
        private void btnLowBand_Click(object sender, EventArgs e)
        {
            btnConnectCom.Enabled = false;
            btnDisconnect.Enabled = true;
            btnRead.Enabled = true;
            btnSetPower.Enabled = true;
            btnSetAudio.Enabled = true;
            btnSetFrequencyHi.Enabled = false;
            btnSetFrequencyLow.Enabled = true;
            btnHiBand.Enabled = true;
            btnLowBand.Enabled = false;
            btnSetPanel.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = true;
            comboBox2.Enabled = true;
            textBox6.Text = "Set Frequency 74.000 MHz - 77.000 Mhz";
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {     }


        
        //////////////////////  BUTTON SET LOW BAND FREQUENCY  /////////////////////////////////////
        private void btnSetFrequencyLow_Click(object sender, EventArgs e)
        {
         serialPort1.Write(String.Format("CF=" + numericUpDown4.Text + "\r"));
         textBox6.Text = "Last command: Set frequency to " + numericUpDown4.Text + " MHz";
        }


        //////////////////////  BUTTON SET HIGH BAND FREQUENCY  /////////////////////////////////////
        private void btnSetHighFrequency_Click(object sender, EventArgs e)
        {
         serialPort1.Write(String.Format("CF=" + numericUpDown3.Text + "\r"));
         textBox6.Text = "Last command: Set frequency to " + numericUpDown3.Text + " MHz";
        }

        private void buttonWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://payhip.com/MavraidisBooks/collection/my-software");
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            using (frmGenerate frm = new frmGenerate())
            {
                frm.ShowDialog();
            }
        }*/
    }



}
