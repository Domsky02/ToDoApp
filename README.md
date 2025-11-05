# Zadanie Rekrutacyjne - ToDo App

# 

# Prosta aplikacja Full-Stack (CRUD) typu "ToDo List", zrealizowana w ramach zadania rekrutacyjnego.

# 

# Wymagane narzędzia

# 

# .NET 9 SDK

# 

# Angular CLI v20.3.8

# 

# Docker Desktop

# 

# Node.js (LTS)

# 

# Instrukcja Uruchomienia

# 

# 1\. Baza Danych (Docker)

# 

# Uruchom kontener PostgreSQL. Hasło (todoapp) jest zgodne z tym w appsettings.json.

# 

# docker run --name todoapp-postgres -e POSTGRES\_PASSWORD=todoapp -p 5432:5432 -d postgres

# 

# 2\. Backend (.NET API)

# 

# \# Wejdź do folderu backendu

# cd backend/TodoApi

# 

# \# Zastosuj migrację bazy

# dotnet ef database update

# 

# \# Uruchom API

# dotnet run

# 

# 3\. Frontend (Angular)

# 

# \# Wejdź do folderu frontendu

# cd frontend/TodoClient

# 

# \# Zainstaluj zależności

# npm install

# 

# \# Uruchom aplikację

# ng serve --open

# 

# Uruchomienie Testów

# 

# Aby uruchomić testy jednostkowe backendu (xUnit), wykonaj polecenie w folderze backend/TodoApi.Tests:

# 

# dotnet test



