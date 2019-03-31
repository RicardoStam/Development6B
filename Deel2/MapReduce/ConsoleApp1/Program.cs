using ConsoleApp1.Data;
using ConsoleApp1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public static class MapReduce
    {
        /// <summary>
        /// Manipulate the values of a collection
        /// </summary>
        /// <typeparam name="T1">Input type</typeparam>
        /// <typeparam name="T2">Output type</typeparam>
        /// <param name="collection">Input collection</param>
        /// <param name="transformation">Lambda function which manipulates the collection.</param>
        /// <returns></returns>
        public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> collection, Func<T1, T2> transformation)
        {
            T2[] result = new T2[collection.Count()];
            for (int i = 0; i < collection.Count(); i++)
            {
                result[i] = transformation(collection.ElementAt(i));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1">Input type</typeparam>
        /// <typeparam name="T2">Output type</typeparam>
        /// <param name="collection">Input collection</param>
        /// <param name="init">"collector" object</param>
        /// <param name="operation">Lambda function in which the result (init) is or isnt changed.</param>
        /// <returns></returns>
        public static T2 Reduce<T1, T2>(this IEnumerable<T1> collection, T2 init, Func<T2, T1, T2> operation)
        {
            T2 result = init;
            for (int i = 0; i < collection.Count(); i++)
            {
                result = operation(result, collection.ElementAt(i));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1">Input type</typeparam>
        /// <typeparam name="T2">Output type</typeparam>
        /// <param name="table1">Input table</param>
        /// <param name="table2">Output table</param>
        /// <param name="condition">Lambda function which returns a boolean</param>
        /// <returns></returns>
        public static IEnumerable<Tuple<T1, T2>> Join<T1, T2>(this IEnumerable<T1> table1, IEnumerable<T2> table2, Func<T1, T2, bool> condition)
        {
            return
              Reduce(table1, new List<Tuple<T1, T2>>(),
                (queryResult, table1Element) =>
                {
                    List<Tuple<T1, T2>> combination =
                Reduce(table2, new List<Tuple<T1, T2>>(),
                        (combi, table2Element) =>
                        {
                            Tuple<T1, T2> row = new Tuple<T1, T2>(table1Element, table2Element);
                            if (condition(table1Element,table2Element))
                            {
                                combi.Add(row);
                            }

                            return combi;
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
            //Query 1:
            // print de voornamen van alle studenten (met map en een keer met reduce).
            // var q1 = StudentTable.Reduce();
            var q1 = StudentTable.Map();

            //Query 2:
            // print de namen van alle courses

            //Query 3:
            // print de namen en slc'ers van alle klassen

            // Query 4:
            // Print het aantal vakken na het 4e uur

            // Query 5:
            // print de voornaam, achternaam en klas van een student

            //Query:
            // print de voor en achternaam van alle studenten die in klas "INF1A" zitten.

            // En nu?...
            // Wat wil je nog meer weten over de data? 
            // Maak je eigen data?!
        }
    }
}