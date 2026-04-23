# University HR Management System

A full-stack HR management web application built for the German University in Cairo (GUC). The system supports three user roles — **Employee**, **Admin**, and **HR** — each with their own portal and set of features.

---

## Tech Stack

- **Frontend:** ASP.NET Web Forms (ASPX), HTML, CSS
- **Backend:** C# (.NET Framework 4.8)
- **Database:** Microsoft SQL Server (LocalDB)
- **Architecture:** Role-based access control with stored procedures and user-defined functions

---

## Features

### Employee Portal
- View semester performance evaluations
- View monthly attendance records
- View last month's payroll
- View salary deductions by month
- Apply for Annual, Accidental, Medical, Unpaid, and Compensation leaves
- Track leave request status
- Approve/Reject leaves (Managers only)
- Evaluate other employees (Deans only)

### Admin Portal
- View all employee profiles
- Update employee attendance (check-in / check-out)
- Remove deductions
- View employee count per department
- Initiate daily attendance
- Add official holidays
- View rejected medical leaves
- Fetch yesterday's attendance report
- Fetch winter semester performance report
- Remove attendance for holidays
- Replace employees during leave periods
- Update employment status

### HR Portal
- Approve / Reject Annual & Accidental leave requests
- Approve / Reject Unpaid leave requests
- Approve / Reject Compensation leave requests
- Add deductions (missing hours, missing days, unpaid leave)
- Generate monthly payroll for employees

---

## Login Credentials

### Admin (hardcoded)
| ID | Password |
|----|----------|
| 1  | `adminpassword` |

### Employee Portal
| ID | Name | Password |
|----|------|----------|
| 1  | Jack John | `123` |
| 2  | Ahmed Zaki | `345` |
| 3  | Sarah Sabry | `567` |
| 9  | Amr Diab | `8954` |
| 13 | Hazem Ali (Dean) | `h@123` |
| 14 | Hadeel Adel (Vice Dean) | `ha@123` |

### HR Portal
| ID | Name | Password |
|----|------|----------|
| 4  | Ahmed Helmy | `908` |
| 5  | Menna Shalaby | `670` |
| 10 | Marwan Khaled (HR Manager) | `9023` |

---

## Project Structure
DatabaseProjV1/
├── WebApplications/
│ └── DatabaseProject/
│ ├── *.aspx # Page views
│ ├── *.aspx.cs # Code-behind logic
│ ├── *.ascx # Navigation bar controls
│ ├── site.css # Global stylesheet
│ └── Web.config # DB connection string
└── GUC_126_67_62304_.../
├── final_implementation.sql # Schema, stored procedures & functions
└── SqlQuery_1.sql # Seed data


---

## Setup

1. Open `WebApplications/WebApplications.sln` in Visual Studio
2. Restore the database using `final_implementation.sql` then `SqlQuery_1.sql` in SQL Server
3. Update the connection string in `Web.config` if needed
4. Run the project with IIS Express

---

## Database

The SQL Server database includes:
- Tables for Employees, Departments, Roles, Attendance, Leaves, Payroll, and Deductions
- Stored procedures for all business logic
- User-defined functions for login validation, salary calculation, and reporting
- Triggers for automated workflow (leave approval chains, attendance tracking)
