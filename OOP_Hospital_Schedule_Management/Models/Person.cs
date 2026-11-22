using System;

namespace OOP_Hospital_Schedule_Management
{
    public abstract class Person
    {
        // private fields: only this class touches them directly
        private string _fullName;
        private DateTime? _birthdate;

        protected Person(string fullName)
        {
            FullName = fullName;
        }

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

        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}