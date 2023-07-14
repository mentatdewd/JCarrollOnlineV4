using IdentityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace JCarrollOnline.Helpers
{
    public static class Utilities
    {
        public static void QuickLog(string text, string logPath)
        {
            string dirPath = Path.GetDirectoryName(logPath);

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            using (StreamWriter writer = File.AppendText(logPath))
            {
                writer.WriteLine($"{DateTime.Now} - {text}");
            }
        }

        public static string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirstValue(JwtClaimTypes.Subject)?.Trim();
        }

        public static string[] GetRoles(ClaimsPrincipal identity)
        {
            return identity.Claims
                .Where(c => c.Type == JwtClaimTypes.Role)
                .Select(c => c.Value)
                .ToArray();
        }

        private static IEnumerable<Tuple<T, int>> ToLeveled<T>(this IEnumerable<T> source, int level)
        {
            if (source == null)
            {
                return null;
            }
            else
            {
                return source.Select(item => new Tuple<T, int>(item, level));
            }
        }

        public static IEnumerable<Tuple<T, int>> FlattenWithLevel<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> elementSelector)
        {
            Stack<IEnumerator<Tuple<T, int>>> stack = new Stack<IEnumerator<Tuple<T, int>>>();
            IEnumerable<Tuple<T, int>> leveledSource = source.ToLeveled(0);
            IEnumerator<Tuple<T, int>> e = leveledSource.GetEnumerator();
            try
            {
                while (true)
                {
                    while (e.MoveNext())
                    {
                        Tuple<T, int> item = e.Current;
                        yield return item;
                        IEnumerable<Tuple<T, int>> elements = elementSelector(item.Item1).ToLeveled(item.Item2 + 1);
                        if (elements == null) continue;
                        stack.Push(e);
                        e = elements.GetEnumerator();
                    }
                    if (stack.Count == 0) break;
                    e.Dispose();
                    e = stack.Pop();
                }
            }
            finally
            {
                e.Dispose();
                while (stack.Count != 0) stack.Pop().Dispose();
            }
        }

        //public static IEnumerable<T> Expand<T>(
        //this IEnumerable<T> source, Func<T, IEnumerable<T>> elementSelector)
        //{
        //    Stack<IEnumerator<T>> stack = new Stack<IEnumerator<T>>();
        //    IEnumerator<T> e = source.GetEnumerator();
        //    try
        //    {
        //        while (true)
        //        {
        //            while (e.MoveNext())
        //            {
        //                T item = e.Current;
        //                yield return item;
        //                IEnumerable<T> elements = elementSelector(item);
        //                if (elements == null) continue;
        //                stack.Push(e);
        //                e = elements.GetEnumerator();
        //            }
        //            if (stack.Count == 0) break;
        //            e.Dispose();
        //            e = stack.Pop();
        //        }
        //    }
        //    finally
        //    {
        //        e.Dispose();
        //        while (stack.Count != 0) stack.Pop().Dispose();
        //    }
        //}
    }
}
