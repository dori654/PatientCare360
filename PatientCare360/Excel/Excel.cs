using System;
using  IronXL;
using System.Diagnostics;



namespace PatientCare360.Excel
{


    internal class Excel
    {
        public static string ExcelPafh1 = "../../Excel/Users.xlsx";
        public static WorkBook workBook = WorkBook.Load(ExcelPafh1);
        public static WorkSheet Worksheet = workBook.DefaultWorkSheet;

        public static Boolean SearchUser(string UserName, string Pass)
        {
            for (int i = 1; i <= Worksheet.Rows.Length; i++)
            {
                if(UserName == Worksheet["A"+i].Value.ToString())
                    if (Pass == Worksheet["B"+i].Value.ToString())
                        return true;
                
            }
            return false;

        }

        public static void AddUser(string UserName, string Pass, string id)
        {
            int i = Worksheet.Rows.Length + 1;
            Worksheet["A" + i].Value = UserName;
            Worksheet["B" + i].Value = Pass;
            Worksheet["C" + i].Value = id;
            workBook.SaveAs(ExcelPafh1);
        }

    }
    // public void writeToCell(int i ,int j, string s)
    // {
    //     
    //
    //
    //     // string filePath = "C:\\Users\\dori6\\source\\repos\\PatientCare360\\PatientCare360\\Users.xlsx";
    //     // Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
    //     // Workbook wb;
    //     // Worksheet ws;
    //     //
    //     // wb = excel.Workbooks.Open(filePath);
    //     // ws = wb.Worksheets[1];
    //     //
    //     // Range cell = ws.Range["A2:C2"];
    //     //
    //     // string[] User = new[] {form.Username,cExcel.Fullname,cExcel.Password};
    //     //
    //     // cell.Value[XlRangeValueDataType.xlRangeValueDefault] = User;
    //     //
    //     // wb.SaveAs(filePath);
    //     // wb.Close();
    //
    // }

}

