using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            
            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Room> allRooms = roomRepo.GetAll();

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }

            /*
            Room bathroom = new Room
            {
               Name = "Bathroom",
               MaxOccupancy = 1
            };

            roomRepo.Insert(bathroom);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id}");

            singleRoom.MaxOccupancy = 21;
            roomRepo.Update(singleRoom);

            Console.WriteLine("----------------------------");
            Console.WriteLine($"{singleRoom.Name}'s occupancy has been changed to 21.");

            Console.WriteLine($"{singleRoom.Id} {singleRoom.Name} {singleRoom.MaxOccupancy}");

            Roommate roommate1 = new Roommate
            {
                Firstname = "Michael",
                Lastname = "Carroll",
                RentPortion = 100,
                MovedInDate = DateTime.Now,
                Room = singleRoom
            };

            roommateRepo.Insert(roommate1);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new roommate {roommate1.Firstname} {roommate1.Lastname} with id {roommate1.Id} in the {roommate1.Room.Name} for {roommate1.RentPortion} to move in on {roommate1.MovedInDate}.");

            roomRepo.Delete(8);

            roommateRepo.Delete(5);

            singleRoommate.RentPortion = 75;
            roommateRepo.Update(singleRoommate);

            Console.WriteLine("----------------------------");
            Console.WriteLine($"{singleRoommate.Firstname}'s rent portion has been changed to {singleRoommate.RentPortion}.");
            */

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 5");

            Room singleRoom = roomRepo.GetById(5);

            Console.WriteLine($"{singleRoom.Id} {singleRoom.Name} {singleRoom.MaxOccupancy}");

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Roommate with Id 4");

            Roommate singleRoommate = roommateRepo.GetById(4);

            Console.WriteLine($"{singleRoommate.Id} {singleRoommate.Firstname} {singleRoommate.Lastname} {singleRoommate.RentPortion} {singleRoommate.MovedInDate} {singleRoommate.Room.Name}");

            Console.WriteLine("----------------------------");
            Console.WriteLine($"Getting all roommates in the room.");
            Console.WriteLine();

            List<Roommate> allRoommatesWithRoom = roommateRepo.GetAllWithRoom(5);

            foreach (Roommate roommate in allRoommatesWithRoom)
            {
                Console.WriteLine(@$"
                Name: {roommate.Firstname} {roommate.Lastname}, 
                Rent/Month: ${roommate.RentPortion}, 
                Moved in: {roommate.MovedInDate}, 
                Lives in: {roommate.Room.Name}");
            }
        }
    }
}