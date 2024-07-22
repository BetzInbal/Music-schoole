using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiusucScule2.Models
{
    internal static class PractisFunc
    {
        public static Func<List<string>, bool> IsStartWithA = (l)
            => l.Any(x => x[0] == "a"[0]);
        public static Func<List<string>, bool> IsStartWithA2 = (l)
            => l.Any(x => x.StartsWith("a"));




        public static Func<List<string>, bool> IsEmpty = (l)
    => l.Any(x => x == "");

        //public static Func<List<string>, bool> IsEmpty2 = (l)
        //=> l.Any(string.IsE);







        public static Func<List<string>, bool> IsAllStartWithA = (l)
        => l.Any(x => !x.Contains("a"));


        public static Func<List<string>, bool> IsAllStartWithA2 = (l)
        => l.All(x => x.Contains("a"));






        public static Func<List<string>, List<string>> StrToUpCa = (l)
            => l.Select(x => x.ToUpper()).ToList();
        public static Func<List<string>, List<string>> StrToUpCa2 = (list) =>
            (
            from str in list
            select str.ToUpper()
            ).ToList();





        public static Func<List<string>, List<string>> Longthn3 = (l)
            => l.Where(x => x.Length > 3).ToList();

        public static Func<List<string>, List<string>> Longthn32 = (l) =>
            ( from str in l
            where str.Length > 3
            select str
            ).ToList();




        public static Func<List<string>, string> ListTOStr = (l) =>
        l.Aggregate("", (Res, next) => $"{Res} {next}");
        public static Func<List<string>, string> ListTOStr2 = (l) 
            => string.Join("");



        public static Func<List<string>, int> ListTOInt = (l) =>
        l.Select(i => i.Length)
        .Aggregate(0, (Res, next) => Res + next);
        public static Func<List<string>, int> ListTOInt2 = (l) =>
        l.Aggregate(0, (Res, next) => Res + next.Length);





        public static Func<List<string>, List<string>> Longthn3Aggre = (l) =>
        l.Aggregate(new List<string>(),(res, next) => next.Length>3 ?[..res, next] : res);



        public static Func<List<string>, List<int>> Longthnint3Aggre = (l) =>
            l.Aggregate(new List<int>(), (res, next) => next.Length > 3 ? [.. res, next.Length] : res);




    }
}

/*
 * 
 * 
 * 
 * 
 * 
כתבו פונקציה שמקבלת
list<string ומחזירה bool
- האם אחד מהאיברים מתחיל באות a
כתבו פונקציה שמקבלת list<string ומחזירה boll - האם קיים string ריק ברשימה
כתבו פונקציה שמקבלת list<string ומחזירה bool - האם כל האיברים מכילים את האות a
כתבו פונקציה שמקבלת list<string ומחזירה list<string שכל איבר יהיה upper case
כתבו פונקציה כמו 4. רק עם Linq query
כתבו פונקציה שמקבלת list<string ומחזירה list<string רק עם האיברים שאורכם גדול מ3
כתבו פונקציה כמו 6. רק עם Linq query
כתבו פונקציה שמקבלת list<string שמחברת את כל האיברים לסטרינג אחד עם רווח בינהם
כתבו פונקציה שמקבלת list<string ומחברת את כולם ל int באמצעות האורך של כל איבר


*/