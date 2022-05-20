using System;
using  IronXL;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace PatientCare360.Excel
{


    internal class Excel
    {
        public static string ExcelPafh1 = "../../Excel/Users.xlsx";
        public static string ExcelPafh2 = "../../Excel/Patients.xlsx";

        public static WorkBook workBook = WorkBook.Load(ExcelPafh1);
        public static WorkSheet Worksheet = workBook.DefaultWorkSheet;

        public static WorkBook workBook1 = WorkBook.Load(ExcelPafh2);
        public static WorkSheet Worksheet1 = workBook1.DefaultWorkSheet;

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

        public static void AddPatient(string f_name, string l_name, string id ,string age , string smokes , string fever ,string diarrhea ,string vomiting , string pregnant , string wbc , string neut ,string lymph
            , string rbc , string hct , string urea , string hb , string crtn , string iron , string hdl , string ap ,string diagnosis )
        {
            int i = Worksheet1.Rows.Length + 1;
            Worksheet1["A" + i].Value = f_name;
            Worksheet1["B" + i].Value = l_name;
            Worksheet1["C" + i].Value = id;
            Worksheet1["D" + i].Value = age;
            Worksheet1["E" + i].Value = smokes;
            Worksheet1["F" + i].Value = fever;
            Worksheet1["G" + i].Value = diarrhea;
            Worksheet1["H" + i].Value = vomiting;
            Worksheet1["I" + i].Value = pregnant;
            Worksheet1["J" + i].Value = wbc;
            Worksheet1["K" + i].Value = neut;
            Worksheet1["L" + i].Value = lymph;
            Worksheet1["M" + i].Value = rbc;
            Worksheet1["N" + i].Value = hct;
            Worksheet1["O" + i].Value = urea;
            Worksheet1["P" + i].Value = hb;
            Worksheet1["Q" + i].Value = crtn;
            Worksheet1["R" + i].Value = iron;
            Worksheet1["S" + i].Value = hdl;
            Worksheet1["T" + i].Value = ap;
            Worksheet1["U" + i].Value = diagnosis;
            workBook1.SaveAs(ExcelPafh2);
            

        }
        public static void ReadFile(string pafh)
        {
           WorkBook workBook = WorkBook.Load(pafh);
           WorkSheet Worksheet = workBook.DefaultWorkSheet;

           

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

