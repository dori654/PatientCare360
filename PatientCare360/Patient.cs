using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;

namespace PatientCare360
{
    class Patient : DoctorUI
    {
        public int age;
        public bool gender;


        Dictionary<string, string> patientInfo = new Dictionary<string, string>();

        public void ConvertsValuesTo_LOW_HIGH_NORMAL(Dictionary<string,string> dict)
        {
            var age = dict["age"];
            var gender = dict["gender"];
            var origin = dict["origin"];

            dict["WBC"] = white_Blood_Cells(Convert.ToInt32(dict["WBC"]), Convert.ToInt32(age));
            dict["Neut"] = Neutrophil(Convert.ToInt32(dict["Neut"]));
            dict["Lymph"] = Lymphocytes(Convert.ToInt32(dict["Lymph"]));
            dict["RBC"] = Red_Blood_Cells(Convert.ToInt32(dict["RBC"]));
            dict["HCT"] = HCT(Convert.ToInt32(dict["HCT"]), gender);
            dict["Urea"] = Urea(Convert.ToInt32(dict["Urea"]), origin);
            dict["Hb"] = Hemoglobin(Convert.ToInt32(dict["Hb"]), Convert.ToInt32(age), gender);
            dict["Creatinine"] = Criatin(Convert.ToInt32(dict["Creatinine"]), Convert.ToInt32(age));
            dict["Iron"] = Iron(Convert.ToInt32(dict["Iron"]), gender);
            dict["HDL"] = HDL(Convert.ToInt32(dict["HDL"]), gender, origin);
            dict["AP"] = AP(Convert.ToInt32(dict["AP"]), origin);

        }

        public  int CheckDictionaryValues1(Dictionary<string, double> dict)
        {
            try
            {
                dict["WBC"] = Convert.ToDouble(dict["WBC"]);
                dict["Neut"] = Convert.ToDouble(dict["Neut"]);
                dict["Lymph"] = Convert.ToDouble(dict["Lymph"]);
                dict["RBC"] = Convert.ToDouble(dict["RBC"]);
                dict["HCT"] = Convert.ToDouble(dict["HCT"]);
                dict["Urea"] = Convert.ToDouble(dict["Urea"]);
                dict["Hb"] = Convert.ToDouble(dict["Hb"]);
                dict["Creatinine"] = Convert.ToDouble(dict["Creatinine"]);
                dict["Iron"] = Convert.ToDouble(dict["Iron"]);
                dict["HDL"] = Convert.ToDouble(dict["HDL"]);
                dict["AP"] = Convert.ToDouble(dict["AP"]);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return 1;
            }
            var lst = dict.Values.Where(x => x < 0).ToList().ToList();
            if (lst.Count != 0)
            {
                return 2;
            }
            return 3;
        }


        public bool CheckDictionaryValues(Dictionary<string, double> dict)
        {
            int flag = CheckDictionaryValues1(dict);
            MessageBox.Show("Error");

            if (flag == 1)
            {
                MessageBox.Show("Value must be numeric");
                return false;
            }
            else if (flag == 2)
            {
                MessageBox.Show("Value must be not negative");
                return false;
            }
            else
            {
                return true;
            }
        }




        public string Return_LOWorHIGHorNORMAL(double a, double b, int val)
        {
            if (val < a)
            {
                return "LOW";
            }

            else if (val > b)
            {
                return "HIGH";
            }

            return "Normal";
        }

        public string white_Blood_Cells(int val, int age)
        {
            double a = 0, b = 0;
            if (age >= 18)
            {
                a = 4500;
                b = 11000;
            }
            else if (age >= 4)
            {
                a = 5500;
                b = 15500;
            }
            else
            {
                a = 6000;
                b = 17500;
            }
            return Return_LOWorHIGHorNORMAL(a, b, val);
        }

        public string Neutrophil(int val)
        {
            return Return_LOWorHIGHorNORMAL(28, 54, val);
        }

        public string Lymphocytes(int val)
        {
            return Return_LOWorHIGHorNORMAL(36, 52, val);
        }
        public string Red_Blood_Cells(int val)
        {
            return Return_LOWorHIGHorNORMAL(4.5, 6, val);
        }

