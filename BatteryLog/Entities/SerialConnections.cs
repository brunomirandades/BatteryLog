using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace Entities
{
    public static class SerialConnections
    {
        public static void Connect(SerialPort sport, String port, int baudrate,
            Parity parity, int databits, StopBits stopbits, EventHandler eventHandler)
        {
            try
            {
                sport = new SerialPort(port, baudrate, parity, databits, stopbits);
                sport.ReadTimeout = 500;
                sport.Close();
                sport.Open();
                sport.DataReceived += new SerialDataReceivedEventHandler(eventHandler); //set correct event handler
            }
            catch (Exception)
            {
                MessageBox.Show("Problema ao abrir porta COM.\nVeirifique as conexões e parâmetros.", "Erro!");
            }
        }

        public static void Disconnect(SerialPort sport)
        {
            try
            {
                if (sport.IsOpen)
                {
                    sport.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problema ao fechar porta COM.\nA porta pode estar ocupada.", "Erro!");
            }
        }

        //comandos da fonte:
            //configurar tensao e corrente
            //ler saida
            //ler entrada
            //lock
            //unlock
            //ativar saida
            //desativar saida

        //respostas para o event handler de leitura da serial:
            //configurar tensao e corrente
            //ler saida
            //ler entrada
            //lock
            //unlock
            //ativar saida
            //desativar saida
    }
}
