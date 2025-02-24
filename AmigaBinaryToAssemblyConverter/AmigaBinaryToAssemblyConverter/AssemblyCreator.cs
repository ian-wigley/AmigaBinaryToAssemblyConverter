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
        private readonly string branch = "BRANCH";
        public List<string> PassOned { get; private set; } = new List<string>();
        private readonly List<string> passTwo = new List<string>();
        private readonly List<string> found = new List<string>();
        private readonly Dictionary<string, string> branchLoc = new Dictionary<string, string>();

        /// <summary>
        /// Convert To Hex Eight
        /// </summary>
        private string ConvertToHexEight(string value)
        {
            return int.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString("X8");
        }

        /// <summary>
        /// PassOne
        /// </summary>
        public void PassOne(
            string start,
            string end,
            List<string> originalFileContent
            )
        {
            bool firstPass = true;
            string dataWord = "";
            int count = 0;
            int branchCount = 0;

            int userSelectedFileEnd = int.Parse(end, System.Globalization.NumberStyles.HexNumber);
            int originalFileLength = Code.Length;

            // First pass parses the content looking for branch & jump conditions
            while (firstPass)
            {
                // Split each line into an array
                if (Code[count].Contains("DC.B"))
                {
                    dataWord = Code[count];
                    int startLocation = dataWord.IndexOf("DC.B");
                    dataWord = dataWord.Substring(startLocation, dataWord.Length - startLocation);
                }

                string[] lineDetails = Code[count++].Split(' ');
                if (lineDetails.Length > 1)
                {
                    switch (lineDetails[1])
                    {
                        case "41F9": // LEA
                        case "43FA": // LEA
                        case "43F9": // LEA
                        case "45F9": // LEA
                        case "4DF9": // LEA
                            int length = lineDetails.Length - 1;
                            string location = lineDetails[length].Replace("$", "");
                            int index = location.IndexOf(",");
                            location = location.Substring(0, index);
                            if (!branchLoc.ContainsKey(location))
                            {
                                branchLoc.Add(location, branch + branchCount++.ToString());
                            }
                            PassOned.Add(lineDetails[length - 1] + " " + lineDetails[length]);
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
                            if (!branchLoc.ContainsKey(location))
                            {
                                branchLoc.Add(location, branch + branchCount++.ToString());
                            }
                            PassOned.Add(lineDetails[length - 1] + " " + lineDetails[length]);
                            break;
                        case "4280": // CLR
                            PassOned.Add(lineDetails[21] + " " + lineDetails[22]);
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
                                PassOned.Add(dataWord);
                                dataWord = "";
                            }
                            else
                            {
                                int indexLength = lineDetails.Length;
                                PassOned.Add(lineDetails[indexLength - 2] + " " + lineDetails[indexLength - 1]);
                            }
                            break;
                    }
                }
                if (count >= userSelectedFileEnd || count >= originalFileLength || lineDetails[0].ToLower().Contains(end.ToLower()))
                {
                    firstPass = false;
                }
            }
        }

        /// <summary>
        /// PassTwo
        /// </summary>
        public void PassTwo()
        {
            // Add the labels to the front of the code
            for (int i = 0; i < PassOned.Count; i++)
            {
                string currentRowFromPassOne = PassOned[i];
                string currentRowFromOriginalFileContent = Code[i];
                var splitCurrentRow = currentRowFromOriginalFileContent.Split(' ');
                int length = splitCurrentRow.Length - 1;
                string label = "                ";
                foreach (KeyValuePair<string, string> memLocation in branchLoc)
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
                        label = memLocation.Value + "         ";
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
                        ///

                        if (currentRowFromOriginalFileContent.Contains("BEQ"))
                        {
                            // TODO !
                            var debug = true;
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
                passTwo.Add(label + currentRowFromPassOne);
            }
        }

        /// <summary>
        /// Pass Three
        /// </summary>
        public string[] PassThree()
        {
            if (found.Count != branchLoc.Count)
            {
                passTwo.Add("\n; ---------------------------------------------------------");
                passTwo.Add("; The memory locations below were not found within the file\n");
            }

            // Finally iterate through the found list & add references to the address not found
            foreach (KeyValuePair<string, string> memLocation in branchLoc)
            {
                if (!found.Contains(memLocation.Key))
                {
                    passTwo.Add(memLocation.Value + "; @: " + memLocation.Key);
                }
            }

            return passTwo.ToArray();
        }
    }
}
