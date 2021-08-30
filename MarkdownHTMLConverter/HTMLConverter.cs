using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MarkdownHTMLConverter
{
    public class HTMLConverter
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("HTML Converveter in C#\r");
            Console.WriteLine("------------------------\n");
            Console.Write(new string('\n', 5));


            string text;
            // Read test data from path
            StreamReader file = new StreamReader(@"mailchimpTestData.txt");

            // Clear all content in the output text file
            File.WriteAllText(@"convertedHTML.txt", String.Empty);
            while ((text = file.ReadLine()) != null)
            {
                // Check for Heading
                if (text.Contains("#"))
                {
                    text = HeadingConverter(text);
                }

                // Check for link
                if (text.Contains("http"))
                {
                    text = LinkTextConverter(text);
                }

                // Check for unformated text 
                if (text.Length != 0 && text.FirstOrDefault() != '<')
                {
                    text = UnformatTextConverter(text);
                }

                // Write to output file
                using(StreamWriter writetext = new StreamWriter(@"convertedHTML.txt", true))
                {
                    writetext.WriteLine(text);
                }
            }

            Process.Start("notepad.exe", @"convertedHTML.txt");
               
            return;
        }


        public static string HeadingConverter(string text)
        {
            int length = 0;
            foreach(char c in text)
            {
                if(c == '#')
                {
                    length++;
                }
                else if(c != '#')
                {
                    break;
                }
            }

            text = text.Replace(text.Substring(0,length+1), "<h" + length + ">");
            return text += @"</h" + length + ">";
        }

        public static string LinkTextConverter(string text)
        {
            int startIdx = text.IndexOf('[');
            int endIdx = text.IndexOf(')');
            int length = endIdx - startIdx;
            string linkString = text.Substring(startIdx, length + 1);

            string linkText = linkString.Substring(1, linkString.IndexOf(']')-1);
            string newlinkString = linkString.Remove(0, linkString.IndexOf(']')+1);
            newlinkString = newlinkString.Replace("(", @"<a href=""");
            newlinkString = newlinkString.Replace(")", @""">" + linkText + "</a>");

            text = text.Replace(linkString, newlinkString);
            return text;

        }

        public static string UnformatTextConverter(string text)
        {
            text = text.Insert(0, "<p>");
            return text += @"</p>";
        }
    }
}
