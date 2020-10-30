﻿using Forms.Enum;
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

        #region Property

        /// <summary>
        /// Contient toutes les données du form
        /// </summary>
        FormData formData = new FormData();

        /// <summary>
        /// Grille principal du form
        /// </summary>
        Grid mainGrid = new Grid();

        #endregion

        #region Constructeur

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //InitializeFormDataTest();
            InitializeFormDataAbcd();

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

                        control = GenerateLabel(item);
                        currentGrid.Children.Add(control);

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

                                           },

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
                BackgroundHexColor = "#FFFFFF",
                Fields = new List<FieldData>()
                {
                    new FieldData()
                    {
                        Name= "GridTitle",
                        TypeComponent = EnumTypeComponent.Grid,
                        HorizontalSpaceUsage = 1,
                        HorizontalSpaceType = EnumSpaceType.Star,
                        VerticalSpaceUsage = 1,
                        VerticalSpaceType = EnumSpaceType.Auto,
                        BackgroundHexColor ="#8F969C",
                        Fields = new List<FieldData>()
                        {
                            new FieldData()
                            {
                                Name= "LabelbilanUrgenceVital",
                                TypeComponent = EnumTypeComponent.Label,
                                HorizontalAlignement= EnumHorizontalAlignement.Center,
                                VerticalAlignement = EnumVerticalAlignement.Center,
                                ContentHorizontalAlignement = EnumContentHorizontalAlignement.Center,
                                ContentVerticalAlignement= EnumContentVerticalAlignement.Center,
                                VerticalSpaceUsage=1,
                                VerticalSpaceType= EnumSpaceType.Auto,
                                HorizontalSpaceUsage=1,
                                HorizontalSpaceType = EnumSpaceType.Auto,
                                BackgroundHexColor="#00000000",
                                ForeGroundHexColor="#FFFFFF",
                                FontWeight = EnumFontWeight.SemiBold,
                                FontSize = EnumFontSize._12,
                                DataValueType = EnumDataValuesType.StringValue,
                                Data= new DataValues()
                                {
                                    StringValue="BILAN D'URGENCE VITALE"
                                }
                            }
                        }
                    }
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
        private VerticalAlignment GetVerticalContentAlignment(EnumContentVerticalAlignement verticalAlignement)
        {
            return verticalAlignement switch
            {
                EnumContentVerticalAlignement.NonRenseigne => VerticalAlignment.Stretch,
                EnumContentVerticalAlignement.Bottom => VerticalAlignment.Bottom,
                EnumContentVerticalAlignement.Center => VerticalAlignment.Center,
                EnumContentVerticalAlignement.Top => VerticalAlignment.Top,
                EnumContentVerticalAlignement.Stretch => VerticalAlignment.Stretch,
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

        private HorizontalAlignment GetHorizontalContentAlignment(EnumContentHorizontalAlignement horizontalAlignement)
        {
            return horizontalAlignement switch
            {
                EnumContentHorizontalAlignement.NonRenseigne => HorizontalAlignment.Stretch,
                EnumContentHorizontalAlignement.Left => HorizontalAlignment.Left,
                EnumContentHorizontalAlignement.Center => HorizontalAlignment.Center,
                EnumContentHorizontalAlignement.Right => HorizontalAlignment.Right,
                EnumContentHorizontalAlignement.Stretch => HorizontalAlignment.Stretch,
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

        private FontWeight GetFontWeight(EnumFontWeight fontWeight)
        {
            return fontWeight switch
            {
                EnumFontWeight.Black => FontWeights.Black,
                EnumFontWeight.Bold => FontWeights.Bold,
                EnumFontWeight.DemiBold => FontWeights.DemiBold,
                EnumFontWeight.ExtraBlack => FontWeights.ExtraBlack,
                EnumFontWeight.ExtraBold => FontWeights.ExtraBold,
                EnumFontWeight.ExtraLight => FontWeights.ExtraLight,
                EnumFontWeight.Heavy => FontWeights.Heavy,
                EnumFontWeight.Light => FontWeights.Light,
                EnumFontWeight.Medium => FontWeights.Medium,
                EnumFontWeight.Normal => FontWeights.Normal,
                EnumFontWeight.Regular => FontWeights.Regular,
                EnumFontWeight.SemiBold => FontWeights.SemiBold,
                EnumFontWeight.Thin => FontWeights.Thin,
                EnumFontWeight.UltraBlack => FontWeights.UltraBlack,
                EnumFontWeight.UltraBold => FontWeights.UltraBold,
                EnumFontWeight.UltraLight => FontWeights.UltraLight,
                _ => FontWeights.Normal,
            };
        }

        private double GenerateFontSize(EnumFontSize fontSize)
        {
            return fontSize switch
            {
                EnumFontSize._8 => 8,
                EnumFontSize._10 => 10,
                EnumFontSize._12 => 12,
                EnumFontSize._14 => 14,
                EnumFontSize._16 => 16,
                EnumFontSize._18 => 18,
                EnumFontSize._20 => 20,
                _ => 12,
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
                HorizontalContentAlignment = GetHorizontalContentAlignment(item.ContentHorizontalAlignement),
                VerticalContentAlignment = GetVerticalContentAlignment(item.ContentVerticalAlignement),
                Margin = item.Margin,
                Width = item.HorizontalSpaceType == EnumSpaceType.Auto ? double.NaN : item.HorizontalSpaceUsage,
                Height = item.VerticalSpaceType == EnumSpaceType.Auto ? double.NaN : item.VerticalSpaceUsage,
                FontWeight = GetFontWeight(item.FontWeight),
                FontSize = GenerateFontSize(item.FontSize),
                Foreground = string.IsNullOrEmpty(item.ForeGroundHexColor) ? Foreground : (Brush)new BrushConverter().ConvertFromString(item.ForeGroundHexColor),
                Background = string.IsNullOrEmpty(item.BackgroundHexColor) ? Background : (Brush)new BrushConverter().ConvertFromString(item.BackgroundHexColor)
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
                HorizontalContentAlignment = GetHorizontalContentAlignment(item.ContentHorizontalAlignement),
                VerticalContentAlignment = GetVerticalContentAlignment(item.ContentVerticalAlignement),
                Margin = item.Margin,
                Width = item.HorizontalSpaceType == EnumSpaceType.Auto ? double.NaN : item.HorizontalSpaceUsage,
                Height = item.VerticalSpaceType == EnumSpaceType.Auto ? double.NaN : item.VerticalSpaceUsage,
                FontWeight = GetFontWeight(item.FontWeight),
                FontSize = GenerateFontSize(item.FontSize),
                Foreground = string.IsNullOrEmpty(item.ForeGroundHexColor) ? Foreground : (Brush)new BrushConverter().ConvertFromString(item.ForeGroundHexColor),
                Background = string.IsNullOrEmpty(item.BackgroundHexColor) ? Background : (Brush)new BrushConverter().ConvertFromString(item.BackgroundHexColor)
            };
        }

        /// <summary>
        /// Genere un label depuis un FieldData
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Label GenerateLabel(FieldData item)
        {
            return new Label()
            {
                Name = item.Name,
                Content = (string)GetDataFromDataValuestype(item),

                HorizontalAlignment = GetHorizontalAlignment(item.HorizontalAlignement),
                VerticalAlignment = GetVerticalAlignment(item.VerticalAlignement),
                HorizontalContentAlignment = GetHorizontalContentAlignment(item.ContentHorizontalAlignement),
                VerticalContentAlignment = GetVerticalContentAlignment(item.ContentVerticalAlignement),
                Margin = item.Margin,
                Width = item.HorizontalSpaceType == EnumSpaceType.Auto ? double.NaN : item.HorizontalSpaceUsage,
                Height = item.VerticalSpaceType == EnumSpaceType.Auto ? double.NaN : item.VerticalSpaceUsage,
                FontWeight = GetFontWeight(item.FontWeight),
                FontSize = GenerateFontSize(item.FontSize),
                Foreground = string.IsNullOrEmpty(item.ForeGroundHexColor) ? Foreground : (Brush)new BrushConverter().ConvertFromString(item.ForeGroundHexColor),
                Background = string.IsNullOrEmpty(item.BackgroundHexColor) ? Background : (Brush)new BrushConverter().ConvertFromString(item.BackgroundHexColor)
            };
        }
        #endregion

    }
}
