using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Windows.Forms;
using System.Globalization;

namespace Entities
{
    public static class PowerSupplyCommands
    {
        //conversao Hex para Dec
        public static string ConvertHexToDec(byte value1, byte value2)
        {
            string value1Hex = value1.ToString("X");
            string value2Hex = value2.ToString("X");
            //if (Convert.ToInt32(value2Hex, 16) <= 9 && Convert.ToInt32(value2Hex, 16) >= 0)
            //{
            //    value1Hex += "0";
            //}
            if (value2Hex.Length == 1)
            {
                value2Hex = "0" + value2Hex;
            }
            string fullValueHex = value1Hex + value2Hex;
            double valueDec = Convert.ToInt32(fullValueHex, 16);
            valueDec /= 100;
            return valueDec.ToString("F2", CultureInfo.InvariantCulture);
        }

        //gerar comando de configuracao de tensao e corrente
        private static byte[] GenerateInputCode(int voltage, int current)
        {
            //01 - slave address
            //10 - function code
            //00 00 - register starting address
            //00 02 - registers to write to
            //04 - bytes to write
            //XX XX -voltage
            //XX XX -current
            //XX XX -CRC code

            byte slaveAddress = 0x1;
            byte functionCode = 0x10;
            ushort startAddress = 0x0;
            ushort numberOfPoints = 0x2;
            byte bytesToWrite = 0x4;
            ushort voltageToSet = (ushort)voltage;
            ushort currentToSet = (ushort)current;

            List<byte> entryCode = new List<byte>();

            entryCode.Add(slaveAddress);
            entryCode.Add(functionCode);
            entryCode.Add((byte)(startAddress >> 8));
            entryCode.Add((byte)startAddress);
            entryCode.Add((byte)(numberOfPoints >> 8));
            entryCode.Add((byte)numberOfPoints);
            entryCode.Add(bytesToWrite);
            entryCode.Add((byte)(voltageToSet >> 8));
            entryCode.Add((byte)voltageToSet);
            entryCode.Add((byte)(currentToSet >> 8));
            entryCode.Add((byte)currentToSet);

            int entryCodeSize = entryCode.Count;

            byte[] frame = new byte[entryCodeSize + 2];

            for (int i = 0; i <= entryCodeSize - 1; i++)
            {
                frame[i] = entryCode[i];
            }

            byte[] checkSum = CRC16(frame);
            frame[entryCodeSize] = checkSum[0];
            frame[entryCodeSize + 1] = checkSum[1];

            return frame;
        }

        //calculo do CRC
        private static byte[] CRC16(byte[] data)
        {
            byte[] checkSum = new byte[2];
            ushort reg_crc = 0XFFFF;

            for (int i = 0; i < data.Length - 2; i++)
            {
                reg_crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((reg_crc & 0x01) == 1)
                    {
                        reg_crc = (ushort)((reg_crc >> 1) ^ 0xA001);
                    }
                    else
                    {
                        reg_crc = (ushort)(reg_crc >> 1);
                    }
                }
            }
            checkSum[1] = (byte)((reg_crc >> 8) & 0xFF);
            checkSum[0] = (byte)((reg_crc & 0xFF));
            return checkSum;
        }

        //comandos da fonte:
        //configurar tensao e corrente
        public static byte[] SetPowerSupplyInput(string voltageTxt, string currentTxt)
        {

            string voltTxtBoxValue = voltageTxt.Replace(",", ".");
            string amperTxtBoxValue = currentTxt.Replace(",", ".");

            double inputSetVoltage = Double.Parse(voltTxtBoxValue, CultureInfo.InvariantCulture);
            double inputSetCurrent = Double.Parse(amperTxtBoxValue, CultureInfo.InvariantCulture);

            if ((inputSetVoltage > 21.00 || inputSetVoltage < 00.00) || (inputSetCurrent > 15.00 || inputSetCurrent < 00.00))
            {
                throw new ApplicationException("Valores de configuração aceitos: " +
                    "\nTensão: 00.00 V - 21.00 V." +
                    "\nCorrente: 00.00 A - 15.00 A.");
            }

            inputSetVoltage *= 100;
            inputSetCurrent *= 100;

            int voltage = Convert.ToInt32(inputSetVoltage);
            int current = Convert.ToInt32(inputSetCurrent);

            byte[] command = GenerateInputCode(voltage, current);

            return command;
        }

        //ler entrada
        public static byte[] ReadPowerSupplyInput()
        {
            String data = "01 03 00 00 00 02 c4 0b"; //read input

            byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex
            return bytes;
        }

