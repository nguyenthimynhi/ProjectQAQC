﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;

namespace QAQCDesktopApplication.ValueConverter
{
    
    public class OrdinalConverter : IValueConverter
        {
           
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            DataGridRow lvi = value as DataGridRow;
            int ordinal = 0;

            if (lvi != null)
            {
                DataGrid lv = ItemsControl.ItemsControlFromItemContainer(lvi) as DataGrid;
                ordinal = lv.ItemContainerGenerator.IndexFromContainer(lvi) + 1;
            }

            return ordinal;

        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // This converter does not provide conversion back from ordinal position to list view item
            throw new System.InvalidOperationException();
        }
    }
}
