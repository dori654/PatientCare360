using  Microsoft.Office.Interop.Excel;
using System.Diagnostics;


namespace PatientCare360.Excel
{

    
    internal class WriteExcel :SignUpForm
    {


        public static void writeExcel()
        {
            SignUpForm form = new SignUpForm();
            string filePath = "C:\\Users\\dori6\\source\\repos\\PatientCare360\\PatientCare360\\Users.xlsx";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;

            wb = excel.Workbooks.Open(filePath);
            ws = wb.Worksheets[1];

            Range cell = ws.Range["A2:C2"];

            string[] User = new[] {form.Username,form.Fullname,form.Password};

            cell.set_Value(XlRangeValueDataType.xlRangeValueDefault,User);

            wb.SaveAs(filePath);
            wb.Close();

        }
    }
}
