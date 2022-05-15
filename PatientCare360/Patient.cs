using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PatientCare360
{
    class Patient
    {
        private int age;
        private bool gender;

        public static void ConvertsValues_to_HIGH_LOW_Normal(Dictionary<string, string> dict)
        {
            var age = dict["age"];
            // var 

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
    }
}
