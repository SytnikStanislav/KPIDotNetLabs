using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Ticket")]
    [DataContract]
    public class Ticket : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }

        [Column]
        [DataMember()]
        public DateTime ArrivalDate { get; set; }

        [Column]
        [DataMember()]
        public DateTime DepartureTime { get; set; }

        [Column]
        [DataMember()]
        public string ArrivalStation { get; set; }

        [Column]
        [DataMember()]
        public string DepartureStation { get; set; }

        [Column]
        [DataMember()]
        public Guid CartId { get; set; }

        [Column]
        [DataMember()]
        public Guid PassangerId { get; set; }


        public object Clone() => new Ticket()
        {
            Id = this.Id,
            CartId = this.CartId,
            PassangerId = this.PassangerId,
            DepartureTime =  this.DepartureTime,
            DepartureStation = this.DepartureStation,
            ArrivalDate =  this.ArrivalDate,
            ArrivalStation = this.ArrivalStation
        };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Ticket)mapFrom;
            this.Id = entity.Id;
            this.CartId = entity.CartId;
            this.PassangerId = entity.PassangerId;
            DepartureTime = entity.DepartureTime;
            DepartureStation = entity.DepartureStation;
            ArrivalDate = entity.ArrivalDate;
            ArrivalStation = entity.ArrivalStation;

            return this;
        }
    }
}
