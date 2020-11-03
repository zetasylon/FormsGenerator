using Forms.Enum;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Windows;

namespace Forms.Models
{
    [AddINotifyPropertyChangedInterface]
    public class FieldData
    {
        #region Constante
        #endregion
        public FieldData()
        {
            HorizontalAlignement = EnumHorizontalAlignement.Stretch;
            VerticalAlignement = EnumVerticalAlignement.Stretch;
            Data = new DataValues();
            Fields = new List<FieldData>();
            Id = Guid.NewGuid();
            ForeGroundHexColor = string.Empty;
            BackgroundHexColor = string.Empty;
            BorderHexColor = string.Empty;
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
        public List<EnumDataValuesType> DataValueType { get; set; }
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

        public List<FieldData> Fields { get; set; }

        public DataValues Data { get; set; }



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
