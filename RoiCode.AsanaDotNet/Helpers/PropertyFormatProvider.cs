﻿using System;
using System.Globalization;
using System.Reflection;

namespace RoiCode.AsanaDotNet
{
    public class PropertyFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrWhiteSpace(format))
                return arg.ToString();

            var pInternal = arg.GetType().GetProperty(format);
            if (pInternal == null)
                throw new CustomAttributeFormatException(
                    $"An AsanaFunction tried to format a Property ('{format}') that couldn't be found. ");

            object value = pInternal.GetValue(arg, new object[] { });
            return value.ToString();
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}
