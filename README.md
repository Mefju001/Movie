# 🎮 Filmweb Clone (ASP.NET Core + PostgreSQL)

Prosty klon Filmwebu zbudowany w ASP.NET Core Web API z wykorzystaniem Entity Framework Core i PostgreSQL jako bazy danych. Projekt sluży do nauki C#, EF Core oraz tworzenia REST API.

---

## 🚀 Technologie

* ASP.NET Core Web API (.NET 7/8)
* Entity Framework Core
* PostgreSQL
* JWT Authentication (planowane)
* REST API
* (Opcjonalnie: Blazor/React jako frontend)

---

## 📂 Struktura projektu

```
FilmwebApp/
├── Controllers/
├── Models/
├── Data/
├── DTOs/
├── Migrations/
├── Program.cs
└── appsettings.json
```

---

## ⚙️ Konfiguracja

### 1. Klonowanie repozytorium

```bash
git clone https://github.com/twoj-login/filmweb-clone.git
cd filmweb-clone
```

### 2. Ustawienia połączenia do bazy

W `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=FilmwebDb;Username=postgres;Password=TwojeHaslo"
}
```

---

## 💠 Migracje i baza danych

### Instalacja narzędzi EF Core (jeśli jeszcze nie masz):

```bash
dotnet tool install --global dotnet-ef
```

### Tworzenie migracji:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 📬 Endpointy API

| Metoda | Endpoint             | Opis                    |
| ------ | -------------------- | ----------------------- |
| GET    | `/api/movies`        | Pobierz wszystkie filmy |
| GET    | `/api/movies/{id}`   | Szczegóły filmu         |
| POST   | `/api/movies`        | Dodaj film (admin/dev)  |
| POST   | `/api/reviews`       | Dodaj recenzję          |
| POST   | `/api/auth/register` | Rejestracja użytkownika |
| POST   | `/api/auth/login`    | Logowanie i JWT         |

---

## ✅ TODO

* [x] Konfiguracja EF Core z PostgreSQL
* [x] Modele: `Movie`, `Review`
* [x] REST API (GET, POST)
* [ ] JWT autoryzacja i role
* [ ] Frontend (Blazor/React)
* [ ] Rekomendacje filmów
* [ ] Ulubione / top lista

---

## 📌 Wymagania

* .NET 7 lub .NET 8
* PostgreSQL
* Visual Studio / VS Code
* `dotnet-ef` CLI

---

## 📄 Licencja

Projekt edukacyjny. Możesz używać i modyfikować do własnych celów.