        //ler saida
        public static byte[] ReadPowerSupplyOutput()
        {
            String data = "01 03 00 02 00 02 65 cb"; //read output

            byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex

            return bytes;
        }

        //lock
        public static byte[] LockPowerSupplyInput()
        {
            String data = "01 10 00 06 00 01 02 00 01 67 f6"; //lock input

            byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex

            return bytes;
        }

        //unlock
        public static byte[] UnlockPowerSupplyInput()
        {
            String data = "01 10 00 06 00 01 02 00 00 a6 36"; //unlock input

            byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex
            return bytes;
        }

        //ativar saida
        public static byte[] ActivatePowerSupplyOutput()
        {
            String data = "01 10 00 09 00 01 02 00 01 67 09"; //output on

            byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex

            return bytes;
        }

        //desativar saida
        public static byte[] DeactivatePowerSupplyOutput()
        {
            String data = "01 10 00 09 00 01 02 00 00 a6 c9"; //output off

            byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex

            return bytes;
        }

        //respostas para o event handler de leitura da serial:
        //configurar tensao e corrente
        public static string ReceivePowerSupplySetInputResponse(string bufferString)
        {
            //compare the buffer string with the standard response to confirm operation
            string message = ""; //
            string standardResponse = "1 16 0 0 0 2 65 200";
            if (bufferString == standardResponse)
            {
                message = "Entrada configurada com sucesso";
            }
            else { throw new ApplicationException("Entrada não pode ser configurada."); }
            return message;
        }

        //ler saida
        public static string ReceivePowerSupplyReadOutputResponse(byte voltageFirstHalf, byte voltageSecondHalf, byte currentFirstHalf, byte currentSecondHalf)
        {
            //convert from hex and concatenate the indexes: 2 and 3 (voltage), 4 and 5 (current) from the buffer byte array
            string message = "";
            string outputVoltage = ConvertHexToDec(voltageFirstHalf, voltageSecondHalf);
            string outputCurrent = ConvertHexToDec(currentFirstHalf, currentSecondHalf);
            message = $"{outputVoltage};{outputCurrent}";
            return message;
        }

        //ler entrada
        public static string ReceivePowerSupplyReadInputResponse(byte voltageFirstHalf, byte voltageSecondHalf, byte currentFirstHalf, byte currentSecondHalf)
        {
            //convert from hex and concatenate the indexes: 3 and 4 (voltage), 5 and 6 (current) from the buffer byte array
            string message = "";
            string inputVoltage = ConvertHexToDec(voltageFirstHalf, voltageSecondHalf);
            string inputCurrent = ConvertHexToDec(currentFirstHalf, currentSecondHalf);
            message = $"{inputVoltage};{inputCurrent}";
            return message;
        }

        //lock
        public static string ReceivePowerSupplyLockInputResponse(string bufferString)
        {
            //compare the buffer string with the standard response to confirm operation
            string message = ""; //
            string standardResponse = "1 16 0 6 0 1 225 200";
            if (bufferString == standardResponse)
            {
                message = "Entrada travada.";
            }
            else { throw new ApplicationException("Entrada não pode ser travada."); }
            return message;
        }

        //unlock
        public static string ReceivePowerSupplyUnlockInputResponse(string bufferString)
        {
            //compare the buffer string with the standard response to confirm operation
            string message = ""; //
            string standardResponse = "1 16 0 6 0 1 225 200";
            if (bufferString == standardResponse)
            {
                message = "Entrada destravada.";
            }
            else { throw new ApplicationException("Entrada não pode ser destravada."); }
            return message;
        }

        //ativar saida
        public static string ReceivePowerSupplyActivateOutputResponse(string bufferString)
        {
            //compare the buffer string with the standard response to confirm operation
            string message = ""; //
            string standardResponse = "1 16 0 9 0 1 209 203";
            if (bufferString == standardResponse)
            {
                message = "Saída ativada.";
            }
            else { throw new ApplicationException("Saída não pode ser ativada."); }
            return message;
        }

        //desativar saida
        public static string ReceivePowerSupplyDeactivateOutputResponse(string bufferString)
        {
            //compare the buffer string with the standard response to confirm operation
            string message = ""; //
            string standardResponse = "1 16 0 9 0 1 209 203";
            if (bufferString == standardResponse)
            {
                message = "Saída desativada.";
            }
            else { throw new ApplicationException("Saída não pode ser desativada."); }
            return message;
        }
    }
}
