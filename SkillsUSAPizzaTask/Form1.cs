using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkillsUSAPizzaTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //declaring global vars here

        int pizza; //pizza counter variable used for hiding aspects of the form and for displaying number of pizzas
        string customer; //customer name var
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CALC!");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CLEAR!");
        }

        private void orderContinue_Click(object sender, EventArgs e)
        {
           
            bool inputValid = false;
            
                inputValid = Int32.TryParse(numPizzas.Text, out pizza); // checking if the input is a 
            //valid Int32 returns input valid becomes false if not valid, and become true if is, 
            //pizza also gets the int value if valid
                

                if (!inputValid || pizza > 2 || pizza < 1)
                {
                    MessageBox.Show("Please Enter a Valid Number of Pizzas.");
                }
          
        }

        private void customerName_TextChanged(object sender, EventArgs e)
        {
            customer = customerName.Text;
        }
    }
}
