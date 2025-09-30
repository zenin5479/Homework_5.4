using System;
using System.IO;
using System.Text;

namespace Homework_5._4
{
   public class MethodsForArray
   {
      public static int Number1DArrayElements(string nameArray)
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество элементов массива {0}:", nameArray);
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static double[] Enter1DArray(string path, string nameArray)
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
               //Console.WriteLine("Исходный строковый массив {0}:", nameArray);
               //Console.WriteLine(stroka);
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
               //Console.WriteLine("Массив вещественных чисел {0}:", nameArray);
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
                     //Console.Write(arrayDouble[сolumn] + " ");
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     //Console.Write(arrayDouble[сolumn]);
                     stringModified.Clear();
                     сolumn++;
                  }

                  symbolСount++;
               }
            }

            streamReader.Close();
            //Console.WriteLine();
         }

         return arrayDouble;
      }

      public static double[] Input1DArray(double[] inputArray, int n, string nameArray)
      {
         Console.WriteLine("Одномерный массив вещественных чисел {0}:", nameArray);
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

      public static int Searching1DArrayNegative(double[] inputArray, string nameArray)
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

         Console.WriteLine("В одномерном массиве {0} отрицательных элементов: {1}", nameArray, count);
         if (count == 0)
         {
            Console.WriteLine("В одномерном массиве {0} нет отрицательных элементов", nameArray);
         }

         return count;
      }
      
      public static double[,] Enter2DArray(string path, string nameFile)
      {
         // Двумерный массив вещественных чисел
         double[,] arrayDouble = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         if (allLines == null || allLines.Length == 0)
         {
            Console.WriteLine("Ошибка содержимого файла для чтения {0}", nameFile);
            //Console.WriteLine("Ошибка содержимого файла для чтения {0}. Файл пуст", nameFile);
         }
         else
         {
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               indexLines++;
            }

            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            int[] sizeArray = new int[allLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < allLines.Length)
            {
               string line = allLines[countRow];
               while (countSymbol < line.Length)
               {
                  if (symbolSpace == line[countSymbol])
                  {
                     countСolumn++;
                  }

                  if (countSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  countSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new double[allLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter == line[countCharacter])
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        stringModified.Clear();
                        column++;
                     }
                     else
                     {
                        stringModified.Append(line[countCharacter]);
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               column = 0;
               row++;
            }
         }

         return arrayDouble;
      }

      public static double[,] Input2DArrayMatrix(double[,] inputArray, int n, string nameArray)
      {
         Console.WriteLine("Двумерный массив (матрица) вещественных чисел {0}:", nameArray);
         double[,] outputArray = new double[n, n];
         int i = 0;
         while (i < n)
         {
            int j = 0;
            while (j < n)
            {
               outputArray[i, j] = inputArray[i, j];
               //Console.Write("{0:f2} ", outputArray[i, j]);
               //Console.Write("{0:f} ", outputArray[i, j]);
               Console.Write("{0} ", outputArray[i, j]);
               j++;
            }

            i++;
            Console.WriteLine();
         }

         return outputArray;
      }

      public static double[,] Swap2DArrayLastLine(double[,] inputArray)
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

      public static int Searching2DArrayNegative(double[,] inputArray, string nameArray)
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

         Console.WriteLine("В двумерном массиве {0} отрицательных элементов: {1}", nameArray, count);
         if (count == 0)
         {
            Console.WriteLine("В двумерном массиве нет отрицательных элементов");
         }

         return count;
      }

      public static bool Comparison2DArrayNegative(double negativeOne, double negativeTwo)
      {
         return negativeOne > negativeTwo;
      }

      public static string[] Output2DArray(double[,] inputArray)
      {
         // Объединение двумерного массива double[]
         // в одномерный массив строк string[] для записи в файл
         //Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[inputArray.GetLength(0)];
         string subLine;
         int row = 0;
         while (row < inputArray.GetLength(0))
         {
            int column = 0;
            while (column < inputArray.GetLength(1))
            {
               if (column == inputArray.GetLength(1) - 1)
               {
                  stringModified.Append(inputArray[row, column]);
                  subLine = stringModified.ToString();
                  arrayString[row] = subLine;
               }
               else
               {
                  stringModified.Append(inputArray[row, column] + " ");
                  subLine = stringModified.ToString();
                  arrayString[row] = subLine;
               }

               column++;
            }

            //Console.WriteLine(subLine);
            stringModified.Clear();
            row++;
         }

         return arrayString;
      }

      public static void FileWrite2DArray(string[] arrayString, string nameFile)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл {0}", nameFile);
         string filePath = AppContext.BaseDirectory + nameFile;
         File.WriteAllLines(filePath, arrayString);
      }
   }
}