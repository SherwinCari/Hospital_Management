namespace OOP_Hospital_Schedule_Management.Models;

/// <summary>Input for a staff member creating or rescheduling an appointment.</summary>
public sealed record AppointmentScheduleRequest(
    int PatientId,
    int DoctorId,
    DateTime StartsAt);
