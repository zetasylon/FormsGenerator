using Forms.Enum;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Data = new DataValues();
            Fields = new List<FieldData>();
            Id = Guid.NewGuid();
        }

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
        public int RowIndex { get; set; }
        public int RowSpan { get; set; }
        public int ColumnIndex { get; set; }
        public int ColumnSpan { get; set; }
        public double HorizontalSpaceUsage { get; set; }
        public double VerticalSpaceUsage { get; set; }
        public string BackgroundHexColor { get; set; }
        public string ForeGroundHexColor { get; set; }
        public string BorderHexColor { get; set; }
        public Thickness Margin { get; set; }
        public Thickness BorderThickness { get; set; }
        public List<FieldData> Fields { get; set; }
        public DataValues Data { get; set; }
    }
}
