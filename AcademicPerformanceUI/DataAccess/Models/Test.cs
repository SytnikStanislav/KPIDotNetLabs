﻿using System;

namespace DataAccess.Models
{
    public class Test : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime Date { get; set; }

        public Guid TeacherId;
        public Teacher Teacher
        {
            get => ObjectLists.Teachers.Find(t => t.Id == TeacherId);
        }

        public object Clone() => new Test()
        {
            Id = this.Id,
            Name = this.Name,
            Theme = this.Theme,
            Date = this.Date,
            TeacherId = this.TeacherId
        };
    }
}
