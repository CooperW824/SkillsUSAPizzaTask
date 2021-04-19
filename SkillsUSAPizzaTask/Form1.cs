using System;
using System.Windows.Forms;

namespace SkillsUSAPizzaTask
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //declaring global vars here

        Label[] pizza1Labels;
        CheckBox[] pizza1CheckBoxes;
        Label[] pizza2Labels;
        CheckBox[] pizza2CheckBoxes;

        int pizza; //pizza counter variable used for hiding aspects of the form and for displaying number of pizzas
        string customer; //customer name var
        string pizza1size = "", pizza2size = "";
        float pizza1Price, pizza2Price;
        float pizza1toppingPrice, pizza2toppingPrice;
        string pizza1crust = "", pizza2crust = "";
        string pizza1shape = "", pizza2shape = "";
        string pizza1output = "", pizza2output = "";
        float totalPrice = 0.00f;
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            int pizza1toppings, pizza2toppings;
            bool pizza1topvalid = Int32.TryParse(pizza1ToppingIn.Text, out pizza1toppings);
            bool pizza2topvalid = Int32.TryParse(pizza2ToppingIn.Text, out pizza2toppings);

            if (pizza1topvalid == true && pizza1toppings > -1)
            {
                pizza1toppingPrice = pizza1toppings * 1.25f;
            }
            else
            {
                MessageBox.Show("Please enter a valid number of toppings for Pizza 1. (>= 0)");
            }

            if (pizza2topvalid == true && pizza == 2 && pizza2toppings > -1)
            {
                pizza2toppingPrice = pizza2toppings * 1.25f;
            }
            else
            {
                MessageBox.Show("Please enter a valid number of toppings for Pizza 2 (>= 0)");
            }
            if (pizza1size != "")
            {
                if(pizza1crust != "")
                {
                    if(pizza1shape != "")
                    {
                        if(pizza == 2)
                        {
                            if(pizza2size != "")
                            {
                                if(pizza2shape != "")
                                {
                                    if (pizza2crust != "")
                                    {

                                    }
                                }
                            }
                        }
                        pizza1Price += pizza1toppingPrice;
                        //pizza1output = "Size: " + pizza1size;
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Shape for Pizza 1.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Crust Type for Pizza 1.");
                }
            }
            else
            {
                MessageBox.Show("Please Select A Size for Pizza 1.");
            }
            new OutputForm().Show();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pizza1ToppingIn.Text = "0";
            pizza2ToppingIn.Text = "0";

            numPizzas.Text = "";
            customerName.Text = "";

            visible_labels(pizza1Labels, false);
            visible_labels(pizza2Labels, false);
            visible_checkboxes(pizza2CheckBoxes, false);
            visible_checkboxes(pizza1CheckBoxes, false);
            checked_boxes(pizza2CheckBoxes, false);
            checked_boxes(pizza1CheckBoxes, false);

            pizza1ToppingIn.Visible = false;
            pizza2ToppingIn.Visible = false;
            pizza1Price = 0.00f;
            pizza2Price = 0.00f;
            totalPrice = 0.00f;

            pizza1crust = "";
            pizza2crust = "";
            pizza1shape = "";
            pizza2shape = "";
            pizza1output = ""; 
            pizza2output = "";
            pizza1size = "";
            pizza2size = "";
        }

        private void orderContinue_Click(object sender, EventArgs e)
        {

            bool inputValid = false;

            inputValid = Int32.TryParse(numPizzas.Text, out pizza); // checking if the input is a 
            //valid Int32 returns input valid becomes false if not valid, and become true if is, 
            //pizza also gets the int value if valid
            customer = customerName.Text;

            if (customer == "")
            {
                MessageBox.Show("Please Enter a Customer Name.");
            }
            else
            {
                if (!inputValid || pizza > 2 || pizza < 1)
                {
                    MessageBox.Show("Please Enter a Valid Number of Pizzas.");
                }
                else
                {
                    if (pizza == 1)
                    {
                        visible_labels(pizza1Labels, true);
                        visible_labels(pizza2Labels, false);
                        visible_checkboxes(pizza2CheckBoxes, false);
                        visible_checkboxes(pizza1CheckBoxes, true);
                        pizza1ToppingIn.Visible = true;
                        pizza2ToppingIn.Visible = false;
                    }
                    else
                    {
                        visible_labels(pizza1Labels, true);
                        visible_labels(pizza2Labels, true);
                        visible_checkboxes(pizza2CheckBoxes, true);
                        visible_checkboxes(pizza1CheckBoxes, true);
                        pizza1ToppingIn.Visible = true;
                        pizza2ToppingIn.Visible = true;
                    }
                }
            }
        }

        private void customerName_TextChanged(object sender, EventArgs e)
        {
            customer = customerName.Text;
        }

        private void visible_labels(Label[] labels, bool vis)
        {
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = vis;
            }
        }

        private void visible_checkboxes(CheckBox[] checkBoxes, bool vis)
        {
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i].Visible = vis;
            }
        }

        private void pizza2LargeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2LargeCheck.Checked == false)
            {
                pizza2size = "";
            }
            else
            {
                pizza2size = "Large $15.95";
                pizza2MedCheck.Checked = false;
                pizza2SmallCheck.Checked = false;
                pizza2Price = 15.95f;
            }
        }

        private void pizza2MedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2MedCheck.Checked == false)
            {
                pizza2size = "";
            }
            else
            {
                pizza2size = "Medium $12.95";
                pizza2LargeCheck.Checked = false;
                pizza2SmallCheck.Checked = false;
                pizza2Price = 15.95f;
            }
        }

        private void pizza1RoundCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1RoundCheck.Checked == true)
            {
                pizza1shape = "Round";
                pizza1SquareCheck.Checked = false;
            }
        }


        private void pizza1SquareCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(pizza1SquareCheck.Checked == true)
            {
                pizza1shape = "Square";
                pizza1RoundCheck.Checked = false;
            }
        }

        private void pizza1ThickCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1ThickCheck.Checked == true)
            {
                pizza1crust = "Thick";
                pizza1ThinCheck.Checked = false;
            }
        }

        private void pizza1ThinCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1ThinCheck.Checked == true)
            {
                pizza1crust = "Thin";
                pizza1ThickCheck.Checked = false;
            }
        }

        private void pizza2RoundCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(pizza2RoundCheck.Checked == true)
            {
                pizza2shape = "Square";
                pizza2SquareCheck.Checked = false;
            }
        }

        private void pizza2SquareCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2SquareCheck.Checked == true)
            {
                pizza2shape = "Square";
                pizza2RoundCheck.Checked = false;
            }
        }

        private void pizza2ThickCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2ThickCheck.Checked == true)
            {
                pizza2shape = "Square";
                pizza2ThinCheck.Checked = false;
            }
        }

        private void pizza2ThinCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2ThinCheck.Checked == true)
            {
                pizza2shape = "Square";
                pizza2ThickCheck.Checked = false;
            }
        }

        private void pizza2SmallCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2SmallCheck.Checked == false)
            {
                pizza2size = "";
            }
            else
            {
                pizza2size = "Small 10.95";
                pizza2MedCheck.Checked = false;
                pizza2LargeCheck.Checked = false;
                pizza2Price = 15.95f;
            }
        }

        private void checked_boxes(CheckBox[] checkBoxes, bool check)
        {
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i].Checked = check;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            pizza1Labels = new Label[12] { pizza1Label, pizza1LargeLabel, pizza1MedLabel, pizza1ShapeLabel, pizza1RoundLabel, pizza1SquareLabel, pizza1ThickLabel, pizza1ThinLabel, pizza1CrustLabel, Pizza1SmallLabel, Pizza1TopNumLabel, Pizza1ToppingLabel };
            pizza1CheckBoxes = new CheckBox[7] { pizza1LargeCheck, pizza1MedCheck, pizza1RoundCheck, pizza1SmallCheck, pizza1SquareCheck, pizza1ThickCheck, pizza1ThinCheck };
            pizza2Labels = new Label[12] { pizza2Label, pizza2LargeLabel, pizza2MedLabel, pizza2ShapeLabel, pizza2RoundLabel, pizza2SquareLabel, pizza2ThickLabel, pizza2ThinLabel, pizza2CrustLabel, pizza2SmallLabel, pizza2TopLabel, pizza2ToppingLabel };
            pizza2CheckBoxes = new CheckBox[7] { pizza2LargeCheck, pizza2MedCheck, pizza2RoundCheck, pizza2SmallCheck, pizza2SquareCheck, pizza2ThickCheck, pizza2ThinCheck };

            visible_labels(pizza1Labels, false);
            visible_labels(pizza2Labels, false);
            visible_checkboxes(pizza2CheckBoxes, false);
            visible_checkboxes(pizza1CheckBoxes, false);

            pizza1ToppingIn.Visible = false;
            pizza2ToppingIn.Visible = false;

        }

        private void pizza1LargeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1LargeCheck.Checked == false)
            {
                pizza1size = "";
            }
            else
            {
                pizza1size = "Large 15.95";
                pizza1MedCheck.Checked = false;
                pizza1SmallCheck.Checked = false;
                pizza1Price = 15.95f;
            }


        }

        private void pizza1MedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1MedCheck.Checked == false)
            {
                pizza1size = "";
            }
            else
            {
                pizza1size = "Medium 12.95";
                pizza1LargeCheck.Checked = false;
                pizza1SmallCheck.Checked = false;
                pizza1Price = 12.95f;
            }
            
        }

        private void pizza1SmallCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1SmallCheck.Checked == false)
            {
                pizza1size = "";
            }
            else
            {
                pizza1size = "Small 10.95";
                pizza1LargeCheck.Checked = false;
                pizza1MedCheck.Checked = false;
                pizza1Price = 10.95f;
            }
            
        }
    }
}