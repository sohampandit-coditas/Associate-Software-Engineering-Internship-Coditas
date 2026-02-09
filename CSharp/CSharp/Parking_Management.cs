using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    enum VehicleType
    {
        TwoWheeler=1,
        Car,
        Truck
    }

    enum ParkingStatus
    {
        Available,
        Occupied
    }

    struct ParkingTicket
    {
        public string VehicleNumber;
        public DateTime EntryTime;
        public DateTime ExitTime;
        public decimal Fee;
    }

    class ParkedVehicle
    {
        public string vehicleNumber {  get; set; }
        public VehicleType vehicleType {  get; set; }
        public DateTime entryTime { get; set; }
        public int spotNumber {  get; set; }

    }

    static class Helper
    {
        public static int ReadInt(string m)
        {
            int value;
            while (true) 
            {
                Console.WriteLine(m);
                if(int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid Number. Enter a valid number");
            
            }
        }

        public static string ReadString(string m)
        {
            Console.Write(m);
            return Console.ReadLine();
        }

        public static VehicleType ReadVehicleType()
        {
            Console.WriteLine("Select Vehicle Type: ");
            foreach(var type in Enum.GetValues(typeof(VehicleType)))
            {
                Console.WriteLine($"{(int)type}.{type}");
            }

            while (true)
            {
                int ch = ReadInt("Enter the choice: ");
                if (Enum.IsDefined(typeof(VehicleType), ch))
                {
                    return (VehicleType)ch;
                }
                Console.WriteLine("Invalid Selection!");
            }
        }

        public static int CalculateFee(VehicleType type, TimeSpan time)
        {
            int ratePerHour = type switch
            {
                VehicleType.TwoWheeler => 10,
                VehicleType.Truck => 40,
                VehicleType.Car => 20,
                _=>0
            };

            int hours = (int)Math.Ceiling(time.TotalHours);
            return hours * ratePerHour;

        }

        public static void ShowMenu()
        {
            Console.WriteLine("**** Smart Parking Lot ****");
            Console.WriteLine("1. Park Vehicle");
            Console.WriteLine("2. Exit Vehicle");
            Console.WriteLine("3. View Parked Vehicles");
            Console.WriteLine("4. Exit");
        }
    }

    partial class ParkingLot
    {
        private Dictionary<int, ParkedVehicle> parkingSpot = new();
        private List<ParkingTicket> tickets = new();
    }

    partial class ParkingLot
    {
        public void ViewParkedVehicles()
        {
            if (!parkingSpot.Any())
            {
                Console.WriteLine("No vehicle found!");
                return;
            }
            Console.WriteLine("The Parked Vehicles Are: ");
            foreach(var v in parkingSpot.Values)
            {
                Console.WriteLine($"Spot: {v.spotNumber}, Vehicle:{v.vehicleNumber}, Type:{v.vehicleType}, EntryTime:{v.entryTime}");

            }
        }
    }

    partial class ParkingLot
    {
        public void ParkVehicle()
        {
            int spot = Helper.ReadInt("Enter Parking Spot Number: ");
            if (parkingSpot.ContainsKey(spot))
            {
                Console.WriteLine("Spot occupied");
                return;
            }

            string vehicle = Helper.ReadString("Enter the vehicle number: ");
            VehicleType type = Helper.ReadVehicleType();

            parkingSpot[spot] = new ParkedVehicle
            {
                vehicleNumber = vehicle,
                vehicleType =type,
                entryTime = DateTime.Now,
                spotNumber=spot
            };

            Console.WriteLine("Vehicle Parked Successfully!!");
        }

        public void ExitVehicle()
        {
            string vehicleNumber = Helper.ReadString("Enter Vehicle Number:- ");
            ParkedVehicle foundVehicle = null;
            foreach(var vehicle in parkingSpot.Values)
            {
                if (vehicle.vehicleNumber == vehicleNumber)
                {
                    foundVehicle = vehicle;
                    break;
                }
            }

            if (foundVehicle == null)
            {
                Console.WriteLine("Invalid Vehicle");
                return;
            }

            DateTime exitTime = DateTime.Now;
            TimeSpan duration = exitTime - foundVehicle.entryTime;
            int fee = Helper.CalculateFee(foundVehicle.vehicleType, duration);
            ParkingTicket ticket = new ParkingTicket
            {
                VehicleNumber = foundVehicle.vehicleNumber,
                EntryTime = foundVehicle.entryTime,
                ExitTime=exitTime,
                Fee=fee
                
            };

            tickets.Add(ticket);

            parkingSpot.Remove(foundVehicle.spotNumber);
            Console.WriteLine($"Duration: {duration}");
            Console.WriteLine($"Fee: {fee}");
            Console.WriteLine("Vehicle exited successfully!");
        }

        
    }
    internal class Parking_Management
    {
        public static void Main(string[] args)
        {
            ParkingLot lot = new ParkingLot();
            bool runs = true;

            while (runs)
            {
                Helper.ShowMenu();
                int ch = Helper.ReadInt("Enter option: ");
                switch (ch)
                {
                    case 1:
                        lot.ParkVehicle();
                        break;
                    case 2:
                        lot.ExitVehicle();
                        break;
                    case 3:
                        lot.ViewParkedVehicles();
                        break;
                    case 4:
                        runs = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!");
                        break;
                }
            }
        }
    }
}
