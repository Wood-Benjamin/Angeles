using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MegaDesk_Wood
{
    public partial class AddQuote : Form
    {
        DeskQuote quote = new DeskQuote();
        Desk desk = new Desk();
        public List<string> listMaterial = new List<string>();
        int rushOrder;
        public AddQuote()
        {
            InitializeComponent();
            CurrentDate();
            txtCustName.Focus();

            //enum and combobox
            listMaterial.Insert(0, "Select");
            foreach (var name in Enum.GetNames(typeof(DeskMaterial)))
            {
                listMaterial.Add(name);
                cmbDeskMaterial.Items.Add(name);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (numWidth.Text.ToString().Trim() == "")
            {
                numWidth.Text = "24";
            }
            else if (numDepth.Text.ToString().Trim() == "")
            {
                numWidth.Text = "24";
            }
            else if (numDrawers.Text.ToString().Trim() == "")
            {
                numWidth.Text = "0";
            }
            MainMenu viewMainMenu = (MainMenu)Tag;
            viewMainMenu.Show();
            Close();
        }

        public void CurrentDate()
        {
            // set and display current date
            DateTime now = DateTime.Now;
            lblQuoteDate.Text = now.ToString("dd MMMM yyyy");
        }

        private void cmbDeskMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewDesk();
            //CalMaterialCost();This is done in the quote refresh method
            QuoteRefresh();
        }

        private void numWidth_TextChanged(object sender, EventArgs e)
        {
            //CalSurfaceAreaCost();This is done in the quote refresh method
            NewDesk();
            QuoteRefresh();
        }

        private void numDepth_TextChanged(object sender, EventArgs e)
        {
            //CalSurfaceAreaCost();This is done in the quote refresh method
            NewDesk();
            QuoteRefresh();
        }

        private void numDrawers_TextChanged(object sender, EventArgs e)
        {
            //CalDrawerCost(); This is done in the quote refresh method
            NewDesk();//TT need this to update desk to get quote
            QuoteRefresh();
        }
        public Desk NewDesk()
        {
            int.TryParse(numWidth.Text, out int width);
            int.TryParse(numDepth.Text, out int depth);
            int.TryParse(numDrawers.Text, out int drawers);

            desk.Width = width;
            desk.Depth = depth;
            desk.Drawers = drawers;
            //TT==This isn't being set in Desk because constructor is called before selected
            desk.Rush = rushOrder;
            desk.Material = cmbDeskMaterial.Text;

            return desk;
        }
        public DeskQuote QuoteRefresh()
        {
            quote.QuoteDate = DateTime.Parse(lblQuoteDate.Text);
            quote.CustomerName = txtCustName.Text;
            quote.desk = desk;
            quote.MaterialCost = CalMaterialCost();
            quote.SurfaceAreaCost = CalSurfaceAreaCost();
            quote.DrawerCost = CalDrawerCost();
            quote.RushCost = CalRushOrderCost();
            quote.QuoteTotal = CalQuoteTotal();

            label31.Text = ($"${DeskQuote.BASEPRICE.ToString()}");
            label32.Text = ($"${CalSurfaceAreaCost().ToString()}");
            label33.Text = ($"${CalMaterialCost().ToString()}");
            label34.Text = ($"${CalDrawerCost().ToString()}");
            label35.Text = ($"${CalRushOrderCost().ToString()}");
            label36.Text = ($"${CalQuoteTotal().ToString()}");
            lblSurfaceArea.Text = desk.SurfaceArea.ToString();
            return quote;
        }
        public int CalMaterialCost()
        {
            switch (cmbDeskMaterial.Text.ToString().Trim())
            {
                case "Laminate":
                    return 100;
                case "Oak":
                    return 200;
                case "Pine":
                    return 50;
                case "Rosewood":
                    return 300;
                case "Veneer":
                    return 125;
                default:
                    return 0;
            }
        }
        public int CalSurfaceAreaCost()
        {
            if (desk.SurfaceArea > DeskQuote.BASESURFACE)
            {
                return (desk.SurfaceArea - DeskQuote.BASESURFACE) * DeskQuote.OVERSURFACE;
            }
            else
            {
                return 0;
            }
        }
        public int CalDrawerCost()
        {
            if (desk.Drawers > 0)
            {
                return (desk.Drawers * 50);
            }
            else
            {
                return 0;
            }
        }



        public int CalRushOrderCost()
        {
            DeskQuote.rushOrderPrices = DeskQuote.GetRushOrderPrices();
            if (rushOrder == 14)
            {
                return 0;
            }
            else if (rushOrder == 3)
            {
                if (desk.SurfaceArea < DeskQuote.BASESURFACE)
                {
                    return DeskQuote.rushOrderPrices[0, 0];
                }
                else if (desk.SurfaceArea >= DeskQuote.BASESURFACE && desk.SurfaceArea <= DeskQuote.LARGESURFACE)
                {
                    return DeskQuote.rushOrderPrices[0, 1];
                }
                else
                {
                    return DeskQuote.rushOrderPrices[0, 2];
                }
            }
            else if (rushOrder == 5)
            {
                if (desk.SurfaceArea < DeskQuote.BASESURFACE)
                {
                    return DeskQuote.rushOrderPrices[1, 0];
                }
                else if (desk.SurfaceArea >= DeskQuote.BASESURFACE && desk.SurfaceArea <= DeskQuote.LARGESURFACE)
                {
                    return DeskQuote.rushOrderPrices[1, 1];
                }
                else
                {
                    return DeskQuote.rushOrderPrices[1, 2];
                }
            }
            else if (rushOrder == 7)
            {
                if (desk.SurfaceArea < DeskQuote.BASESURFACE)
                {
                    return DeskQuote.rushOrderPrices[2, 0];
                }
                else if (desk.SurfaceArea >= DeskQuote.BASESURFACE && desk.SurfaceArea <= DeskQuote.LARGESURFACE)
                {
                    return DeskQuote.rushOrderPrices[2, 1];
                }
                else
                {
                    return DeskQuote.rushOrderPrices[2, 2];
                }
            }
            else
            {
                return 1;
            }
        }
        public int CalQuoteTotal()
        {
            try
            {
                int QuoteTotal = DeskQuote.BASEPRICE + quote.SurfaceAreaCost + quote.DrawerCost + quote.MaterialCost + quote.RushCost;
                return QuoteTotal;
            }
            catch (FormatException e)
            {
                MessageBox.Show($"Sorry, something has gone wrong.\n\n{e.Message}");
                return 0;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
        private void txtCustName_Validating(object sender, CancelEventArgs e)
        {

        }

        private void numWidth_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(numWidth.Text, out int WidthInput) == true)
            {
                if (WidthInput < Desk.MINWIDTH || WidthInput > Desk.MAXWIDTH)
                {
                    //message
                    //message
                    MessageBox.Show($"Oops, Check your Width.\n\n\nRound to the nearest Inch between {Desk.MINWIDTH} and {Desk.MAXWIDTH} inches.");
                    numWidth.Text = String.Empty;
                    answer_Enter(this, EventArgs.Empty);
                    numWidth.BackColor = Color.Red;
                    numWidth.Focus();

                    numWidth.Text = String.Empty;
                    answer_Enter(this, EventArgs.Empty);
                    numWidth.BackColor = Color.Red;
                    numWidth.Focus();
                }
                else
                {
                    numWidth.BackColor = default(Color);
                    QuoteRefresh();
                }
            }
            else if (numWidth.Text.Trim() == "")
            {
                //message
                string message = "Click Ok to go back or Cancel to Quit.";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result = MessageBox.Show(message, title, buttons, icon);
                if (result == DialogResult.Cancel)
                {
                    MainMenu viewMainMenu = new MainMenu();
                    viewMainMenu.Tag = this;
                    viewMainMenu.Show(this);
                    Hide();
                }
            }
        }

        private void numWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                //message
                MessageBox.Show("Only Numbers are allowed, please try again.");
                e.Handled = true;
                numWidth.BackColor = Color.Red;
                numWidth.Focus();
            }
            else
            {
                numWidth.BackColor = default(Color);
                QuoteRefresh();
            }
        }

        private void numDepth_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(numDepth.Text, out int DepthInput) == true)
            {
                if (DepthInput < Desk.MINDEPTH || DepthInput > Desk.MAXDEPTH)
                {
                    //message
                    MessageBox.Show($"Oops, Check your Depth.\n\n\nRound to the nearest Inch between {Desk.MINDEPTH} and {Desk.MAXDEPTH} inches.");
                    numDepth.Text = String.Empty;
                    answer_Enter(this, EventArgs.Empty);
                    numDepth.BackColor = Color.Red;
                    numDepth.Focus();
                }
                else
                {
                    numDepth.BackColor = default(Color);
                    QuoteRefresh();
                }
            }
            else if (numDepth.Text.Trim() == "")
            {
                //message
                string message = "Click Ok to go back or Cancel to Quit.";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result = MessageBox.Show(message, title, buttons, icon);
                if (result == DialogResult.Cancel)
                {
                    MainMenu viewMainMenu = new MainMenu();
                    viewMainMenu.Tag = this;
                    viewMainMenu.Show(this);
                    Hide();
                }
            }
        }

        private void numDepth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                //message
                MessageBox.Show("Only Numbers are allowed, please try again.");
                e.Handled = true;
                numDepth.BackColor = Color.Red;
                numDepth.Focus();
            }
            else
            {
                numDepth.BackColor = default(Color);
                QuoteRefresh();
            }
        }

        private void numDrawers_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(numDrawers.Text, out int DrawersInput) == true)
            {
                if (DrawersInput < Desk.MINDRAWERS || DrawersInput > Desk.MAXDRAWERS)
                {
                    //message
                    MessageBox.Show($"Oops, Check your Number of Drawers.\n\n\nSelect between {Desk.MINDRAWERS} and {Desk.MAXDRAWERS} drawers.");
                    numDrawers.Text = String.Empty;
                    answer_Enter(this, EventArgs.Empty);
                    numDrawers.BackColor = Color.Red;
                    numDrawers.Focus();
                }
                else
                {
                    numDrawers.BackColor = default(Color);
                    QuoteRefresh();
                }
            }
            else if (numDrawers.Text.Trim() == "")
            {
                //message
                string message = "Click Ok to go back or Cancel to Quit.";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result = MessageBox.Show(message, title, buttons, icon);
                if (result == DialogResult.Cancel)
                {
                    MainMenu viewMainMenu = new MainMenu();
                    viewMainMenu.Tag = this;
                    viewMainMenu.Show(this);
                    Hide();
                }
            }
        }

        private void numDrawers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                //message
                MessageBox.Show("Only Numbers are allowed, please try again.");
                e.Handled = true;
                numDrawers.BackColor = Color.Red;
                numDrawers.Focus();
            }
            else
            {
                numDrawers.BackColor = default(Color);
                QuoteRefresh();
            }
        }


        private void rd14Days_CheckedChanged(object sender, EventArgs e)
        {
            rushOrder = 14;
            QuoteRefresh();
        }

        private void rd7Days_CheckedChanged(object sender, EventArgs e)
        {
            rushOrder = 7;
            QuoteRefresh();
        }

        private void rd5Days_CheckedChanged(object sender, EventArgs e)
        {
            rushOrder = 5;
            QuoteRefresh();
        }

        private void rd3Days_CheckedChanged(object sender, EventArgs e)
        {
            rushOrder = 3;
            QuoteRefresh();
        }

        private void lblQuoteDate_TextChanged(object sender, EventArgs e)
        {
            QuoteRefresh();
        }

        private void txtCustName_TextChanged(object sender, EventArgs e)
        {
            QuoteRefresh();
        }

        private bool custNameValidate()
        {
            if (txtCustName.Text.Trim() == "")
            {
                //message
                MessageBox.Show($"Oops, You must enter a name");
                txtCustName.Text = String.Empty;
                answer_Enter(this, EventArgs.Empty);
                txtCustName.BackColor = Color.Red;
                txtCustName.Focus();
                return false;
            }
            else
            {
                txtCustName.BackColor = default(Color);
                QuoteRefresh();
                return true;
            }

        }

        private bool rushOrderShippingValidate()
        {
            int chkShippingSelected = CalRushOrderCost();
            if (chkShippingSelected == 1)
            {
                MessageBox.Show($"Oops, You must select Delivery Time");
                return false;

            }
            else
            {
                return true;
            }
        }

        private bool materialValidate()
        {

            if (cmbDeskMaterial.Text == "")
            {
                MessageBox.Show($"Oops, You must select desk material");
                return false;

            }
            else
            {
                return true;
            }
        }

        private bool drawersValidate()
        {
            if (numDrawers.Text.Trim() == "")
            {
                MessageBox.Show($"Oops, You must select number of drawers");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool widthNotEmptyValidate()
        {
            if (numWidth.Text.Trim() == "")
            {
                MessageBox.Show($"Oops, You must enter the Width");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool depthNotEmptyValidate()
        {
            if (numDepth.Text.Trim() == "")
            {
                MessageBox.Show($"Oops, You must enter Depth");
                return false;
            }
            else
            {
                return true;
            }
        }


        private void btnSubmitDisplayQuote_Click(object sender, EventArgs e)
        {

            if (custNameValidate() && widthNotEmptyValidate() && depthNotEmptyValidate() && materialValidate() && drawersValidate() && rushOrderShippingValidate())
            {
                Desk desk = new Desk()
                {
                    Material = cmbDeskMaterial.Text,
                    Width = int.Parse(numWidth.Text),
                    Depth = int.Parse(numDepth.Text),
                    Drawers = int.Parse(numDrawers.Text),
                    Rush = rushOrder
                };
                DeskQuote quote = new DeskQuote()
                {
                    CustomerName = txtCustName.Text,
                    QuoteDate = DateTime.Parse(lblQuoteDate.Text),
                    desk = desk,
                    QuoteTotal = CalQuoteTotal(),
                    MaterialCost = CalMaterialCost(),
                    SurfaceAreaCost = CalSurfaceAreaCost(),
                    DrawerCost = CalDrawerCost(),
                    RushCost = CalRushOrderCost()
                };

                DisplayQuote viewQuote = new DisplayQuote(desk, quote);
                this.Hide();
                viewQuote.Show();
            }

        }

        private void AddQuote_Load(object sender, EventArgs e)
        {
            int[,] rushOrderPrices4Table = DeskQuote.GetRushOrderPrices();
            label15.Text = "$" + rushOrderPrices4Table[0, 0].ToString();
            label20.Text = "$" + rushOrderPrices4Table[0, 1].ToString();
            label23.Text = "$" + rushOrderPrices4Table[0, 2].ToString();
            label16.Text = "$" + rushOrderPrices4Table[1, 0].ToString();
            label19.Text = "$" + rushOrderPrices4Table[1, 1].ToString();
            label22.Text = "$" + rushOrderPrices4Table[1, 2].ToString();
            label17.Text = "$" + rushOrderPrices4Table[2, 0].ToString();
            label18.Text = "$" + rushOrderPrices4Table[2, 1].ToString();
            label21.Text = "$" + rushOrderPrices4Table[2, 2].ToString();


        }
    }
}
