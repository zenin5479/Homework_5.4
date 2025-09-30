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
      static void Main()
      {
         string name1DArray = "P";
         string name2DArray = "A";
         string nameFile1DArray = "p.txt";
         string nameFile2DArray = "a.txt";
         string nameFileInput = "finish.txt";
         string pathFile1DArray = Path.GetFullPath(nameFile1DArray);
         string pathFile2DArray = Path.GetFullPath(nameFile2DArray);
         int n = MethodsForArray.Number1DArrayElements(name1DArray);
         double[] source1DArray = MethodsForArray.Enter1DArray(pathFile1DArray, name1DArray);
         double[,] source2DArray = MethodsForArray.Enter2DArrayDouble(pathFile2DArray, name2DArray);
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
            double[] input1DArray = MethodsForArray.Input1DArrayDouble(source1DArray, n, name1DArray);
            double[,] input2DArray = MethodsForArray.Input2DArrayMatrixDouble(source2DArray, n, name2DArray);
            int negative1DArray = MethodsForArray.Searching1DArrayNegativeDouble(input1DArray, name1DArray);
            int negative2DArray = MethodsForArray.Searching2DArrayNegativeDouble(input2DArray, name2DArray);
            bool comparison = MethodsForArray.Comparison2DArrayNegativeDouble(negative1DArray, negative2DArray);
            if (!comparison)
            {
               Console.WriteLine("В одномерном массиве {0} меньше отрицательных элементов чем в двумерном массиве {1}", name1DArray, name2DArray);
            }
            else
            {
               Console.WriteLine("В одномерном массиве {0} больше отрицательных элементов чем в двумерном массиве {1}", name1DArray, name2DArray);
               double[,] sortArray = MethodsForArray.Swap2DArrayLastLine(input2DArray);
               string pathFileInput = Path.GetFullPath(nameFileInput);
               File.Create(pathFileInput).Close();
               string[] arrayLines = MethodsForArray.Output2DArrayString(sortArray);
               MethodsForArray.FileWrite2DArrayString(arrayLines, nameFileInput);
            }
         }

         Console.ReadKey();
      }
   }
}