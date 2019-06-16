using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using TurboDisplay.source.common.aim;

namespace AimEmulator
{
    public partial class Form1 : Form
    {
        static TextBox myTextBox;
        static ListBox myListBox;
        static SerialPort port_;
        AimReceiver receiver_;
        AimData aimData_;

        public delegate void AddListBoxItem(String s);
        public static AddListBoxItem myDelegate;

       

        public Form1()
        {
            InitializeComponent();
            myTextBox = textBoxComPortSend;
            myListBox = listBoxData;
            myDelegate = new AddListBoxItem(AddListBoxItemMethod);

            receiver_ = new AimReceiver();
            AimReceiver.aimPacketHandler = new AimReceiver.AimPacketHandler(onNewAimData);

            aimData_ = new AimData();

            DataTable t = new DataTable();


            t.Columns.Add(new DataColumn());
            t.Columns.Add(new DataColumn("Protokoll"));
            t.Columns.Add(new DataColumn("Konvertiert"));

            for (int i = 0; i < (int)AimType.MAX; i++)
            {
                DataRow dr = t.NewRow();
                dr[0] = ((AimType)i).ToString();
                t.Rows.Add(dr);
            }

            dataGridView.DataSource = t;

            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
           


        }

        void onNewAimData(AimPacket packet)
        {
            String s = packet.toString();
            dataGridView.Rows[(int)packet.getType()].Cells[1].Value = packet.getValue();
            dataGridView.Rows[(int)packet.getType()].Cells[2].Value = packet.toString();
            
        }

        

        public void AddListBoxItemMethod(String s)
        {
            listBoxData.Items.Add(s);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //openComport(textBoxComPortSend.Text);  

            port_ = new SerialPort();

            port_.PortName = textBoxComPortSend.Text;
            port_.BaudRate = 19200;
            port_.Parity = Parity.None;
            port_.DataBits = 8;
            port_.StopBits = StopBits.One;
            port_.Handshake = Handshake.None;
            port_.ReadTimeout = 50;
            port_.WriteTimeout = 50;

            try
            {
                port_.Open();

                Thread t = new Thread(MyWrite);
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



           

            
        }

        public static void MyWrite()
        {
            FileStream f = File.Open("output_2010-08-28_12-42-30.log", FileMode.Open);

            while (true)
            {
                byte[] data = new byte[5];
                if (f.Read(data, 0, 5) == 5)
                {
                    myTextBox.Invoke(myDelegate, data[0] + " " + data[1] + " " + data[2] + " " + data[3] + " " + data[4]);

                    if (port_.IsOpen)
                    {
                        try { port_.Write(data, 0, 5); }
                        catch (Exception) { }
                    }
                    Thread.Sleep(10);
                }
                else
                {
                    break;
                }
            }

        }

        

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            receiver_.stopReceiving();
        }

        private void receiveButtonConnect_Click(object sender, EventArgs e)
        {
            if (receiveButtonConnect.Text == "disconnect")
            {
                receiver_.stopReceiving();
                receiveButtonConnect.Text = "connect";
            }
            else
            {
                string filename = "";
                string portname = textBoxComPortReceive.Text;
                if (checkBoxUseFile.CheckState == CheckState.Checked)
                {
                    filename = textBoxReceiveFile.Text;
                }

                try
                {
                    receiver_.open(portname, filename);
                    receiver_.receive(portname, filename);
                    receiveButtonConnect.Text = "disconnect";
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                } 


                
            }
            
        }

        

    }
}
