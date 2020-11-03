using Forms.Models;
using Forms.Tools;
using Newtonsoft.Json;
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
        public bool LiveReload { get; set; } = false;
        public FormData Formulaire { get; set; }
        public string FormulaireJson { get; set; } = string.Empty;
        JsonSerializerSettings jsonSettings = new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate };

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Formulaire = generator.GenerateData();
            generator.GenerateGrid(Formulaire.Field, GridRendu);
            FormulaireJson = JsonConvert.SerializeObject(Formulaire, Formatting.Indented, jsonSettings);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearGrid();
            //Formulaire = JsonConvert.DeserializeObject<FormData>(FormulaireJson, jsonSettings);
            generator.GenerateGrid(Formulaire.Field, GridRendu);
            
        }

        private void ClearGrid()
        {
            GridRendu.Children.Clear();
            GridRendu.ColumnDefinitions.Clear();
            GridRendu.RowDefinitions.Clear();
        }
    }
}
