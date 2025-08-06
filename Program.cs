using System;
using System.IO;
using System.Text;

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
         string name1Array = "P";
         string name2Array = "A";
         string nameFile1Array = "p.txt";
         string nameFile2Array = "a.txt";
         string nameFileInput = "finish.txt";
         int row = VariousMethods.SizeRow();
         string pathFile1Array = Path.GetFullPath(nameFile1Array);
         string pathFile2Array = Path.GetFullPath(nameFile2Array);

         double[] source1Array = Enter1DArrayDouble(nameFile1Array, name1Array);
         double[,] source2Array = VariousMethods.EnterArrayDouble(row, row, pathFile2Array);

         if (source2Array.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFile2Array);
         }
         else
         {
            double[,] input2Array = VariousMethods.InputArrayDouble(source2Array, row, row);
            int Negative2Array = SearchingNegativeDouble(input2Array);
            //double[,] sortArray = VariousMethods.BubbleSortArray(inputArray, sumRow);
            //string pathFileInput = Path.GetFullPath(nameFileInput);
            //File.Create(pathFileInput).Close();
            //string[] arrayLines = VariousMethods.OutputArrayString(sortArray);
            //VariousMethods.FileWriteArrayString(arrayLines, nameFileInput);
         }

         Console.ReadKey();
      }

      public static double[] Enter1DArrayDouble(string path, string nameArray)
      {
         string stroka = null;
         double[] arrayDouble = { };
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         if (filestream == null || filestream.Length == 0)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            StreamReader streamReader = new StreamReader(filestream);
            while (streamReader.Peek() >= 0)
            {
               stroka = streamReader.ReadLine();
               //Console.WriteLine(stroka);
            }

            // Определение количества столбцов в строке разделением строки на подстроки по пробелу
            // Символ пробела
            char symbolSpace = ' ';
            // Счетчик символов
            int symbolСount = 0;
            // Количество столбцов в строке
            int сolumn = 0;
            if (stroka != null)
            {
               Console.WriteLine("Исходный строковый массив {0}:", nameArray);
               Console.WriteLine(stroka);
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace == stroka[symbolСount])
                  {
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     сolumn++;
                  }

                  symbolСount++;
               }

               //Console.WriteLine("Количество столбцов {0}:", сolumn);

               // Разделение строки на подстроки по пробелу и конвертация подстрок в double
               Console.WriteLine("Массив вещественных чисел {0}:", nameArray);
               // Одномерный массив вещественных чисел
               arrayDouble = new double[сolumn];
               // Построитель строк
               StringBuilder stringModified = new StringBuilder();
               // Счетчик символов обнуляем
               symbolСount = 0;
               // Количество столбцов в строке обнуляем
               сolumn = 0;
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace != stroka[symbolСount])
                  {
                     stringModified.Append(stroka[symbolСount]);
                  }
                  else
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     Console.Write(arrayDouble[сolumn] + " ");
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     Console.Write(arrayDouble[сolumn]);
                     stringModified.Clear();
                     сolumn++;
                  }

                  symbolСount++;
               }
            }

            streamReader.Close();
            Console.WriteLine();
         }

         return arrayDouble;
      }

      public static double[] InputArrayDouble(double[] inputArray, int n, string nameArray)
      {
         Console.WriteLine("Массив вещественных чисел {0} для проведения поиска:", nameArray);
         double[] outputArray = new double[n];
         int i = 0;
         while (i < n)
         {
            outputArray[i] = inputArray[i];
            //Console.Write("{0:f2} ", outputArray[i]);
            //Console.Write("{0:f} ", outputArray[i]);
            Console.Write("{0} ", outputArray[i]);
            i++;
         }

         Console.WriteLine();
         return outputArray;
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