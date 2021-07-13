using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChillExe.Controls
{
    public partial class ElementsList : UserControl
    {
        private readonly Regex cellStringValueRegex = new Regex(@"^http[s]?");
        public ElementsList()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {

        }

        private void ImportButton_Click(object sender, EventArgs e)
        {

        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            if (urlList.Rows.Count <= 0)
                return;

            urlList.Rows.Clear();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
        }

        private void UrlList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (urlList.Rows.Count <= 0 || e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCellCollection currentRowCells = urlList.Rows[e.RowIndex].Cells;
            var urlValue = currentRowCells[0].Value.ToString();

            if (!cellStringValueRegex.IsMatch(urlValue))
                urlList.Rows[e.RowIndex].ErrorText = "Text specified is not a http/https";
            else
                urlList.Rows[e.RowIndex].ErrorText = "";

            // Setting value in Last Update column
            currentRowCells[1].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
