# 🌿 GreenBuddy – Smart Plant Care Reminder API

GreenBuddy is a backend API project that helps users manage and maintain their houseplants through structured care schedules, 
smart reminders, and care logging.The project is built following **Clean Architecture**, uses **CQRS with MediatR**, and
integrates modern backend development practices like **JWT authentication**, **DTO mapping**, and **unit testing**.

---

## 🧠 Project Idea (Scenario)

Many plant lovers struggle to consistently remember when to water or fertilize their plants — 
leading to overwatering, neglect, or general confusion.
**GreenBuddy** solves this by acting as a smart assistant that helps you:

- Keep track of all your plants
- Set care schedules (like watering every 5 days)
- Receive reminders when it's time to take action
- Log completed care activities
- View care history over time

It’s like having a gardening journal and reminder system in one — but in API form.

---

## 🎯 Project Goals

| Goal | Description |
|------|-------------|
| 🌱 Track Plants | Users can register their houseplants and manage basic data like name, species, and care instructions. |
| 🔁 Care Schedules | Each plant can have recurring tasks like watering, misting, or fertilizing with customizable frequencies. |
| 📓 Logging | When a care task is completed, it gets logged with a timestamp and optional notes. |
| 🔐 Auth | Secure endpoints with JWT and support for role-based access (e.g., Admin vs User). |
| 📦 Clean Architecture | Ensure clear separation between layers (API, Application, Domain, Infrastructure). |
| 🧪 Testing | Provide reliable unit tests for CQRS handlers to ensure logic is validated. |

---

## ✅ Deliverables

- [x] Full CRUD API for:
  - `Plant`
  - `CareTask`
  - `CareLog`
- [x] CQRS with MediatR
- [x] Repository pattern (generic optional)
- [x] DTOs via AutoMapper
- [x] FluentValidation pipeline
- [x] JWT-based authentication
- [x] Role-based access control 
- [x] Unit tests for handlers 

---

## 🧱 Technologies Used

- ASP.NET Core 8
- MediatR
- AutoMapper
- Entity Framework Core
- FluentValidation
- JWT Authentication
- PostgreSQL / SQL Server
- xUnit / NUnit for testing
- Postman

---

## 📁 Clean Architecture Layout

