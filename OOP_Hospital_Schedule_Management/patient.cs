using System;

namespace OOP_Hospital_Schedule_Management
{
    public class Patient
    {
        // private fields: only this class can touch them directly
        private string _fullName;
        private DateTime? _birthdate;
        private string _bloodType;

        public Patient(string fullName)
        {
            FullName = fullName;
        }

        // properties with rules
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name is required.");
                _fullName = value.Trim();
            }
        }

        public DateTime? Birthdate
        {
            get { return _birthdate; }
            set
            {
                if (value.HasValue && value.Value.Date > DateTime.Today)
                    throw new ArgumentException("Birthdate cannot be in the future.");
                _birthdate = value;
            }
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

        // read-only: calculated, no setter
        public int? Age
        {
            get
            {
                if (_birthdate == null) return null;
                int age = DateTime.Today.Year - _birthdate.Value.Year;
                if (_birthdate.Value.Date > DateTime.Today.AddYears(-age)) age--;
                return age;
            }
        }

        // simple properties
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Allergies { get; set; }
        public string ExistingConditions { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNo { get; set; }
        public int DepartmentId { get; set; }
        public string ProblemDescription { get; set; }
    }
}