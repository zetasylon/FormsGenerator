using Forms.Models;
using Forms.Tools;
using Newtonsoft.Json;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Forms
{
    [AddINotifyPropertyChangedInterface]
    public partial class FormsGenerator : Window
    {
        GeneratorHelpers generator = new GeneratorHelpers();
        public ObservableCollection<FormData> FormulaireList { get; set; }
        public FormData Formulaire { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Formulaire = generator.GenerateData();
            generator.GenerateGrid(Formulaire, null, GridRendu);
            FormulaireList = new ObservableCollection<FormData>() { Formulaire };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearGrid();
            generator.GenerateGrid((FormData)TreeViewField.SelectedItem, null, GridRendu);

        }

        private void ClearGrid()
        {
            GridRendu.Children.Clear();
            GridRendu.ColumnDefinitions.Clear();
            GridRendu.RowDefinitions.Clear();
        }

        private void ButtonAddChildren_Click(object sender, RoutedEventArgs e)
        {
            FieldData field = (sender as Button).DataContext as FieldData;
            var child = new FieldData() { Name = "Unknow" };
            field.Fields.Add(child);
        }

        private void ButtonRemoveChildren_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCreateForms_Click(object sender, RoutedEventArgs e)
        {
            FormulaireList.Add(new FormData()
            {
                Name = "New Forms",
                Field = new FieldData()
                {
                    Name = "FirstNode"
                }
            });
        }
    }
}
