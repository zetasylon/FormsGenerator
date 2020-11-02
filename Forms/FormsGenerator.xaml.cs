using Forms.Models;
using Forms.Tools;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Forms
{
    [AddINotifyPropertyChangedInterface]
    public partial class FormsGenerator : Window
    {
        GeneratorHelpers generator = new GeneratorHelpers();
        public bool LiveReload { get; set; } = true;
        public FormData Formulaire { get; set; }
        public string FormulaireJson { get; set; } = string.Empty;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Formulaire = generator.GenerateData();
            generator.GenerateGrid(Formulaire.Field, GridRendu);
            FormulaireJson = JsonSerializer.Serialize(Formulaire, options);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearGrid();
            Formulaire = JsonSerializer.Deserialize<FormData>(FormulaireJson);
            generator.GenerateGrid(Formulaire.Field, GridRendu);
        }

        private void ClearGrid()
        {
            GridRendu.Children.Clear();
            GridRendu.ColumnDefinitions.Clear();
            GridRendu.RowDefinitions.Clear();
        }

        private void SearchtextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int pos = TextBoxJson.Text.ToLower().IndexOf(SearchtextBox.Text.ToLower());
            if (pos != -1)
            {
                TextBoxJson.SelectionStart = pos;
                TextBoxJson.SelectionLength = SearchtextBox.Text.Length;
                TextBoxJson.Select(TextBoxJson.SelectionStart, TextBoxJson.SelectionLength);
                TextBoxJson.ScrollToLine(TextBoxJson.GetLineIndexFromCharacterIndex(TextBoxJson.SelectionStart));
                // MessageBox("Error");
            }
        }
    }
}
