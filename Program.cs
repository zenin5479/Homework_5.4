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
         string name1DArray = "P";
         string name2DArray = "A";
         string nameFile1DArray = "p.txt";
         string nameFile2DArray = "a.txt";
         string nameFileInput = "finish.txt";
         string pathFile1DArray = Path.GetFullPath(nameFile1DArray);
         string pathFile2DArray = Path.GetFullPath(nameFile2DArray);
         int n = MethodsFor1DArray.NumberArrayElements(name1DArray);
         double[] source1DArray = MethodsFor1DArray.EnterArrayDouble(nameFile1DArray, name1DArray);
         double[,] source2DArray = MethodsFor2DArray.EnterArrayDouble(pathFile2DArray, name2DArray);
         if (source1DArray.Length == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFile1DArray);
         }
         else if (source2DArray.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFile2DArray);
         }
         else
         {
            double[] input1DArray = MethodsFor1DArray.InputArrayDouble(source1DArray, n, name1DArray);
            double[,] input2DArray = MethodsFor2DArray.InputMatrixDouble(source2DArray, n, name2DArray);
            int negative1DArray = MethodsFor1DArray.SearchingNegativeDouble(input1DArray, name1DArray);
            int negative2DArray = MethodsFor2DArray.SearchingNegativeDouble(input2DArray, name2DArray);
            bool comparison = MethodsFor2DArray.ComparisonNegativeDouble(negative1DArray, negative2DArray);
            if (comparison)
            {
               double[,] sortArray = SwapLastLine(input2DArray);
               string pathFileInput = Path.GetFullPath(nameFileInput);
               File.Create(pathFileInput).Close();
               string[] arrayLines = MethodsFor2DArray.OutputArrayString(sortArray);
               MethodsFor2DArray.FileWriteArrayString(arrayLines, nameFileInput);
            }
            else
            {
               Console.WriteLine("Файл {0} пуст", nameFile1DArray); //
               Console.WriteLine("Файл {0} пуст", nameFile2DArray); //
            }
         }

         Console.ReadKey();
      }

      public static double[,] SwapLastLine(double[,] inputArray)
      {
         Console.WriteLine("Замена первой строки двумерного массива последней");
         int i = 0;
         int j = inputArray.GetLength(0) - 1;
         int k = 0;
         while (k < inputArray.GetLength(1))
         {
            inputArray[i, k] = inputArray[j, k];
            k++;
         }

         int l = 0;
         while (l < inputArray.GetLength(0))
         {
            int m = 0;
            while (m < inputArray.GetLength(1))
            {
               if (m == inputArray.GetLength(1) - 1)
               {
                  //Console.Write(inputArray[l, m]);
                  Console.Write("{0:f}", inputArray[l, m]);
                  //Console.Write("{0:f2}", inputArray[l, m]);
               }
               else
               {
                  //Console.Write(inputArray[l, m] + " ");
                  Console.Write("{0:f} ", inputArray[l, m]);
                  //Console.Write("{0:f2} ", inputArray[l, m]);
               }

               m++;
            }

            l++;
            Console.WriteLine();
         }

         return inputArray;
      }
   }
}