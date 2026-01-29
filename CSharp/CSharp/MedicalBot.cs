/*using CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    internal class Medic
    {
        public static void Main(string[] args)
        {
            Patient patient = new Patient();
            Console.WriteLine("Enter the name of the patient: ");
            patient.SetName(Console.ReadLine());
            Console.WriteLine("Enter the age of the Patient: ");
            patient.SetAge(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter the symptoms of the patient: ");
            patient.SetSymptom(Console.ReadLine());

            string name = patient.GetName();
            string symp = patient.GetSymptom();
            int age = patient.GetAge();

            Console.WriteLine("The name of the patient is: " + name + " , the age of the patient is: " + age + " , the symptom of the age is: " + symp);
            
            MedicalBot md=new MedicalBot();

            md.StartConsultation(patient);
           

        }
        
        
    }
}*/
