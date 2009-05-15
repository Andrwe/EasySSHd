using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace parser
{
    public class parser
    {
        private ArrayList fileContent = new ArrayList();

        public void readFile(string file)
        {
            string fileLine = "";
            StreamReader fileStr = new StreamReader(file);
            while (fileLine != null)
            {
                fileLine = fileStr.ReadLine();
                if (fileLine != null)
                    fileContent.Add(fileLine);
            }
            fileStr.Close();
        }
        public void writeFile(string file)
        {
        }
        public string getValue(string option)
        {
            string value = "test";
            return value;
        }
        public void setValue(string option, string value)
        {
        }
    }
}
