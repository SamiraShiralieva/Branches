using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Vizhenera
{
    class Program
    {
        static void Main()
        {
            do
            {
                uint k = 0;
                string s = "";
                string result = "", result1 = "";
                string key = "";
                string key_on_s = "";
                int x = 0, y = 0;
                int registr = 0;
                char dublicat;
                int shift = 0;
                char[,] tabula_recta = new char[32, 32];
                string alfabet = "абвгдежзийклмнопрстуфхцчшщьыъэюя";
                for (int i = 0; i < 32; i++)
                    for (int j = 0; j < 32; j++)
                    {
                        shift = j + i;
                        if (shift >= 32)
                            shift = shift % 32;
                        tabula_recta[i, j] = alfabet[shift];
                    }
                Console.Write("Введите ключ шифра: ");
                bool flag = false;
                while (flag != true)
                {
                    flag = true;
                    key = Console.ReadLine();
                    for (int i = 0; i < key.Length; i++)
                    {
                        if ((Convert.ToInt16(key[i]) < 1072) || (Convert.ToInt16(key[i]) > 1103))
                            flag = false;
                    }
                    if (flag == false)
                        Console.WriteLine("Ошибка");
                }
				
				Console.WriteLine("revert: ");
				Console.WriteLine("cherry-pick: ");
				
                Console.Write("Введите строку для шифрования: ");
                s = Console.ReadLine();
               
                for (int i = 0; i < s.Length; i++)
                {
                    key_on_s += key[i % key.Length];
                    if (((int)(s[i]) < 1040) || ((int)(s[i]) > 1103))
                        result += s[i];
                    else
                    {
                        int l = 0;
                        flag = false;
                        while ((l < 32) && (flag == false))
                        {
                            if (key_on_s[i] == tabula_recta[l, 0])
                            {
                                x = l; flag = true;
                            }
                            l++;
                        }
                        if ((Convert.ToInt16(s[i]) < 1072) && (Convert.ToInt16(s[i]) >= 1040))
                        {
                            dublicat = Convert.ToChar(Convert.ToInt16(s[i]) + 32);
                            registr = 1;
                        }
                        else
                        {
                            registr = 0;
                            dublicat = s[i];
                        }
                        l = 0;
                        flag = false;
                        while ((l < 32) && (flag == false))
                        {
                            if (dublicat == tabula_recta[0, l])
                            {
                                y = l;
                                flag = true;
                            }
                            l++;
                        }
                        if (registr == 1)
                        {
                            dublicat = Convert.ToChar(Convert.ToInt16(tabula_recta[x, y]) - 32);
                            result += dublicat;
                        }
                        else result += tabula_recta[x, y];
                    }
                }
                Console.WriteLine("Строка зашифрована: " + result);
                s = result;
              
                for (int i = 0; i < s.Length; i++)
                {
                    key_on_s += key[i % key.Length];
                    if (((int)(s[i]) < 1040) || ((int)(s[i]) > 1103))
                        result1 += s[i];
                    else
                    {
                        int l = 0;
                        flag = false;
                        while ((l < 32) && (flag == false))
                        {
                            if (key_on_s[i] == tabula_recta[l, 0])
                            {
                                x = l;
                                flag = true;
                            }
                            l++;
                        }
                        if ((Convert.ToInt16(s[i]) < 1072) && (Convert.ToInt16(s[i]) >= 1040))
                        {
                            dublicat = Convert.ToChar(Convert.ToInt16(s[i]) + 32);
                            registr = 1;
                        }
                        else
                        {
                            registr = 0;
                            dublicat = s[i];
                        }
                        l = 0;
                        flag = false;
                        while ((l < 32) && (flag == false))
                        {
                            if (dublicat == tabula_recta[x, l])
                            {
                                y = l;
                                flag = true;
                            }
                            l++;
                        }
                        if (registr == 1)
                        {
                            dublicat = Convert.ToChar(Convert.ToInt16(tabula_recta[0, y]) - 32);
                            result1 += dublicat;
                        }
                        else result1 += tabula_recta[0, y];
                    }
                }
                Console.WriteLine("Строка дешифрована: " + result1);
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Tab);
        }
    }

}
