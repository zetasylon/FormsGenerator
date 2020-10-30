using Forms.Enum;
using Forms.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        /// <summary>
        /// Grille principal du form
        /// </summary>
        Grid mainGrid = new Grid();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeFormDataTest();
            //InitializeFormDataAbcd();

            GenerateGrid(formData.Field, mainGrid);
            scrollViewer.Children.Add(mainGrid);
        }


        /// <summary>
        /// Transforme le models en grid avec tout les élements
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        private void GenerateGrid(FieldData fieldData, Grid currentGrid)
        {

            foreach (var item in fieldData.Fields)
            {
                Grid subgrid = new Grid();
                Control control = new Control();

                switch (item.TypeComponent)
                {
                    case EnumTypeComponent.NonRenseigne:
                        break;
                    case EnumTypeComponent.Combobox:
                        break;
                    case EnumTypeComponent.Label:
                        break;
                    case EnumTypeComponent.Grid:

                        subgrid.VerticalAlignment = GetVerticalAlignment(item.VerticalAlignement);
                        subgrid.HorizontalAlignment = GetHorizontalAlignment(item.HorizontalAlignement);
                        if (!string.IsNullOrEmpty(item.BackgroundHexColor)) subgrid.Background = (Brush)new BrushConverter().ConvertFromString(item.BackgroundHexColor);

                        if (item.ColumnIndex > currentGrid.ColumnDefinitions.Count - 1)
                        {
                            currentGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(item.HorizontalSpaceUsage, GetGridUnitType(item.HorizontalSpaceType)) });
                            Grid.SetColumn(subgrid, item.ColumnIndex);
                        }
                        if (item.RowIndex > currentGrid.RowDefinitions.Count - 1)
                        {
                            currentGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(item.VerticalSpaceUsage, GetGridUnitType(item.VerticalSpaceType)) });
                            Grid.SetRow(subgrid, item.RowIndex);
                        }
                        if (item.ColumnSpan > 0) Grid.SetColumnSpan(subgrid, item.ColumnSpan);
                        if (item.RowSpan > 0) Grid.SetRowSpan(subgrid, item.RowSpan);

                        currentGrid.Children.Add(subgrid);

                        break;
                    case EnumTypeComponent.Checkbox:

                        control = GenerateCheckBox(item);
                        currentGrid.Children.Add(control);

                        break;
                    case EnumTypeComponent.RadioButton:

                        control = GenerateRadioButton(item);
                        currentGrid.Children.Add(control);

                        break;
                    case EnumTypeComponent.Textbox:

                        control = GenerateTextBox(item);
                        currentGrid.Children.Add(control);

                        break;
                    case EnumTypeComponent.OptionText:
                        break;

                    default:
                        break;
                }

                if (item.Fields != null && item.Fields.Count > 0)
                {
                    GenerateGrid(item, subgrid);
                }

            }
        }


        /// <summary>
        /// Initialisation de l'objet formData avec des données de test
        /// </summary>
        private void InitializeFormDataTest() => formData = new FormData()
        {
            Name = "Formulaire_Test",
            Field = new FieldData()
            {
                Name = "MainGrid",
                TypeComponent = EnumTypeComponent.Grid,
                HorizontalSpaceUsage = 1,
                HorizontalSpaceType = EnumSpaceType.Star,
                VerticalSpaceUsage = 1,
                VerticalSpaceType = EnumSpaceType.Star,
                BackgroundHexColor = "#000000",
                Fields = new List<FieldData>()
                    {
                        new FieldData()
                        {
                               Name = "Grid_0",
                               TypeComponent = EnumTypeComponent.Grid,
                               HorizontalSpaceUsage = 1,
                               HorizontalSpaceType = EnumSpaceType.Star,
                               VerticalSpaceUsage = 1,
                               VerticalSpaceType = EnumSpaceType.Star,
                               BackgroundHexColor ="#FF0000",
                               ColumnIndex=1,
                               RowIndex=1,
                               Fields = new List<FieldData>()
                               {
                                   new FieldData()
                                   {
                                       Name = "Grid_0C0",
                                       TypeComponent = EnumTypeComponent.Grid,
                                       HorizontalSpaceUsage=1,
                                       HorizontalSpaceType = EnumSpaceType.Star,
                                       ColumnSpan=2,
                                       VerticalSpaceUsage = 1,
                                       VerticalSpaceType = EnumSpaceType.Star,
                                       RowSpan=1,
                                       BackgroundHexColor ="#0000FF",
                                       ColumnIndex=0,
                                       RowIndex=0,
                                       Fields = new List<FieldData>()
                                       {
                                           new FieldData()
                                           {
                                               Name="Grid_0C0_TextBox",
                                               TypeComponent = EnumTypeComponent.Textbox,
                                               Margin = new Thickness(10),
                                               VerticalSpaceUsage=80,
                                               VerticalSpaceType= EnumSpaceType.Pixel,
                                               HorizontalSpaceUsage=200,
                                               HorizontalSpaceType = EnumSpaceType.Pixel,
                                               HorizontalAlignement= EnumHorizontalAlignement.Left,
                                               VerticalAlignement = EnumVerticalAlignement.Bottom,
                                               DataValueType = EnumDataValuesType.StringValue,
                                               Data = new DataValues()
                                               {
                                                   StringValue = "test d'un contenu"
                                               }

                                           }
                                       }
                                   },
                                   new FieldData()
                                   {
                                       Name= "Grid_0C1",
                                       TypeComponent= EnumTypeComponent.Grid,
                                       HorizontalSpaceUsage = 2,
                                       HorizontalSpaceType = EnumSpaceType.Star,
                                       VerticalSpaceUsage = 2,
                                       VerticalSpaceType = EnumSpaceType.Star,
                                       BackgroundHexColor ="#A1F2EC",
                                       ColumnIndex=1,
                                       RowIndex=1,
                                       Fields = new List<FieldData>()
                                       {
                                           new FieldData()
                                           {
                                               Name = "Grid_0C1_Radiobutton"
                                           }
                                       }
                                   }
                               }
                            }
                    }
            }
        };

        /// <summary>
        /// Initialisation de l'objet formData avec des données de test
        /// </summary>
        private void InitializeFormDataAbcd() => formData = new FormData()
        {
            Name = "Formulaire_ABCD",
            Field = new FieldData()
            {
                Name = "MainGrid",
                TypeComponent = EnumTypeComponent.Grid,
                HorizontalSpaceUsage = 1,
                HorizontalSpaceType = EnumSpaceType.Star,
                VerticalSpaceUsage = 1,
                VerticalSpaceType = EnumSpaceType.Star,
                BackgroundHexColor = "#000000",
                Fields = new List<FieldData>()
                {

                }

            }
        };

        #region DataHelpers

        private VerticalAlignment GetVerticalAlignment(EnumVerticalAlignement verticalAlignement)
        {
            return verticalAlignement switch
            {
                EnumVerticalAlignement.NonRenseigne => VerticalAlignment.Stretch,
                EnumVerticalAlignement.Stretch => VerticalAlignment.Stretch,
                EnumVerticalAlignement.Bottom => VerticalAlignment.Bottom,
                EnumVerticalAlignement.Center => VerticalAlignment.Center,
                EnumVerticalAlignement.Top => VerticalAlignment.Top,
                _ => VerticalAlignment.Center,
            };
        }

        private HorizontalAlignment GetHorizontalAlignment(EnumHorizontalAlignement horizontalAlignement)
        {
            return horizontalAlignement switch
            {
                EnumHorizontalAlignement.NonRenseigne => HorizontalAlignment.Stretch,
                EnumHorizontalAlignement.Left => HorizontalAlignment.Left,
                EnumHorizontalAlignement.Center => HorizontalAlignment.Center,
                EnumHorizontalAlignement.Right => HorizontalAlignment.Right,
                EnumHorizontalAlignement.Stretch => HorizontalAlignment.Stretch,
                _ => HorizontalAlignment.Left,
            };
        }

        private GridUnitType GetGridUnitType(EnumSpaceType spaceType)
        {
            return spaceType switch
            {
                EnumSpaceType.Pixel => GridUnitType.Pixel,
                EnumSpaceType.Star => GridUnitType.Star,
                EnumSpaceType.Auto => GridUnitType.Auto,
                _ => GridUnitType.Pixel,
            };
        }

        private object GetDataFromDataValuestype(FieldData fieldData)
        {
            return fieldData.DataValueType switch
            {
                EnumDataValuesType.BoolValue => fieldData.Data.BoolValue,
                EnumDataValuesType.ByteValue => fieldData.Data.ByteValue,
                EnumDataValuesType.DateValue => fieldData.Data.DateValue,
                EnumDataValuesType.FloatValue => fieldData.Data.FloatValue,
                EnumDataValuesType.IntValue => fieldData.Data.IntValue,
                EnumDataValuesType.StringValue => fieldData.Data.StringValue,
                _ => null,
            };
        }
        #endregion

        #region Control Generator

        /// <summary>
        /// Genere une textbox depuis un FieldData
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private TextBox GenerateTextBox(FieldData item)
        {
            return new TextBox()
            {
                Name = item.Name,
                Text = (string)GetDataFromDataValuestype(item),

                HorizontalAlignment = GetHorizontalAlignment(item.HorizontalAlignement),
                VerticalAlignment = GetVerticalAlignment(item.VerticalAlignement),

                Margin = item.Margin,
                Width = item.HorizontalSpaceUsage,
                Height = item.VerticalSpaceUsage
            };
        }

        /// <summary>
        /// Genere une CheckBox depuis un FieldData
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private CheckBox GenerateCheckBox(FieldData item)
        {
            return new CheckBox()
            {
                Name = item.Name,
                Content = (string)GetDataFromDataValuestype(item),

                HorizontalAlignment = GetHorizontalAlignment(item.HorizontalAlignement),
                VerticalAlignment = GetVerticalAlignment(item.VerticalAlignement),

                Margin = item.Margin,
                Width = item.HorizontalSpaceUsage,
                Height = item.VerticalSpaceUsage
            };
        }

        /// <summary>
        /// Genere une RadioButton depuis un FieldData
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private RadioButton GenerateRadioButton(FieldData item)
        {
            return new RadioButton()
            {
                Name = item.Name,
                Content = (string)GetDataFromDataValuestype(item),

                HorizontalAlignment = GetHorizontalAlignment(item.HorizontalAlignement),
                VerticalAlignment = GetVerticalAlignment(item.VerticalAlignement),

                Margin = item.Margin,
                Width = item.HorizontalSpaceUsage,
                Height = item.VerticalSpaceUsage
            };
        }


        #endregion
    }
}
