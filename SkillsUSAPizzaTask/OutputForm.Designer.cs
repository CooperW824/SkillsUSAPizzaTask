namespace SkillsUSAPizzaTask
{
    partial class OutputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.pizza1Output = new System.Windows.Forms.Label();
            this.pizza2Output = new System.Windows.Forms.Label();
            this.orderButton = new System.Windows.Forms.Button();
            this.totalOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(237, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(213, 44);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Skills Pizza";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.Location = new System.Drawing.Point(69, 53);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(227, 64);
            this.outputLabel.TabIndex = 1;
            this.outputLabel.Text = "Customer Name:\r\nPizzas Ordered:";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Red;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(12, 9);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(106, 44);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // pizza1Output
            // 
            this.pizza1Output.AutoSize = true;
            this.pizza1Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pizza1Output.Location = new System.Drawing.Point(108, 141);
            this.pizza1Output.Name = "pizza1Output";
            this.pizza1Output.Size = new System.Drawing.Size(95, 29);
            this.pizza1Output.TabIndex = 3;
            this.pizza1Output.Text = "Pizza 1:";
            // 
            // pizza2Output
            // 
            this.pizza2Output.AutoSize = true;
            this.pizza2Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pizza2Output.Location = new System.Drawing.Point(390, 141);
            this.pizza2Output.Name = "pizza2Output";
            this.pizza2Output.Size = new System.Drawing.Size(95, 29);
            this.pizza2Output.TabIndex = 4;
            this.pizza2Output.Text = "Pizza 2:";
            // 
            // orderButton
            // 
            this.orderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderButton.Location = new System.Drawing.Point(245, 421);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(133, 62);
            this.orderButton.TabIndex = 6;
            this.orderButton.Text = "Order!";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // totalOutput
            // 
            this.totalOutput.AutoSize = true;
            this.totalOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalOutput.Location = new System.Drawing.Point(239, 382);
            this.totalOutput.Name = "totalOutput";
            this.totalOutput.Size = new System.Drawing.Size(166, 36);
            this.totalOutput.TabIndex = 7;
            this.totalOutput.Text = "Total Cost: ";
            // 
            // OutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 489);
            this.Controls.Add(this.totalOutput);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.pizza2Output);
            this.Controls.Add(this.pizza1Output);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "OutputForm";
            this.Text = "Skills Pizza";
            this.Load += new System.EventHandler(this.OutputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label pizza1Output;
        private System.Windows.Forms.Label pizza2Output;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Label totalOutput;
    }
}