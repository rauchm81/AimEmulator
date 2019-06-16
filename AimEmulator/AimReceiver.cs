using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using TurboDisplay.source.common.aim;
using System.IO;

namespace AimEmulator
{
    class AimReceiver
    {
        public delegate void AimPacketHandler(AimPacket packet);

        public static AimPacketHandler aimPacketHandler;

        Thread t_;
        static bool isInitialized = false;
        static AbstractSerialPort serialPort_;
        static bool threadContinue = true;

        public void open(string portname, string filename)
        {
            serialPort_ = new AbstractSerialPort();
            serialPort_.open(portname, filename);
        }

        public void receive(string portname, string filename)
        {
            
            threadContinue = true;
            t_ = new Thread(ThreadEntry);
            t_.Start();
        }

        public void stopReceiving()
        {
            
            threadContinue = false;
            if (t_ != null)
            {
                if (t_.IsAlive)
                    t_.Join(50);
                t_.Abort();
            }

            if (serialPort_ != null)
            {
                serialPort_.close();
            }

            
        }

        public static void ThreadEntry()
        {
            
            while (threadContinue)
            {
                try
                {
                    
                    System.Console.WriteLine("start serial AIM packet receiver");
                    while (serialPort_.BytesToRead() < 1)
                    {
                        System.Console.WriteLine("no data at serial port");
                        Thread.Sleep(500);
                    }

                    if (serialPort_.BytesToRead() > 1000)
                    {
                        System.Console.WriteLine("serialPort_.DiscardInBuffer");
                        serialPort_.DiscardInBuffer();
                    }

                    System.Console.WriteLine("AIM packet receiver: " + serialPort_.BytesToRead() + " bytes available");
                    

                    // initialize
                    if (isInitialized == false)
                    {
                        int initialization = serialPort_.ReadByte();
                        while (initialization != 0xA3)
                        {
                            initialization = serialPort_.ReadByte();
                        }
                        byte[] dummy = new byte[3];
                        serialPort_.Read(dummy, 0, 3);
                        isInitialized = true;
                    }

                    
                    byte[] data = new byte[5];
                    if (serialPort_.Read(data, 0, 5) == 5)
                    {
                        AimPacket packet = new AimPacket(data);

                        if (packet.getConstant() != 0xA3)
                        {
                            isInitialized = false;
                            System.Console.WriteLine("lost synchronization of AIM packet");
                        }
                        else
                        {
                            if (aimPacketHandler != null)
                            {
                                aimPacketHandler(packet);
                            }
                        }

                        System.Console.WriteLine("AIM packet channel" + packet.getChannel() + " value " + packet.getValue());

                    }

                }
                catch (Exception) { }
            }


            /*FileStream f = File.Open("D:\\tools\\Einstein\\Terminals\\hterm\\output_2010-08-28_12-42-30.log", FileMode.Open);

            while (threadContinue)
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
            */

        }

        
    }

    class AbstractSerialPort
    {
        FileStream f;
        SerialPort p;

        static bool useFile = false;

        public AbstractSerialPort()
        {
                 
        }

        public void open(string portname, string filename)
        {
            if (filename.Length > 0)
            {
                f = File.Open(filename, FileMode.Open);
                useFile = true;
            }
            else
            {
                openComport(portname);
            }
   
        }

        public void close()
        {
            if (useFile == false &&p!=null)
            {
                p.Close();
            }
            else if(f != null)
            {
                f.Close();
            }
        }

        private void openComport(String name)
        {
            p = new SerialPort();

            p.PortName = name;
            p.BaudRate = 19200;
            p.Parity = Parity.None;
            p.DataBits = 8;
            p.StopBits = StopBits.One;
            p.Handshake = Handshake.None;
            p.ReadTimeout = 50;
            p.WriteTimeout = 50;

            p.Open();
            
            return;

        }

        public int BytesToRead()
        {
            if (useFile)
            {
                return 1;
            }
            else
            {
                return p.BytesToRead;
            }
        }

        public int Read(byte[] array, int offset, int count)
        {
            if (useFile)
            {
                return f.Read(array, offset, count);
            }
            else
            {
                return p.Read(array, offset, count);
            }
        }

        public int ReadByte()
        {
            if (useFile)
            {
                return f.ReadByte();
            }
            else
            {
                return p.ReadByte();
            }
        }

        public void DiscardInBuffer()
        {
            if (useFile)
            {
                return;
            }
            else
            {
                p.DiscardInBuffer();
                return;
            }
        }


    }
}

