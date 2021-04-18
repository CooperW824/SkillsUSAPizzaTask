using System;
using System.Windows.Forms;

namespace SkillsUSAPizzaTask
{
    public partial class OutputForm : Form
    {
        public OutputForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ordered!");
            this.Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cleared!");
            this.Close();
        }
    }
}
