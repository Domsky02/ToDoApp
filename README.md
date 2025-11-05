# Zadanie Rekrutacyjne - ToDo App

Prosta aplikacja Full-Stack (CRUD) typu "ToDo List", zrealizowana w ramach zadania rekrutacyjnego.

## Wymagane narzędzia

* .NET 9 SDK
* Angular CLI (v20 lub nowszy)
* Node.js (wersja LTS)
* Docker Desktop

-----

## Instrukcja Uruchomienia

### 1\. Baza Danych (Docker)

Uruchom kontener PostgreSQL. Hasło (`todoapp`) jest zgodne z tym w `appsettings.json`.

```bash
docker run --name todoapp-postgres -e POSTGRES_PASSWORD=todoapp -p 5432:5432 -d postgres
```

### 2\. Backend (.NET API)

W terminalu przejdź do folderu backendu, zastosuj migracje i uruchom API.

```bash
# Wejdź do folderu backendu
cd backend/TodoApi

# Zastosuj migrację bazy
dotnet ef database update

# Uruchom API
dotnet run
```

### 3\. Frontend (Angular)

W **nowym** terminalu przejdź do folderu frontendu, zainstaluj zależności i uruchom aplikację.

```bash
# Wejdź do folderu frontendu
cd frontend/TodoClient

# Zainstaluj zależności
npm install

# Uruchom aplikację
ng serve --open
```

Aplikacja powinna automatycznie otworzyć się w przeglądarce pod adresem `http://localhost:4200`.

-----

## Uruchomienie Testów

Aby uruchomić testy jednostkowe backendu (xUnit), wykonaj polecenie w folderze `backend/TodoApi.Tests`:

```bash
dotnet test
```