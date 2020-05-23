using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MegaDesk_Wood
{
    public partial class SearchQuotes : Form
    {
        public List<string> listMaterial = new List<string>();
        public SearchQuotes()
        {
            InitializeComponent();
            dataGridSearchQuotes.Visible = false;

            //enum and combobox
            listMaterial.Insert(0, "Select");
            foreach (var name in Enum.GetNames(typeof(DeskMaterial)))
            {
                listMaterial.Add(name);
                cmbSearchMaterial.Items.Add(name);
            }
        }

        private void SearchQuotes_Load(object sender, EventArgs e)
        {
            try
            {
                var json = @"../../docs/quotes.json";
                using (StreamReader streamReader = new StreamReader(json))
                {
                    string readQuotes = streamReader.ReadToEnd();
                    List<NewQuote> newQuote = JsonConvert.DeserializeObject<List<NewQuote>>(readQuotes);
                    dataGridSearchQuotes.DataSource = newQuote.Select(parameter => new
                    {
                        Customer = parameter.SpecName,
                        Date = parameter.SpecDate.ToString("dd MMMM yyyy"),
                        Material = parameter.SpecMaterial,
                        Width = parameter.SpecWidth,
                        Depth = parameter.SpecDepth,
                        Drawers = parameter.SpecDrawers,
                        Shipping = parameter.SpecRush,
                        Total = parameter.SpecTotal

                    }).ToList();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Error: " + ea.Message);
                Close();
            }
        }

        // cited works:
        // stackoverflow.com/questions/13173915/search-for-value-in-datagridview-in-a-column/13174039
        // www.codeproject.com/Questions/657059/Row-associated-with-the-currency-managers-position

        private void cmbSearchMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchValue = cmbSearchMaterial.Text;
            dataGridSearchQuotes.Visible = true;

            try
            {
                foreach (DataGridViewRow row in dataGridSearchQuotes.Rows)
                {

                    if (row.Cells[2].Value.ToString().Equals(searchValue))
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridSearchQuotes.DataSource];
                        currencyManager1.SuspendBinding();
                        row.Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    else if (row.Cells[2].Value.ToString() != searchValue)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridSearchQuotes.DataSource];
                        currencyManager1.SuspendBinding();
                        row.Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCloseSearch_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = new MainMenu();
            viewMainMenu.Tag = this;
            viewMainMenu.Show(this);
            Hide();
        }
    }
}
