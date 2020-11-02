using Forms.Enum;
using Forms.Models;
using Forms.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Forms
{
    public partial class MainWindow : Window
    {

        FormData formData = new FormData();

        #region Constructeur

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GeneratorHelpers generator = new GeneratorHelpers();

            formData = generator.GenerateData();
            generator.GenerateGrid(formData.Field, ContentGrid);
        }
    }
}
