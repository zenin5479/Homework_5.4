using System;
using System.IO;

// Обработка массивов подпрограммами
// Даны одномерный массив P из n элементов и двумерный массив A: n строк и n столбцов
// Выделить подзадачи, реализовать их подпрограммами и собирать из них программу решения поставленной задачи
// Предусмотреть подпрограммы ввода/вывода
// Глобальными переменными не пользоваться
// Если в P больше отрицательных элементов, чем в A, заменить значения элементов первой строки А значениями элементов последней строки
// Последнюю строку не менять

namespace Homework_5._4
{
   internal class Program
   {
      static void Main(string[] args)
      {
         string nameFileEnter1Array = "p.txt";
         string nameFileEnter2Array = "a.txt";
         string nameFileInput = "finish.txt";
         int row = VariousMethods.SizeRow();
         string pathFileEnter = Path.GetFullPath(nameFileEnter2Array);
         double[,] source = VariousMethods.EnterArrayDouble(row, row, pathFileEnter);
         if (source.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileEnter2Array);
         }
         else
         {
            double[,] inputArray = VariousMethods.InputArrayDouble(source, row, row);
            int sumRow = SearchingNegativeDouble(inputArray);
            //double[,] sortArray = VariousMethods.BubbleSortArray(inputArray, sumRow);
            //string pathFileInput = Path.GetFullPath(nameFileInput);
            //File.Create(pathFileInput).Close();
            //string[] arrayLines = VariousMethods.OutputArrayString(sortArray);
            //VariousMethods.FileWriteArrayString(arrayLines, nameFileInput);
         }

         Console.ReadKey();
      }

      public static int SearchingNegativeDouble(double[,] inputArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.GetLength(0))
         {
            int j = 0;
            while (j < inputArray.GetLength(1))
            {

               if (inputArray[i, j] < 0)
               {
                  count++;
               }

               j++;
            }
            
            i++;
         }

         Console.WriteLine("В массиве отрицательных элементов: {0}", count);
         if (count == 0)
         {
            Console.WriteLine("В массиве нет отрицательных элементов");
         }

         return count;
      }

      public static int SearchingNegativeDouble(double[,] inputArray, string nameArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.GetLength(0))
         {
            int j = 0;
            while (j < inputArray.GetLength(1))
            {

               if (inputArray[i, j] < 0)
               {
                  count++;
               }

               j++;
            }

            i++;
         }

         Console.WriteLine("В массиве {0} отрицательных элементов: {1}", nameArray, count);
         if (count == 0)
         {
            Console.WriteLine("В массиве {0} нет отрицательных элементов", nameArray);
         }

         return count;
      }

      public static int SearchingNegativeDouble(double[] inputArray, string nameArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            if (inputArray[i] < 0)
            {
               count++;
            }

            i++;
         }

         Console.WriteLine("В массиве {0} отрицательных элементов: {1}", nameArray, count);
         if (count == 0)
         {
            Console.WriteLine("В массиве {0} нет отрицательных элементов", nameArray);
         }

         return count;
      }
   }
}