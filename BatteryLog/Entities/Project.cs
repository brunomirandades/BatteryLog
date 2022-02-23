using BatteryLog.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryLog.Entities
{
    class Project
    {
        public string Name { get; set; }
        public string Slot { get; set; }
        public string ComPort { get; set; }
        public int Baudrate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime LastRegister { get; set; }
        public TimeSpan TestTime { get; set; }
        public TimeSpan TimeLeft { get; set; }
        public TimeSpan RegisterInterval { get; set; }
        public string VoltageConfig { get; set; }
        public string CurrentConfig { get; set; }
        public string VoltageMeas { get; set; }
        public string CurrentMeas { get; set; }
        public string RegisterFile { get; set; }
        public Status Status { get; set; } = Status.Idle;
        public List<Meas> MeasList { get; set; } = new List<Meas>();

        public Project(string name, string slot, string comport, int baudrate, DateTime start, TimeSpan time, TimeSpan interval,
                        string voltage, string current)
        {
            Name = name;
            Slot = slot;
            ComPort = comport;
            Baudrate = baudrate;
            StartTime = start;
            TestTime = time;
            RegisterInterval = interval;
            VoltageConfig = voltage;
            CurrentConfig = current;
        }

        public void UpdateTimeLeft()
        {
            TimeSpan diff = DateTime.Now.Subtract(this.StartTime);
            this.TimeLeft = this.TestTime.Subtract(diff);
        }

        //gerar doc excel com header e medidas
        public string ExportMeasToExcel()
        {
            InsertMeasInFile();
            
            return RegisterFile;
        }

        //funcao para gerar formulário
        public void GenerateFile()
        {
            string outputDir = @"C:\BatteryLog_output\" + Slot;
            Directory.CreateDirectory(outputDir);

            string outputFile = outputDir
                                    + @"\"
                                    + Name
                                    + "_"
                                    + StartTime.ToString("dd-MM-yyyy")
                                    + "_"
                                    + StartTime.ToString("HH-mm-ss")
                                    + ".csv";
            RegisterFile = outputFile;

            //configurar header:
            using (StreamWriter sw = File.AppendText(outputFile))
            {
                //numero do processo e numero do ese
                sw.WriteLine("Project;" + Name);
                //armario e posicao
                sw.WriteLine("Slot;" + Slot);
                //porta COM e inicio
                sw.WriteLine("COM;" + ComPort + ";;Start;" + StartTime.ToString("dd-MM-yyyy HH:mm:ss"));
                //tempo total de teste configurado
                sw.WriteLine("Test time;" +
                              string.Format("{0} hour(s)", TestTime.TotalHours) +
                              ";;Interval;" +
                              string.Format("{0} minute(s)", RegisterInterval.TotalMinutes));
                //tensão e corrente configuradas
                sw.WriteLine($"Configured Voltage;{VoltageConfig}V;;" +
                             $"Configured Current;{CurrentConfig}A;");

                sw.WriteLine();
                sw.WriteLine();

                //gerar colunas: data, hora, tensão medida, corrente medida, observações - quando houver alteração na configuração de tensão e corrente (input)
                //indicar quando houve interrupção de medidas (ConexaoOk = false)
                sw.WriteLine("Date;Hour;Measured Voltage;Measured Current;");
            }
        }

        //adicionar dados no formulario com observacao
        public void InsertMeasInFile()
        {

            //verificar se o form existe, caso não, criar
            if (!File.Exists(this.RegisterFile))
            {
                this.GenerateFile();
            }

            //verificar se o form se encontra aberto e fechar caso positivo
            this.CheckFileOpen();

            //inserir data, hora, tensão medida, corrente medida
            //inserir observação se houver
            using (StreamWriter sw = File.AppendText(RegisterFile))
            {
                foreach (Meas meas in MeasList)
                {
                    sw.WriteLine(meas.Date +
                              ";" +
                              meas.Hour +
                              ";" +
                              meas.Voltage +
                              ";" +
                              meas.Current +
                              ";");
                }
            }
        }

        //fechar formulario de processo se estiver aberto
        public void CheckFileOpen()
        {
            string[] splitDir = RegisterFile.Split('\\');
            string usedFile = splitDir[3];

            foreach (var process in Process.GetProcesses())
            {
                if (process.MainWindowTitle.Contains(usedFile))
                {
                    process.Kill();
                    break;
                }
            }
        }
    }


}
