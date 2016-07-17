// <copyright company="Benjamin Abt (  http://benjamin-abt.com - http://schwabencode.com  )">
//    Copyright (c) 2016 All Rights Reserved
// </copyright>
// <project>FlexMapper</project>
// <author>Benjamin Abt</author>
// <date>July 18, 2016</date>

using System;
using System.Globalization;
using System.ComponentModel;

namespace SchwabenCode.FlexMapper
{
    /// <summary>
    /// FlexMapper Core with helpers to convert the values
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class FlexMappeCore
    {
        #region DateTime
        /// <summary>
        /// Converts given <paramref name="value"/> to <see cref="DateTime"/> by given <paramref name="format"/>.
        /// If <paramref name="ci"/> is null <see cref="CultureInfo.InvariantCulture"/> will be used.
        /// </summary>
        protected DateTime ToDateTime(string value, string format, CultureInfo ci = null)
        {
            if(ci == null)
            {
                ci = CultureInfo.InvariantCulture;
            }

            return DateTime.ParseExact(value, format, ci);
        }
        /// <summary>
        /// Converts given <paramref name="value"/> to <see cref="DateTime"/> by given <paramref name="format"/>.
        /// If <paramref name="ci"/> is null <see cref="CultureInfo.InvariantCulture"/> will be used.
        /// </summary>
        protected DateTime ToDateTimeUtc(string value, string format, CultureInfo ci = null)
        {
            return ToDateTime(value, format, ci).ToUniversalTime();
        }
        /// <summary>
        /// Converts given <paramref name="value"/> to <see cref="DateTime"/> by given <paramref name="format"/>.
        /// If <paramref name="ci"/> is null <see cref="CultureInfo.InvariantCulture"/> will be used.
        /// </summary>
        protected DateTime ToDateTimeLocal(String value, string format, CultureInfo ci = null)
        {
            return ToDateTime(value, format, ci).ToLocalTime();
        }

        /// <summary>
        /// Converts given <paramref name="value"/> to <see cref="string"/> by given <paramref name="format"/>.
        /// </summary>
        protected string ToString(DateTime value, string format)
        {
            return value.ToString(format);
        }

        /// <summary>
        /// Converts given <paramref name="value"/> to <see cref="string"/> by given <paramref name="format"/>.
        /// </summary>
        protected string ToString(DateTime value, IFormatProvider format)
        {
            return value.ToString(format);
        }
        #endregion DateTime
    }

}
