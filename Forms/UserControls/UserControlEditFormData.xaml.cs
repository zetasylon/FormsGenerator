using Forms.Enum;
using Forms.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forms.UserControls
{

    [AddINotifyPropertyChangedInterface]
    public partial class UserControlEditFormData : UserControl
    {
        public ObservableCollection<EnumDataValuesType> ListDataValuesTypesDispo { get; set; } = new ObservableCollection<EnumDataValuesType>();

        private FieldData field;

        public UserControlEditFormData()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            field = new FieldData();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext != null)
            {
                field = DataContext as FieldData;
                ChangeDataValueTypeDispo();
            }
        }

        private void ChangeDataValueTypeDispo()
        {
            ListDataValuesTypesDispo.Clear();
            foreach (var dataType in (EnumDataValuesType[])System.Enum.GetValues(typeof(EnumDataValuesType)))
            {
                if (!field.DataValueType.Contains(dataType)) ListDataValuesTypesDispo.Add(dataType);
            }
        }

        private void ButtonAddProperty_Click(object sender, RoutedEventArgs e)
        {
            if (ListeViewProprieteDispo.SelectedItem != null)
            {
                field.DataValueType.Add((EnumDataValuesType)ListeViewProprieteDispo.SelectedItem);
                ChangeDataValueTypeDispo();
            }

        }

        private void ButtonRemoveProperty_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewProprieteUtilise.SelectedItem != null)
            {
                field.DataValueType.Remove((EnumDataValuesType)ListViewProprieteUtilise.SelectedItem);
                ChangeDataValueTypeDispo();
            }
        }
    }
}
