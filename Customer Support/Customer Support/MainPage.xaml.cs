using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataGrid.Exporting;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace Customer_Support
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void searchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            this.dataGrid.SearchController.AllowFiltering = true;
            this.dataGrid.SearchController.Search(SearchBar.Text);
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                dataGrid.SearchController.ClearSearch();
            }

        }

        private void OnExportClicked(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream();
            DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
            DataGridPdfExportingOption option = new DataGridPdfExportingOption();
            option.CanFitAllColumnsInOnePage = true;
            var pdfDoc = new PdfDocument();
            pdfDoc = pdfExport.ExportToPdf(this.dataGrid, option);
            pdfDoc.Save(stream);
            pdfDoc.Close(true);
            SaveServices saveService = new();
            saveService.SaveAndView("Support_logs.pdf", "application/pdf", stream);

        }

        private void CustomerComboBox_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
        {
            dataGrid.SortColumnDescriptions.Clear();
            if (e.AddedItems != null && e.AddedItems.Count > 0 && e.AddedItems[0] != null)
            {
                dataGrid.SortColumnDescriptions.Add(new SortColumnDescription()
                {
                    ColumnName = e.AddedItems[0]!.ToString()!,
                    SortDirection = System.ComponentModel.ListSortDirection.Ascending

                });
            }
        }
    }
}
