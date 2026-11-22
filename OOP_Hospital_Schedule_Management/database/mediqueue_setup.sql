-- =====================================================
-- MediQueue - Database setup script (SQL Server / LocalDB)  v3
-- Run this against Database1.mdf (Server Explorer >
-- right-click the database > New Query > paste > Execute)
-- WARNING: this resets the application's tables and deletes their existing data.
-- Back up the database before running this script against a database you need.
-- =====================================================

-- ---------- DROP (view and child tables first) ----------
IF OBJECT_ID('vw_PatientVisitHistory', 'V') IS NOT NULL DROP VIEW vw_PatientVisitHistory;
IF OBJECT_ID('MedicalRecords', 'U')        IS NOT NULL DROP TABLE MedicalRecords;
IF OBJECT_ID('Vitals', 'U')                IS NOT NULL DROP TABLE Vitals;
IF OBJECT_ID('Appointments', 'U')          IS NOT NULL DROP TABLE Appointments;
IF OBJECT_ID('DoctorAvailability', 'U')    IS NOT NULL DROP TABLE DoctorAvailability;
IF OBJECT_ID('Doctors', 'U')               IS NOT NULL DROP TABLE Doctors;
IF OBJECT_ID('Patients', 'U')              IS NOT NULL DROP TABLE Patients;
IF OBJECT_ID('Departments', 'U')           IS NOT NULL DROP TABLE Departments;
IF OBJECT_ID('Users', 'U')                 IS NOT NULL DROP TABLE Users;
GO

-- ---------- TABLES ----------
CREATE TABLE Users (
    user_id    INT IDENTITY(1,1) PRIMARY KEY,
    username   NVARCHAR(50)  NOT NULL UNIQUE,
    password   NVARCHAR(100) NOT NULL,          -- plain text for now; hash before final demo
    role       NVARCHAR(10)  NOT NULL CHECK (role IN ('Staff', 'Doctor')),
    full_name  NVARCHAR(100) NOT NULL
);

