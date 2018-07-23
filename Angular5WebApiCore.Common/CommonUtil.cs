using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Angular5WebApiCore
{
    public static class CommonUtil
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();

            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element))) yield return element;
            }
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> array, Action<T> act)
        {
            foreach (var i in array)
                act(i);
            return array;
        }

        public static IEnumerable<RT> ForEach<T, RT>(this IEnumerable<T> array, Func<T, RT> func)
        {
            var list = new List<RT>();
            foreach (var i in array)
            {
                var obj = func(i);
                if (obj != null)
                    list.Add(obj);
            }
            return list;
        }

        public static void AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
        {
            items.ForEach(item => collection.Add(item));
        }

        /// <summary>
        /// Makes a copy from the object.
        /// Doesn't copy the reference memory, only data.
        /// </summary>
        /// <typeparam name="T">Type of the return object.</typeparam>
        /// <param name="item">Object to be copied.</param>
        /// <returns>Returns the copied object.</returns>
        public static T Clone<T>(this object item)
        {
            if (item != null)
            {
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                var stream = new System.IO.MemoryStream();

                formatter.Serialize(stream, item);
                stream.Seek(0, System.IO.SeekOrigin.Begin);

                T result = (T)formatter.Deserialize(stream);

                stream.Close();

                return result;
            }
            else
                return default(T);
        }
        /// <summary>
        /// if the object this method is called on is not null, runs the given function and returns the value.
        /// if the object is null, returns default(TResult)
        /// </summary>
        public static TResult IfNotNull<T, TResult>(this T target, Func<T, TResult> getValue)
        {
            return target == null ? default(TResult) : getValue(target);
        }
        public static bool HasProperty(this Type obj, string propertyName)
        {
            return obj.GetProperty(propertyName) != null;
        }

        public static bool HasData<TSource>(this IEnumerable<TSource> source) => source != null && source.Count() > 0;
        public static bool HasData(this string[] source) => source != null && source.Count() > 0;
        public static bool HasData(this string source) => source != null && source.Trim().Length > 0;
        public static bool HasData(this bool? source) => (source != null && source.HasValue) ? source.Value : false;
        public static bool HasData(this DateTime? source) => (source != null && source.HasValue);
        public static bool HasData(this TimeSpan? source) => (source != null && source.HasValue);
        public static bool HasData(this DateTime source) => (source != null && source != DateTime.MinValue);
        public static bool HasData(this TimeSpan source) => (source != null && source != TimeSpan.MinValue);
        public static bool HasData(this int source) => (source > 0);
        public static bool HasData(this int? source) => (source != null && source.HasValue && source.Value > 0);
        public static bool HasData(this long source) => (source > 0);
        public static bool HasData(this long? source) => (source != null && source.HasValue && source.Value > 0);
        public static bool HasData(this short source) => (source > 0);
        public static bool HasData(this short? source) => (source != null && source.HasValue && source.Value > 0);

        public static string GetCharSeperatedString(this IEnumerable<string> source, char seperator) => source != null ? string.Join(seperator, source) : null;
        public static string GetCharSeperatedString(this IEnumerable<string> source, string seperator) => source != null ? string.Join(seperator, source) : null;
        public static string GetCharSeperatedString(this string[] source, char seperator) => source != null ? string.Join(seperator, source) : null;
        public static string GetCharSeperatedString(this string[] source, string seperator) => source != null ? string.Join(seperator, source) : null;

        public static string Truncate(this string str) => str == null || (str != null && str.Length == 0) ? null : str.Trim();
        public static string TruncateAndUpper(this string str) => str == null || (str != null && str.Length == 0) ? null : str.Trim().ToUpper();
        public static string RemoveChar(this string str, char c) => str.Contains(c) ? str.Remove(str.IndexOf(c), 1) : str;

        public static void TrimAllStrings<T>(this T obj) where T : class
        {
            if (obj != null)
            {
                BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
                foreach (PropertyInfo p in obj.GetType().GetProperties(flags))
                {
                    var currentNodeType = p.PropertyType;
                    if (currentNodeType == typeof(String))
                    {
                        var currentValue = p.GetValue(obj, null) as string;
                        if (currentValue != null)
                        {
                            p.SetValue(obj, currentValue.Trim(), null);
                        }
                    }
                    // see http://stackoverflow.com/questions/4444908/detecting-native-objects-with-reflection
                    else if (currentNodeType != typeof(object) && Type.GetTypeCode(currentNodeType) == TypeCode.Object)
                    {
                        p.GetValue(obj, null).TrimAllStrings();
                    }
                }
            }
        }

        public static bool HasImplementedInterface(this Type type, Type arg)
        {
            bool implemented = type.GetInterfaces().Contains(arg);
            return implemented;
        }

        private static TAttribute GetAttributeItem<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
        public static string ToDescription(this Enum value)
        {
            var description = GetAttributeItem<DescriptionAttribute>(value);
            return description != null ? description.Description : null;
        }
        /// <summary>
        /// Converts string to enum object
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value) where T : struct
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        /// <summary>
        ///  Replaces the format item in a specified System.String with the text equivalent
        ///  of the value of a specified System.Object instance.
        /// </summary>
        /// <param name="value">A composite format string</param>
        /// <param name="args">An System.Object array containing zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the System.String
        /// equivalent of the corresponding instances of System.Object in args.</returns>
        public static string Format(this string value, params object[] args)
        {
            return string.Format(value, args);
        }
        /// <summary>
        /// Checks string object's value to array of string values
        /// </summary>        
        /// <param name="stringValues">Array of string values to compare</param>
        /// <returns>Return true if any string value matches</returns>
        public static bool In(this string value, params string[] stringValues)
        {
            foreach (string otherValue in stringValues)
                if (string.Compare(value, otherValue) == 0)
                    return true;

            return false;
        }

        /// <summary>
        /// Time passed since specified value in user friendly string e.g '3 days ago'
        /// </summary>
        /// <param name="dateTime">Value to convert in user friendly string</param>
        /// <param name="currentTime">Value to take reference as current time when converting to user friendly string</param>
        /// <returns>User friendly datetime string e.g '3 days ago'</returns>
        public static string When(this DateTime dateTime, DateTime currentTime)
        {
            var timespan = currentTime - dateTime;

            if (timespan.Days > 365) return string.Format("{0} year{1} ago", timespan.Days / 365, (timespan.Days / 365) > 1 ? "s" : "");

            if (timespan.Days > 30) return string.Format("{0} month{1} ago", timespan.Days / 30, (timespan.Days / 30) > 1 ? "s" : "");

            if (timespan.Days > 0) return string.Format("{0} day{1} ago", timespan.Days, timespan.Days > 1 ? "s" : "");

            if (timespan.Hours > 0) return string.Format("{0} hour{1} ago", timespan.Hours, timespan.Hours > 1 ? "s" : "");

            if (timespan.Minutes > 0) return string.Format("{0} minute{1} ago", timespan.Minutes, timespan.Minutes > 1 ? "s" : "");

            return "A moment ago";
        }
        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }
        public static DateTime LastDayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(6);
        }
        public static DateTime FirstDayOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }
        public static DateTime LastDayOfMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }
        public static DateTime FirstDayOfNextMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(1);
        }
        public static DateTime GetDateInCurrentWeek(this DateTime date, DayOfWeek day)
        {
            if (date.DayOfWeek == day) return date;
            var limit = (int)date.DayOfWeek;
            DateTime temp = date, returnDate = DateTime.MinValue;

            for (int i = limit; i < 6; i++)
            {
                temp = temp.AddDays(1);
                if (day == temp.DayOfWeek)
                {
                    returnDate = temp;
                    break;
                }
            }
            if (returnDate == DateTime.MinValue)
            {
                for (int i = limit; i > -1; i++)
                {
                    date = date.AddDays(-1);

                    if (day == date.DayOfWeek)
                    {
                        returnDate = date;
                        break;
                    }
                }
            }
            return returnDate;
        }
        public static bool CompareFromTodayOverSomeDay(this DateTime date, int day)
        {
            var result = date >= DateTime.Now.Date && date <= DateTime.Now.Date.AddDays(day);
            return result;
        }
        public static bool CompareFromPastDate(this DateTime date, int day)
        {
            var result = date >= DateTime.Now.Date.AddDays(day) && date <= DateTime.Now.Date;
            return result;
        }
        public static bool CompareToRange(this DateTime date, DateTime fromDate, DateTime toDate)
        {
            var result = date >= fromDate && date <= toDate;
            return result;
        }
        public static bool CompareToRange(this DateTime date, DateTime fromDate, DateTime toDate, bool includeFromDate, bool includeToDate)
        {
            var result = true;

            if (includeFromDate && includeToDate) result = date >= fromDate && date <= toDate;
            else if (includeFromDate && !includeToDate) result = date >= fromDate && date < toDate;
            else if (!includeFromDate && includeToDate) result = date > fromDate && date <= toDate;
            else if (!includeFromDate && !includeToDate) result = date > fromDate && date < toDate;

            return result;
        }
        public static bool CompareToRange(this DateTime? date, DateTime fromDate, DateTime toDate)
        {
            if (!date.HasData()) return false;
            var result = date.Value >= fromDate && date.Value <= toDate;
            return result;
        }
        public static string GetDateFormat(DateTime dt)
        {
            string datae = dt.Date.ToString("dd/MM/yyyy");
            return datae;
        }
        public static DateTime ToDate_Format_MMddyyyy(this string date) => DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        public static string FormatDate(this DateTime date, DateTimeFormat format) => string.Format($"{{0:{format.ToDescription()}}}", date);

        public static string FormatTimeFromDate(this DateTime? date, TimeFormat format) => string.Format($"{{0:{format.ToDescription()}}}", date);
        public static string FormatTime(this TimeSpan time, TimeFormat format) => string.Format($"{{0:{format.ToDescription()}}}", time);
        public static string FormatDate(this DateTime? date, DateTimeFormat format) => (date != null && date.HasValue) ? date.Value.FormatDate(format) : null;
        public static string FormatTime(this TimeSpan? time, TimeFormat format) => time.HasData() ? string.Format($"{{0:{format.ToDescription()}}}", time.Value) : null;
        public static KeyValuePair<string, string> PairUp(this string key, string value) => new KeyValuePair<string, string>(key, value);

        public static string GetTime(string format)
        {
            TimeSpan interval;
            interval = TimeSpan.ParseExact(format, "c", null);
            string time = string.Format("{0:D2}:{1:D2}", interval.Minutes, interval.Seconds);
            return time;
        }

        public static DateTime SwapDayWithMonth(string arg)
        {
            var returnDate = DateTime.MinValue;
            if (arg != null && arg.Split("/").Length == 3)
            {
                var s = arg.Split("/");

                var d = $"{s[1]}/{s[0]}/s[2]" + "/" + s[0] + "/" + s[2];
                returnDate = DateTime.Parse(d);
            }
            return returnDate;
        }

        public static DateTime GetDate(this string s, DateTimeFormat dateTimeFormat) => s.HasData() ? s.GetDateNullable(dateTimeFormat).Value : DateTime.MinValue;
        public static DateTime? GetDateNullable(this string s, DateTimeFormat dateTimeFormat)
        {
            DateTime? date = null;
            if (s.HasData())
            {
                string[] dateAndTime = null, dateComponents = null;

                if (s.Contains("/"))
                {
                    dateComponents = s.Split("/");
                }
                if (s.Contains("/") && s.Contains(" ") && s.Contains(":"))
                {
                    dateAndTime = s.Split(" ");
                    dateComponents = dateAndTime[0].Split("/");
                }

                switch (dateTimeFormat)
                {
                    case DateTimeFormat.day_MontName_year_Hour_Min:
                        date = DateTime.Parse($"{dateComponents[1]}/{dateComponents[0]}/{dateComponents[2]} {dateAndTime[1]}", CultureInfo.InvariantCulture);
                        //date = DateTime.Parse(string.Format("{0}/{1}/{2} {3}", dateComponents[1], dateComponents[0], dateComponents[2], dateAndTime[1]));                        
                        break;
                    case DateTimeFormat.day_MontName_year:
                        date = DateTime.Parse($"{dateComponents[1]}/{dateComponents[0]}/{dateComponents[2]}", CultureInfo.InvariantCulture);
                        break;
                    case DateTimeFormat.day_Month_year:
                        date = DateTime.Parse($"{dateComponents[1]}/{dateComponents[0]}/{dateComponents[2]}", CultureInfo.InvariantCulture);
                        break;
                    case DateTimeFormat.day_Month_Hour_Min:
                        date = DateTime.Parse($"{dateComponents[1]}/{dateComponents[0]}/{dateComponents[2]} {dateAndTime[1]}", CultureInfo.InvariantCulture);
                        break;
                    default:
                        break;
                }
            }
            return date;
        }

        /// <summary>
        /// Serialize an object of type T into an JSON string using NewtonSoft.JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">any T object</param>
        /// <returns>A JSON string</returns>
        public static string SerializeToJSON<T>(this T arg) where T : class => arg != null ? JsonConvert.SerializeObject(arg) : null;
        /// <summary>
        /// Serialize an object of type T into an XML-formatted string using XmlSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">any T object</param>
        /// <returns>A XML-formatted string</returns>
        public static string SerializeToXML<T>(this T arg)
        {
            string xml = null;
            if (arg != null)
            {
                using (var stringWriter = new StringWriter())
                using (var xmlWriter = XmlWriter.Create(stringWriter))
                {
                    new XmlSerializer(typeof(T)).Serialize(xmlWriter, arg);
                    xml = stringWriter.ToString();
                }
            }
            return xml;
        }
        /// <summary>
        /// Deserialize an object of type T into an XML-formatted string using XmlSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">any T object</param>
        /// <returns>an XML-formatted string</returns>
        public static T DeserializeFromXML<T>(this string xml)
        {
            T obj = default(T);
            if (xml.HasData())
            {
                using (var reader = XmlReader.Create(new StringReader(xml)))
                {
                    obj = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                }
            }
            return obj;
        }
        /// <summary>
        /// Deserialize an object into a JSON-formatted string using NewtonSoft.JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">any T object</param>
        /// <returns>a JSON-formatted string</returns>
        public static T DeserializeFromJson<T>(this object json) => Convert.ToString(json).DeserializeFromJson<T>();
        /// <summary>
        /// Deserialize an object into a JSON-formatted string using NewtonSoft.JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">any T object</param>
        /// <returns>a JSON-formatted string</returns>
        public static T DeserializeFromJson<T>(this string json)
        {
            return json.HasData() ? JsonConvert.DeserializeObject<T>(json) : default(T);
        }
        /// <summary>
        /// Internal utility method to convert an UTF8 Byte Array to an UTF8 string.
        /// </summary>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static string UTF8ByteArrayToString(this byte[] characters) => new UTF8Encoding().GetString(characters);

        /// <summary>
        /// Internal utility method to convert an UTF8 string to an UTF8 Byte Array.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static byte[] StringToUTF8ByteArray(this string xml) => new UTF8Encoding().GetBytes(xml);

        /// <summary>
        /// Serialize an object of type T into an XML/UTF8 string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(this T arg)
        {
            if (arg == null) return null;
            using (var stream = new MemoryStream())
            using (var xml = new XmlTextWriter(stream, new UTF8Encoding(false)))
            {
                new XmlSerializer(typeof(T)).Serialize(xml, arg);
                return (xml.BaseStream as MemoryStream).ToArray().UTF8ByteArrayToString();
                //return UTF8ByteArrayToString(((MemoryStream)xml.BaseStream).ToArray());
            }
        }

        /// <summary>
        /// Deserialize an XML/UTF8 string into an object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string xml)
        {
            if (!xml.HasData()) return default(T);

            using (var stream = new MemoryStream(xml.StringToUTF8ByteArray()))
            using (new XmlTextWriter(stream, new UTF8Encoding(false)))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(stream);
            }
        }

        /// <summary>
        /// Serialize an object T using BinaryFormatter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string SerializeObjectUsingBinaryFormatter<T>(this T arg)
        {
            if (arg == null) return null;
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, arg);
                return ms.ToArray().UTF8ByteArrayToString();
                //return UTF8ByteArrayToString(ms.ToArray());
            }
        }

        /// <summary>
        /// Deserialize a BinaryFormatter-serialized string into an object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeserializeObjectUsingBinaryFormatter<T>(string str)
        {
            if (!str.HasData()) return default(T);
            using (var ms = new MemoryStream(StringToUTF8ByteArray(str)))
            {
                return (T)new BinaryFormatter().Deserialize(ms);
            }
        }
    }
    public enum DOextensionStaus
    {
        [Description("DO Extension Requested")]
        DO_Extension_Requested,
        [Description("Payment Pending")]
        Payment_Pending,
        [Description("Payment Done")]
        Payment_Done,
        [Description("D/O Extended")]
        DO_Extended,
        [Description("Extension Rejected")]
        Extension_Reject,
        [Description("Extension Delete")]
        Extension_Delete
    }
    public enum DateTimeFormat
    {
        [Description("dd/MMM/yyyy HH:mm")]
        day_MontName_year_Hour_Min,
        [Description("dd/MMM/yyyy")]
        day_MontName_year,
        [Description("dd/MM/yyyy")]
        day_Month_year,
        [Description("dd/MM HH:mm")]
        day_Month_Hour_Min
    }
    public enum TimeFormat
    {
        [Description("hh")]
        Hour,
        [Description("mm")]
        Min,
        [Description("hh\\:mm")]
        Hour_Min,
        [Description("hh\\:mm\\:ss")]
        Hour_Min_Sec
    }
}
