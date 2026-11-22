using System.Data;
using OOP_Hospital_Schedule_Management.Models;
using OOP_Hospital_Schedule_Management.Repositories;

namespace OOP_Hospital_Schedule_Management.Controllers;

/// <summary>Validates scheduling actions and coordinates appointment persistence.</summary>
public sealed class ScheduleController(AppointmentRepository appointments)
{
    public DataTable GetPatients() => appointments.GetPatients();
    public DataTable GetDoctors() => appointments.GetDoctors();
    public DataTable GetSchedules(DateTime date) => appointments.GetSchedules(date);

    public ScheduleActionResult Create(AppointmentScheduleRequest request, int staffUserId)
    {
        var validation = Validate(request, staffUserId);
        if (validation is not null) return ScheduleActionResult.Failure(validation);
        try
        {
            appointments.Create(request, staffUserId);
            return ScheduleActionResult.Success("Appointment scheduled.");
        }
        catch (ScheduleConflictException ex)
        {
            return ScheduleActionResult.Failure(ex.Message);
        }
        catch (InvalidAppointmentException ex)
        {
            return ScheduleActionResult.Failure(ex.Message);
        }
    }

    public ScheduleActionResult Reschedule(int appointmentId, AppointmentScheduleRequest request)
    {
        if (appointmentId <= 0) return ScheduleActionResult.Failure("Select an appointment first.");
        var validation = Validate(request, staffUserId: null);
        if (validation is not null) return ScheduleActionResult.Failure(validation);
        try
        {
            return appointments.Reschedule(appointmentId, request)
                ? ScheduleActionResult.Success("Appointment updated.")
                : ScheduleActionResult.Failure("Only scheduled appointments can be changed.");
        }
        catch (ScheduleConflictException ex)
        {
            return ScheduleActionResult.Failure(ex.Message);
        }
        catch (InvalidAppointmentException ex)
        {
            return ScheduleActionResult.Failure(ex.Message);
        }
    }

    public ScheduleActionResult Cancel(int appointmentId)
    {
        if (appointmentId <= 0) return ScheduleActionResult.Failure("Select an appointment first.");
        return appointments.Cancel(appointmentId)
            ? ScheduleActionResult.Success("Appointment cancelled.")
            : ScheduleActionResult.Failure("Only scheduled appointments can be cancelled.");
    }

    private static string? Validate(AppointmentScheduleRequest request, int? staffUserId)
    {
        if (request.PatientId <= 0) return "Select a patient.";
        if (request.DoctorId <= 0) return "Select a doctor.";
        if (staffUserId.HasValue && staffUserId.Value <= 0) return "The staff user is not valid.";
        if (request.StartsAt < DateTime.Now) return "Choose a future date and time.";
        return null;
    }
}

public sealed record ScheduleActionResult(bool IsSuccess, string Message)
{
    public static ScheduleActionResult Success(string message) => new(true, message);
    public static ScheduleActionResult Failure(string message) => new(false, message);
}
