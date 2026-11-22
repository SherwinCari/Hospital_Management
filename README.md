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

## 2. Database setup

The app uses a private SQL Server LocalDB database named `MediQueue` for the current Windows user. On first launch, it creates that database and initializes it with `OOP_Hospital_Schedule_Management/database/mediqueue_setup.sql`.

You need Visual Studio's **Data storage and processing** workload (which installs LocalDB). You do not need to create or attach `Database1.mdf`, execute SQL manually, or edit a connection string. The old `Database1.mdf` and `Database1_log.ldf` files are not used by the app.

The setup script contains sample accounts and records. It drops and recreates tables, but the app runs it only when creating a new `MediQueue` database. Existing databases with an incomplete schema are left untouched and reported as an error.

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
├── Controllers/    PatientController, ScheduleController
├── Data/           Db (per-user LocalDB initialization)
├── Models/         Person, Patient, Doctor, AppointmentScheduleRequest
├── Repositories/   PatientRepository, AppointmentRepository
├── Views/          Main, Patients, Staff, Doctor WinForms
└── database/       mediqueue_setup.sql
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
