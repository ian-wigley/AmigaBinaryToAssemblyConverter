using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinToAssembly
{
    public class AssemblyCreator
    {
        public string[] Code { get; set; }
        private readonly string label = "LABEL";
        public List<string> PassOne { get; private set; } = new List<string>();
        public List<string> PassTwo { get; private set; } = new List<string>();
        private readonly List<string> found = new List<string>();
        private readonly Dictionary<string, string> labelLocation = new Dictionary<string, string>();

        /// <summary>
        /// Convert To Hex Eight
        /// </summary>
        private string ConvertToHexEight(string value)
        {
            return int.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString("X8");
        }

        /// <summary>
        /// InitialPass
        /// </summary>
        public void InitialPass(
            string start,
            string end
            )
        {
            bool firstPass = true;
            string dataWord = "";
            int count = 0;
            int labelCount = 0;

            int userSelectedFileEnd = int.Parse(end, System.Globalization.NumberStyles.HexNumber);
            int originalFileLength = Code.Length;

            // First pass parses the content looking for branch & jump conditions
            while (firstPass)
            {
                if (Code[count].Contains("DC.B"))
                {
                    dataWord = Code[count];
                    int startLocation = dataWord.IndexOf("DC.B");
                    dataWord = dataWord.Substring(startLocation, dataWord.Length - startLocation);
                }

                // Split each line into an array
                string[] lineDetails = Code[count++].Split(' ');
                if (lineDetails.Length > 1)
                {
                    switch (lineDetails[1])
                    {
                        case "41F9": // LEA
                        case "43FA": // LEA
                        case "43F9": // LEA
                        case "45F9": // LEA
                        case "47F9": // LEA
                        case "4DF9": // LEA
                            int length = lineDetails.Length - 1;
                            string location = lineDetails[length].Replace("$", "");
                            int index = location.IndexOf(",");
                            location = location.Substring(0, index);
                            location = location.Replace("(PC)", "");
                            if (location.Length < 8)
                            {
                                location = ConvertToHexEight(location);
                            }
                            if (!labelLocation.ContainsKey(location))
                            {
                                labelLocation.Add(location, label + labelCount++.ToString());
                            }
                            PassOne.Add(lineDetails[length - 1] + " " + lineDetails[length]);
                            break;
                        case "4EF9": // JMP
                        case "6000": // BRA
                        case "60EC": // BRA
                        case "6100": // BSR
                        case "6600": // BNE
                        case "66CA": // BNE
                        case "66F2": // BEQ
                        case "670A": // BEQ
                        case "6700":
                        case "6701": // BEQ
                        case "6501": // BCS
                        case "6901": // BVS
                        case "6B01": // BMI
                        case "6D01": // BLT
                        case "6D6F": // BLT
                        case "6F01": // BLE
                            length = lineDetails.Length - 1;
                            location = lineDetails[length].Replace("$", "");
                            location = location.Replace("#", "").ToUpper();
                            location = ConvertToHexEight(location);
                            if (!labelLocation.ContainsKey(location))
                            {
                                labelLocation.Add(location, label + labelCount++.ToString());
                            }
                            PassOne.Add(lineDetails[length - 1] + " " + lineDetails[length]);
                            break;
                        case "4280": // CLR
                            PassOne.Add(lineDetails[21] + " " + lineDetails[22]);
                            break;
                        //case "51C8": // DBF
                        //    //string[] locations = lineDetails[18].Split(',');
                        //    //var temp = locations[1].Replace("$", "").ToUpper();
                        //    //temp = ConvertToHexEight(temp);
                        //    //if (!branchLoc.ContainsKey(temp))
                        //    //{
                        //    //    branchLoc.Add(temp, branch + branchCount++.ToString());
                        //    //}
                        //    break;
                        default:
                            // Add the DC.W's
                            if (dataWord != "")
                            {
                                PassOne.Add(dataWord);
                                dataWord = "";
                            }
                            else
                            {
                                int indexLength = lineDetails.Length;
                                PassOne.Add(lineDetails[indexLength - 2] + " " + lineDetails[indexLength - 1]);
                            }
                            break;
                    }
                }
                if (count >= userSelectedFileEnd || count >= originalFileLength || lineDetails[0].ToUpper().Equals(end.ToUpper()))
                {
                    firstPass = false;
                }
            }
        }

        /// <summary>
        /// SecondPass
        /// </summary>
        public void SecondPass()
        {
            // Add the labels to the front of the code
            for (int i = 0; i < PassOne.Count; i++)
            {
                string currentRowFromPassOne = PassOne[i];
                string currentRowFromOriginalFileContent = Code[i];
                var splitCurrentRow = currentRowFromOriginalFileContent.Split(' ');
                int length = splitCurrentRow.Length - 1;
                string spacing = "                ";
                foreach (KeyValuePair<string, string> memLocation in labelLocation)
                {
                    // If the current line number matches the memory loction, add a label
                    if (splitCurrentRow[0].ToUpper().Contains(memLocation.Key.ToUpper()) &&
                        !currentRowFromOriginalFileContent.Contains("BEQ") &&
                        !currentRowFromOriginalFileContent.Contains("BNE") &&
                        !currentRowFromOriginalFileContent.Contains("BSR") &&
                        !currentRowFromOriginalFileContent.Contains("BRA") &&
                        !currentRowFromOriginalFileContent.Contains("BVS") &&
                        !currentRowFromOriginalFileContent.Contains("BCS") &&
                        !currentRowFromOriginalFileContent.Contains("BLT") &&
                        !currentRowFromOriginalFileContent.Contains("BLE") &&
                        !currentRowFromOriginalFileContent.Contains("BMI") &&
                        !currentRowFromOriginalFileContent.Contains("JMP") &&
                        !currentRowFromOriginalFileContent.Contains("LEA")
                        //!currentRowFromOriginalFileContent.Contains("DBF")
                        )
                    {
                        spacing = memLocation.Value + "         ";
                        found.Add(memLocation.Key);
                    }
                    else if (currentRowFromOriginalFileContent.Contains("BEQ") ||
                        currentRowFromOriginalFileContent.Contains("BNE") ||
                        currentRowFromOriginalFileContent.Contains("BRA") ||
                        currentRowFromOriginalFileContent.Contains("BSR") ||
                        currentRowFromOriginalFileContent.Contains("BVS") ||
                        currentRowFromOriginalFileContent.Contains("BCS") ||
                        currentRowFromOriginalFileContent.Contains("BLT") ||
                        currentRowFromOriginalFileContent.Contains("BLE") ||
                        currentRowFromOriginalFileContent.Contains("BMI") ||
                        currentRowFromOriginalFileContent.Contains("JMP") ||
                        currentRowFromOriginalFileContent.Contains("LEA")
                        //currentRowFromOriginalFileContent.Contains("DBF")
                        )
                    {
                        var memoryLocation = splitCurrentRow[length].Replace("#", "");
                        memoryLocation = memoryLocation.Replace("$", "").ToUpper();
                        ////if (currentRowFromOriginalFileContent.Contains("DBF"))
                        ////{
                        ////    var debug = true;
                        ////    var a = memoryLocation.IndexOf(",") + 1;
                        ////    memoryLocation = memoryLocation.Substring(a, 4);
                        ////}
                        if (currentRowFromOriginalFileContent.Contains("BEQ"))
                        {
                            currentRowFromPassOne = currentRowFromPassOne.Replace("$" + memoryLocation, memLocation.Value);
                        }

                        if (currentRowFromOriginalFileContent.Contains("LEA"))
                        {
                            int index = memoryLocation.IndexOf(",");
                            memoryLocation = memoryLocation.Substring(0, index);
                            memoryLocation = memoryLocation.Replace("(PC)", "");
                        }
                        memoryLocation = ConvertToHexEight(memoryLocation);
                        if (memLocation.Key.Equals(memoryLocation))
                        {
                            if (!currentRowFromPassOne.Contains("LEA"))
                            {
                                currentRowFromPassOne = currentRowFromPassOne.Replace("$" + memoryLocation.Substring(4, 4), memLocation.Value);
                            }
                            else
                            {
                                currentRowFromPassOne = currentRowFromPassOne.Replace("$" + memoryLocation, memLocation.Value);
                            }
                            //var currentRowSplit = currentRowFromPassOne.Split(' ');
                            //currentRowFromPassOne = currentRowSplit[0] + " " + memLocation.Value;
                        }
                    }
                }
                PassTwo.Add(spacing + currentRowFromPassOne);
            }
        }

        /// <summary>
        /// FinalPass
        /// </summary>
        public string[] FinalPass()
        {
            if (found.Count != labelLocation.Count)
            {
                PassTwo.Add("\n; ---------------------------------------------------------");
                PassTwo.Add("; The memory locations below were not found within the file\n");
            }

            // Finally iterate through the found list & add references to the address not found
            foreach (KeyValuePair<string, string> memLocation in labelLocation)
            {
                if (!found.Contains(memLocation.Key))
                {
                    PassTwo.Add(memLocation.Value + "; @: " + memLocation.Key);
                }
            }

            return PassTwo.ToArray();
        }
    }
}
