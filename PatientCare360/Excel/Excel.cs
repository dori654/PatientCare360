using  IronXL;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml.Style;
using _Excel = IronXL;


namespace PatientCare360.Excel
{

    
    public class Excel
    {
        private string path = "";
        private WorkBook wb;
        private WorkSheet ws;


        public Excel()
        {

        }
        public Excel(string path, int Sheet)
        {
            this.path = path;
            this.wb = WorkBook.Load(@"Users.xlsx");
            this.ws = wb.GetWorkSheet("Sheet1");
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws["A2:C2"] != null)
                return ws["A2:C2"].Value.ToString();
            else
                return "";


        }
        public void writeToCell(int i ,int j, string s)
        {
            for (int y = 2; y < 101; y++)
            {
                var result =new 
                
            }




            // string filePath = "C:\\Users\\dori6\\source\\repos\\PatientCare360\\PatientCare360\\Users.xlsx";
            // Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            // Workbook wb;
            // Worksheet ws;
            //
            // wb = excel.Workbooks.Open(filePath);
            // ws = wb.Worksheets[1];
            //
            // Range cell = ws.Range["A2:C2"];
            //
            // string[] User = new[] {form.Username,cExcel.Fullname,cExcel.Password};
            //
            // cell.Value[XlRangeValueDataType.xlRangeValueDefault] = User;
            //
            // wb.SaveAs(filePath);
            // wb.Close();

        }

        public void Save()
        {
            wb.Save();
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }

        public void Close()
        {
            wb.Close();
        }

        public void CreateNewFile()
        {
            this.wb = excel.Workbooks.Add(_Excel.XlWBATemplate.xlWBATWorksheet);
        }
    }
}