CREATE TABLE Departments (
    department_id   INT IDENTITY(1,1) PRIMARY KEY,
    department_name NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Doctors (
    doctor_id     INT IDENTITY(1,1) PRIMARY KEY,
    user_id       INT NOT NULL UNIQUE REFERENCES Users(user_id),
    department_id INT NOT NULL REFERENCES Departments(department_id),
    full_name     NVARCHAR(100) NOT NULL
);

-- One shared record per patient. Patient-level medical info lives here,
-- so any doctor who opens the patient sees it.
CREATE TABLE Patients (
    patient_id              INT IDENTITY(1,1) PRIMARY KEY,
    full_name               NVARCHAR(100) NOT NULL,
    birthdate               DATE          NULL,
    contact_no              NVARCHAR(20)  NULL,
    address                 NVARCHAR(200) NULL,
    blood_type              NVARCHAR(5)   NULL,
    allergies               NVARCHAR(200) NULL,
    existing_conditions     NVARCHAR(200) NULL,
    emergency_contact_name  NVARCHAR(100) NULL,
    emergency_contact_no    NVARCHAR(20)  NULL,
    created_at              DATETIME      NOT NULL DEFAULT GETDATE(),
    -- Added by the team for walk-in registration (exist in the real Database1.mdf):
    department_id           INT           NULL REFERENCES Departments(department_id),
    problem_description     NVARCHAR(MAX) NULL
);

CREATE TABLE DoctorAvailability (
    availability_id INT IDENTITY(1,1) PRIMARY KEY,
    doctor_id       INT  NOT NULL REFERENCES Doctors(doctor_id),
    slot_date       DATE NOT NULL,
    slot_time       TIME(0) NOT NULL,
    is_booked       BIT  NOT NULL DEFAULT 0,
    CONSTRAINT UQ_DoctorSlot UNIQUE (doctor_id, slot_date, slot_time)
);

-- Status flow: Scheduled -> Checked-in -> Completed
--              (or Cancelled / No-show)
CREATE TABLE Appointments (
    appointment_id   INT IDENTITY(1,1) PRIMARY KEY,
    patient_id       INT NOT NULL REFERENCES Patients(patient_id),
    department_id    INT NOT NULL REFERENCES Departments(department_id),
    -- Walk-in registration creates a queue entry before a doctor claims it.
    doctor_id        INT NULL REFERENCES Doctors(doctor_id),
    created_by       INT NOT NULL REFERENCES Users(user_id),   -- staff who scheduled it
    appointment_date DATE    NOT NULL,
    appointment_time TIME(0) NOT NULL,
    status           NVARCHAR(15) NOT NULL DEFAULT 'Scheduled'
                     CHECK (status IN ('Scheduled', 'Checked-in', 'Completed', 'Cancelled', 'No-show')),
    queue_number     INT      NULL,        -- assigned at check-in
    checked_in_at    DATETIME NULL,
    created_at       DATETIME NOT NULL DEFAULT GETDATE()
);

-- Prevent double-booking the same doctor/date/time.
-- Cancelled and No-show appointments do not block the slot.
CREATE UNIQUE INDEX UX_Appointments_NoDoubleBooking
    ON Appointments (doctor_id, appointment_date, appointment_time)
    WHERE doctor_id IS NOT NULL
      AND status IN ('Scheduled', 'Checked-in', 'Completed');

-- A patient cannot be booked with two doctors at the same date and time.
CREATE UNIQUE INDEX UX_Appointments_PatientNoDoubleBooking
    ON Appointments (patient_id, appointment_date, appointment_time)
    WHERE status IN ('Scheduled', 'Checked-in', 'Completed');

-- Entered at check-in (by staff acting as the nurse), read by the doctor.
CREATE TABLE Vitals (
    vital_id        INT IDENTITY(1,1) PRIMARY KEY,
    appointment_id  INT NOT NULL UNIQUE REFERENCES Appointments(appointment_id),
    blood_pressure  NVARCHAR(10)  NULL,     -- e.g. 120/80
    temperature_c   DECIMAL(4,1)  NULL,
    pulse_rate      INT           NULL,
    weight_kg       DECIMAL(5,1)  NULL,
    chief_complaint NVARCHAR(200) NULL,
    recorded_by     INT NOT NULL REFERENCES Users(user_id),
    recorded_at     DATETIME NOT NULL DEFAULT GETDATE()
);

-- Check-up history. Shared across all doctors (read access),
-- but only the attending doctor writes (recorded_by).
-- Saved records are never edited or deleted: a correction is a NEW row
-- that points to the original through corrects_record_id.
CREATE TABLE MedicalRecords (
    record_id          INT IDENTITY(1,1) PRIMARY KEY,
    appointment_id     INT NOT NULL REFERENCES Appointments(appointment_id),
    patient_id         INT NOT NULL REFERENCES Patients(patient_id),
    recorded_by        INT NOT NULL REFERENCES Doctors(doctor_id),
    diagnosis          NVARCHAR(200) NULL,
    prescription       NVARCHAR(300) NULL,
    notes              NVARCHAR(MAX) NULL,
    follow_up_date     DATE NULL,                      -- next appointment date (optional)
    corrects_record_id INT  NULL REFERENCES MedicalRecords(record_id),
    record_date        DATETIME NOT NULL DEFAULT GETDATE()
);

-- Only one ORIGINAL record per appointment (corrections are allowed)
CREATE UNIQUE INDEX UX_MedicalRecords_OnePerAppointment
    ON MedicalRecords (appointment_id)
    WHERE corrects_record_id IS NULL;
GO

-- ---------- SAMPLE DATA ----------

-- Departments
INSERT INTO Departments (department_name) VALUES
 ('Cardiology'), ('Pediatrics'), ('Dermatology');

-- Users (1 staff + 6 doctors) -- password is "1234" for everyone
INSERT INTO Users (username, password, role, full_name) VALUES
 ('staff1',  '1234', 'Staff',  'Ana Lopez'),
 ('msantos', '1234', 'Doctor', 'Dr. Maria Santos'),
 ('creyes',  '1234', 'Doctor', 'Dr. Carlos Reyes'),
 ('jtan',    '1234', 'Doctor', 'Dr. Jenny Tan'),
 ('rgomez',  '1234', 'Doctor', 'Dr. Ramon Gomez'),
 ('lcruz',   '1234', 'Doctor', 'Dr. Liza Cruz'),
 ('pnavarro','1234', 'Doctor', 'Dr. Paolo Navarro');

-- Doctors (user_id matches the order above: staff1 = 1, msantos = 2, ...)
-- doctor_id: Santos=1, Reyes=2, Tan=3, Gomez=4, Cruz=5, Navarro=6
INSERT INTO Doctors (user_id, department_id, full_name) VALUES
 (2, 1, 'Dr. Maria Santos'),    -- Cardiology
 (3, 1, 'Dr. Carlos Reyes'),    -- Cardiology
 (4, 2, 'Dr. Jenny Tan'),       -- Pediatrics
 (5, 2, 'Dr. Ramon Gomez'),     -- Pediatrics
 (6, 3, 'Dr. Liza Cruz'),       -- Dermatology
 (7, 3, 'Dr. Paolo Navarro');   -- Dermatology

-- Patients
INSERT INTO Patients (full_name, birthdate, contact_no, address, blood_type, allergies, existing_conditions, emergency_contact_name, emergency_contact_no) VALUES
 ('Juan Dela Cruz', '1990-05-14', '09171234567', 'Cainta, Rizal',  'O+', 'Penicillin', 'Hypertension', 'Rosa Dela Cruz', '09170000001'),
 ('Maria Clara',     '1985-11-02', '09181234567', 'Taytay, Rizal',  'A+', NULL,         NULL,           'Jose Clara',     '09180000002'),
 ('Pedro Penduko',   '2015-03-20', '09191234567', 'Antipolo, Rizal', NULL, NULL,        NULL,           'Lita Penduko',   '09190000003');

-- Example availability for today and tomorrow. Dates stay current when the
-- setup script is run by another team member or at a later time.
;WITH Days  AS (SELECT CAST(GETDATE() AS DATE) AS d
                UNION SELECT DATEADD(DAY, 1, CAST(GETDATE() AS DATE))),
      Hours AS (SELECT CAST('09:00' AS TIME(0)) AS t
                UNION ALL SELECT CAST('10:00' AS TIME(0))
                UNION ALL SELECT CAST('11:00' AS TIME(0))
                UNION ALL SELECT CAST('12:00' AS TIME(0)))
INSERT INTO DoctorAvailability (doctor_id, slot_date, slot_time, is_booked)
SELECT doc.doctor_id, Days.d, Hours.t, 0
FROM Doctors doc CROSS JOIN Days CROSS JOIN Hours;

-- (1) PAST visit: Juan saw Dr. Carlos Reyes on Oct 15, 2026 (shows shared history across doctors)
INSERT INTO Appointments (patient_id, department_id, doctor_id, created_by, appointment_date, appointment_time, status, queue_number)
VALUES (1, 1, 2, 1, DATEADD(DAY, -39, CAST(GETDATE() AS DATE)), '10:00', 'Completed', 1);

INSERT INTO Vitals (appointment_id, blood_pressure, temperature_c, pulse_rate, weight_kg, chief_complaint, recorded_by)
VALUES (1, '150/95', 36.8, 88, 78.5, 'Headache and dizziness', 1);

INSERT INTO MedicalRecords (appointment_id, patient_id, recorded_by, diagnosis, prescription, notes, follow_up_date)
VALUES (1, 1, 2, 'Mild hypertension', 'Amlodipine 5mg once daily', 'Advised low-salt diet. Monitor BP at home.', CAST(GETDATE() AS DATE));

-- (2) Example follow-up: Juan -> Dr. Maria Santos, today at 10:00 AM.
INSERT INTO Appointments (patient_id, department_id, doctor_id, created_by, appointment_date, appointment_time, status)
VALUES (1, 1, 1, 1, CAST(GETDATE() AS DATE), '10:00', 'Scheduled');
UPDATE DoctorAvailability SET is_booked = 1
WHERE doctor_id = 1 AND slot_date = CAST(GETDATE() AS DATE) AND slot_time = '10:00';

-- (3) TODAY: Maria Clara -> Dr. Maria Santos 9:00 AM, already checked in (queue #1) with vitals
INSERT INTO Appointments (patient_id, department_id, doctor_id, created_by, appointment_date, appointment_time, status, queue_number, checked_in_at)
VALUES (2, 1, 1, 1, CAST(GETDATE() AS DATE), '09:00', 'Checked-in', 1, GETDATE());
INSERT INTO Vitals (appointment_id, blood_pressure, temperature_c, pulse_rate, weight_kg, chief_complaint, recorded_by)
VALUES (SCOPE_IDENTITY(), '118/76', 36.6, 72, 58.0, 'Chest tightness when climbing stairs', 1);
UPDATE DoctorAvailability SET is_booked = 1
WHERE doctor_id = 1 AND slot_date = CAST(GETDATE() AS DATE) AND slot_time = '09:00';

-- (4) TODAY: Pedro Penduko -> Dr. Jenny Tan 9:00 AM, still Scheduled (not yet arrived)
INSERT INTO Appointments (patient_id, department_id, doctor_id, created_by, appointment_date, appointment_time, status)
VALUES (3, 2, 3, 1, CAST(GETDATE() AS DATE), '09:00', 'Scheduled');
UPDATE DoctorAvailability SET is_booked = 1
WHERE doctor_id = 3 AND slot_date = CAST(GETDATE() AS DATE) AND slot_time = '09:00';
GO

-- ---------- VIEW: patient visit history (all doctors) ----------
CREATE VIEW vw_PatientVisitHistory AS
SELECT
    a.appointment_id,
    p.patient_id,
    p.full_name        AS patient_name,
    dep.department_id,
    dep.department_name,
    d.doctor_id,
    d.full_name        AS doctor_name,
    a.appointment_date,
    a.appointment_time,
    a.status,
    a.queue_number,
    v.blood_pressure,
    v.temperature_c,
    v.pulse_rate,
    v.weight_kg,
    v.chief_complaint,
    r.record_id,
    r.diagnosis,
    r.prescription,
    r.notes,
    r.follow_up_date,
    r.corrects_record_id
FROM Appointments a
JOIN Patients    p   ON a.patient_id    = p.patient_id
JOIN Departments dep ON a.department_id = dep.department_id
JOIN Doctors     d   ON a.doctor_id     = d.doctor_id
LEFT JOIN Vitals         v ON v.appointment_id = a.appointment_id
LEFT JOIN MedicalRecords r ON r.appointment_id = a.appointment_id;
GO

-- =====================================================
-- QUERIES TO USE IN C# (use parameters: @doctorId, @patientId, ...)
-- Keep them in your repository classes, not in the forms.
-- =====================================================

-- A) Doctor dashboard, Table 1: today's patients, checked-in first (by queue number)
-- SELECT a.appointment_id, p.patient_id, p.full_name, a.appointment_time,
--        a.status, a.queue_number, dep.department_name
-- FROM Appointments a
-- JOIN Patients p ON a.patient_id = p.patient_id
-- JOIN Departments dep ON a.department_id = dep.department_id
-- WHERE a.doctor_id = @doctorId
--   AND a.appointment_date = CAST(GETDATE() AS DATE)
--   AND a.status IN ('Scheduled', 'Checked-in')
-- ORDER BY CASE a.status WHEN 'Checked-in' THEN 0 ELSE 1 END, a.queue_number, a.appointment_time;

-- B) Doctor dashboard, Table 2: NEW patients = no medical record with ANY doctor
-- SELECT a.appointment_id, p.patient_id, p.full_name, a.appointment_time, a.status
-- FROM Appointments a
-- JOIN Patients p ON p.patient_id = a.patient_id
-- WHERE a.doctor_id = @doctorId
--   AND a.appointment_date = CAST(GETDATE() AS DATE)
--   AND a.status IN ('Scheduled', 'Checked-in')
--   AND NOT EXISTS (SELECT 1 FROM MedicalRecords r WHERE r.patient_id = p.patient_id);

