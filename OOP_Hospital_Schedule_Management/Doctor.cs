namespace OOP_Hospital_Schedule_Management
{
    public class Doctor : Person
    {
        public Doctor(int doctorId, string fullName, int departmentId, string departmentName)
            : base(fullName)
        {
            DoctorId = doctorId;
            DepartmentId = departmentId;
            DepartmentName = departmentName;
        }

        public int DoctorId { get; private set; }
        public int DepartmentId { get; private set; }
        public string DepartmentName { get; private set; }
    }
}