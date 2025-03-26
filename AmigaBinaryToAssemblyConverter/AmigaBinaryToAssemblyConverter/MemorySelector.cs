using System.Collections.Generic;
using System.Windows.Forms;

namespace BinToAssembly
{
    public partial class MemorySelector : Form
    {
        private readonly IList<object> memValues = new List<object>();

        public string GetSelectedMemStartLocation
        {
            get
            {
                return
                    startAddress1.Text + startAddress2.Text + startAddress3.Text + startAddress4.Text + startAddress5.Text + startAddress6.Text + startAddress7.Text + startAddress8.Text;
            }
        }
        public string GetSelectedMemEndLocation {
            get
            {
                return
                    endAddress1.Text + endAddress2.Text + endAddress3.Text + endAddress4.Text + endAddress5.Text + endAddress6.Text + endAddress7.Text + endAddress8.Text;
            }
        }

        public MemorySelector(
            char[] startAdress,
            char[] endAdress)
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            for (int i = 0; i < 16; i++)
            {
                memValues.Add(new { Text = i.ToString("X1"), Value = i });
            }

            InitialiseComboBoxes(startAddress1);
            InitialiseComboBoxes(startAddress2);
            InitialiseComboBoxes(startAddress3);
            InitialiseComboBoxes(startAddress4);

            InitialiseComboBoxes(startAddress5);
            InitialiseComboBoxes(startAddress6);
            InitialiseComboBoxes(startAddress7);
            InitialiseComboBoxes(startAddress8);

            InitialiseComboBoxes(endAddress1);
            InitialiseComboBoxes(endAddress2);
            InitialiseComboBoxes(endAddress3);
            InitialiseComboBoxes(endAddress4);

            InitialiseComboBoxes(endAddress5);
            InitialiseComboBoxes(endAddress6);
            InitialiseComboBoxes(endAddress7);
            InitialiseComboBoxes(endAddress8);

            startAddress1.Text = startAdress[0].ToString();
            startAddress2.Text = startAdress[1].ToString();
            startAddress3.Text = startAdress[2].ToString();
            startAddress4.Text = startAdress[3].ToString();

            startAddress5.Text = startAdress[4].ToString();
            startAddress6.Text = startAdress[5].ToString();
            startAddress7.Text = startAdress[6].ToString();
            startAddress8.Text = startAdress[7].ToString();

            endAddress1.Text = endAdress[0].ToString();
            endAddress2.Text = endAdress[1].ToString();
            endAddress3.Text = endAdress[2].ToString();
            endAddress4.Text = endAdress[3].ToString();

            endAddress5.Text = endAdress[4].ToString();
            endAddress6.Text = endAdress[5].ToString();
            endAddress7.Text = endAdress[6].ToString();
            endAddress8.Text = endAdress[7].ToString();
        }

        private void InitialiseComboBoxes(
            ComboBox comboBox)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
            comboBox.DataSource = memValues;
        }

        private void Button1_Click(
            object sender,
            System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}