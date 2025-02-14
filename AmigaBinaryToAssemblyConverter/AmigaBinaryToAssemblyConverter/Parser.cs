using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace BinToAssembly
{
    public class Parser
    {
        private readonly int startAddress = 0;
        private Dictionary<string, string[]> dataStatements = new Dictionary<string, string[]>();

        private readonly string graphicsLibrary = "graphics.library";

        /// <summary>
        ///
        /// </summary>
        public byte[] LoadBinaryData(string fileName)
        {
            try
            {
                return File.ReadAllBytes(fileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error occurred whilst loading data ", exception.Message);
                return new byte[0];
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void ParseFileContent(
            byte[] data,
            PopulateOpCodeList populateOpCodeList,
            TextBox textBox,
            ref List<string> lineNumbers,
            ref List<string> code
            )
        {
            int start = -10;
            string converted = Encoding.UTF8.GetString(data, 0, data.Length);
            if (converted.Contains(graphicsLibrary))
            {
                DialogResult result = MessageBox.Show("The text `graphics.library` found do\n you want to convert this to data?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    start = converted.IndexOf(graphicsLibrary);
                }
            }
            textBox.Clear();
            int filePosition = 0;
            while (filePosition < data.Length - 4)
            {
                int firstByte = data[filePosition];
                int secondByte = data[filePosition + 1];

                // lookup the first 4 bits of each byte (Nybble)
                int byteOne = data[filePosition] << 8;
                int opCode = byteOne + data[filePosition + 1];
                int lineNumber = startAddress + filePosition;
                lineNumbers.Add(lineNumber.ToString("X8"));
                string line = (startAddress + filePosition).ToString("X8");
                line += " " + opCode.ToString("X4");
                int pc = startAddress + filePosition;
                bool found = false;

                // Get the Opcode object
                var oc = populateOpCodeList.GetOpCode(firstByte.ToString("X2"), secondByte.ToString("X2"));

                if (filePosition == start || filePosition == start + 1)
                {
                    filePosition = filePosition % 2 == 0 ? filePosition : filePosition + 1;
                    filePosition = ConvertDataToByte(filePosition, out line, out oc);
                }

                if (oc != null)
                {
                    ConvertToAssembly(oc, ref line, ref filePosition, data, lineNumber, pc, ref dataStatements);
                    found = true;
                }

                code.Add(line);
                if (!found)
                {
                    filePosition += 2;
                }
            }
            // Use a monospaced font
            textBox.Font = new Font(FontFamily.GenericMonospace, textBox.Font.Size);
            textBox.Lines = code.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        private int ConvertDataToByte(int filePosition, out string line, out dynamic oc)
        {
            line = (startAddress + filePosition).ToString("X8") + "                         DC.B '" + graphicsLibrary + "'";
            oc = null;
            filePosition += graphicsLibrary.Length;
            return filePosition;
        }

        /// <summary>
        ///
        /// </summary>
        private void ConvertDataToWords()
        {
            // TODO
        }

        /// <summary>
        ///
        /// </summary>
        public void ConvertToAssembly(
            dynamic oc,
            ref string line,
            ref int filePosition,
            byte[] binaryFileData,
            int? lineNumber,
            int pc,
            ref Dictionary<string, string[]> dataStatements
            )
        {
            switch (oc.Code)
            {
                case "0000": // OR
                case "0001":
                case "0002":
                case "0003":
                case "0004":
                case "0005":
                case "0007":
                case "0008":
                case "0010":
                case "0014":
                case "0015":
                case "0016":
                case "0018":
                case "0020":
                case "0028":
                case "0034":
                case "0040":
                case "0048":
                case "006F":
                case "0079":
                case "0092":
                case "0096":
                case "00B1":
                case "00B3":
                case "00B4":
                case "00B5":
                case "00B6":
                case "00B7":
                case "00B8":
                case "00E0":
                case "00E2":
                case "00E4":
                case "00E6":
                case "00E8":
                case "00EC":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "6600": // BNE
                case "66CA":
                case "66CE":
                case "66F2":
                case "66F6":
                case "670A": // BEQ
                case "6772":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "6000": // BRA
                case "6008":
                case "60EC":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "51C8": // DBF
                case "51CA":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "4E75": // RTS
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "C3FC":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "0600": // ADD
                case "0611":
                case "5239":
                case "5240":
                case "5243":
                case "5261":
                case "544B":
                case "5480":
                case "5C4B":
                case "D0FC":
                case "D27C":
                case "D2FC":
                case "D5C1":
                case "D67C":
                case "DE46":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "4A11":
                case "4A13":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                //case "6000":
                //    line += oc.Detail(ref filePosition, binaryFileData);
                //    break;
                case "0A00": // EOR
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "E218": // ROR
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "0041": // MOVE
                case "0042":
                case "0043":
                case "0044":
                case "0046":
                case "0047":
                case "1039":
                case "1200":
                case "1211":
                case "1219":
                case "1281":
                case "12E9":
                case "1E3C":
                case "13D1":
                case "13FC":
                case "1683":
                case "2020":
                case "2039":
                case "2079":
                case "203C":
                case "207A":
                case "20B8":
                case "2239":
                case "223C":
                case "2240":
                case "23C0":
                case "217C":
                case "2209":
                case "2279":
                case "227A":
                case "23C8":
                case "23C9":
                case "23E9":
                case "23FC":
                case "267A":
                case "2829":
                case "289A":
                case "296A":
                case "2B48":
                case "2C78":
                case "2C79":
                case "2D7A":
                case "303C":
                case "30C1":
                case "30C3":
                case "30FC":
                case "317C":
                case "323C":

                case "32DB":

                case "33D2":
                case "33EE":
                case "33F0":
                case "33FC":
                case "3412":
                case "3481":
                case "34EA":
                case "3607":
                case "3613":
                case "363C":
                case "3681":
                case "3482":
                case "38DD":
                case "3B7C":
                case "3C3C":

                case "3D01":
                case "3F01":

                case "3D7A":
                case "3D7C":
                case "48E7":
                case "4CDF":
                case "7000":
                case "7450":
                case "2E6C":
                case "7261":
                case "7279":
                case "7665":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "41F9": // LEA
                case "43F9":
                case "43FA":
                case "45F9":
                case "47F9":
                case "49EC":
                case "49F9":
                case "4BF9":
                case "4DF9":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "4201":
                case "4240": // CLR
                case "4268":
                case "4278":
                case "4280":
                case "4281":
                case "42A8":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "0828":
                case "0839":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "6700": // BEQ
                case "6701": // BEQ
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "0401": // SUB
                case "0439":
                case "0479":
                case "0679":
                case "5761":
                case "927C":
                case "92FC":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "0C00": // CMP
                case "0C2D":
                case "0C39":
                case "0C40":
                case "B21B":
                case "B240":
                case "B3FC":
                case "B5FC":
                case "B7FC":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "6100": // BSR
                case "6170":
                case "6869":
                case "6373":
                case "6974":
                case "6D6F": // BGE
                case "6C6F":
                case "6F70":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "4EAE":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "4446":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "4E71": // NOP
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "E289": // LSR
                case "EE49":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "4841": // SWAP
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                //case "0008":
                case "0033": // ILLEGAL
                             //                case "00E0":
                case "0184":
                case "0888":
                case "0999":
                case "0BBB":
                case "0CCC":
                case "0FFF":
                case "4143":
                case "436F":
                case "444D":
                case "4F4E":
                case "494E":
                case "7331":
                case "7332":
                case "735C":
                case "7374":
                case "7365":
                case "7565":
                case "7761":
                case "FFFF":
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;

                case "001A": // To sort & put into order ...
                case "008E":
                case "00D0":
                case "00FF":
                case "0100": // BTST
                case "0102": // BTST
                case "0104": // BTST
                case "0105": // BTST
                case "0106":
                case "0108":
                case "010A":
                case "0111":
                case "0146":
                case "0154":
                case "0160":
                case "0176":
                case "0180": // BCLR
                case "0182": // BCLR
                case "0186": // BCLR
                case "0188": // MOVEP
                case "018A": // MOVEP
                case "018C": // MOVEP
                case "018E": // MOVEP
                case "0190": // BCLR
                case "0198": // BCLR
                case "01B0": // BCLR
                case "01C0":
                case "01D2":
                case "01D4":
                case "01D8":
                case "01E2":
                case "01FC":
                case "01FE":
                case "0200":
                case "020A":
                case "0211":
                case "0222":
                case "0300":
                case "0311":
                case "0333":
                case "0338":
                case "0349": // MOVEP
                case "0400":
                case "040A":
                case "0422":
                case "0444":
                case "045A": // SUB
                case "0500":
                case "050B":
                case "0510":
                case "0533":
                case "0555":
                case "060C":
                case "0620":
                case "0644":
                case "0666":
                case "066B": // ADD
                case "070D":
                case "0730":
                case "0755":
                case "0777":
                case "07A4":
                case "07A8":
                case "07AA":
                case "07AC":
                case "0800":
                case "0801":
                case "0840":
                case "0866":
                case "0879": // BCHG
                case "089D": // BCLR
                case "0909":
                case "0920":
                case "0948":
                case "0950":
                case "0977":
                case "09D8":
                case "09FC":
                case "0A01":
                case "0A28":
                case "0A2C":
                case "0A30":
                case "0A34":
                case "0A38":
                case "0A3C":
                case "0A40":
                case "0A54":
                case "0A58":
                case "0A5C":
                case "0A60":
                case "0A64":
                case "0A68":
                case "0A6C":
                case "0A74":
                case "0A88":
                case "0AAA":
                case "0B00":
                case "0B70":
                case "0C79":
                case "0C80":
                case "0D00":
                case "0D90":
                case "0DDD":
                case "0E00":
                case "0EA0":
                case "0ECA":
                case "0EEE":
                case "0F00":
                case "0FB0":
                case "0FC0":
                case "0FD0":
                case "1000":
                case "101A":
                case "12D8":
                case "1C01":
                case "1CCC":
                case "1E01":
                case "2000":
                case "2001":
                case "2009":
                case "2041":
                case "2042":
                case "2043":
                case "2044":
                case "2045":
                case "2046":
                case "2047":
                case "2048":
                case "2049":
                case "204A":
                case "204B":
                case "204C":
                case "204D":
                case "204E":
                case "204F":
                case "2050":
                case "2052":
                case "2053":
                case "2054":
                case "2055":
                case "2056":
                case "2057":
                case "2058":
                case "2059":
                case "205A":
                case "205B":
                case "20FF":
                case "2601":
                case "2901":
                case "2940":
                case "2A01":
                case "2C01":
                case "2D61":
                case "2D65":
                case "2D77":
                case "2E69":
                case "345C":
                case "4000": // NEGX
                case "40C0":
                case "4101": // CHK
                case "4120":
                case "4142":
                case "4144":
                case "4145":
                case "4147":
                case "4148":
                case "4149":
                case "414B":
                case "414C":
                case "414D":
                case "414E":
                case "4150":
                case "4152":
                case "4153":
                case "4154":
                case "4155":
                case "4158":
                case "4159":
                case "415A":
                case "4220":
                case "4241":
                case "4243":
                case "4245":
                case "4249":
                case "424C":
                case "424F":
                case "4253":
                case "4255":
                case "4259":
                case "4279":
                case "4301": // CHK
                case "4320":
                case "4341":
                case "4343":
                case "4345":
                case "4348":
                case "4349":
                case "434B":
                case "434F":
                case "4352":
                case "4354":
                case "4357":
                case "4420":
                case "4441":
                case "4442":
                case "4445":
                case "4449":
                case "444E":
                case "444F":
                case "4452":
                case "4453":
                case "4454":
                case "4455":
                case "4459":
                case "4501": // CHK
                case "4520":
                case "4541":
                case "4543":
                case "4544":
                case "4545":
                case "4546":
                case "4547":
                case "4549":
                case "454C":
                case "454D":
                case "454E":
                case "454F":
                case "4550":
                case "4552":
                case "4553":
                case "4554":
                case "4556":
                case "4557":
                case "4558":
                case "4559":
                case "455B":
                case "4620":
                case "4641":
                case "4643":
                case "4645":
                case "4646":
                case "4649":
                case "464C":
                case "464F":
                case "4652":
                case "4654":
                case "4655":
                case "4701": // CHK
                case "4720":
                case "4741":
                case "4745":
                case "4748":
                case "474C":
                case "474D":
                case "474F":
                case "4752":
                case "4753":
                case "4755":
                case "4759":
                case "4820":
                case "4845":
                case "4849":
                case "484C":
                case "484F":
                case "4854":
                case "4855":
                case "4920":
                case "4941":
                case "4943":
                case "4944":
                case "4945":
                case "4946":
                case "4947":
                case "494B":
                case "494C":
                case "494D":
                case "494F":
                case "4952":
                case "4953":
                case "4954":
                case "4955":
                case "4956":
                case "4957":
                case "4958":
                case "495A":
                case "4A41":
                case "4A45":
                case "4A55":
                case "4B20":
                case "4B41":
                case "4B45":
                case "4B49":
                case "4B4E":
                case "4B53":
                case "4B59":
                case "4C20":
                case "4C41":
                case "4C42":
                case "4C44":
                case "4C45":
                case "4C47":
                case "4C48":
                case "4C49":
                case "4C4B":
                case "4C4C":
                case "4C4F":
                case "4C53":
                case "4C59":
                case "4D20":
                case "4D41":
                case "4D42":
                case "4D45":
                case "4D49":
                case "4D4D":
                case "4D4F":
                case "4D50":
                case "4D55":
                case "4D59":
                case "4E20":
                case "4E41":
                case "4E43":
                case "4E44":
                case "4E45":
                case "4E47":
                case "4E49":
                case "4E4B":
                case "4E4E":
                case "4E4F":
                case "4E53":
                case "4E54":
                case "4E55":
                case "4E58":
                case "4E59":
                case "4E5A":
                case "4EF9":
                case "4F20":
                case "4F41":
                case "4F42":
                case "4F44":
                case "4F46":
                case "4F47":
                case "4F48":
                case "4F4B":
                case "4F4C":
                case "4F4D":
                case "4F4F":
                case "4F50":
                case "4F52":
                case "4F53":
                case "4F54":
                case "4F55":
                case "4F56":
                case "4F57":
                case "4F59":
                case "5000":
                case "5020":
                case "5041":
                case "5045":
                case "5048":
                case "5049":
                case "504C":
                case "504F":
                case "5050":
                case "5055":
                case "5120":
                case "5155":
                case "5220":
                case "5241":
                case "5244":
                case "5245":
                case "5246":
                case "5247":
                case "5249":
                case "524D":
                case "524F":
                case "5252":
                case "5253":
                case "5254":
                case "5255":
                case "5259":
                case "5279":
                case "5320":
                case "5341":
                case "5343":
                case "5345":
                case "5348":
                case "5349":
                case "534C":
                case "534F":
                case "5350":
                case "5351":
                case "5353":
                case "5354":
                case "5355":
                case "5357":
                case "5359":
                case "535B":
                case "5361":
                case "5420":
                case "5441":
                case "5443":
                case "5445":
                case "5446":
                case "5448":
                case "5449":
                case "544C":
                case "544F":
                case "5453":
                case "5454":
                case "5455":
                case "5457":
                case "5459":
                case "5520":
                case "5541":
                case "5542":
                case "5543":
                case "5546":
                case "554C":
                case "554E":
                case "5550":
                case "5552":
                case "5553":
                case "5554":
                case "5559":
                case "5645":
                case "5649":
                case "564F":
                case "5720":
                case "5741":
                case "5745":
                case "5749":
                case "574F":
                case "5753":
                case "5759":
                case "5820":
                case "5920":
                case "5942":
                case "5945":
                case "594F":
                case "5953":
                case "5954":
                case "5957":
                case "5958":
                case "5A41":
                case "5A45":
                case "5A59":
                case "5A5A":
                case "5B20":
                case "5B4C":
                case "5B5B":
                case "5C44":
                case "5C55":
                case "5C67":
                case "5C69":
                case "5C76":
                case "5F6C":
                case "612D":
                case "616D":
                case "616E":
                case "6176":
                case "6261":
                case "633A":
                case "6368":
                case "636F":
                case "6465":
                case "6473":
                case "6500": // BCS
                case "6501": // BCS
                case "652D":
                case "6563":
                case "656E":
                case "6572":
                case "6578":
                case "6761":
                case "6766":
                case "6901": // BVS
                case "6963":
                case "6967":
                case "696E": // BVS
                case "6B01": // BMI
                case "6B6D":
                case "6B73":
                case "6C65":
                case "6C69":
                case "6C75":
                case "6D01": // BLT
                case "6D69":
                case "6D70":
                case "6E63":
                case "6E64":
                case "6E6C":
                case "6E74":
                case "6F01": // BLE
                case "6F61":
                case "6F64":
                case "6F75":
                case "6F77":
                case "702E":
                case "7068":
                case "706C":
                case "7070":
                case "7200":
                case "7232":
                case "7265":
                case "7273":
                case "7300":
                case "732D":
                case "735F":
                case "7363":
                case "7463":
                case "7673": // MOVEQ
                case "7769":
                case "776B":
                case "7836":
                case "7861":
                case "786E":
                case "7E35": // MOVEQ
                case "7FFF":
                case "8B4C":
                case "90FC":
                case "9701":
                case "9801":
                case "9901":
                case "9A01":
                case "9B01":
                case "9C01":
                case "9D01":
                case "9E01":
                case "9F01":
                case "A001":
                case "A101":
                case "A201":
                case "A301":
                case "A401":
                case "A501":
                case "A601":
                case "A6B5":
                case "A701":
                case "AB01":
                case "AE01":
                case "AF01":
                case "B101":
                case "B201":
                case "B301":
                case "B401":
                case "B501":
                case "B601":
                case "B701":
                case "B801":
                case "B901":
                case "BA01":
                case "BAFC":
                case "BB01":
                case "BC01":
                case "BD01":
                case "C001":
                case "C0FC":
                case "C101":
                case "C201":
                case "C301":
                case "C401":
                case "C501":
                case "C801":
                case "CA01":
                case "CC01":
                case "CD01":
                case "D001":
                case "D0D6":
                case "D101":
                case "D201":
                case "DA01":
                case "DB01":
                case "DC01":
                case "DCC0":
                case "DD01":
                case "DE01":
                case "DF01":
                case "E001":
                case "E101":
                case "E201":
                case "E301":
                case "E401":
                case "E501":
                case "E601":
                case "E701":
                case "E801":
                case "E901":
                case "EA01":
                case "EC01":
                case "EF01":
                case "F001":
                case "F201":
                case "F301":
                case "F401":
                case "F501":
                case "FF00":
                case "FF01":
                case "FFE1":
                case "FFEE":
                case "FFFE":

                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "4EB9":  // JSR
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                case "48F9": // movem
                    line += oc.Detail(ref filePosition, binaryFileData);
                    break;
                default: // Stop here if op code not found above
                    filePosition = binaryFileData.Length;
                    break;
            }
        }
    }
}
