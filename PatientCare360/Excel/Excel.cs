using System;
using  IronXL;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;


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

        public static int index;
        //For readFile
        public static string wbc, neut, lymph, rbc, hct, urea, hb, crtn, iron, hdl, ap;

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

        public static bool CheckId(string ID)
        {
            for (int i = 1; i <= Worksheet1.Rows.Length+1; i++)
            {

                if (ID == Worksheet["C" + i].Value.ToString())
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        public static string printDiagnosis(int index)
        {
            return Worksheet1["U" + index].Value.ToString();
        }

        public static void ReadFile(string pafh)
        {

            WorkBook workBook = WorkBook.Load(pafh);
            WorkSheet Worksheet = workBook.DefaultWorkSheet;

            int i = Worksheet.Rows.Length;

            wbc = Worksheet["A" + i].Value.ToString();
            neut = Worksheet["B" + i].Value.ToString();
            lymph = Worksheet["C" + i].Value.ToString();
            rbc = Worksheet["D" + i].Value.ToString();
            hct = Worksheet["E" + i].Value.ToString();
            urea = Worksheet["F" + i].Value.ToString();
            hb = Worksheet["G" + i].Value.ToString();
            crtn = Worksheet["H" + i].Value.ToString();
            iron = Worksheet["I" + i].Value.ToString();
            hdl = Worksheet["J" + i].Value.ToString();
            ap = Worksheet["K" + i].Value.ToString();

        }
    }
    }




