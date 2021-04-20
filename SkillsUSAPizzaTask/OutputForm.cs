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

        //on closeButton click event close the current form
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close(); //close the current form 

        }

        //on orderButton click, "Order" the pizza, display that to the user, and close the current form
        private void orderButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pizza Ordered!"); //tell the user the pizza(s) have been "ordered"
            this.Close(); //close the current form
        }


        private void OutputForm_Load(object sender, EventArgs e)
        {
            int pizzaAmt = MainForm.pizza; //get the number of pizzas from the mainform
            float totalPrice = MainForm.totalPrice; //get the total price from the main form

            if(pizzaAmt == 2) //if there are two pizzas output both of their infomation
            {
                pizza1Output.Text = "Pizza 1:\n" + MainForm.pizza1output; //output pizza 1 info
                pizza2Output.Text = "Pizza 2: \n" + MainForm.pizza2output;//output pizza 2 info
                outputLabel.Text = "Customer Name: " + MainForm.customer + "\n Pizzas Ordered: " + MainForm.pizza; //output customer name and num pizzas ordered
                totalOutput.Text = "Total: $" + totalPrice.ToString(); //output total price
                pizza2Output.Visible = true; //make the pizza 2 output visible
            }
            else //if there is only 1 pizza ordered
            {
                pizza1Output.Text = "Pizza 1:\n" + MainForm.pizza1output; // output pizza 1 information
                outputLabel.Text = "Customer Name: " + MainForm.customer + "\n Pizzas Ordered: " + MainForm.pizza; //output customer name and pizzas ordered
                totalOutput.Text = "Total: $" + totalPrice.ToString(); //output total price
                pizza2Output.Visible = false; //hide the second pizza output
            }
        }
    }
}
