using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Forms.Models
{
    [AddINotifyPropertyChangedInterface]
    public class DataValues
    {
        public bool BoolValue { get; set; }
        public byte[] ByteValue { get; set; }
        public DateTime DateValue { get; set; }
        public float FloatValue { get; set; }
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        public string GroupValue { get; set; }
    }
}
