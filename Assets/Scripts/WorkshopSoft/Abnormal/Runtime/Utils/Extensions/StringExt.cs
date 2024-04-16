using System.Threading;

namespace WorkshopSoft.Abnormal.Utils.Extensions
{
    public static class StringExt
    {
        public static string ToTitleCase(this string str) =>
            Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str);
    }
}