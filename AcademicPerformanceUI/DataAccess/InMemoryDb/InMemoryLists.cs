using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.InMemoryDb
{
    public static class InMemoryLists
    {
        static InMemoryLists()
        {
            Groups = new List<Cart>();
            Subjects = new List<Train>();
            TestResults = new List<Ticket>();
            Teachers = new List<Passanger>();

            Groups.Add(new Cart()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                TrainId = Guid.NewGuid(),
                MaxCapacity = 30
            });
        }

        public static List<Cart> Groups;
        public static List<Train> Subjects;
        public static List<Passanger> Teachers;
        public static List<Ticket> TestResults;
    }
}
