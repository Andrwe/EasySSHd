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
            string value = "";
            int positionComment;
            int positionOption;
            value = searchLine(option);
            if (value == "")
            {
                value = "Option does not exist.";
            }
            else
            {
                positionComment = value.IndexOf('#');
                if (positionComment > -1)
                {
                    value = value.Substring(0, positionComment - 1);
                }
                value.Trim();
                positionOption = value.IndexOf(' ');
                value = value.Substring(positionOption + 1, value.Length - 1 - positionOption);
            }
            return value;
        }
        public void setValue(string option, string value)
        {
        }
        private string searchLine(string option)
        {
            int position;
            int positionComment;
            foreach (string line in fileContent)
            {
                line.Trim();
                positionComment = line.IndexOf('#');
                position = line.IndexOf(option);
                if (positionComment == 0 || (positionComment < position && positionComment != -1))
                {
                    continue;
                }
                if (position == 0)
                {
                    return line;
                }
            }
            return "";
        }
    }
}
