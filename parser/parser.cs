/*
 * ****************************************************************************************************
 * Develloper-Team:                      RENONA-Studios
 * Develloper:                           Andrwe Lord Weber
 *                                       Seiichiro0185
 *                                       Lokozar
 * IRC:                                  #renona-studios@irc.freenode.net
 * E-Mail:                               support@renona-studios.org
 * ****************************************************************************************************
 * This is a file parser class. 
 * It reads and writes a given file, searchs and changes the value of an option in this file.
 * It also exclude comments starting with #.
 * 
 * class global variables:
 * name: fileContent
 * type: ArrayList
 * 
 * 
 * functions:
 * 
 * name:        readFile
 * type:        Integer
 * parameter:   string file
 * 
 * name:        writeFile
 * type:        Integer
 * parameter:   string file
 * 
 * name:        getValue
 * type:        string
 * parameter:   string option
 * 
 * name:        setValue
 * type:        void
 * parameter:   string option, string value
 * 
 * name:        searchLine
 * type:        Integer
 * parameter:   string option
 */
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace parser
{
    public class parser
    {
        /*
         * Global Array for working with content of a file.
         */
        private ArrayList fileContent = new ArrayList();

        /*
         * Open file, read content and save read content into "ArrayList fileContent"
         * Exception:
         * 0 - all fine
         * 1 - file not found
         * 2 - file not readable
         */
        public int readFile(string file)
        {
            string fileLine = "";
            StreamReader fileStr;
            try
            {
                fileStr = new StreamReader(file);
            }
            catch (FileNotFoundException)
            {
                return 1;
            }
            catch (UnauthorizedAccessException)
            {
                return 2;
            }
            while (fileLine != null)
            {
                fileLine = fileStr.ReadLine();
                if (fileLine != null)
                    fileContent.Add(fileLine);
            }
            fileStr.Close();
            return 0;
        }
        /*
         * Open file for writing and write lines from "ArrayList fileContent" into "file".
         * Exceptions:
         * 0 - all fine
         * 1 - file not writable
         */
        public int writeFile(string file)
        {
            string fileLine = "";
            StreamWriter fileStr;
            try
            {
                fileStr = new StreamWriter(file, false);
            }
            catch(UnauthorizedAccessException)
            {
                return 1;
            }

            foreach (string line in fileContent)
            {
                fileLine = line;
                if (fileLine != null)
                {
                    fileStr.WriteLine(line);
                }
            }
            fileStr.Close();

            return 0;
        }
        /*
         * Read value of given option from "fileContent"
         * Exception:
         * "value" - value of option
         * "" - no value
         */
        public string getValue(string option)
        {
            string value = "";
            if (option != "")
            {
                int positionComment;
                int positionOption;
                int linePosition;
                linePosition = searchLine(option);
                if (linePosition > -1 && linePosition < fileContent.Count)
                {
                    value = fileContent[linePosition].ToString();
                }
                if (value != "")
                {
                    positionComment = value.IndexOf('#');
                    if (positionComment > -1)
                    {
                        value = value.Substring(0, positionComment);
                    }
                    value.Trim();
                    positionOption = value.IndexOf(' ');
                    value = value.Substring(positionOption + 1, value.Length - 1 - positionOption);
                }
            }
            return value;
        }
        /*
         * Set given value of given option into "fileContent".
         */
        public void setValue(string option, string value)
        {
            if (option != "" && value != "")
            {
                int linePosition;
                string line;
                string lineComment = "";
                int commentPosition;
                linePosition = searchLine(option);
                line = fileContent[linePosition].ToString();
                commentPosition = line.IndexOf('#');
                if (commentPosition > -1)
                {
                    lineComment = line.Substring(commentPosition, line.Length - 1 - commentPosition);
                }
                fileContent[linePosition] = option + " " + value + " " + lineComment;
            }
        }
        /*
         * Search in "ArrayList fileContent" for given option and return line where it was found.
         * Exception:
         * line - line which contains given option
         * -1   - option not found
         */
        private int searchLine(string option)
        {
            int position;
            int positionComment;
            int linePosition = 0;
            foreach (string line in fileContent)
            {
                line.Trim();
                positionComment = line.IndexOf('#');
                position = line.IndexOf(option);
                if (positionComment == 0 || (positionComment < position && positionComment != -1))
                {
                    linePosition++;
                    continue;
                }
                if (position == 0)
                {
                    return linePosition;
                }
                linePosition++;
            }
            return -1;
        }
    }
}
