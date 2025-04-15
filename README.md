# ✈️ Airline Reservation Console System (Array Version)

A C# console-based airline reservation system using **arrays** to manage flight and booking data.
This project provides a basic simulation of flight booking operations with 
user and admin functionalities. Ideal for learning programming fundamentals,
array handling, and basic logic flow in C#.

---

## 🛠 Features

- Admin and User Modes
- Add new flights (Admin only)
- Book flights with optional discount codes
- Cancel existing bookings
- Display all available flights
- Show detailed flight information
- Search flights by destination city
- Update departure time of a flight
- Generate unique Booking IDs
- Calculate fares (with and without discount)
- Use of method overloading and optional parameters

---

## 🧑‍💻 Technologies Used

- Language: C#
- Environment: .NET Console App
- Data Storage: Static Arrays
- IDE: Visual Studio (recommended)

---

## 📂 How It Works

1. Choose whether you are a **User** or an **Admin**.
2. Based on the role:
   - **Users** can:
     - Book flights
     - Cancel bookings
     - View flights
     - Search and view details
   - **Admins** can:
     - Add new flights
     - Update departure time
3. Data is stored in fixed-length arrays (e.g., `string[] flightCodeArray = new string[100];`).

---

## 💸 Discount Code

When booking a flight, you can use the following code to receive a discount:

