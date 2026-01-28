using System;
namespace CSharp
{
    public class Employee
    {
        internal string name;
        private int age;
        public string type;
        internal int leaveBalance=30;
        private static int allowedLeaves = 30;

        public void SetName(Employee employee)
        {
            Console.WriteLine("Enter the employee name: ");
            string name = Console.ReadLine();
            employee.name = name;
        }

        public void SetAge(Employee employee)
        {
            Console.WriteLine("Enter the employee's age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            employee.age = age;
        }

        public void SetType(Employee employee)
        {
            Console.WriteLine("Enter the employment type of the employee: ");
            string type = Console.ReadLine();
            employee.type = type;
        }

        public void UpdateLeaves(Employee employee, int leaves)
        {
            employee.leaveBalance = employee.leaveBalance - leaves;
        }



    }

    public class LeaveManager
    {
        public void LeaveApprover(Employee employee, int days)
        {
            if (employee.leaveBalance > days)
            {
                employee.UpdateLeaves(employee, days);
            }
            else
            {
                Console.WriteLine("Cannot apply for leaves!! Leave Balance: " + employee.leaveBalance);
            }
        }
        public void LeaveApprover(Employee employee, DateTime startDate, DateTime endDate)
        {
            int days = (int)(endDate - startDate).TotalDays;

            if (employee.leaveBalance > days)
            {
                employee.UpdateLeaves(employee, days);
            }
            else
            {
                Console.WriteLine("Cannot apply for leaves!! Leave Balance: " + employee.leaveBalance);
            }
        }
    }

    public class ContractLeaveManager : LeaveManager
    {
        public void LeaveApprover(Employee employee, int days)
        {
            employee.leaveBalance = 20;
            if (employee.leaveBalance > days)
            {
                employee.UpdateLeaves(employee, days);
            }
            else
            {
                Console.WriteLine("Cannot apply for leaves!! Leave Balance: " + employee.leaveBalance);
            }
        }
        public void LeaveApprover(Employee employee, DateTime startDate, DateTime endDate)
        {

            int days = (int)(endDate - startDate).TotalDays;
            days = days - 5;
            if (employee.leaveBalance > days)
            {
                days = days - 5;
                employee.UpdateLeaves(employee, days);
            }
            else
            {
                Console.WriteLine("Cannot apply for leaves!! Leave Balance: " + employee.leaveBalance);
            }
        }
    }

    public class Patient
    {
        string name;
        int age;
        string symptom;

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public void SetSymptom(string symptom, string description="")
        {
            this.symptom = symptom;

            if (description != "")
            {
                symptom += "-" + description;
            }
        }

        public string GetName()
        {
            return name;
        }

        public int GetAge() 
        { 
            return age;
        }

        public string GetSymptom()
        {
            return symptom;
        }
    }

    public class MedicalBot
    {
        public void StartConsultation(Patient patient)
        {
            string advice;
            AnalyzeSymptoms(patient.GetSymptom(), patient, out advice);
            Console.WriteLine(advice);
        }

        private void AnalyzeSymptoms(string symptom,Patient patient, out string advice)
        {
            bool IsSevere()
            {
                return symptom.ToLower().Contains("chest") || symptom.ToLower().Contains("breathing");
            }

            bool IsEmergency()
            {
                return patient.GetAge() > 60 && IsSevere();
            }

            if (IsSevere())
            {
                advice = "This is a serious cause of concern, please report to your doctor as soon as possible!!";
            }

            if (IsEmergency())
            {
                advice = "This is an emergency, please visit your hospital at the earliest!!!!";
            }

            else
            {
                advice = "This is a mild disease, take medications and rest!";
            }
        }
    }
}