        public string HCT(int val, string gender)
        {
            double a = 0, b = 0;
            if (gender == "F")
            {
                a = 33;
                b = 47;
            }
            else
            {
                a = 37;
                b = 54;
            }

            return Return_LOWorHIGHorNORMAL(a, b, val);
        }

        public string Urea(int val, string origin)
        {
            double a = 0, b = 0;
            if (origin == "Middle-Eastern")
            {
                a = 18.7;
                b = 47.3;
            }
            else
            {
                a = 17;
                b = 43;
            }
            return Return_LOWorHIGHorNORMAL(a, b, val);
        }

        public string Hemoglobin(int val, int age, string gender)
        {
            double a = 0, b = 0;
            if (age <= 17)
            {
                a = 11.5;
                b = 15.5;
            }
            else if (gender == "F")
            {
                a = 12;
                b = 16;
            }
            else
            {
                a = 12;
                b = 18;
            }

            return Return_LOWorHIGHorNORMAL(a, b, val);
        }

        public string Criatin(int val, int age)
        {
            double a = 0, b = 0;
            if (age <= 2)
            {
                a = 0.2;
                b = 0.5;
            }
            else if (age <= 17)
            {
                a = 0.5;
                b = 1;
            }
            else if(age <= 59)
            {
                a = 0.6;
                b = 1;
            }
            else
            {
                a = 0.6;
                b = 1.2;
            }

            return Return_LOWorHIGHorNORMAL(a, b, val);
        }

        public string Iron(int val, string gender)
        {
            double a = 0, b = 0;
            if (gender == "F")
            {
                a = 48;
                b = 128;
            }
            else
            {
                a = 60;
                b = 160;
            }

            return Return_LOWorHIGHorNORMAL(a, b, val);
        }

        public string HDL(int val, string gender, string origin)
        {
            double a = 0, b = 0;
            if (gender == "F")
            {
                a = 34;
                b = 82;
            }
            else
            {
                a = 29;
                b = 61;
            }

            if (origin == "Ethiopian")
            {
                a *= 1.2;
                b *= 1.2;
            }

            return Return_LOWorHIGHorNORMAL(a, b, val);
        }

        public string AP(int val, string origin)
        {
            double a = 0, b = 0;
            if (origin == "Middle-Eastern")
            {
                a = 60;
                b = 120;
            }
            else
            {
                a = 30;
                b = 90;
            }

            return Return_LOWorHIGHorNORMAL(a, b, val);
        }

