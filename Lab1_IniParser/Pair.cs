using System.Text.RegularExpressions;

namespace Lab1_IniParser
{
    class Pair
    {
        public string name;
        public string value;
        public string valueType()
        {
            Regex rgxint = new Regex(@"^([0-9])+$");
            Regex rgxdouble = new Regex(@"^([0-9])+.([0-9])+$");
            Match match = rgxint.Match(value);
            if (match.Success)
                return "int";
            match = rgxdouble.Match(value);
            if (match.Success)
                return "double";
            return "string";
        }
    }
}
