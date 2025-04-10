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
         static int flightCount = 0; // to keep track of the number of flights
        // Main method to start the application
        static void Main(string[] args)
        {
            DisplayWelcomeMessage();
            ShowMenu();
            Console.Write("Please enter a date and time (e.g., 2025-04-10 14:30): ");
            string  input = Console.ReadLine();
            DateTime userDateTime = DateTime.Parse(input);
            AddFlight("AI101", "New York", "Los Angeles", userDateTime, 6);
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
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Book Flight");
            Console.WriteLine("2. Cancel Flight");
            Console.WriteLine("3. View Flights");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");
            string input = Console.ReadLine();
            int choice;
            // Validate the input
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 4)
            {
                Console.Write("Invalid input. Please enter a number between 1 and 4: ");
                input = Console.ReadLine();
            }
            return choice;
        }
        // exit the application
        public static void Exit()
        {
            Console.WriteLine("Thank you for using the Airline Reservation System. Goodbye!");
            Environment.Exit(0);
        }
        // add filghts to the system 
        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration)
        {
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
        // view the flights in the system
        public static void DisplayFlights()
        {
            Console.WriteLine("Available Flights:");
            Console.WriteLine("Flight Code\tFrom City\tTo City\tDeparture Time\tDuration");
            for (int i = 0; i < flightCount; i++)
            {
                Console.WriteLine($"{flightCodeArry[i]}\t{fromCityArry[i]}\t{toCityArry[i]}\t{departureTimeArry[i]}\t{durationArry[i]} hours");
            }
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

        // cancel the flight by 

    }
}
