using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
namespace Excel
{
    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel(string path,int Sheet)
        {
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
            
        }

        public string [,] ReadRange(int starti,int starty,int endi,int endy)
        {
          
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            
            object[,] holder = range.Value2;
            string[,] returnString = new string[3, 2];

            for (int p = 1; p <=3; p++)
            {
                for (int q = 1; q <= 2; q++)
                {
                    returnString[p - 1, q - 1] = holder[p, q].ToString();
                }
            }
            
            
            return returnString;
        }
        public void WriteRange(int starti,int starty,int endi,int endy,string[,] writeData)
        {
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            range.Value2 = writeData;
        }
        public  void Save()
        {
            
            wb.Save();
        }

        public void Close()
        {
            wb.Close();
        }
        static void Main(string[] args)
        {

            Excel excel = new Excel(@"C:\Users\Samarth\Desktop\Folder\Excel.xlsx", 1);

    
            string[,] writeData= new string[2, 2];
            for (int p = 0; p < 2; p++)
            {
                for (int q = 0; q < 2; q++)
                {
                    Console.WriteLine("Enter ");
                    writeData[p, q] = Console.ReadLine();
                    Console.WriteLine(writeData[p,q]);
                }
                
            }
            excel.WriteRange(1, 1, 2, 4, writeData);
            excel.Save();
            excel.Close();

            

            /*Excel excel1 = new Excel(@"C:\Users\Samarth\Desktop\Folder\Excel.xlsx", 1);

            string[,] read = excel1.ReadRange(1, 1, 2, 2);
            for (int p = 0; p < read.GetLength(0); p++)
            {
                for (int q = 0; q <read.GetLength(1); q++)
                {
                    Console.Write(Convert.ToString(read[p,q])+"  ");
                }
                Console.WriteLine();
            }
          
            excel.Save();
            excel.Close();*/
            Console.ReadKey();
        }
    }
}
