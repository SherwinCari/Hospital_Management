using System.Data;

namespace OOP_Hospital_Schedule_Management.Controllers;

/// <summary>Coordinates patient registration and search between views and persistence.</summary>
public sealed class PatientController
{
    private readonly PatientRepository _patients;

    public PatientController(PatientRepository patients) => _patients = patients;

    public DataTable GetDepartments() => _patients.GetDepartments();

    public PatientActionResult Register(Patient patient, int staffUserId)
    {
        if (patient.DepartmentId <= 0)
            return PatientActionResult.Failure("Select a department.");
        try
        {
            _patients.RegisterAndQueue(patient, staffUserId);
            return PatientActionResult.Success("Patient registered and added to the department queue.");
        }
        catch (DuplicatePatientException)
        {
            return PatientActionResult.Failure("A patient with this name and birthdate is already registered.");
        }
    }

    public DataTable Search(string query) => _patients.Search(query?.Trim() ?? string.Empty);
}

public sealed record PatientActionResult(bool IsSuccess, string Message)
{
    public static PatientActionResult Success(string message) => new(true, message);
    public static PatientActionResult Failure(string message) => new(false, message);
}
