using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;

namespace PatientCare360
{
    class Patient
    {
        
        Dictionary<string, string> patientInfo = new Dictionary<string, string>();
        private Dictionary<string, double> diagnosis = new Dictionary<string, double>();
        public string diagnosis1;


        public Patient()
        {
            patientInfo.Add("f_name", "");
            patientInfo.Add("l_name", "");
            patientInfo.Add("id", "");
            patientInfo.Add("age", "");
            patientInfo.Add("smokes", "");
            patientInfo.Add("fever", "");
            patientInfo.Add("diarrhea", "");
            patientInfo.Add("vomiting", "");
            patientInfo.Add("pregnant", "");
            patientInfo.Add("wbc", "");
            patientInfo.Add("neut", "");
            patientInfo.Add("rbc", "");
            patientInfo.Add("hct", "");
            patientInfo.Add("urea", "");
            patientInfo.Add("hb", "");
            patientInfo.Add("crtn", "");
            patientInfo.Add("iron", "");
            patientInfo.Add("hdl", "");
            patientInfo.Add("ap", "");
            patientInfo.Add("diagnosis", "");
            patientInfo.Add("recommends", "");

            diagnosis.Add("fever", 0);
            diagnosis.Add("diarrhea", 0);
            diagnosis.Add("vomiting", 0);
            diagnosis.Add("pregnant", 0);
            diagnosis.Add("wbc", 0);
            diagnosis.Add("neut", 0);
            diagnosis.Add("rbc", 0);
            diagnosis.Add("hct", 0);
            diagnosis.Add("urea", 0);
            diagnosis.Add("hb", 0);
            diagnosis.Add("crtn", 0);
            diagnosis.Add("iron", 0);
            diagnosis.Add("hdl", 0);
            diagnosis.Add("ap", 0);
            diagnosis.Add("diagnosis", 0);
            diagnosis.Add("recommends", 0); 

        }

        public Patient(Dictionary<string, string> patientInfo)
        {
            this.patientInfo = patientInfo;
        }
        public void ConvertsValuesTo_LOW_HIGH_NORMAL(Dictionary<string, string> dict)
        {
            var age = dict["age"];
            var gender = dict["gender"];
            var origin = dict["origin"];

            dict["WBC"] = white_Blood_Cells(ConvertToDouble(dict["WBC"]), ConvertToInt(age));
            dict["Neut"] = Neutrophil(ConvertToDouble(dict["Neut"]));
            dict["Lymph"] = Lymphocytes(ConvertToDouble(dict["Lymph"]));
            dict["RBC"] = Red_Blood_Cells(ConvertToDouble(dict["RBC"]));
            dict["HCT"] = HCT(ConvertToDouble(dict["HCT"]), gender);
            dict["Urea"] = Urea(ConvertToDouble(dict["Urea"]), origin);
            dict["Hb"] = Hemoglobin(ConvertToDouble(dict["Hb"]), ConvertToInt(age), gender);
            dict["Creatinine"] = Criatin(ConvertToDouble(dict["Creatinine"]), ConvertToInt(age));
            dict["Iron"] = Iron(ConvertToDouble(dict["Iron"]), gender);
            dict["HDL"] = HDL(ConvertToDouble(dict["HDL"]), gender, origin);
            dict["AP"] = AP(ConvertToDouble(dict["AP"]), origin);

        }

        public double ConvertToDouble(string str)
        {
            return double.Parse(str, CultureInfo.InstalledUICulture);
        }
        public int ConvertToInt(string str)
        {
            int x = Int32.Parse(str);
            return x;
        }

