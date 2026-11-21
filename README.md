# MediQueue: Hospital Schedule Management

A Windows Forms hospital appointment system built with C# and SQL Server LocalDB (BSIT 1-P, OOP project).

Staff register patients, schedule check-ups, and check patients in. Doctors see their own queue, read each patient's full shared history, and record check-ups.

## Before you start

You need:

- **Visual Studio 2022** with these workloads: *.NET desktop development* and *Data storage and processing* (this installs SQL Server LocalDB)
- **Git**
- A **GitHub account** that has accepted the collaborator invite

## 1. Get the project

```powershell
git clone https://github.com/SherwinCari/Hospital_Management.git
cd Hospital_Management
```

Then open `OOP_Hospital_Schedule_Management.slnx` in Visual Studio.

## 2. Set up your own local database (important)

The database files (`*.mdf` and `*.ldf`) are **not stored in Git**. They are binary files that cannot be merged and are locked while Visual Studio is open. Every member builds their own copy from the SQL script instead, so everyone ends up with the same tables and sample data.

1. In Solution Explorer, right-click the `database` folder, then **Add → New Item → Service-based Database**. Name it `Database1.mdf`. (If the file already exists in your folder, skip this.)
2. Open **View → Server Explorer** (or SQL Server Object Explorer).
3. Expand **Data Connections**, right-click `Database1.mdf`, and choose **New Query**.
4. Open `database/mediqueue_setup.sql`, copy everything, paste it into the query window, and click **Execute**.
5. Refresh the connection. You should see the tables `Users`, `Departments`, `Doctors`, `Patients`, `DoctorAvailability`, `Appointments`, `Vitals`, `MedicalRecords`, and the view `vw_PatientVisitHistory`.

The script drops and recreates everything, so you can re-run it any time to reset your data.

If the script is changed by someone else, pull the update and run it again.

### Test logins

All accounts use the password `1234` (testing only).

| Role | Username |
|---|---|
| Staff | `staff1` |
| Doctor (Cardiology) | `msantos`, `creyes` |
| Doctor (Pediatrics) | `jtan`, `rgomez` |
| Doctor (Dermatology) | `lcruz`, `pnavarro` |

## 3. Project structure

```
OOP_Hospital_Schedule_Management
├── database/       mediqueue_setup.sql (shared), Database1.mdf (local only)
├── models/         Patient, CheckupRecord, Vitals, Appointment, Doctor, Department
├── data/           DbConnection, PatientRepository, AppointmentRepository, DoctorRepository
├── helpers/        CurrentUser (logged-in user session)
├── staff_tab/      staff_main_ui and staff forms
├── doctor_tab/     doctor_main_ui and doctor forms
└── main_ui         Login screen
```

## 4. Code rules

- **Forms never write SQL.** They call model and repository classes.
- **All patient data goes through the `Patient` class** (register, update medical info, load history, add check-up).
- Always use **parameterized queries** (`@name` with `SqlParameter`), never string concatenation.
- Saved medical records are **never edited or deleted**. A correction is a new record linked to the original.
- Class names are `PascalCase`, variables are `camelCase`, and database columns are `snake_case`.

## 5. Git workflow

Never work directly on `main`. Use one branch per task.

```powershell
git checkout main
git pull                                   # always pull first
git checkout -b feature/short-task-name    # e.g. feature/login-form

# ...do your work...

git status                                 # check what changed
git add .
git commit -m "Short, clear message"
git push -u origin feature/short-task-name
```

Then open GitHub, click **Compare & pull request**, and ask a teammate to review. After it is merged, everyone runs `git checkout main` and `git pull`.

### Branch name examples

- `feature/database-setup`
- `feature/login-form`
- `feature/schedule-checkup`
- `feature/doctor-dashboard`
- `fix/duplicate-patient-check`

### Commit message examples

- `Add Patient class and PatientRepository`
- `Fix queue number not resetting each day`
- `Update setup script with Vitals table`

### Avoid conflicts

- **Do not edit the same form at the same time.** Two people changing one `.Designer.cs` file almost always causes a conflict. Agree on who owns which form.
- Tell the team before changing a table or column name, then update `mediqueue_setup.sql` and everyone re-runs it.
- Pull often, and commit small changes.
- Never commit `bin/`, `obj/`, `.vs/`, `*.user`, `*.mdf` or `*.ldf`. They should all be in `.gitignore`.

## 6. Troubleshooting

| Problem | Fix |
|---|---|
| `Permission denied` on `Database1.mdf` when running `git add` | The file is locked and should not be committed. Make sure `*.mdf` and `*.ldf` are in `.gitignore`. If it was already tracked, run `git rm --cached` on both files. |
| `src refspec ... does not match any` on push | The branch has no commits yet. Run `git status`, `git add .`, and `git commit`, then push again. |
| `fatal: not a git repository` | You are not inside the project folder. Use `cd` to go into it first. |
| Merge conflict after `git pull` | Open the marked files (they contain `<<<<<<<`), keep the correct parts, then `git add` and `git commit`. Visual Studio's merge editor helps. |
| Cannot connect to the database | Check that LocalDB is installed, that `Database1.mdf` exists in the `database` folder, and that you ran the setup script. |
| Tables are missing or outdated | Re-run `mediqueue_setup.sql`. |

## 7. Team

| Member | Role / area |
|---|---|
| | |
| | |
| | |
