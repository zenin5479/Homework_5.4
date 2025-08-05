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
         string nameFileEnter = "a.txt";
         string nameFileInput = "finish.txt";
         int row = VariousMethods.SizeRow();
         int column = VariousMethods.SizeColumn();
         string pathFileEnter = Path.GetFullPath(nameFileEnter);
         double[,] source = VariousMethods.EnterArrayDouble(row, column, pathFileEnter);
         if (source.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileEnter);
         }
         else
         {
            double[,] inputArray = VariousMethods.InputArrayDouble(source, row, column);
            double[] sumRow = VariousMethods.SumRowElements(inputArray);
            double[,] sortArray = VariousMethods.BubbleSortArray(inputArray, sumRow);
            string pathFileInput = Path.GetFullPath(nameFileInput);
            File.Create(pathFileInput).Close();
            string[] arrayLines = VariousMethods.OutputArrayString(sortArray);
            VariousMethods.FileWriteArrayString(arrayLines, nameFileInput);
         }

         Console.ReadKey();
      }
   }
}