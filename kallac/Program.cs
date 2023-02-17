using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace kallac
{
    internal class Program
    {
        static void printTab(string s, Hashtable a)
        {
            Console.WriteLine(s);
            ICollection key = a.Keys;
            foreach (string i in key)
            {
                Console.WriteLine(i + "\t" + a[i]);
            }
        }

        static void Main(string[] args)
        {
            //string path = "text.txt";
            //if (!File.Exists(path))
            //{
            //    string createText = "Hello and Welcome" + Environment.NewLine;
            //    File.WriteAllText(path, createText);
            //}
            //string appendText = "This is extra text" + Environment.NewLine;
            //File.AppendAllText(path, appendText);
            //string readText = File.ReadAllText(path);
            //Console.WriteLine(readText);



            int[] mass = new int[10000];
            StreamReader fileIn = new StreamReader("text.txt");
            string line;
            Hashtable people = new Hashtable();
            while ((line = fileIn.ReadLine()) != null)
            {
                string[] temp = line.Split(' ');
                people.Add(temp[0], temp[1]);
            }
            
            printTab("Сейчас в ваших контактах: ", people);

            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine("Выберите что вы хотите сделать: ");
                Console.Write("1-Добавить в контакты. ");
                Console.Write("2-Убрать из контактов. ");
                Console.WriteLine("3-Закрыть записную книжку.");
                int viovr = int.Parse(Console.ReadLine());
                switch (viovr)
                {
                    case 1:
                        Console.WriteLine("Введите номер телефона: ");
                        line = Console.ReadLine();
                        if (people.ContainsKey(line)) Console.WriteLine("У вас в записной книге под номер " + line + ", Записан " + people[line]);
                        else
                        {
                            Console.WriteLine("Введите фамилию: ");
                            string line2 = Console.ReadLine();
                            people.Add(line, line2);
                        }
                        printTab("Сейчас в ваших контактах: ", people);
                        break;
                    case 2:
                        Console.WriteLine("Введите фамилию для удаления");
                        line = Console.ReadLine();
                        if (people.ContainsValue(line))
                        {
                            ICollection key = people.Keys;
                            Console.WriteLine(line);
                            string del = "";
                            foreach (string j in key)
                                if (string.Compare((string)people[j], line) == 0)
                                {
                                    del = j;
                                    break;
                                }
                            Console.WriteLine(del + "\t" + people[del] + "- данные удалены!!!");
                            people.Remove(del);
                            printTab("Сейчас в ваших контактах: ", people);
                        }
                        break;
                    case 3:
                        System.Environment.Exit(1);
                        break;
                }
            }

        }
    }
}            

    

