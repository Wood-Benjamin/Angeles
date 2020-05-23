using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MegaDesk_Wood
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
        }

        // Cited Works:
        // docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
        // jsoneditoronline.org
        // www.youtube.com/playlist?list=PLcua2z32WXCI5AudSzqnO-shKgpG4JsK_
        // www.youtube.com/playlist?list=PLFDH5bKmoNqyDKntkVv-NURTAlPIhMPqA
        // youtu.be/RKw5UM0Hi0g
        // json2csharp.com

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {
            try
            {
                var json = @"../../docs/quotes.json";
                using (StreamReader streamReader = new StreamReader(json))
                {
                    string readQuotes = streamReader.ReadToEnd();
                    List<NewQuote> newQuote = JsonConvert.DeserializeObject<List<NewQuote>>(readQuotes);
                    dataGridViewAllQuotes.DataSource = newQuote.Select(parameter => new
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = new MainMenu();
            viewMainMenu.Tag = this;
            viewMainMenu.Show(this);
            Hide();
        }
    }
}
