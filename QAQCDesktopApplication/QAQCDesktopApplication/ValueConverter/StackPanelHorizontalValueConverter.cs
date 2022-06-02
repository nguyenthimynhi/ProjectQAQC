﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace QAQCDesktopApplication.ValueConverter
{
    public class StackPanelHorizontalValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.TryParse(value as string, out double DoubleValue) && double.TryParse(parameter as string, out double DoubleParameter) && DoubleValue> DoubleParameter;    
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
