using System;

namespace Airline_Reservation_Console_System
{
    internal class Program
    {
        // add the arryes of string flightCode, string fromCity, string toCity, DateTime departureTime, int duration each has 10 
        static string[] flightCodeArry = new string[100];
        static string[] fromCityArry = new string[100];
        static string[] toCityArry = new string[100];
        static DateTime[] departureTimeArry = new DateTime[100];
        static int[] durationArry = new int[100];
        static string[] availableFlightsArry = new string[100];
        static string[] bookedFlightsArry = new string[100];
        static string[] passengerNameArry = new string[100];
        static double[] tikitsPreice  = new double[100];
        static string[] bookingID = new string[100];
        static int flightCount = 0; // to keep track of the number of flights
        // Main method to start the application
        static void Main(string[] args)
        {
            try
            {
                StartSystem();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


        }

        //display a welcome message to the filgth apllecatoins
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("                                     --------------------------------------------");
            Console.WriteLine("                                     |                                          |");
            Console.WriteLine("                                     |Welcome to the Airline Reservation System!|");
            Console.WriteLine("                                     |                                          |");
            Console.WriteLine("                                     --------------------------------------------");


        }
        // show the menu to the user Book Flight, Cancel, View Flights, Exit
        public static int ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("                                     --------------------------------------------");
                Console.WriteLine(" if you are user choice number 1 or admin press 2   ");
                int userType = int.Parse(Console.ReadLine());
                if (userType == 1)
                {
                    Console.WriteLine("Welcome User!");
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("1. Book Flight");
                    Console.WriteLine("2. Cancel Flight");
                    Console.WriteLine("3. View Flights");
                    Console.WriteLine("9. Exit");
                    Console.Write("Enter your choice (1-4): ");
                }
                else if (userType == 2)
                {
                    Console.WriteLine("Welcome Admin!");
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("1. Book Flight");
                    Console.WriteLine("2. Cancel Flight");
                    Console.WriteLine("3. View Flights");
                    Console.WriteLine("4. Add Flight");
                    Console.WriteLine("9. Exit");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    return ShowMenu();
                }


                Console.Write("Enter your choice (1-4) and 9 to exit : ");

                string input = Console.ReadLine();
                int choice;
                // Validate the input
                while (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
                {
                    Console.Write("Invalid input. Please enter a number between 1 and 4: ");
                    input = Console.ReadLine();
                }
                return choice;
            }

        }
        // exit the application
        public static void Exit()
        {
            Console.WriteLine("Thank you for using the Airline Reservation System. Goodbye!");
            Environment.Exit(0);
        }
        // add flight code, from city, to city, departure time, duration

