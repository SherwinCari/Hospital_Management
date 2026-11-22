using System;

namespace OOP_Hospital_Schedule_Management
{
    public class Patient : Person
    {
        private string _bloodType;

        public Patient(string fullName) : base(fullName)
        {
        }

        public string BloodType
        {
            get { return _bloodType; }
            set
            {
                string[] valid = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
                if (!string.IsNullOrEmpty(value) && Array.IndexOf(valid, value) < 0)
                    throw new ArgumentException("Invalid blood type.");
                _bloodType = value;
            }
        }

        public string Allergies { get; set; }
        public string ExistingConditions { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNo { get; set; }
        public int DepartmentId { get; set; }
        public string ProblemDescription { get; set; }
    }
}