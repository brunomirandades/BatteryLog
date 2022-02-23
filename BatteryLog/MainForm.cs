using BatteryLog.Entities;
using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BatteryLog.Entities.Enums;

namespace BatteryLog
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            controlPanel.Hide();
            AddBaudrateSpeed();
            RefreshAvailableComPorts();
            ClearSlotControllers();
        }

        private List<Project> projectList = new List<Project>();
        private Project updatingProject;
        private int stdTime = 168;
        private int stdInterval = 10;

        //adicionar confirmação para fechar o software
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Do you want to close?\nAll unsaved data will be lost.",
                                    "Confirm",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }

        #region control invokes
        private string GetSelectedCOM()
        {
            if (comPortComboBox.InvokeRequired)
                return (string)comPortComboBox.Invoke(new Func<string>(GetSelectedCOM));
            else
                return comPortComboBox.Text;
        }

        private int GetSelecetdBaudrate()
        {
            if (baudrateComboBox.InvokeRequired)
                return (int)baudrateComboBox.Invoke(new Func<int>(GetSelecetdBaudrate));
            else
                return Convert.ToInt32(baudrateComboBox.Text);
        }
        #endregion

        #region serial port config
        //var auxiliar para conter o retorno do eventhandler da serial
        private string _retornoSerial = null;

        private int _delay = 500; //ms

        //informacoes da conexao serial
        Parity standardParity = (Parity)Enum.Parse(typeof(Parity), "None");
        int standardDatabits = 8;
        StopBits standardStopbits = (StopBits)Enum.Parse(typeof(StopBits), "One");
        //to use the declared port in all contexts inside this form it needs to be declared as private
        private SerialPort sPort;
        Analysis analysis = new Analysis();

        //criar funcao serial_connect
        private void SerialPort_Connect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
        {
            try
            {
                //connecting and defining the event handler
                sPort = new SerialPort(port, baudrate, parity, databits, stopbits);
                sPort.ReadTimeout = 500;
                sPort.Close();
                sPort.Open();
                sPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString(), "Opening Port Error!"); 
                return;
            }
        }

        //criar funcao serial_disconnect
        private void SerialPort_Disconnect()
        {
            try
            {
                if (sPort.IsOpen)
                {
                    sPort.Close();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString(), "Closing Port Error!");
                return;
            }
        }

        //criar event handler da serial
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string message = "";
                int length = sPort.BytesToRead;
                byte[] buf = new byte[length];

                string bufferStr = "";

                List<string> bufferStrList = new List<string>();

                sPort.Read(buf, 0, length);

                foreach (byte b in buf)
                {
                    string bString = b.ToString();
                    bufferStrList.Add(bString);
                }

                foreach (string s in bufferStrList)
                {
                    bufferStr += " " + s;
                }

                bufferStr = bufferStr.Trim();

                //MessageBox.Show(bufferStr + "\n" + analysis.Operation);

                _retornoSerial = null;

                //inserir switch para as diferentes respostas recebidas pelo event handler
                //switch with the response for each operation defined in the analysis operation property
                switch (analysis.Operation)
                {
                    case OperationType.SetInput:
                        message = PowerSupplyCommands.ReceivePowerSupplySetInputResponse(bufferStr);
                        _retornoSerial = message;
                        //MessageBox.Show(message, "Aviso");
                        break;
                    case OperationType.ReadInput:
                        message = PowerSupplyCommands.ReceivePowerSupplyReadInputResponse(buf[3], buf[4], buf[5], buf[6]);
                        _retornoSerial = message;
                        //MessageBox.Show(message, "Aviso");
                        break;
                    case OperationType.LockInput:
                        message = PowerSupplyCommands.ReceivePowerSupplyLockInputResponse(bufferStr);
                        _retornoSerial = message;
                        //MessageBox.Show(message, "Aviso");
                        break;
                    case OperationType.UnlockInput:
                        message = PowerSupplyCommands.ReceivePowerSupplyUnlockInputResponse(bufferStr);
                        _retornoSerial = message;
                        //MessageBox.Show(message, "Aviso");
                        break;
                    case OperationType.ReadOutput:
                        message = PowerSupplyCommands.ReceivePowerSupplyReadOutputResponse(buf[3], buf[4], buf[5], buf[6]);
                        _retornoSerial = message;
                        //MessageBox.Show(message, "Aviso");
                        break;
                    case OperationType.ActivateOutput:
                        message = PowerSupplyCommands.ReceivePowerSupplyActivateOutputResponse(bufferStr);
                        _retornoSerial = message;
                        //MessageBox.Show(message, "Aviso");
                        break;
                    case OperationType.DeactivateOutput:
                        message = PowerSupplyCommands.ReceivePowerSupplyDeactivateOutputResponse(bufferStr);
                        _retornoSerial = message;
                        //MessageBox.Show(message, "Aviso");
                        break;
                    default:
                        break;
                }

                //MessageBox.Show(_retornoSerial, "Aviso");

                SerialPort_Disconnect();
            }
            catch (Exception) { return; }
        }

        //criar funcao serial_send
        //switch com operacoes para envio do comando
        private void SerialPort_SendCommand(OperationType operation, string comport=null, int baud=0)
        {
            SerialPort_Disconnect();

            analysis.Operation = operation;

            string port;
            int baudrate;

            if (comport == null && baud == 0)
            {
                port = GetSelectedCOM();
                baudrate = GetSelecetdBaudrate();
            }
            else
            {
                port = comport;
                baudrate = baud;
            }

            SerialPort_Connect(port, baudrate, standardParity, standardDatabits, standardStopbits);

            byte[] bytes;

            switch (analysis.Operation)
            {
                case OperationType.SetInput:
                    bytes = PowerSupplyCommands.SetPowerSupplyInput(voltageInputTextBox.Text, currentInputTextBox.Text);
                    sPort.Write(bytes, 0, bytes.Length);
                    break;
                case OperationType.ReadInput:
                    bytes = PowerSupplyCommands.ReadPowerSupplyInput();
                    sPort.Write(bytes, 0, bytes.Length);
                    //MessageBox.Show("Comando de leitura de entrada enviado","teste");
                    break;
                case OperationType.LockInput:
                    bytes = PowerSupplyCommands.LockPowerSupplyInput();
                    sPort.Write(bytes, 0, bytes.Length);
                    break;
                case OperationType.UnlockInput:
                    bytes = PowerSupplyCommands.UnlockPowerSupplyInput();
                    sPort.Write(bytes, 0, bytes.Length);
                    break;
                case OperationType.ReadOutput:
                    bytes = PowerSupplyCommands.ReadPowerSupplyOutput();
                    sPort.Write(bytes, 0, bytes.Length);
                    break;
                case OperationType.ActivateOutput:
                    bytes = PowerSupplyCommands.ActivatePowerSupplyOutput();
                    sPort.Write(bytes, 0, bytes.Length);
                    break;
                case OperationType.DeactivateOutput:
                    bytes = PowerSupplyCommands.DeactivatePowerSupplyOutput();
                    sPort.Write(bytes, 0, bytes.Length);
                    break;
                default:
                    break;
            }


        }

        #endregion

        #region add items to comboboxes
        private void AddBaudrateSpeed()
        {
            baudrateComboBox.Items.AddRange(new object[] {
                "4800",
                "9600",
                "14400",
                "19200",
                "38400",
                "57600",
                "115200"
            });
            baudrateComboBox.SelectedIndex = 1;
        }

        private void RefreshAvailableComPorts()
        {
            comPortComboBox.Items.Clear();
            List<string> comportsInUse = new List<string>();

            foreach (Project p in projectList)
            {
                comportsInUse.Add(p.ComPort);
            }

            foreach (string s in SerialPort.GetPortNames())
            {
                if (!comportsInUse.Contains(s))
                {
                    comPortComboBox.Items.Add(s);
                }
            }

            if (comPortComboBox.Items.Count > 0)
            {
                comPortComboBox.SelectedIndex = 0;
            }
        }

        #endregion

        #region select slots
        private void slot1Button_Click(object sender, EventArgs e)
        {
            if (!controlPanel.Visible)
            {
                controlPanel.Show();
            }
            SelectedButtonColor(1);
            slotTitleLabel.Text = "Slot 1";
            ClearSlotControllers();
            RefreshAvailableComPorts();
            FillSlotProjectInfo();
        }

        private void slot2Button_Click(object sender, EventArgs e)
        {
            if (!controlPanel.Visible)
            {
                controlPanel.Show();
            }
            SelectedButtonColor(2);
            slotTitleLabel.Text = "Slot 2";
            ClearSlotControllers();
            RefreshAvailableComPorts();
            FillSlotProjectInfo();
        }

        private void slot3Button_Click(object sender, EventArgs e)
        {
            if (!controlPanel.Visible)
            {
                controlPanel.Show();
            }
            SelectedButtonColor(3);
            slotTitleLabel.Text = "Slot 3";
            ClearSlotControllers();
            RefreshAvailableComPorts();
            FillSlotProjectInfo();
        }

        private void slot4Button_Click(object sender, EventArgs e)
        {
            if (!controlPanel.Visible)
            {
                controlPanel.Show();
            }
            SelectedButtonColor(4);
            slotTitleLabel.Text = "Slot 4";
            ClearSlotControllers();
            RefreshAvailableComPorts();
            FillSlotProjectInfo();
        }

        private void slot5Button_Click(object sender, EventArgs e)
        {
            if (!controlPanel.Visible)
            {
                controlPanel.Show();
            }
            SelectedButtonColor(5);
            slotTitleLabel.Text = "Slot 5";
            ClearSlotControllers();
            RefreshAvailableComPorts();
            FillSlotProjectInfo();
        }

        private void SelectedButtonColor(int btn)
        {
            switch (btn)
            {
                case 1:
                    slot1Button.BackColor = Color.FromArgb(121, 121, 121);
                    slot2Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot3Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot4Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot5Button.BackColor = Color.FromArgb(64, 64, 64);
                    break;
                case 2:
                    slot1Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot2Button.BackColor = Color.FromArgb(121, 121, 121);
                    slot3Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot4Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot5Button.BackColor = Color.FromArgb(64, 64, 64);
                    break;
                case 3:
                    slot1Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot2Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot3Button.BackColor = Color.FromArgb(121, 121, 121);
                    slot4Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot5Button.BackColor = Color.FromArgb(64, 64, 64);
                    break;
                case 4:
                    slot1Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot2Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot3Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot4Button.BackColor = Color.FromArgb(121, 121, 121);
                    slot5Button.BackColor = Color.FromArgb(64, 64, 64);
                    break;
                case 5:
                    slot1Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot2Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot3Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot4Button.BackColor = Color.FromArgb(64, 64, 64);
                    slot5Button.BackColor = Color.FromArgb(121, 121, 121);
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void testConfigButton_Click(object sender, EventArgs e)
        {
            if (!testConfigBackgroundWorker.IsBusy)
            {
                try
                {
                    CheckSlotInUse();
                    CheckConfigFields();
                    testConfigBackgroundWorker.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void startTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                CheckSlotInUse();
                CheckConfigFields();
                CheckProjectInfoFields();

                addProjectBackgroundWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void stopTestButton_Click(object sender, EventArgs e)
        {
            string slot = slotTitleLabel.Text;
            Project project = CheckProjectRunning(slot);

            if (project == null)
            {
                MessageBox.Show($"No project running in {slot}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (project.Status != Status.Finished)
            {
                if (MessageBox.Show("Would you like to stop the running test?", "Running Test",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    project.Status = Status.Finished;
                    FillSlotProjectInfo();
                    GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                                    $"{project.Slot}: Testing cancelled.");
                }
            }
            else
            {
                MessageBox.Show($"Project test already stopped in {slot}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            string slot = slotTitleLabel.Text;
            Project project = CheckProjectRunning(slot);

            if (project == null)
            {
                MessageBox.Show($"No project running in {slot}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (project.Status != Status.Finished)
            {
                MessageBox.Show($"Testing not finished yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (project.Status == Status.Finished)
            {
                try
                {
                    string address = project.ExportMeasToExcel();
                    MessageBox.Show($"Export successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                                        $"{project.Slot}: Measurements exported to \"{address}\".");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            string slot = slotTitleLabel.Text;
            Project project = CheckProjectRunning(slot);

            if (project == null)
            {
                MessageBox.Show($"No project running in {slot}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (project.Status != Status.Finished)
            {
                MessageBox.Show($"Testing not finished yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (project.Status == Status.Finished)
            {
                if (MessageBox.Show("Would you like to clear this project info?\nAll unsaved data will be lost.", "Project Info",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    project.Status = Status.Finished;
                    projectList.Remove(project);
                    ClearSlotControllers();
                    GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                                    $"{project.Slot}: Project cleared.");
                }
            }
        }

        private void testConfigBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool _verificarExcecaoIndicada = false;

            try
            {
                Invoke((MethodInvoker)delegate{
                    this.UseWaitCursor = true;
                    testConfigButton.Enabled = false;
                });
                //checar se configuracoes estão corretas (conexão Serial funcionando?)
                //enviar comando de fonte unlock
                SerialPort_SendCommand(OperationType.UnlockInput);
                //await Task.Delay(_delay);
                Thread.Sleep(_delay);

                //enviar comando de configuração da fonte com tensão e corrente das text box
                SerialPort_SendCommand(OperationType.SetInput);
                Thread.Sleep(_delay);

                //ativar saída da fonte
                SerialPort_SendCommand(OperationType.ActivateOutput);
                Thread.Sleep(_delay);

                //ler input
                SerialPort_SendCommand(OperationType.ReadInput);
                Thread.Sleep(_delay);
            }
            catch (FormatException)
            {
                _verificarExcecaoIndicada = true;
                Invoke((MethodInvoker)delegate
                {
                    this.UseWaitCursor = false;
                    testConfigButton.Enabled = true;
                    MessageBox.Show("Invalid input values.\nAside from voltage and current input fields, please use only integer values.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
                testConfigBackgroundWorker.CancelAsync();
            }
            catch (Exception)
            {
                _verificarExcecaoIndicada = true;
                Invoke((MethodInvoker)delegate {
                    this.UseWaitCursor = false;
                    testConfigButton.Enabled = true;
                    MessageBox.Show("Configuration command could not be sent.\nPlease check the serial connection parameters.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
                testConfigBackgroundWorker.CancelAsync();
            }
            finally
            {
                Invoke((MethodInvoker)delegate {
                    this.UseWaitCursor = false;
                    testConfigButton.Enabled = true;
                });
                try
                {
                    sPort.Close();
                }
                catch (Exception)
                {
                    if (!_verificarExcecaoIndicada)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Select a COM Port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
                _verificarExcecaoIndicada = false;
            }

            if (testConfigBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        private void testConfigBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //confirmar configurações (messagebox)
            if (_retornoSerial != null && !e.Cancelled)
            {
                string[] inputValues = _retornoSerial.Split(';');
                UseWaitCursor = false;
                testConfigButton.Enabled = true;
                MessageBox.Show($"Configuration was successful!\n" +
                                $"Voltage: {inputValues[0]} V\tCurrent: {inputValues[1]} A",
                                "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UseWaitCursor = false;
                testConfigButton.Enabled = true;
                MessageBox.Show("Reading command error.\nNo response.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void addProjectBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool _adicionarExcecaoIndicada = false;

            try
            {
                Invoke((MethodInvoker)delegate {
                    this.UseWaitCursor = true;
                    startTestButton.Enabled = false;
                });

                string name = projectNameTextBox.Text;
                string slot = slotTitleLabel.Text;
                string comport = GetSelectedCOM();
                int baudrate = GetSelecetdBaudrate();
                TimeSpan interval = TimeSpan.FromMinutes(int.Parse(intervalTextBox.Text));
                TimeSpan testTime = TimeSpan.FromHours(int.Parse(testTimeTextBox.Text));
                string voltage = voltageInputTextBox.Text;
                string current = currentInputTextBox.Text;

                //checar se configurações estão corretas (conexão Serial funcionando?)
                //enviar comando de configuração da fonte com tensão e corrente das text box
                SerialPort_SendCommand(OperationType.SetInput);
                Thread.Sleep(_delay);

                //ativar saída da fonte
                SerialPort_SendCommand(OperationType.ActivateOutput);
                Thread.Sleep(_delay);

                //fonte lock
                SerialPort_SendCommand(OperationType.LockInput);
                Thread.Sleep(_delay);

                //ler input
                SerialPort_SendCommand(OperationType.ReadInput);
                Thread.Sleep(_delay);

                DateTime start = DateTime.Now;
                Project newProj = new Project(name, slot, comport, baudrate, start, testTime, interval, voltage, current);
                newProj.Status = Status.OnGoing;

                //ler saída da fonte
                SerialPort_SendCommand(OperationType.ReadOutput);
                Thread.Sleep(_delay);

                //Invoke((MethodInvoker)delegate
                //{
                //    MessageBox.Show(newProj.ComPort);
                //});

                //registrar leitura de saída
                if (_retornoSerial != null)
                {
                    string[] outputValues = _retornoSerial.Split(';');
                    newProj.VoltageMeas = outputValues[0];
                    newProj.CurrentMeas = outputValues[1];
                    //incluir primeira medida na lista meas
                    //newProj.AddNewMeas();
                    Meas newMeas = new Meas(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                                    newProj.VoltageMeas, newProj.CurrentMeas);
                    newProj.MeasList.Add(newMeas);
                    newProj.LastRegister = DateTime.Now;
                }
                else
                {
                    throw new ApplicationException("Reading command error.\nNo return.");
                }

                newProj.UpdateTimeLeft();
                projectList.Add(newProj);
            }
            catch (ApplicationException ex)
            {
                _adicionarExcecaoIndicada = true;
                Invoke((MethodInvoker)delegate
                {
                    this.UseWaitCursor = false;
                    startTestButton.Enabled = true;
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
                addProjectBackgroundWorker.CancelAsync();
            }
            catch (FormatException)
            {
                _adicionarExcecaoIndicada = true;
                Invoke((MethodInvoker)delegate
                {
                    this.UseWaitCursor = false;
                    startTestButton.Enabled = true;
                    MessageBox.Show("Invalid input.\nPlease enter only integers for test time and inteval.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
                addProjectBackgroundWorker.CancelAsync();
            }
            catch (Exception ex)
            {
                _adicionarExcecaoIndicada = true;
                Invoke((MethodInvoker)delegate
                {
                    this.UseWaitCursor = false;
                    startTestButton.Enabled = true;
                    //MessageBox.Show("Configuration command could not be sent.\nPlease check the serial connection parameters.",
                    //"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
                addProjectBackgroundWorker.CancelAsync();
            }
            finally
            {
                Invoke((MethodInvoker)delegate {
                    this.UseWaitCursor = false;
                    testConfigButton.Enabled = true;
                });
                try
                {
                    sPort.Close();
                }
                catch (Exception)
                {
                    if (!_adicionarExcecaoIndicada)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Select a COM Port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
                _adicionarExcecaoIndicada = false;
            }

            if (addProjectBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

        }

        private void addProjectBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //confirmar configurações (messagebox)
            if (!e.Cancelled)
            {
                UseWaitCursor = false;
                startTestButton.Enabled = true;
                FillSlotProjectInfo();

                GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    New project added to {slotTitleLabel.Text}.");
                MessageBox.Show("New project added successfully");
            }
            else
            {
                UseWaitCursor = false;
                startTestButton.Enabled = true;
                MessageBox.Show("Project could not be added.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void testMeasurementBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int maxProjCount = projectList.Count - 1;
                for (int i = 0; i <= maxProjCount; i++)
                {
                    updatingProject = projectList[i];

                    if (updatingProject.Status != Status.Finished)
                    {
                        //atualizar o tempo de teste (Regressivo)
                        updatingProject.UpdateTimeLeft();

                        //ler tensao e corrente de saida para registro
                        SerialPort_SendCommand(OperationType.ReadOutput, updatingProject.ComPort, updatingProject.Baudrate);
                        Thread.Sleep(_delay);

                        if (_retornoSerial != null)
                        {
                            string[] outputValues = _retornoSerial.Split(';');
                            updatingProject.VoltageMeas = outputValues[0];
                            updatingProject.CurrentMeas = outputValues[1];
                        }
                        else
                        {
                            continue;
                            throw new ApplicationException($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                                $"{updatingProject.Slot}: Reading command error. No return.");
                        }

                        //verificar os intervalos de atualização de cada processo
                        //realizar registro no processo somente se o tempo de intervalo (TempoIntervalo) for o mesmo da diferença do último registro (UltimoRegistro)
                        if (DateTime.Now.Subtract(updatingProject.LastRegister) >= updatingProject.RegisterInterval)
                        {
                            Meas newMeas = new Meas(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                                        updatingProject.VoltageMeas, updatingProject.CurrentMeas);
                            updatingProject.MeasList.Add(newMeas);
                            Invoke((MethodInvoker)delegate
                            {
                                measDataGridView.DataSource = null;
                                FillSlotProjectInfo();
                            });
                            updatingProject.LastRegister = DateTime.Now;
                        }

                        if (updatingProject.TimeLeft <= TimeSpan.Zero)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                                    $"{updatingProject.Slot}: Testing complete!");
                            });

                            updatingProject.Status = Status.Finished;

                            //desativar saída
                            SerialPort_SendCommand(OperationType.DeactivateOutput, updatingProject.ComPort, updatingProject.Baudrate);
                            Thread.Sleep(_delay);
                            //destravar controlador
                            SerialPort_SendCommand(OperationType.UnlockInput, updatingProject.ComPort, updatingProject.Baudrate);
                            Thread.Sleep(_delay);

                            Invoke((MethodInvoker)delegate
                            {
                                measDataGridView.DataSource = null;
                                FillSlotProjectInfo();
                            });
                        }
                    }
                    else
                    {
                        continue;
                    }

                    if (updatingProject!=null)
                    {
                        updatingProject = null;
                    }
                }

            }
            catch (ApplicationException ex)
            {
                if (updatingProject.Status != Status.GeneralError)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        GeneralLogListBox.Items.Add(ex.Message);
                    });
                    updatingProject.Status = Status.GeneralError;
                }
            }
            catch (System.InvalidOperationException exc)
            {
                if (exc.ToString().Contains("The port is closed"))
                {
                    try
                    {
                        if (updatingProject.Status != Status.ConnectionError)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                                    $"{updatingProject.Slot}: Communication error. Please check the serial connection.");
                            });
                            updatingProject.Status = Status.ConnectionError;
                            //updatingProject.VoltageMeas = "ERR";
                            //updatingProject.CurrentMeas = "ERR";
                        }
                    }
                    catch (NullReferenceException exce)
                    {
                        if (exce.ToString().Contains("Object reference not set"))
                        {
                            //do nothing
                        }
                        else
                        {
                            if (updatingProject.Status != Status.GeneralError)
                            {
                                Invoke((MethodInvoker)delegate
                                {
                                    GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                                        $"{updatingProject.Slot}: {exce.Message}");
                                });
                                updatingProject.Status = Status.GeneralError;
                            }
                        }
                    }
                }
                else if (exc.ToString().Contains("Index was out of range"))
                {
                    //do nothing
                }
                else
                {
                    if (updatingProject.Status != Status.GeneralError)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                                $"{updatingProject.Slot}: {exc.Message}");
                        });
                        updatingProject.Status = Status.GeneralError;
                    }
                }
            }
            catch (ArgumentOutOfRangeException exc)
            {
                if (exc.ToString().Contains("Index was out of range"))
                {
                    //do nothing
                }
                else
                {
                    if (updatingProject.Status != Status.GeneralError)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                                $"{updatingProject.Slot}: {exc.Message}");
                        });
                        updatingProject.Status = Status.GeneralError;
                    }
                }
            }
            catch (Exception exc)
            {
                if (updatingProject.Status != Status.GeneralError)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        GeneralLogListBox.Items.Add($"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}]    " +
                            $"{updatingProject.Slot}: {exc.Message}");
                    });
                    updatingProject.Status = Status.GeneralError;
                }
            }
            finally
            {
                if (updatingProject != null)
                {
                    //updatingProject.Status = Status.OnGoing;
                    updatingProject = null;
                }
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (!testMeasurementBackgroundWorker.IsBusy)
            {
                testMeasurementBackgroundWorker.RunWorkerAsync();
            }
        }

        private void CheckConfigFields()
        {
            //formato de tensao e corrente (99,99 ou 99.99)
            //verificar incidencia de ',' ou '.'
            if (!((voltageInputTextBox.Text.Contains(".") || voltageInputTextBox.Text.Contains(",")) &&
                (currentInputTextBox.Text.Contains(".") || currentInputTextBox.Text.Contains(","))))
            {
                throw new ApplicationException("Accepted voltage and current values: 0.00-99.99 or 0,00-99,99.");
            }

            string tensaoReplace = voltageInputTextBox.Text.Replace(",", ".");
            string correnteReplace = currentInputTextBox.Text.Replace(",", ".");

            string[] tensaoSplit = tensaoReplace.Split('.');
            string[] correnteSplit = correnteReplace.Split('.');

            if (tensaoSplit[1].Length < 1 || correnteSplit[1].Length < 1)
            {
                throw new ApplicationException("Accepted voltage and current values: 0.00-99.99 or 0,00-99,99.");
            }

            if (tensaoSplit[0].Length < 1)
            {
                tensaoSplit[0] = "0";
                voltageInputTextBox.Text = $"{tensaoSplit[0]}.{tensaoSplit[1]}";
            }

            if (correnteSplit[0].Length < 1)
            {
                correnteSplit[0] = "0";
                currentInputTextBox.Text = $"{correnteSplit[0]}.{correnteSplit[1]}";
            }

            if (tensaoSplit[1].Length == 1)
            {
                voltageInputTextBox.Text += "0";
            }
            else if (tensaoSplit[1].Length > 2)
            {
                voltageInputTextBox.Text = $"{tensaoSplit[0]}.{tensaoSplit[1][0]}{tensaoSplit[1][1]}";
            }

            if (correnteSplit[1].Length == 1)
            {
                currentInputTextBox.Text += "0";
            }
            else if (correnteSplit[1].Length > 2)
            {
                currentInputTextBox.Text = $"{correnteSplit[0]}.{correnteSplit[1][0]}{correnteSplit[1][1]}";
            }
        }

        private void CheckProjectInfoFields()
        {
            if (projectNameTextBox.Text.Length > 60)
            {
                throw new ApplicationException("Too long project name.");
            }

            if (projectNameTextBox.Text == string.Empty)
            {
                throw new ApplicationException("Project name cannot be empty.");
            }

            if (testTimeTextBox.Text == string.Empty)
            {
                throw new ApplicationException("Test time cannot be empty.");
            }

            if (intervalTextBox.Text == string.Empty)
            {
                throw new ApplicationException("Test interval time cannot be empty.");
            }

            //tempo 1-200 h
            if (int.Parse(testTimeTextBox.Text) < 1 || int.Parse(testTimeTextBox.Text) > 200)
            {
                throw new ApplicationException("Insert a test time between 1 and 200 hours.");
            }

            //intervalo 1-180 min
            if (int.Parse(intervalTextBox.Text) < 1 || int.Parse(intervalTextBox.Text) > 180 || intervalTextBox.Text == string.Empty)
            {
                throw new ApplicationException("Insert an interval time between 1 and 180 minutes");
            }
        }

        private void CheckSlotInUse()
        {
            string name = projectNameTextBox.Text;
            string slot = slotTitleLabel.Text;
            string comport = comPortComboBox.Text;

            foreach (Project p in projectList)
            {
                if (p.Slot == slot)
                {
                    throw new ApplicationException("This Slot is already in use.");
                }

                if (p.Name == name)
                {
                    throw new ApplicationException("A project with the same name is already running.");
                }

                if (p.ComPort == comport)
                {
                    throw new ApplicationException("Chosen Com Port is already in use.");
                }

            }
        }

        private void FillSlotProjectInfo()
        {
            foreach (Project project in projectList)
            {
                if (project.Slot == slotTitleLabel.Text)
                {
                    projectNameTextBox.Text = project.Name;
                    testTimeTextBox.Text = project.TestTime.TotalHours.ToString();
                    intervalTextBox.Text = project.RegisterInterval.TotalMinutes.ToString();
                    //corrigir comport
                    comPortComboBox.Text = project.ComPort.ToString();
                    baudrateComboBox.Text = project.Baudrate.ToString();
                    voltageInputTextBox.Text = project.VoltageConfig;
                    currentInputTextBox.Text = project.CurrentConfig;
                    startDateLabel.Text = project.StartTime.ToString("dd-MM-yyyy\nHH:mm");
                    timeLeftLabel.Text = string.Format("{0} days\n{1} hours\n{2} minutes", project.TimeLeft.Days, project.TimeLeft.Hours, project.TimeLeft.Minutes);
                    if (project.VoltageMeas.Length == 4)
                    {
                        voltageMeasLabel.Text = "0" + project.VoltageMeas + " V";
                    }
                    else
                    {
                        voltageMeasLabel.Text = project.VoltageMeas + " V";
                    }
                    if (project.CurrentMeas.Length == 4)
                    {
                        currentMeasLabel.Text = "0" + project.CurrentMeas + " A";
                    }
                    else
                    {
                        currentMeasLabel.Text = project.CurrentMeas + " A";
                    }

                    measDataGridView.DataSource = project.MeasList;
                    measDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    measDataGridView.ReadOnly = true;
                    measDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    measDataGridView.RowHeadersVisible = false;
                    measDataGridView.EnableHeadersVisualStyles = false;
                    //measDataGridView.Columns["Date"].Width = 50; 

                    if (project.Status != Status.Finished)
                    {
                        projectNameTextBox.Enabled = false;
                        testTimeTextBox.Enabled = false;
                        intervalTextBox.Enabled = false;
                        comPortComboBox.Enabled = false;
                        baudrateComboBox.Enabled = false;
                        voltageInputTextBox.Enabled = false;
                        currentInputTextBox.Enabled = false;
                    }
                    else
                    {
                        projectNameTextBox.Enabled = true;
                        testTimeTextBox.Enabled = true;
                        intervalTextBox.Enabled = true;
                        comPortComboBox.Enabled = true;
                        baudrateComboBox.Enabled = true;
                        voltageInputTextBox.Enabled = true;
                        currentInputTextBox.Enabled = true;
                    }
                }
            }
        }

        private void ClearSlotControllers()
        {
            projectNameTextBox.Text = string.Empty;
            testTimeTextBox.Text = stdTime.ToString();
            intervalTextBox.Text = stdInterval.ToString();
            comPortComboBox.Items.Clear();
            //baudrateComboBox.Items.Clear();
            voltageInputTextBox.Text = string.Empty;
            currentInputTextBox.Text = string.Empty;
            startDateLabel.Text = "--/--/----\n--:--";
            timeLeftLabel.Text = "-- days\n-- hours\n-- minutes";
            voltageMeasLabel.Text = " - -.- - V";
            currentMeasLabel.Text = " - -.- -  A";
            measDataGridView.DataSource = null;

            projectNameTextBox.Enabled = true;
            testTimeTextBox.Enabled = true;
            intervalTextBox.Enabled = true;
            comPortComboBox.Enabled = true;
            baudrateComboBox.Enabled = true;
            voltageInputTextBox.Enabled = true;
            currentInputTextBox.Enabled = true;
        }

        private Project CheckProjectRunning(string slot)
        {
            Project project = null;

            foreach (Project p in projectList)
            {
                if (p.Slot == slot)
                {
                    project = p;
                    break;
                }
            }

            return project;
        }
    }
}
