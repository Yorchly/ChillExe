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

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void exportButton_Click(object sender, EventArgs e)
        {

        }

        private void importButton_Click(object sender, EventArgs e)
        {

        }

        private void cleanButton_Click(object sender, EventArgs e)
        {

        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
        }

        private void addButton_Click(object sender, EventArgs e)
        {
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0 || e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCellCollection currentRowCells = dataGridView1.Rows[e.RowIndex].Cells;
            var urlValue = currentRowCells[0].Value.ToString();

            if (!cellStringValueRegex.IsMatch(urlValue))
                dataGridView1.Rows[e.RowIndex].ErrorText = "Text specified is not a http/https";
            else
                dataGridView1.Rows[e.RowIndex].ErrorText = "";

            // Setting value in Last Update column
            currentRowCells[1].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
