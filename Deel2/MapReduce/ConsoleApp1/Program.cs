using ConsoleApp1.Data;
using ConsoleApp1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1

{
    public static class MapReduce
    {
        public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> collection, Func<T1, T2> transformation)
        {
            T2[] result = new T2[collection.Count()];
                for (int i = 0; i < collection.Count(); i++)
            {
                result[i] = transformation(collection.ElementAt(i));
            }
            return result;
        }
        public static T2 Reduce<T1, T2>(this IEnumerable<T1> collection, T2 init, Func<T2, T1, T2> operation)
        {
            T2 result = init;
            for (int i = 0; i < collection.Count(); i++)
            {
                result = operation(result, collection.ElementAt(i));
            }
            return result;
        }
        public static IEnumerable<Tuple<T1, T2>> Join<T1, T2>(this IEnumerable<T1> table1, IEnumerable<T2> table2, Func<T1, T2, bool> condition)
        {
            return
              Reduce(table1, new List<Tuple<T1, T2>>(),
                (queryResult, x) =>
                {
                    List<Tuple<T1, T2>> combination =
                Reduce(table2, new List<Tuple<T1, T2>>(),
                        (c, y) =>
                        {
                            Tuple<T1, T2> row = new Tuple<T1, T2>(x, y);
                            if (condition(x,y))
                            {
                                c.Add(row);
                            }

                            return c;
                        });
                    queryResult.AddRange(combination);
                    return queryResult;
                });
        }
    }
    class Program
    {
        static Student[] StudentTable = Sources.GetStudentTable;
        static Classes[] ClassesTable = Sources.GetClassesTable;
        static StudentAndClasses[] StudentAndClassesTable = Sources.GetStudentAndClassesTable;
        static Schedule[] ScheduleTable = Sources.GetScheduleTable;
        static ClassAndSchedule[] ClassAndScheduleTable = Sources.GetClassAndScheduleTable;

        static void Main(string[] args)
        {
            //Query:
            // print de voor en achternaam van alle studenten die in klas "INF1A" zitten.
            // var v1 = null;
        }
    }
}