-- C) Medical History tab: FULL history from ALL doctors
-- SELECT appointment_date, department_name, doctor_name, chief_complaint,
--        blood_pressure, temperature_c, pulse_rate, weight_kg,
--        diagnosis, prescription, notes, follow_up_date, corrects_record_id
-- FROM vw_PatientVisitHistory
-- WHERE patient_id = @patientId AND record_id IS NOT NULL
-- ORDER BY appointment_date DESC, record_id DESC;

-- D) Staff check-in: set status and assign the next queue number for that doctor today
-- UPDATE Appointments
-- SET status = 'Checked-in',
--     checked_in_at = GETDATE(),
--     queue_number = (SELECT ISNULL(MAX(queue_number), 0) + 1
--                     FROM Appointments
--                     WHERE doctor_id = @doctorId AND appointment_date = @date)
-- WHERE appointment_id = @appointmentId AND status = 'Scheduled';
-- (then INSERT INTO Vitals (...) for that appointment_id)

-- E) Doctor saves a check-up: insert the record, then complete the appointment
--    (do both inside ONE SqlTransaction in C#)
-- INSERT INTO MedicalRecords (appointment_id, patient_id, recorded_by, diagnosis, prescription, notes, follow_up_date)
-- VALUES (@appointmentId, @patientId, @doctorId, @diagnosis, @prescription, @notes, @followUpDate);
-- UPDATE Appointments SET status = 'Completed' WHERE appointment_id = @appointmentId;

-- F) Correction note (never UPDATE an old record): insert a new row pointing to the original
-- INSERT INTO MedicalRecords (appointment_id, patient_id, recorded_by, diagnosis, notes, corrects_record_id)
-- VALUES (@appointmentId, @patientId, @doctorId, @diagnosis, @notes, @originalRecordId);

