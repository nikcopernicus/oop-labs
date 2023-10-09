using System;

namespace Lab1_IniParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Ini ini = new Ini();
            Console.Write("Filename: ");
            string filename = Console.ReadLine();
            try
            {
                Console.Write("Choose command: \n1 - get value\n2-close programm\n");
                string command = Console.ReadLine();
                while (command == "1")
                {
                    ini.IniParse(filename);
                    Console.Write("Category: ");
                    string category = Console.ReadLine();
                    Console.Write("Parameter: ");
                    string parameter = Console.ReadLine();
                    Console.Write("ValueType: ");
                    string valuetype = Console.ReadLine();
                    switch (valuetype)
                    {
                        case "int":
                            Console.WriteLine(ini.GetValueInt(category, parameter));
                            break;
                        case "double":
                            Console.WriteLine(ini.GetValueDouble(category, parameter));
                            break;
                        case "string":
                            Console.WriteLine(ini.GetValueString(category, parameter));
                            break;
                        default:
                            throw new Exception("Wrong value type");
                    }
                    Console.Write("Choose command: \n1 - get value\n2 - close programm\n");
                    command = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Programm closed.");
            return;
        }
    }
}
