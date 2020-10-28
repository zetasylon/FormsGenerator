using Forms.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Contient toutes les données du form
        /// </summary>
        FormData formData = new FormData();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeFormData();
            GridMainContent.Children.Add(GenerateGrid(formData));
        }


        /// <summary>
        /// Transforme le models en grid avec tout les élements
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        private UIElement GenerateGrid(FormData formData)
        {
            return new Grid();
        }

        /// <summary>
        /// Initialisation de l'objet formData avec des données de test
        /// </summary>
        private void InitializeFormData()
        {
            formData = new FormData()
            {
                Name = "Formulaire_Test",
                Fields = new List<FieldData>()
                {
                    new FieldData()
                    {
                        Name = "MainGrid",
                        TypeComponent = Enum.EnumTypeComponent.Grid,
                        Fields = new List<FieldData>()
                        {
                            new FieldData()
                            {
                                Name = "Grid_0",
                                TypeComponent = Enum.EnumTypeComponent.Grid,
                                Fields = new List<FieldData>()
                                {
                                    new FieldData()
                                    {
                                        Name = "Grid_0C0",
                                        TypeComponent = Enum.EnumTypeComponent.Grid,
                                        Fields = new List<FieldData>()
                                        {
                                            new FieldData()
                                            {
                                                Name="Grid_0C0_TextBox",
                                                TypeComponent = Enum.EnumTypeComponent.Textbox
                                            }
                                        }
                                    },
                                    new FieldData()
                                    {
                                        Name= "Grid_0C1",
                                        TypeComponent= Enum.EnumTypeComponent.Grid,
                                        Fields = new List<FieldData>()
                                        {
                                            new FieldData()
                                            {
                                                Name = "Grid_0C1_Radiobutton"
                                            }
                                        }
                                    }
                                }
                            },
                            new FieldData()
                            {
                                Name = "Grid_1",
                                TypeComponent = Enum.EnumTypeComponent.Grid,
                                Fields = new List<FieldData>()
                                {
                                    new FieldData()
                                    {
                                        Name = "Grid_1R0",
                                        TypeComponent = Enum.EnumTypeComponent.Grid,
                                        Fields = new List<FieldData>()
                                        {
                                            new FieldData()
                                            {
                                                Name = "Grid_1R0_Label",
                                                TypeComponent= Enum.EnumTypeComponent.Label
                                            }
                                        }
                                    },
                                    new FieldData()
                                    {
                                        Name = "Grid_1R1",
                                        TypeComponent = Enum.EnumTypeComponent.Grid,
                                        Fields  = new List<FieldData>()
                                        {
                                            new FieldData()
                                            {
                                                Name= "Grid_1R1_C0",
                                                TypeComponent = Enum.EnumTypeComponent.Grid,
                                                Fields = new List<FieldData>()
                                                {
                                                    new FieldData()
                                                    {
                                                        Name = "Grid_1R1_C0_Combobox",
                                                        TypeComponent= Enum.EnumTypeComponent.Combobox
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