        public int CheckDictionaryValues1(Dictionary<string, double> dict)
        {
            try
            {

                dict["WBC"] = ConvertToDouble(dict["WBC"].ToString());
                dict["Neut"] = ConvertToDouble(dict["Neut"].ToString());
                dict["Lymph"] = ConvertToDouble(dict["Lymph"].ToString());
                dict["RBC"] = ConvertToDouble(dict["RBC"].ToString());
                dict["HCT"] = ConvertToDouble(dict["HCT"].ToString());
                dict["Urea"] = ConvertToDouble(dict["Urea"].ToString());
                dict["Hb"] = ConvertToDouble(dict["Hb"].ToString());
                dict["Creatinine"] = ConvertToDouble(dict["Creatinine"].ToString());
                dict["Iron"] = ConvertToDouble(dict["Iron"].ToString());
                dict["HDL"] = ConvertToDouble(dict["HDL"].ToString());
                dict["AP"] = ConvertToDouble(dict["AP"].ToString());
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




        public string deter_high_low_normal_fields(double a, double b, double val)
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

        public string white_Blood_Cells(double val, int age)
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
            return deter_high_low_normal_fields(a, b, val);
        }

        public string Neutrophil(double val)
        {
            return deter_high_low_normal_fields(28, 54, val);
        }

        public string Lymphocytes(double val)
        {
            return deter_high_low_normal_fields(36, 52, val);
        }
        public string Red_Blood_Cells(double val)
        {
            return deter_high_low_normal_fields(4.5, 6, val);
        }

        public string HCT(double val, string gender)
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

            return deter_high_low_normal_fields(a, b, val);
        }

        public string Urea(double val, string origin)
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
            return deter_high_low_normal_fields(a, b, val);
        }

        public string Hemoglobin(double val, int age, string gender)
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

