namespace MegaDesk_Wood
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnAddNewQuote = new System.Windows.Forms.Button();
            this.btnViewQuotes = new System.Windows.Forms.Button();
            this.btnSearchQuotes = new System.Windows.Forms.Button();
            this.btnExitMainMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddNewQuote
            // 
            this.btnAddNewQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnAddNewQuote.Location = new System.Drawing.Point(51, 47);
            this.btnAddNewQuote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddNewQuote.Name = "btnAddNewQuote";
            this.btnAddNewQuote.Size = new System.Drawing.Size(179, 50);
            this.btnAddNewQuote.TabIndex = 0;
            this.btnAddNewQuote.Text = "Add New Quote";
            this.btnAddNewQuote.UseVisualStyleBackColor = true;
            this.btnAddNewQuote.Click += new System.EventHandler(this.btnAddNewQuote_Click);
            // 
            // btnViewQuotes
            // 
            this.btnViewQuotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnViewQuotes.Location = new System.Drawing.Point(51, 122);
            this.btnViewQuotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewQuotes.Name = "btnViewQuotes";
            this.btnViewQuotes.Size = new System.Drawing.Size(179, 50);
            this.btnViewQuotes.TabIndex = 1;
            this.btnViewQuotes.Text = "View Quotes";
            this.btnViewQuotes.UseVisualStyleBackColor = true;
            this.btnViewQuotes.Click += new System.EventHandler(this.btnViewQuotes_Click);
            // 
            // btnSearchQuotes
            // 
            this.btnSearchQuotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnSearchQuotes.Location = new System.Drawing.Point(51, 201);
            this.btnSearchQuotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchQuotes.Name = "btnSearchQuotes";
            this.btnSearchQuotes.Size = new System.Drawing.Size(179, 50);
            this.btnSearchQuotes.TabIndex = 2;
            this.btnSearchQuotes.Text = "Search Quotes";
            this.btnSearchQuotes.UseVisualStyleBackColor = true;
            this.btnSearchQuotes.Click += new System.EventHandler(this.btnSearchQuotes_Click);
            // 
            // btnExitMainMenu
            // 
            this.btnExitMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnExitMainMenu.Location = new System.Drawing.Point(51, 281);
            this.btnExitMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExitMainMenu.Name = "btnExitMainMenu";
            this.btnExitMainMenu.Size = new System.Drawing.Size(179, 50);
            this.btnExitMainMenu.TabIndex = 3;
            this.btnExitMainMenu.Text = "Exit";
            this.btnExitMainMenu.UseVisualStyleBackColor = true;
            this.btnExitMainMenu.Click += new System.EventHandler(this.btnExitMainMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(367, 331);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 55);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mega Desk";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MegaDesk_Wood.Properties.Resources.megaDeskBackground;
            this.ClientSize = new System.Drawing.Size(699, 395);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExitMainMenu);
            this.Controls.Add(this.btnSearchQuotes);
            this.Controls.Add(this.btnViewQuotes);
            this.Controls.Add(this.btnAddNewQuote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mega Desk 2.0 - Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewQuote;
        private System.Windows.Forms.Button btnViewQuotes;
        private System.Windows.Forms.Button btnSearchQuotes;
        private System.Windows.Forms.Button btnExitMainMenu;
        private System.Windows.Forms.Label label1;
    }
}