        // add filghts to the system 
        public static void getFlightDetails()
        {
            Console.Write("Enter flight code: ");
            string flightCode = Console.ReadLine();
            Console.Write("Enter from city: ");
            string fromCity = Console.ReadLine();
            Console.Write("Enter to city: ");
            string toCity = Console.ReadLine();
            Console.Write("Enter duration (in hours): ");
            int duration = int.Parse(Console.ReadLine());
            Console.Write("Enter price: ");
            double price = double.Parse(Console.ReadLine());
            AddFlight(flightCode, fromCity, toCity, duration,price);

        }
        // view the flights in the system
        public static void DisplayFlights()
        {
            if (flightCount == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }

            Console.WriteLine("\nAvailable Flights:");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Code\t\tFrom\t\tTo\t\tDeparture\t\tDuration");
            Console.WriteLine("--------------------------------------------------------------");

            for (int i = 0; i < flightCount; i++)
            {
                Console.WriteLine($"{flightCodeArry[i],-10}\t{fromCityArry[i],-10}\t{toCityArry[i],-10}\t{departureTimeArry[i],-20}\t{durationArry[i]} hrs");
            }

            Console.WriteLine("--------------------------------------------------------------");
        }
        // finding flights by the flight code
        public static bool GetFlightCode(string flightCode)
        {
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodeArry[i] == flightCode)
                {
                    return true;
                }
            }
            return false;
        }
        public static DateTime GetUserDateTime()
        {
            int year, month, day, hour, minute;

            Console.Write("Enter the year (e.g., 2025): ");
            year = int.Parse(Console.ReadLine());

            Console.Write("Enter the month (1-12): ");
            month = int.Parse(Console.ReadLine());

            Console.Write("Enter the day (1-31): ");
            day = int.Parse(Console.ReadLine());

            Console.Write("Enter the time in 24-hour format (e.g., 15:30): ");
            string[] timeParts = Console.ReadLine().Split(':');
            hour = int.Parse(timeParts[0]);
            minute = int.Parse(timeParts[1]);

            return new DateTime(year, month, day, hour, minute, 0);
        }
        public static void AddFlight(string flightCode, string fromCity, string toCity, int duration,double price)
        {
            DateTime departureTime = GetUserDateTime(); // This will ask the 4 questions

            // Check if the flight code already exists
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodeArry[i] == flightCode)
                {
                    Console.WriteLine("Flight code already exists. Please use a different flight code.");
                    return;
                }
            }

            // Add the flight details to the arrays
            flightCodeArry[flightCount] = flightCode;
            fromCityArry[flightCount] = fromCity;
            toCityArry[flightCount] = toCity;
            departureTimeArry[flightCount] = departureTime;
            durationArry[flightCount] = duration;
            flightCount++;

            Console.WriteLine("Flight added successfully!");

        }
        // UpdateFlightDeparture method to update the departure time of a flight
        public static void UpdateFlightDeparture(string flightCode, DateTime newDepartureTime)
        {
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodeArry[i] == flightCode)
                {
                    departureTimeArry[i] = newDepartureTime;
                    Console.WriteLine("Flight departure time updated successfully!");
                    return;
                }
            }
            Console.WriteLine("Flight code not found.");
        }
        // CancelFlightBooking(out string passengerName) 
        public static string CancelFlightBooking(out string passengerName)
        {
            Console.Write("Enter the flight code to cancel: ");
            string flightCode = Console.ReadLine();
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodeArry[i] == flightCode)
                {
                    Console.Write("Enter your name: ");
                    passengerName = Console.ReadLine();
                    Console.WriteLine($"Flight {flightCode} booking canceled for {passengerName}.");
                    return passengerName;
                }
            }
            passengerName = null;
            Console.WriteLine("Flight code not found.");
            return passengerName;



        }
        //booking fligth (string passengerName, string flightCode = "Default001")
        public static void BookFlight(string passengerName, string flightCode = "Default001")
        {
            Console.Write("Enter the flight code to book: ");
            flightCode = Console.ReadLine();
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodeArry[i] == flightCode)
                {
                    Console.Write("Enter your name: ");
                    passengerName = Console.ReadLine();
                    bookingID[flightCount] = GenerateBookingID(passengerName);
                    bookedFlightsArry[i] = passengerName;
                    availableFlightsArry[i] = flightCode;
                    Console.WriteLine("do you have a discount code? (Y/N)");
                    string cheak = Console.ReadLine();
                    // Check if the discount code is valid
                    Console.Write("Enter the discount code: ");
                    string  discountCode = Console.ReadLine();
                    int discount = 0;
                    if (cheak.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        if (discountCode == "discount30")
                        {

                            discount = 30;
                            double fare = CalculateFare(tikitsPreice[i], 1, discount);
                        }// Assuming base price is 100
                    }
                    else
                    {
                        double fare = CalculateFare(tikitsPreice[i], 1); // Assuming base price is 100
                    }

                    Console.WriteLine($"Booking ID: {bookingID[i]}");
                    Console.WriteLine($"Flight {flightCode} booked successfully for {passengerName}.");

                    Console.WriteLine($"Flight {flightCode} booked successfully for {passengerName} your boking ID is {bookingID[i]}");
                    return;
                }
            }
            Console.WriteLine("Flight code not found.");
        }
        //validate the flight code(string fligth code)
        public static bool ValidateFlightCode(string flightCode)
        {
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodeArry[i] == flightCode)
                {
                    return true;
                }
            }
            return false;
        }
        // GenerateBookingID(string passengerName)
        public static string GenerateBookingID(string passengerName)
        {
            Random random = new Random();
            int bookingID = random.Next(1000, 9999);
            return $"{passengerName.Substring(0, 3).ToUpper()}-{bookingID}";
        }
        // Display flight details (string code)
        public static void DisplayFlightDetails(string code)
        {
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodeArry[i] == code)
                {
                    Console.WriteLine($"Flight Code: {flightCodeArry[i]}");
                    Console.WriteLine($"From: {fromCityArry[i]}");
                    Console.WriteLine($"To: {toCityArry[i]}");
                    Console.WriteLine($"Departure Time: {departureTimeArry[i]}");
                    Console.WriteLine($"Duration: {durationArry[i]} hours");
                    return;
                }
            }
            Console.WriteLine("Flight code not found.");
        }
        // SearchBookingsByDestination(string toCity)
        public static void SearchBookingsByDestination(string toCity)
        {
            Console.WriteLine($"Searching for flights to {toCity}...");
            bool found = false;
            for (int i = 0; i < flightCount; i++)
            {
                if (toCityArry[i] == toCity)
                {
                    Console.WriteLine($"Flight Code: {flightCodeArry[i]}");
                    Console.WriteLine($"From: {fromCityArry[i]}");
                    Console.WriteLine($"Departure Time: {departureTimeArry[i]}");
                    Console.WriteLine($"Duration: {durationArry[i]} hours");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No flights found to the specified destination.");
            }

        }
        //Function Overloading
        //CalculateFare(int basePrice, int numTickets) 
        // CalculateFare(double basePrice, int numTickets)
        //  CalculateFare(int basePrice, int numTickets, int discount)
        public static double CalculateFare(double basePrice, int numTickets, int discount)
        {
            double totalFare = basePrice * numTickets;
            double discountedFare = totalFare - (totalFare * discount / 100);
            return discountedFare;
        }
        public static double CalculateFare(double basePrice, int numTickets)
        {
            return basePrice * numTickets;
        }
        public static int CalculateFare(int basePrice, int numTickets)
        {
            return basePrice * numTickets;
        }
        //System Utilities & Final Flow
        //ConfirmAction
        public static bool ConfirmAction(string message)
        {
            Console.WriteLine(message);
            Console.Write("Do you want to proceed? (Y/N): ");
            string input = Console.ReadLine();
            return input.Equals("Y", StringComparison.OrdinalIgnoreCase);
        }
        //StartSystem() 1- DisplayWelcomeMessage, 2- ShowMenu, 3- Exit 

        public static void StartSystem()
        {
            DisplayWelcomeMessage();
            while (true)
            {
                int choice = ShowMenu();
                switch (choice)
                {
                    case 1:
                        BookFlight("DefaultPassenger");
                        break;
                    case 2:
                        CancelFlightBooking(out string passengerName);
                        break;
                    case 3:
                        DisplayFlights();
                        break;
                    case 4:
                        getFlightDetails();
                        break;
                    case 9:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    } } 




