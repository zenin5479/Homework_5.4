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
         if (source1DArray.GetLength(0) == 0)
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

            //string pathFileInput = Path.GetFullPath(nameFileInput);
            //File.Create(pathFileInput).Close();
            //string[] arrayLines = VariousMethods.OutputArrayString(sortArray);
            //VariousMethods.FileWriteArrayString(arrayLines, nameFileInput);
         }

         Console.ReadKey();
      }
   }
}