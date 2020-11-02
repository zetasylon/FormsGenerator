using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;

namespace Forms.Models
{
    [AddINotifyPropertyChangedInterface]
    public class FormData
    {
        public string Name { get; set; }
        public FieldData Field { get; set; }
    }
}
