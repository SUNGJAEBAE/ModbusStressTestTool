using DevExpress.XtraEditors;
using FluentModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForParkingCloud
{

    public partial class modbusHelperCurrent1 : DevExpress.XtraEditors.XtraUserControl
    {
        private static modbusHelperCurrent1 _instance;

        public static modbusHelperCurrent1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new modbusHelperCurrent1(0);

                return _instance;
            }
        }

        public bool IsConnected
        {
            get
            {
                return client.IsConnected;
            }
        }
        private int address;
        private short data;
        private int messageCylceTime;
        private int ConnectionCycleTime;
        private double timeDiff;
        private Stopwatch stopwatch = new Stopwatch();
        private bool logging;
        private bool startConnectionCycle;
        private IPEndPoint ipEndPoint;
        private ModbusTcpClient client;
        private object lockObject = new object();
        private CancellationTokenSource cancellationTokenSource;

        public modbusHelperCurrent1(int order)
        {
            InitializeComponent();
            Tbo_Address.Text = order.ToString();
            client = new ModbusTcpClient();
            int.TryParse(Tbo_MessageCycle.Text, out messageCylceTime);
            int.TryParse(Tbo_ConnectionCycle.Text, out ConnectionCycleTime);
            int.TryParse(Tbo_Address.Text, out address);

            timer_CyclicMessage.Interval = messageCylceTime;
            timer_CyclicMessage.Tick += worker_Modbus;

            cancellationTokenSource = new CancellationTokenSource();

        }
        public void Connect(string address)
        {
            string str = Tbo_IP.Text;
            string IP = "";
            string port = "";
            if (client.IsConnected == true)
            {
                return;
            }
            try
            {
                IP = address.Split(':')[0];
                port = address.Split(':')[1];
                ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), int.Parse(port));
                client.Connect(ipEndPoint, ModbusEndianness.BigEndian);
                WriteTextBoxConsole($"{IP}:{port}와 연결 완료");
                if (radioGroup_CyclicRead.SelectedIndex == 1)
                {
                    StartMessageCycle();
                }
            }
            catch (Exception exception)
            {
                ipEndPoint = null;
                WriteTextBoxConsole($"{exception.Message}");
            }
        }

        public void DisConnect()
        {
            if (client.IsConnected == false)
            {
                return;
            }
            try
            {
                StopMessageCycle();
                client.Disconnect();
                WriteTextBoxConsole($"{ipEndPoint.Address.ToString()}:{ipEndPoint.Port}와 연결 해제");
            }
            catch (Exception exception)
            {
                WriteTextBoxConsole($"{exception.Message}");
            }
        }

        private async void worker_Modbus(object sender, EventArgs e) //modbus tcp중 이벤트가 발생하면 ReportProgress 이벤트 발생시킨다
        {
            var task = Task.Run(async () =>
              {
                  while (true)
                  {
                      if (cancellationTokenSource.Token.IsCancellationRequested)
                      {
                          cancellationTokenSource.Token.ThrowIfCancellationRequested();
                      }
                      if (IsConnected == false)
                      {
                          await Task.Delay(1000);
                          continue;
                      }
                      lock (lockObject)
                      {
                          WriteModbus(address, data);
                          ReadModbus();
                      }

                      stopwatch.Stop();
                      await Task.Delay(messageCylceTime);
                      timeDiff = stopwatch.Elapsed.TotalMilliseconds;
                      WriteTextBoxConsole($"address:{address} data:{data} timeDiff:{timeDiff}");
                      stopwatch.Restart();
                  }
              }, cancellationTokenSource.Token);
            try
            {
                await task;
            }
            catch (OperationCanceledException exception)
            {
                WriteTextBoxConsole($"{exception.Message}");
            }
            catch (Exception exception)
            {
                WriteTextBoxConsole($"{exception.Message}");
                DisConnect();
                if (ipEndPoint != null)
                {
                    WriteTextBoxConsole($"{ipEndPoint.Address.ToString()}:{ipEndPoint.Port}에 재연결을 시도합니다");
                    Connect(Tbo_IP.Text);
                }
            }

        }

        public void StartMessageCycle()
        {
            if (!timer_CyclicMessage.Enabled)
            {
                timer_CyclicMessage.Start();
                cancellationTokenSource = new CancellationTokenSource();
            }
        }

        public void StopMessageCycle()
        {
            if (timer_CyclicMessage.Enabled)
            {
                timer_CyclicMessage.Stop();
                cancellationTokenSource.Cancel();
            }
        }

        public void WriteModbus(int startingAddress, short data)
        {
            lock (lockObject)
            {
                try
                {
                    client.WriteSingleRegister(0xFF, startingAddress, (short)(data + 1));
                }
                catch (Exception exception)
                {
                    WriteTextBoxConsole(exception.Message);
                }
            }
        }

        public void WriteTextBoxConsole(string str)
        {
            if (logging == false)
            {
                return;
            }
            if (InvokeRequired) //Worker thread에서 델리게이트로 UI thread에 이 메서드와 파라미터를 넘긴다.
            {
                Invoke(new Action(() => { textBox_Console.AppendText(str + Environment.NewLine); }));
            }
            else
            {
                textBox_Console.AppendText(str + Environment.NewLine);
            }
        }
        #region 이벤트
        private void Btn_Connect_Click(object sender, EventArgs e)
        {

            if (Btn_StartConnectionCycle.Text == "Start")
            {
                //Connect(Tbo_IP.Text);
                startConnectionCycle = true;
                StartConnectionCycle(Tbo_IP.Text);
                Btn_StartConnectionCycle.Text = "Stop";
            }
            else if (Btn_StartConnectionCycle.Text == "Stop")
            {
                //DisConnect();
                StopConnectionCycle();
                Btn_StartConnectionCycle.Text = "Start";
            }

        }

        private async void StartConnectionCycle(string address)
        {
            //connection cycle마다 끊었다 연결하기 반복
            while (startConnectionCycle)
            {
                DisConnect();
                Connect(address);
                await Task.Delay(ConnectionCycleTime);
            }
        }

        private void StopConnectionCycle()
        {
            startConnectionCycle = false;
            DisConnect();
        }

        private void radioGroup_Logging_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup_Logging.SelectedIndex == 0)
            {
                logging = false;
            }
            else if (radioGroup_Logging.SelectedIndex == 1)
            {
                logging = true;
            }
        }
        private void radioGroup_CyclicRead_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsConnected == false)
                return;
            if (radioGroup_CyclicRead.SelectedIndex == 0)
            {
                //Off
                StopMessageCycle();
            }
            else if (radioGroup_CyclicRead.SelectedIndex == 1)
            {
                //On
                StartMessageCycle();
            }
        }
        private void Tbo_MessageCycle_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(Tbo_MessageCycle.Text, out messageCylceTime);
            timer_CyclicMessage.Interval = messageCylceTime;
        }

        private void Tbo_ConnectionCycle_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(Tbo_ConnectionCycle.Text, out ConnectionCycleTime);
        }

        private void Tbo_Address_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(Tbo_Address.Text, out address);
        }
        #endregion

        //ControlRegisters에서 복붙한거
        public void ReadModbus()
        {
            data = client.ReadHoldingRegisters<short>(0xFF, address, 1).ToArray()[0];
        }
    }
}