        public void WBCdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["WBC"] == "HIGH")
            {
                if (patientInfo["Fever"] == "Yes")
                    diagnosis["Infection"] += 1;
                else
                {
                    diagnosis["Blood disease"] += 0.5;
                    diagnosis["Cancer"] += 0.5;
                }
            }
            else if (patientInfo["WBC"] == "LOW")
            {
                diagnosis["Cancer"] += 0.5;
                diagnosis["Viral disease"] += 1;
            }
        }

        public  void Nautdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["Neut"] == "HIGH")
            {
                diagnosis["Infection"] += 1;
            }
            else if (patientInfo["Neut"] == "LOW")
            {
                diagnosis["Cancer"] += 0.5;
                diagnosis["Infection"] += 1;
            }
        }

        public void Lymphdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["Neut"] == "HIGH")
            {
                diagnosis["Infection"] += 1;
                diagnosis["Cancer"] += 1;
            }
            else if (patientInfo["Neut"] == "LOW")
            {
                diagnosis["Disorder of blood formation / blood cells"] += 1;
            }
        }

        public void  RCdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["RBC"] == "HIGH")
            {
                diagnosis["Disorder of blood formation / blood cells"] += 1;
                diagnosis["Lung disease"] += 1;
                if (patientInfo["smoker"] == "Yes")
                {
                    diagnosis["Smokers"] += 1;
                }
            }
            else if (patientInfo["RBC"] == "LOW")
            {
                diagnosis["Anemia"] += 1;
                diagnosis["Bleeding"] += 1;
            }
        }

        public void HCTdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["HCT"] == "HIGH")
            {
                if (patientInfo["smoker"] == "Yes")
                {
                    diagnosis["Smokers"] += 1;
                }
            }
            else if (patientInfo["HCT"] == "LOW")
            {
                diagnosis["Anemia"] += 1;
                diagnosis["Bleeding"] += 1;
            }
        }

        public void Ureadiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["Urea"] == "HIGH")
            {
                diagnosis["Kidney disease"] += 1;
                diagnosis["Dehydration"] += 1;
                diagnosis["Diet"] += 1;
            }
            else if (patientInfo["Urea"] == "LOW" && patientInfo["pregnancy"] == "No")
            {
                diagnosis["Malnutrition"] += 1;
                diagnosis["Diet"] += 1;
                diagnosis["Liver disease"] += 1;
            }
        }

        public void Hbdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["Hb"] == "LOW")
            {
                diagnosis["Anemia"] += 1;
                diagnosis["Hematologic disorder"] += 1;
                diagnosis["Iron deficiency"] += 1;
                diagnosis["Bleeding"] += 1;
            }
        }

        public void Creatininediagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["Creatinine"] == "HIGH")
            {
                if (patientInfo["vomiting"] == "No" && patientInfo["diarrhea"] == "No")
                {
                    diagnosis["Kidney disease"] += 1;
                    diagnosis["Muscle diseases"] += 1;
                    diagnosis["Increased consumption of meat"] += 1;
                }
            }
            else if (patientInfo["Creatinine"] == "LOW")
            {
                diagnosis["Malnutrition"] += 1;
            }
        }

        public void Irondiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["Iron"] == "HIGH")
            {
                diagnosis["Iron poisoning"] += 1;
            }
            else if (patientInfo["Iron"] == "LOW")
            {
                diagnosis["Iron deficiency"] += 1;
                if (patientInfo["pregnancy"] == "No")
                {
                    diagnosis["Bleeding"] += 1;
                    diagnosis["Malnutrition"] += 1;
                }
            }
        }

        public void HDLdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["HDL"] == "LOW")
            {
                diagnosis["Heart disease"] += 1;
                diagnosis["Hyperlipidemia (blood lipids)"] += 1;
                diagnosis["Adult diabetes"] += 1;
            }
        }

        public void APdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["AP"] == "HIGH" && patientInfo["pregnancy"] == "No")
            {
                diagnosis["Liver disease"] += 1;
                diagnosis["Bile duct diseases"] += 1;
                diagnosis["Hypothyroidism"] += 1;
                diagnosis["Use of various drugs"] += 1;
            }
            else if (patientInfo["AP"] == "LOW")
            {
                diagnosis["Vitamin deficiency"] += 1;
                diagnosis["Vitamin deficiency"] += 1;
                diagnosis["Malnutrition"] += 1;
            }
        }

        public Dictionary<string, double> get_diagnosis_dict(Dictionary<string, string> patientInfo)
        {
            Dictionary<string, double> diagnosis = new Dictionary<string, double>
            {
                {"Anemia",0},{"Diet",0},{"Bleeding",0},{"Hyperlipidemia (blood lipids)",0},{"Disorder of blood formation / blood cells",0},{"Hematologic disorder",0},
                {"Iron poisoning",0},{"Dehydration",0},{"Infection",0},{"Vitamin deficiency",0},{"Viral disease",0},
                {"Bile duct diseases",0},{"Heart disease",0},{"Blood disease",0},{"Liver disease",0},
                {"Kidney disease",0},{"Iron deficiency",0},{"Muscle diseases",0},{"Smokers",0},{"Lung disease",0},
                {"Hypothyroidism",0},{"Adult diabetes",0},{"Cancer",0},{"Increased consumption of meat",0},{"Use of various drugs",0},{"Malnutrition",0}
            };

            WBCdiagnosis(patientInfo, diagnosis);
            Nautdiagnosis(patientInfo, diagnosis);
            Lymphdiagnosis(patientInfo, diagnosis);
            RCdiagnosis(patientInfo, diagnosis);
            HCTdiagnosis(patientInfo, diagnosis);
            Ureadiagnosis(patientInfo, diagnosis);
            Hbdiagnosis(patientInfo, diagnosis);
            Creatininediagnosis(patientInfo, diagnosis);
            Irondiagnosis(patientInfo, diagnosis);
            HDLdiagnosis(patientInfo, diagnosis);
            APdiagnosis(patientInfo, diagnosis);
            return diagnosis;
        }

        public string get_string_of_diagnosis_and_Treatment(Dictionary<string, double> diagnosis)
        {
            var max_value = diagnosis.Max().Value;
            if (max_value == 0)
                return "The tests are normal and you are a healthy person.";
            
        }

     
    }
}
