using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Search Criteria 
            string stateCode = "01";
            string name = "U337AL";
            string pdfURL = "";

            Console.WriteLine("Searching with StateCode: " + stateCode);
            Console.WriteLine("Searching with Name: " + name);
            XmlDataDocument xdoc = new XmlDataDocument();
            xdoc.Load(@"C:\Grid\testx.xml");
            XmlNode pdfURLNode = xdoc.DocumentElement.SelectSingleNode("/EODocumentResponse/pdfBaseURL");
            string pdfBaseURL = pdfURLNode.InnerText;
            Console.WriteLine("Found pdfBaseURL: " + pdfBaseURL);
            XmlNodeList documentSets = xdoc.DocumentElement.SelectNodes("/EODocumentResponse/documentSets");

            //Find doc set by description
            foreach (XmlNode document in documentSets)
            {
                string foundStateCode = document.SelectSingleNode("/EODocumentResponse/documentSets/stateCode").InnerText;

                if (foundStateCode == stateCode)
                {
                    //Document with matching statecode found. 
                    //Search Forms for other serach criterea here
                    XmlNodeList formNodes = document.SelectNodes("/EODocumentResponse/documentSets/forms");

                    for (int i = 0; i < formNodes.Count - 1; i++)
                    {
                        string foundName = formNodes[i].ChildNodes[2].InnerText;
                        if (foundName == name)
                        {
                            pdfURL = formNodes[i].SelectSingleNode("/EODocumentResponse/documentSets/forms/pdfURL").InnerText;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Found pdfURL: " + pdfURL);
            Console.ReadLine();

        }
    }
}
