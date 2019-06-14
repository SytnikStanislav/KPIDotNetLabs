﻿using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Passanger")]
    [Serializable]
    public class Passanger : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }
        [Column]
        [DataMember()]
        public string FirstName { get; set; }
        [Column]
        [DataMember()]
        public string LastName { get; set; }

        
        public object Clone() => new Passanger()
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
        };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Passanger)mapFrom;
            this.Id = entity.Id;
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;

            return this;
        }
    }
}
