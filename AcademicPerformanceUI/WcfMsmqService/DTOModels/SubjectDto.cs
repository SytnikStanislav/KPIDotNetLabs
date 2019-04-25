﻿using System;
using System.Runtime.Serialization;

namespace WcfMsMqService.DTOModels
{
    [DataContract]
    public class SubjectDto : IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public FinalTestType FinalTestType { get; set; }

        [DataMember]
        public double Hours { get; set; }
    }
}
