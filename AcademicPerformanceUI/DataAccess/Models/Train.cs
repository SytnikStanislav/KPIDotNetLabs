using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Train")]
    [DataContract]
    public class Train : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }

        [DataMember()]
        [Column]
        public string Name { get; set; }

        [DataMember()]
        [Column]
        public int AmountOfCarts { get; set; }

        public object Clone() => new Train()
        {
            Id = this.Id,
            Name = this.Name,
            AmountOfCarts = this.AmountOfCarts
        };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Train)mapFrom;
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.AmountOfCarts = entity.AmountOfCarts;

            return this;
        }
    }
}
