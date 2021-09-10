﻿using DimensionClient.Common;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DimensionClient.Library.Converters
{
    public class HeadPortraitConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int height = 0;
            if (parameter != null)
            {
                height = System.Convert.ToInt32(parameter, ClassHelper.cultureInfo);
            }
            string uri = $"{ClassHelper.servicePath}/api/Attachment/GetHeadPortraits/{value}";
            uri += height != 0 ? $"?height={height}" : string.Empty;
            return new ImageSourceConverter().ConvertFrom(uri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
