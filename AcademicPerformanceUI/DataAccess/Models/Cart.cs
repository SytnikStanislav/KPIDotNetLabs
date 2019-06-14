using System;
using DataAccess.Interfaces;
using System.Runtime.Serialization;
using System.Data.Linq.Mapping;

namespace DataAccess.Models
{
    [DataContract]
    [Table(Name = "Cart")]
    public class Cart : IEntity
    {
        [DataMember()]
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public Guid Id { get; set; }

        [DataMember()]
        [Column]
        public string Name { get; set; }

        [DataMember()]
        [Column]
        public int MaxCapacity { get; set; }

        [DataMember()]
        [Column]
        public Guid TrainId { get; set; }

        public object Clone()
        {
            return new Cart()
            {
                Id = this.Id,
                Name = this.Name,
                MaxCapacity = this.MaxCapacity,
                TrainId = this.TrainId
            };
        }

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Cart)mapFrom;
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.MaxCapacity = entity.MaxCapacity;
            this.TrainId = entity.TrainId;
            return this;
        }
    }
}
