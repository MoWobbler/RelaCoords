using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelaCoords
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void CalculateButton_Click(object sender, EventArgs e)
        {

            Regex expression = new Regex(@"[-\d]+");

            string startblock = StartBlockTextBox.Text;
            string endblock = EndBlockTextBox.Text;

            List<int> startBlockList = new List<int>();
            List<int> endBlockList = new List<int>(); ;


            var results = expression.Matches(startblock);

            if (results.Count != 3)
            {
                OutputTextBox.Text = "Something went wrong with the start block text box. Make sure to enter 3 integers separate by spaces there!";
                return;
            }

            foreach (Match match in results)
            {
                int temp = Int32.Parse(match.Value);
                startBlockList.Add(temp);
            }

            var results2 = expression.Matches(endblock);

            if (results2.Count != 3)
            {
                OutputTextBox.Text = "Something went wrong with the end block text box. Make sure to enter 3 integers separated by spaces there!";
                return;
            }

            foreach (Match match in results2)
            {
                int temp = Int32.Parse(match.Value);
                endBlockList.Add(temp);
            }

            int finalx = endBlockList[0] - startBlockList[0];
            int finaly = endBlockList[1] - startBlockList[1];
            int finalz = endBlockList[2] - startBlockList[2];

            string output = "~" + finalx + " ~" + finaly + " ~" + finalz;

            OutputTextBox.Text = "Copied these bad boys to your clipboard:\n" + output;
            Clipboard.SetText(output);


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void StartBlockTextBox_DoubleClick(object sender, EventArgs e)
        {
            StartBlockTextBox.SelectAll();
        }

        private void EndBlockTextBox_DoubleClick(object sender, EventArgs e)
        {
            EndBlockTextBox.SelectAll();
        }

    }
}
