using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1_IniParser
{
    class Ini
    {
        private Dictionary<string, List<Pair>> Sections;
        private string[] IniRead(string filename)
        {
            Regex rgxfilename = new Regex(@".ini$");
            Match match = rgxfilename.Match(filename);
            if(!match.Success)
                throw new Exception("Wrong file format");
            if (File.Exists(filename))
                return File.ReadAllLines(filename);
            else
                throw new Exception("File does not exist");
        }
        public void IniParse(string filename)
        {
            var answ = new Dictionary<string, List<Pair>>();
            string[] filelines = DeleteComments(IniRead(filename));
            char OpenBrackets = '[';
            char CloseBrackets = ']';
            char Equality = '=';
            {
                string CurrentSection="";
                bool NewSection = false;
                for (int i = 0; i < filelines.Length; i++)
                {
                    if (filelines[i].IndexOf(OpenBrackets) != -1 && filelines[i].IndexOf(CloseBrackets) != -1)
                    {
                        NewSection = true;
                        int indexOpen = filelines[i].IndexOf(OpenBrackets),
                        indexClose = filelines[i].IndexOf(CloseBrackets);
                        if (indexOpen == 0 && indexClose == filelines[i].Length - 1)
                        {
                            CurrentSection = filelines[i].Substring(indexOpen + 1, indexClose - 1);
                            Regex rgxSection = new Regex(@"^([a-zA-Z0-9_])+$");
                            Match match = rgxSection.Match(CurrentSection);
                            if (!match.Success)
                                throw new Exception("Wrong section name: Bad symbols");
                        }
                        else
                            throw new Exception("Name is not enclosed in brackets");

                        continue;
                    }
                    if (filelines[i].IndexOf(Equality) != -1)
                    {
                        Pair Parameter = new Pair();
                        Regex rgxName = new Regex(@"^([a-zA-Z0-9_])+$");
                        Parameter.name = filelines[i].Substring(0, filelines[i].IndexOf(Equality));
                        Match match = rgxName.Match(Parameter.name);
                        if (!match.Success)
                            throw new Exception("Wrong parameter name: Bad symbols");
                        Regex rgxValue = new Regex(@"^([a-zA-Z0-9_.])+$");
                        Parameter.value = filelines[i].Substring(filelines[i].IndexOf(Equality) + 1);
                        match = rgxValue.Match(Parameter.value);
                        if (!match.Success)
                            throw new Exception("Wrong parameter value: Bad symbols");
                        if (NewSection)
                        {
                            answ[CurrentSection] = new List<Pair>();
                            NewSection = false;
                        }                        
                        answ[CurrentSection].Add(Parameter);
                        continue;
                    }
                }
            }
            Sections = new Dictionary<string, List<Pair>>(answ);
            return;
        }
        private string[] DeleteComments(string[] filelines)
        {
            char Comment = ';';
            for(int i = 0; i < filelines.Length; i++)
            {
                int indexOfComment = filelines[i].IndexOf(Comment);
                if(indexOfComment!=-1)
                    filelines[i] = filelines[i].Substring(0, indexOfComment);
            }
            return filelines;
        }
        public void IniOut()
        {
            foreach (var section in Sections)
            {
                Console.WriteLine(section.Key);
                foreach(var Parameter in section.Value)
                {
                    Console.WriteLine("{0} = {1}", Parameter.name, Parameter.value);
                }
            }
        }
        public int GetValueInt(string section,string name)
        {
            foreach (var s in Sections)
            {
                if (s.Key == section)
                {
                    foreach (var Parameter in s.Value)
                    {
                        if (Parameter.name == name)
                        {
                            if(Parameter.valueType()=="int")
                                return Convert.ToInt32(Parameter.value);
                            else
                                throw new Exception("Wrong value type");
                        }
                    }
                    throw new Exception("Parameter name does not exist");
                }
            }
            throw new Exception("Section name does not exist");
        }
        public double GetValueDouble(string section, string name)
        {
            foreach (var s in Sections)
            {
                if (s.Key == section)
                {
                    foreach (var Parameter in s.Value)
                    {
                        if (Parameter.name == name)
                        {
                            if (Parameter.valueType() == "double" || Parameter.valueType() == "int")
                                return Convert.ToDouble(Parameter.value.Replace('.',','));
                            else
                                throw new Exception("Wrong value type");
                        }
                    }
                    throw new Exception("Wrong parameter name");
                }
            }
            throw new Exception("Wrong section name");
        }
        public string GetValueString(string section, string name)
        {
            foreach (var s in Sections)
            {
                if (s.Key == section)
                {
                    foreach (var Parameter in s.Value)
                    {
                        if (Parameter.name == name)
                        {
                            if (Parameter.valueType() == "string")
                                return Parameter.value;
                            else
                                throw new Exception("Wrong value type");
                        }
                    }
                    throw new Exception("Wrong parameter name");
                }
            }
            throw new Exception("Wrong section name");
        }
    }
}