-- G) Doctor updates patient-level medical info (allergies etc.)
-- UPDATE Patients
-- SET blood_type = @bloodType, allergies = @allergies, existing_conditions = @conditions,
--     emergency_contact_name = @ecName, emergency_contact_no = @ecNo
-- WHERE patient_id = @patientId;

-- H) Cancel / No-show: update status AND free the slot (one transaction)
-- UPDATE Appointments SET status = 'Cancelled' WHERE appointment_id = @appointmentId;
-- UPDATE DoctorAvailability SET is_booked = 0
-- WHERE doctor_id = @doctorId AND slot_date = @date AND slot_time = @time;

-- I) Duplicate check before registering a patient
-- SELECT patient_id, full_name FROM Patients
-- WHERE full_name = @fullName AND birthdate = @birthdate;

-- J) Staff follow-up list: patients due for a return visit this week
-- SELECT p.full_name, p.contact_no, r.follow_up_date, r.diagnosis
-- FROM MedicalRecords r JOIN Patients p ON p.patient_id = r.patient_id
-- WHERE r.follow_up_date BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(DAY, 7, CAST(GETDATE() AS DATE))
-- ORDER BY r.follow_up_date;

-- ---------- QUICK CHECKS (optional) ----------
-- SELECT * FROM Appointments;
-- SELECT * FROM vw_PatientVisitHistory WHERE patient_id = 1;