            return deter_high_low_normal_fields(a, b, val);
        }

        public string Criatin(double val, int age)
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
            else if (age <= 59)
            {
                a = 0.6;
                b = 1;
            }
            else
            {
                a = 0.6;
                b = 1.2;
            }

            return deter_high_low_normal_fields(a, b, val);
        }

        public string Iron(double val, string gender)
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

            return deter_high_low_normal_fields(a, b, val);
        }

        public string HDL(double val, string gender, string origin)
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

            return deter_high_low_normal_fields(a, b, val);
        }

        public string AP(double val, string origin)
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

            return deter_high_low_normal_fields(a, b, val);
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

        public void Nautdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
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

        public void RCdiagnosis(Dictionary<string, string> patientInfo, Dictionary<string, double> diagnosis)
        {
            if (patientInfo["RBC"] == "HIGH")
            {
                diagnosis["Disorder of blood formation / blood cells"] += 1;
                diagnosis["Lung disease"] += 1;
                if (patientInfo["Smokers"] == "Yes")
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
                if (patientInfo["Smokers"] == "Yes")
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
                diagnosis["Overactive thyroid gland"] += 1;
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
                {"Overactive thyroid gland",0},{"Adult diabetes",0},{"Cancer",0},{"Increased consumption of meat",0},{"Use of various drugs",0},{"Malnutrition",0}
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public string diagnosis_and_Treatment_info(Dictionary<string, double> diagnosis)
=======
        public string diagnosis_and_treatment_info(Dictionary<string, double> diagnosis)
>>>>>>> a2e457fc5d387bd08c946d5a7b0a4f577b791063
=======
        public string diagnosis_and_treatment_info(Dictionary<string, double> diagnosis)
>>>>>>> a2e457fc5d387bd08c946d5a7b0a4f577b791063
=======
        public string diagnosis_and_treatment_info(Dictionary<string, double> diagnosis)
>>>>>>> a2e457fc5d387bd08c946d5a7b0a4f577b791063
        {
            var max_value = diagnosis.Values.Max();
            if (max_value == 0)
                return "The tests are normal and you are a healthy person.";
            var Main_diagnoses = diagnosis.Where(x => x.Value == max_value).Select(x => x.Key).ToList();
            var Secondary_diagnoses = diagnosis
                .Where(x => x.Value == max_value - 0.5 || x.Value == max_value - 1)
                .Select(x => x.Key).ToList();
            string ans = "";
            foreach (var i in Main_diagnoses)
            {
                ans += "Diagnoses " + i + "\n" + "Treatment: " + Treatment_according_to_diagnosis(i) + "\n";
            }

            

            if (Secondary_diagnoses.Count > 0)
            {
                ans += "\n In addition there are concerns:\n";
                foreach (var i in Secondary_diagnoses)
                {
                    ans += "Diagnoses " + i + "\n" + "Treatment: " + Treatment_according_to_diagnosis(i) + "\n";
                }
                
            }


            return ans;
        }

        public string Treatment_according_to_diagnosis(string diagnosis)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Anemia","Required to take two pills 10 mg each of B12 a day for a month"},{"Diet","Ask for an appointment with nutritionist"},{"Bleeding","To reach to the nearest hospital as soon as possible"},
                {"Hyperlipidemia (blood lipids)", "schedule an appointment with a nutritionist, 5 mg of Simobil pill per day for a week"},
                {"Disorder of blood formation / blood cells", "Required to take two pills of 10 mg of B12 a day for a month  and required to a 5 mg pill of a folic acid a day for a month"},
                {"Hematologic disorder", "injection of a hormone to encourage red blood cell production"},
                {"Iron poisoning", "reach to the nearest hospital as soon as possible"},{"Dehydration", "Required to lay down and rest + drink water"},{"Infection", "required a specific antibiotics"},
                {"Vitamin deficiency", "required an invitation for blood test and vitamin test"},{"Viral disease", "home rest"},{"Bile duct diseases", "Invitation for a surgical treatment"},
                {"Heart disease", "make an appointment with a nutritionist"},{"Blood disease", "a combination of cyclophosphamide and corticosteroids"},
                {"Liver disease", "Invitation for a specific observation  in order to determine aa treatment"},{"Kidney disease", "balancing blood sugar levels"},{"Iron deficiency", "Required to take two pills of 10 mg of B12 a day for a month"},
                {"Muscle diseases", "two 5 mg pills of Altman C3 turmeric a day for a month"},{"Smokers", "please quit smoking"},{"Lung disease", "please stop smoking / Invitation for an X-ray shot of the lungs"},
                {"Overactive thyroid gland", "Propylthiouracil for shortening activity of  the Thyroid"},{"Adult diabetes", "Re-adjust insulin levels for the patient"},{"Cancer", "Entrectinib"},
                {"Increased consumption of meat", "Ask for an appointment of a nutritionist"},{"Use of various drugs", "Invitation for a family doctor in order to get an approval between the medications"},
                {"Malnutrition", "Ask for an appointment of a nutritionist"}
            };
            return dict[diagnosis];
        }
        public string SavePatientfile()
        {
            //TODO:save patient to file

            ConvertsValuesTo_LOW_HIGH_NORMAL(patientInfo);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            diagnosis1 = diagnosis_and_Treatment_info(get_diagnosis_dict(patientInfo));
            var current_time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string diagnosis =  "\n";
            diagnosis = "\n\nDate: " + current_time + "\n" + diagnosis + "\n" +
                        diagnosis_and_Treatment_info(get_diagnosis_dict(patientInfo));
=======
            diagnosis1 = diagnosis_and_treatment_info(get_diagnosis_dict(patientInfo));
            var current_time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string diagnosis =  "\n";
            diagnosis = "\n\nDate: " + current_time + "\n" + diagnosis + "\n" +
                        diagnosis_and_treatment_info(get_diagnosis_dict(patientInfo));
>>>>>>> a2e457fc5d387bd08c946d5a7b0a4f577b791063
=======
            diagnosis1 = diagnosis_and_treatment_info(get_diagnosis_dict(patientInfo));
            var current_time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string diagnosis =  "\n";
            diagnosis = "\n\nDate: " + current_time + "\n" + diagnosis + "\n" +
                        diagnosis_and_treatment_info(get_diagnosis_dict(patientInfo));
>>>>>>> a2e457fc5d387bd08c946d5a7b0a4f577b791063
=======
            diagnosis1 = diagnosis_and_treatment_info(get_diagnosis_dict(patientInfo));
            var current_time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string diagnosis =  "\n";
            diagnosis = "\n\nDate: " + current_time + "\n" + diagnosis + "\n" +
                        diagnosis_and_treatment_info(get_diagnosis_dict(patientInfo));
>>>>>>> a2e457fc5d387bd08c946d5a7b0a4f577b791063
            
            return diagnosis;
        }
    }
}