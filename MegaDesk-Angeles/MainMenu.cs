using System;
using System.Windows.Forms;

namespace MegaDesk_Wood
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

        }

        private void btnAddNewQuote_Click(object sender, EventArgs e)
        {
            AddQuote viewAddQuote = new AddQuote();
            viewAddQuote.Tag = this;
            viewAddQuote.Show(this);
            Hide();
        }

        private void btnViewQuotes_Click(object sender, EventArgs e)
        {
            ViewAllQuotes viewViewAllQuotes = new ViewAllQuotes();
            viewViewAllQuotes.Tag = this;
            viewViewAllQuotes.Show(this);
            Hide();
        }

        private void btnSearchQuotes_Click(object sender, EventArgs e)
        {
            SearchQuotes viewSearchQuotes = new SearchQuotes();
            viewSearchQuotes.Tag = this;
            viewSearchQuotes.Show(this);
            Hide();
        }

        private void btnExitMainMenu_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close MegaDesk?";
            string title = "Close MegaDesk";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            DialogResult result = MessageBox.Show(message, title, buttons, icon);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }


    }
}
