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
            MessageBox.Show("Pizza Ordered!");
            this.Close();
        }


        private void OutputForm_Load(object sender, EventArgs e)
        {
            int pizzaAmt = MainForm.pizza;
            float totalPrice = MainForm.totalPrice;

            if(pizzaAmt == 2)
            {
                pizza1Output.Text = "Pizza 1:\n" + MainForm.pizza1output;
                pizza2Output.Text = "Pizza 2: \n" + MainForm.pizza2output;
                outputLabel.Text = "Customer Name: " + MainForm.customer + "\n Pizzas Ordered: " + MainForm.pizza; 
                totalOutput.Text = "Total: $" + totalPrice.ToString();
                pizza2Output.Visible = true;
            }
            else
            {
                pizza1Output.Text = "Pizza 1:\n" + MainForm.pizza1output;
                outputLabel.Text = "Customer Name: " + MainForm.customer + "\n Pizzas Ordered: " + MainForm.pizza;
                totalOutput.Text = "Total: $" + totalPrice.ToString();
                pizza2Output.Visible = false;
            }
        }
    }
}
