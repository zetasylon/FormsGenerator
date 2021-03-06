﻿using Forms.Enum;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Windows;

namespace Forms.Models
{
    [AddINotifyPropertyChangedInterface]
    public class FieldData
    {

        public FieldData()
        {
            HorizontalAlignement = EnumHorizontalAlignement.Stretch;
            VerticalAlignement = EnumVerticalAlignement.Stretch;
            Id = Guid.NewGuid();
            ForeGroundHexColor = string.Empty;
            BackgroundHexColor = string.Empty;
            BorderHexColor = string.Empty;
            DataValueType = new ObservableCollection<EnumDataValuesType>();
            fields = new ObservableCollection<FieldData>();
        }

        [DefaultValue("")]
        public string Name { get; set; }

        public Guid Id { get; set; }
        public EnumTypeComponent TypeComponent { get; set; }
        public EnumHorizontalAlignement HorizontalAlignement { get; set; }
        public EnumVerticalAlignement VerticalAlignement { get; set; }
        public EnumContentHorizontalAlignement ContentHorizontalAlignement { get; set; }
        public EnumContentVerticalAlignement ContentVerticalAlignement { get; set; }
        public EnumTextHorizontalAlignement TextHorizontalAlignement { get; set; }
        public EnumTextVerticalAlignement TextVerticalAlignement { get; set; }
        public EnumSpaceType HorizontalSpaceType { get; set; }
        public EnumSpaceType VerticalSpaceType { get; set; }
        public ObservableCollection<EnumDataValuesType> DataValueType { get; set; }
        public EnumFontWeight FontWeight { get; set; }
        public EnumFontSize FontSize { get; set; }

        [DefaultValue(0)]
        public int RowIndex { get; set; }

        [DefaultValue(0)]
        public int RowSpan { get; set; }

        [DefaultValue(0)]
        public int ColumnIndex { get; set; }

        [DefaultValue(0)]
        public int ColumnSpan { get; set; }

        [DefaultValue(1.0)]
        public double HorizontalSpaceUsage { get; set; }

        [DefaultValue(1.0)]
        public double VerticalSpaceUsage { get; set; }

        [DefaultValue("")]
        public string BackgroundHexColor { get; set; }

        [DefaultValue("")]
        public string ForeGroundHexColor { get; set; }

        [DefaultValue("")]
        public string BorderHexColor { get; set; }

        public Thickness Margin { get; set; }

        public Thickness BorderThickness { get; set; }

        private ObservableCollection<FieldData> fields;
        public ObservableCollection<FieldData> Fields
        {
            get
            {
                if (fields == null) fields = new ObservableCollection<FieldData>();
                return fields;
            }
            set => fields = value;
        }

        private DataValues data;
        public DataValues Data
        {
            get
            {
                if (data == null) data = new DataValues();
                return data;
            }

            set => data = value;
        }


        public bool ShouldSerializeFields()
        {
            return Fields.Count > 0;
        }

        public bool ShouldSerializeData()
        {
            return
                Data.BoolValue != default ||
                Data.ByteValue != default ||
                Data.DateValue != default ||
                Data.FloatValue != default ||
                Data.GroupValue != default ||
                Data.IntValue != default ||
                (Data.StringValue != default && !string.IsNullOrEmpty(Data.StringValue));
        }

    }
}
