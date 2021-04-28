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

        Label[] pizza1Labels; //arrays for the labels for the first pizzza, used to store and evetually hide labels until the user inputs name and num pizzas
        CheckBox[] pizza1CheckBoxes;
        Label[] pizza2Labels;
        CheckBox[] pizza2CheckBoxes;

        public static int pizza; //pizza counter variable used for hiding aspects of the form and for displaying number of pizzas
        public static string customer; //customer name var
        string pizza1size = "", pizza2size = ""; //pizza size for the pizza output, and verfiying that the user has selected a size for the pizzas the user selects
        public static float pizza1Price = 0.00f, pizza2Price = 0.00f; //pizza1 price for output 
        float pizza1toppingPrice, pizza2toppingPrice; //topping price calculated by multiplying the amount of toppings and 1.25, then later added to pizza price vars
        string pizza1crust = "", pizza2crust = ""; //used for output and for verifying the user has selected a crust
        string pizza1shape = "", pizza2shape = ""; // used for output and for verifying the user has selected a shape 
        public static string pizza1output = "", pizza2output = ""; //output variables used for displaying data on the second form
        public static float totalPrice = 0.00f; //output var used for total price output
        bool continueOrder = false; //determine if the user has entered their name and number of pizzas

        //exit button closes the current form on click
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); //closes form

        }

        //calculate button on click verifies inputs and promps the user if the input is invalid if all inputs are valid it calculates the price of the pizza
        //then creates the output strings and upens the output form (OutputForm.cs)
        private void calculateButton_Click(object sender, EventArgs e)
        {
            int pizza1toppings, pizza2toppings; //how many toppings are there for each pizza
            bool pizza1topvalid = Int32.TryParse(pizza1ToppingIn.Text, out pizza1toppings); //trying to parse the amount of toppings from the text input boxes. 
            //if not parsable pizza1valid = false, else it equals true
            bool pizza2topvalid = Int32.TryParse(pizza2ToppingIn.Text, out pizza2toppings); //same as pizza 1 parsing
            totalPrice = 0.00f; //reseting total price incase the user orders pizza multiple times
           

            if (pizza1topvalid == true && pizza1toppings > -1) //check if there is a valid number of pizza toppings for pizza 1
            {
                pizza1toppingPrice = pizza1toppings * 1.25f;//calculate topping price by multiplying by 1.25
            }
            else
            {
                MessageBox.Show("Please enter a valid number of toppings for Pizza 1. (>= 0)"); //if invalid prompt the user
                continueOrder = false; //and dont allow the user to continue to the output screen
            }

            
            if (pizza1size != "") //validate that the user selected a pizza size for pizza 1
            {
                if (pizza1shape != "") //validate that the user selected a pizza shape for pizza 1
                {
                    if (pizza1crust != "") //validate that the user slected a crust type for pizza 1
                    {
                        continueOrder = true; // if all are valid, calculate pizza 1 and allow the user to go to the output form
                        pizza1Price += pizza1toppingPrice; //adding topping price to the pizza prce based on size getting the total pizza price
                        pizza1output = "Size: " + pizza1size + "\nToppings: " + pizza1toppings.ToString() + " $" + pizza1toppingPrice.ToString() + "\nShape: " + pizza1shape + "\nCrust: " + pizza1crust + "\nPizza 1 Price: $" + pizza1Price;
                        if (pizza == 2) //check if there are 2 pizzas being ordered
                        {
                            if (pizza2topvalid == true && pizza2toppings > -1) //check if the number of toppings for pizza 2 are valid
                            {
                                pizza2toppingPrice = pizza2toppings * 1.25f; //if so get the price of the toppings by multiplying by 1.25
                                if (pizza2size != "") //validate the user selected a pizza size for pizza 2
                                {
                                    if (pizza2shape != "") //validate the user selected a pizza shape for pizza 2
                                    {
                                        if (pizza2crust != "") //validate the user selected a pizza crust type for pizza 2 
                                        {
                                            pizza2Price += pizza2toppingPrice; //if so then allow the user to continue to the OutputForm and calc pizza pirce and 
                                            //output for pizza 2
                                            pizza2output = "Size: " + pizza2size + "\nToppings: " + pizza2toppings.ToString() + " $" + pizza2toppingPrice.ToString() + "\nShape: " + pizza2shape + "\nCrust: " + pizza2crust + "\nPizza 2 Price: $" + pizza2Price;
                                            continueOrder = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Select a Type of Crust for Pizza 2."); //prompt the user if an input is invalidated 
                                            //and do not allow them to continue onto the output form
                                            continueOrder = false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Select a Shape for Pizza 2.");//prompt the user if an input is invalidated 
                                                                                              //and do not allow them to continue onto the output form
                                        continueOrder = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Select a Size for Pizza 2.");//prompt the user if an input is invalidated 
                                                                                         //and do not allow them to continue onto the output form
                                    continueOrder = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid number of toppings for Pizza 2 (>= 0)");//prompt the user if an input is invalidated 
                                                                                                              //and do not allow them to continue onto the output form
                                continueOrder = false;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Crust Type for Pizza 1.");//prompt the user if an input is invalidated 
                                                                                   //and do not allow them to continue onto the output form
                        continueOrder = false;
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Shape for Pizza 1.");//prompt the user if an input is invalidated 
                                                                          //and do not allow them to continue onto the output form
                    continueOrder = false;
                }
                
            }
            else
            {
                MessageBox.Show("Please Select A Size for Pizza 1.");//prompt the user if an input is invalidated 
                                                                     //and do not allow them to continue onto the output form
                continueOrder = false;
            }

            

            if (continueOrder) //check if the user passed all the validations, and can continue to the output form.
            {
                
                totalPrice = pizza1Price + pizza2Price; //calculate the total price of both pizzas
                new OutputForm().Show(); //display the output form
                pizza1Price = 0.00f; //reset the pizza prices
                pizza2Price = 0.00f;
                clearForm1(); //clear the form incase the user wants to order more pizzas
            }
        }


        //clear the form using the clearForm1 function on clearButton click
        private void clearButton_Click(object sender, EventArgs e)
        {
            clearForm1(); //clear form function, clears values for all inputs on the form, resets them and hides them
        }

        //funtion validate the user has entered a name and valid number of pizzas on orderContinue click event

        private void orderContinue_Click(object sender, EventArgs e)
        {

            bool inputValid = false;

            inputValid = Int32.TryParse(numPizzas.Text, out pizza); // checking if the input is a 
            //valid Int32 returns input valid becomes false if not valid, and become true if is, 
            //pizza also gets the int value if valid
            customer = customerName.Text; //get the text from the customer name input
            totalPrice = 0.00f; //reset total price
            if (customer == "") //check if the user inputed a customer name
            {
                MessageBox.Show("Please Enter a Customer Name."); //Prompt the user if they didnt
            }
            else
            {
                if (!inputValid || pizza > 2 || pizza < 1) //if they did enter a name then check that the number of pizza are valid
                {
                    MessageBox.Show("Please Enter a Valid Number of Pizzas. (1 or 2)"); //if not prompt the user to enter a valid amount
                }
                else
                { //if num pizzas is valid determine if to show inputs for 1 pizza or 2 pizzas
                    if (pizza == 1) //if there is 1 pizza selected
                    {
                        visible_labels(pizza1Labels, true); //show the labels for pizza 1
                        visible_labels(pizza2Labels, false);//hide the labels for pizza w
                        visible_checkboxes(pizza2CheckBoxes, false); //hide the checkboxes for pizza 2
                        visible_checkboxes(pizza1CheckBoxes, true); //show the checkboxes for pizza 1
                        pizza1ToppingIn.Visible = true; //show the topping input for pizza1
                        pizza2ToppingIn.Visible = false; // hide the topping input for pizza 2
                    }
                    else //if there are 2 pizzas 
                    {
                        visible_labels(pizza1Labels, true); //show all the inputs 
                        visible_labels(pizza2Labels, true);
                        visible_checkboxes(pizza2CheckBoxes, true);
                        visible_checkboxes(pizza1CheckBoxes, true);
                        pizza1ToppingIn.Visible = true;
                        pizza2ToppingIn.Visible = true;
                    }
                }
            }
        }
        
        //function iterates throught the list of labels and sets the visible property to the bool parameter vis 

        private void visible_labels(Label[] labels, bool vis)
        {
            for (int i = 0; i < labels.Length; i++) //iterates through the labels array
            {
                labels[i].Visible = vis; //sets the label at the current index as visible or invisible based on vis
            }
        }

        //does the same thing as visible labels on line 204 but with checkboxes

        private void visible_checkboxes(CheckBox[] checkBoxes, bool vis)
        {
            for (int i = 0; i < checkBoxes.Length; i++) //iterates through the checkBoxes array
            {
                checkBoxes[i].Visible = vis; //sets the checkbox at the current index as visible or invisible based on vis
            }
        }

        //function checks if the large size check box for pizza 2 is checked or not and changes the other check boxes, pizza2size var, and pizza2price var as needed.
        private void pizza2LargeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2LargeCheck.Checked == false) //if the checkbox is checked off clear the var pizza 2 size 
            {
                pizza2size = "";
            }
            else //else turn off the other check boxes check, and updates price and size string
            {
                pizza2MedCheck.Checked = false; //unchecks the checkboxes if checked
                pizza2SmallCheck.Checked = false;
                pizza2Price = 15.95f; //update pizza 2 price 
                pizza2size = "Large $15.95"; //update pizza 2 size string

            }
        }

        //function checks if the med size check box for pizza 2 is checked or not and changes the other check boxes, pizza2size var, and pizza2price var as needed.
        //same as the function on 223 but for the pizza 2 med box
        private void pizza2MedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2MedCheck.Checked == false)
            {
                pizza2size = "";
            }
            else
            {
                pizza2LargeCheck.Checked = false;
                pizza2SmallCheck.Checked = false;
                pizza2Price = 12.95f;
                pizza2size = "Medium $12.95";
            }
        }


        //function checks if the round shape check box for pizza 1 is checked or not and changes the other check boxes, pizza1shape var as needed.
        //same as the function on 223 but for the pizza 1 round box
        private void pizza1RoundCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1RoundCheck.Checked == true)
            {
                pizza1SquareCheck.Checked = false;
                pizza1shape = "Round";
            }
            else
            {
                pizza1shape = "";
            }
        }

        //function checks if the square shape check box for pizza 1 is checked or not and changes the other check boxes, pizza1shape var as needed.
        //same as the function on 223 but for the pizza 1 round box
        private void pizza1SquareCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(pizza1SquareCheck.Checked == true)
            {

                pizza1RoundCheck.Checked = false;
                pizza1shape = "Square";
            }
            else
            {
                pizza1shape = "";
            }
        }

        //function checks if the thick crust check box for pizza 1 is checked or not and changes the other check boxes, pizza1crust var as needed.
        //same as the function on 223 but for the pizza 1 thick box
        private void pizza1ThickCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1ThickCheck.Checked == true)
            {
                pizza1ThinCheck.Checked = false;
                pizza1crust = "Thick";
            }
            else
            {
                pizza1crust = "";
            }
        }
        //function checks if the thin crust check box for pizza 1 is checked or not and changes the other check boxes, pizza1crust var as needed.
        //same as the function on 223 but for the pizza 1 thin box
        private void pizza1ThinCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1ThinCheck.Checked == true)
            {
                pizza1ThickCheck.Checked = false;
                pizza1crust = "Thin";
            }
            else
            {
                pizza1crust = "";
            }
        }
        //function checks if the round shape check box for pizza 2 is checked or not and changes the other check boxes, pizza2shape var as needed.
        //same as the function on 223 but for the pizza 2 round box
        private void pizza2RoundCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(pizza2RoundCheck.Checked == true)
            {
                pizza2SquareCheck.Checked = false;
                pizza2shape = "Square";
            }
            else
            {
                pizza2shape = "";
            }
        }
        //function checks if the square shape check box for pizza 2 is checked or not and changes the other check boxes, pizza2shape var as needed.
        //same as the function on 223 but for the pizza 2 square box
        private void pizza2SquareCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2SquareCheck.Checked == true)
            {
                pizza2RoundCheck.Checked = false;
                pizza2shape = "Square";
            }
            else
            {
                pizza2shape = "";
            }
        }
        //function checks if the thick crust check box for pizza 2 is checked or not and changes the other check boxes, pizza2crust var as needed.
        //same as the function on 223 but for the pizza 2 thick box
        private void pizza2ThickCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2ThickCheck.Checked == true)
            {
                pizza2ThinCheck.Checked = false;
                pizza2crust = "Thick";
            }
            else
            {
                pizza2crust = "";
            }
        }
        //function checks if the thin crust check box for pizza 2 is checked or not and changes the other check boxes, pizza2crust var as needed.
        //same as the function on 223 but for the pizza 2 thin box
        private void pizza2ThinCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2ThinCheck.Checked == true)
            {
                pizza2ThickCheck.Checked = false;
                pizza2crust = "Thin";
            }
            else
            {
                pizza2crust = "";
            }
        }
        //function checks if the small size check box for pizza 2 is checked or not and changes the other check boxes, pizza2size var, and pizza2price var as needed.
        //same as the function on 223 but for the pizza 2 small box
        private void pizza2SmallCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza2SmallCheck.Checked == false)
            {
                pizza2size = "";
            }
            else
            {               
                pizza2MedCheck.Checked = false;
                pizza2LargeCheck.Checked = false;
                pizza2Price = 10.95f;
                pizza2size = "Small $10.95";
            }
        }
        //function takes in an array of checkboxes and checks or unchecks them based on the value of the check param
        private void checked_boxes(CheckBox[] checkBoxes, bool check)
        {
            for (int i = 0; i < checkBoxes.Length; i++) //iterate through the array of check boxes 
            {
                checkBoxes[i].Checked = check; //check or uncheck the box at the current index based on the value of check
            }
        }

        //function declares the arrays of labels and checkboxes for both pizzas, sets all as invisible on the execution of the program
        private void MainForm_Load(object sender, EventArgs e)
        {

            //adding values of the check boxes and labels to the appropriate array
            pizza1Labels = new Label[12] { pizza1Label, pizza1LargeLabel, pizza1MedLabel, pizza1ShapeLabel, 
                pizza1RoundLabel, pizza1SquareLabel, pizza1ThickLabel, pizza1ThinLabel, pizza1CrustLabel,
                Pizza1SmallLabel, Pizza1TopNumLabel, Pizza1ToppingLabel };

            pizza1CheckBoxes = new CheckBox[7] { pizza1LargeCheck, pizza1MedCheck, pizza1RoundCheck, 
                pizza1SmallCheck, pizza1SquareCheck, pizza1ThickCheck, pizza1ThinCheck };

            pizza2Labels = new Label[12] { pizza2Label, pizza2LargeLabel, pizza2MedLabel, pizza2ShapeLabel, 
                pizza2RoundLabel, pizza2SquareLabel, pizza2ThickLabel, pizza2ThinLabel, pizza2CrustLabel,
                pizza2SmallLabel, pizza2TopLabel, pizza2ToppingLabel };

            pizza2CheckBoxes = new CheckBox[7] { pizza2LargeCheck, pizza2MedCheck, pizza2RoundCheck,
                pizza2SmallCheck, pizza2SquareCheck, pizza2ThickCheck, pizza2ThinCheck };


            //setting all inputs as invisible
            visible_labels(pizza1Labels, false);
            visible_labels(pizza2Labels, false);
            visible_checkboxes(pizza2CheckBoxes, false);
            visible_checkboxes(pizza1CheckBoxes, false);

            pizza1ToppingIn.Visible = false;
            pizza2ToppingIn.Visible = false;

        }
        //function checks if the large size check box for pizza 1 is checked or not and changes the other check boxes, pizza1size var, and pizza1price var as needed.
        //same as the function on 223 but for the pizza 1 large box
        private void pizza1LargeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1LargeCheck.Checked == false)
            {
                pizza1size = "";
            }
            else
            {
                pizza1MedCheck.Checked = false;
                pizza1SmallCheck.Checked = false;
                pizza1Price = 15.95f;
                pizza1size = "Large $15.95";
            }


        }
        //function checks if the med size check box for pizza 1 is checked or not and changes the other check boxes, pizza1size var, and pizza1price var as needed.
        //same as the function on 223 but for the pizza 1 med box
        private void pizza1MedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1MedCheck.Checked == false)
            {
                pizza1size = "";
            }
            else
            {
                pizza1LargeCheck.Checked = false;
                pizza1SmallCheck.Checked = false;
                pizza1Price = 12.95f;
                pizza1size = "Medium $12.95";
            }
            
        }
        //function checks if the small size check box for pizza 1 is checked or not and changes the other check boxes, pizza1size var, and pizza1price var as needed.
        //same as the function on 223 but for the pizza 1 small box
        private void pizza1SmallCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (pizza1SmallCheck.Checked == false)
            {
                pizza1size = "";
            }
            else
            {
                pizza1LargeCheck.Checked = false;
                pizza1MedCheck.Checked = false;
                pizza1Price = 10.95f;
                pizza1size = "Small $10.95";
            }
            
        }

        //Function resets all values of variables, resets the inputs, hides pizza info inputs 
        public void clearForm1()
        {
            pizza1ToppingIn.Text = "0"; //reset the topping inputs
            pizza2ToppingIn.Text = "0";

            numPizzas.Text = ""; //reset the num pizza input
            customerName.Text = ""; //rset the customer name input

            //hide all the pizza information inputs
            visible_labels(pizza1Labels, false);
            visible_labels(pizza2Labels, false);
            visible_checkboxes(pizza2CheckBoxes, false);
            visible_checkboxes(pizza1CheckBoxes, false);
            checked_boxes(pizza2CheckBoxes, false);
            checked_boxes(pizza1CheckBoxes, false);

            pizza1ToppingIn.Visible = false;
            pizza2ToppingIn.Visible = false;

            //reset prcing variables
            pizza1Price = 0.00f;
            pizza2Price = 0.00f;
            totalPrice = 0.00f;

            //reset output and validation variables
            pizza1crust = "";
            pizza2crust = "";
            pizza1shape = "";
            pizza2shape = "";
            pizza1output = "";
            pizza2output = "";
            pizza1size = "";
            pizza2size = "";
        }
    }
}