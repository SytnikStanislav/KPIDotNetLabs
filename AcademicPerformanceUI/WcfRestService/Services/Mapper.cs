using DataAccess.Interfaces;
using Model = DataAccess.Models;
using Dto = WcfRestService.DTOModels;
using System;
using WcfRestService.DTOModels;
using DataAccess.Models;

namespace WcfRestService.Services
{
    public class Mapper
    {
        public IEntity MapToModel(IBaseDto entity)
        {
            if (entity == null) throw new FormatException();
            var dtoTypeName = entity.GetType().Name;
            switch (dtoTypeName)
            {
                case "GroupDto":
                    {
                        var groupDto = (GroupDto)entity;
                        var id = groupDto.Id;
                        var a = groupDto.GroupName;
                        var x = groupDto.MaxStudents;
                        var s = groupDto.StudyYear;
                        return new Cart() { Id = groupDto.Id, Name = groupDto.GroupName, MaxCapacity = groupDto.MaxStudents, TrainId = groupDto.StudyYear };
                    }
                case "StudentDto":
                    {
                        var dtoEntity = (StudentDto)(IBaseDto)entity;
                        return new Student() { Id = dtoEntity.Id, FirstName = dtoEntity.FirstName, LastName = dtoEntity.LastName, PhoneNumber = dtoEntity.PhoneNumber, GroupId = dtoEntity.GroupId };
                    }
                case "SubjectDto":
                    {
                        var dtoEntity = (SubjectDto)(IBaseDto)entity;
                        var enumInt = (int)dtoEntity.FinalTestType;
                        return new Train()
                        {
                            Id = dtoEntity.Id,
                            FinalTestType = (Model.FinalTestType)enumInt,
                            AmountOfCarts = dtoEntity.Hours,
                            Name = dtoEntity.Name
                        };
                    }
                case "SubjectInGroupDto":
                    {
                        var dtoEntity = (SubjectInGroupDto)(IBaseDto)entity;
                        return new SubjectInGroup()
                        {
                            Id = dtoEntity.Id,
                            GroupId = dtoEntity.GroupId,
                            SubjectId = dtoEntity.SubjectId
                        };
                    }
                case "TeacherDto":
                    {
                        var dtoEntity = (TeacherDto)(IBaseDto)entity;
                        return new Passanger()
                        {
                            Id = dtoEntity.Id,
                            FirstName = dtoEntity.FirstName,
                            LastName = dtoEntity.LastName,
                            PhoneNumber = dtoEntity.PhoneNumber,
                            SubjectId = dtoEntity.SubjectId
                        };
                    }
                case "TestDto":
                    {
                        var dtoEntity = (TestDto)(IBaseDto)entity;
                        return new Test()
                        {
                            Id = dtoEntity.Id,
                            Date = dtoEntity.Date,
                            Name = dtoEntity.Name,
                            Theme = dtoEntity.Theme,
                            TeacherId = dtoEntity.TeacherId
                        };
                    }
                case "TestResultDto":
                    {
                        var dtoEntity = (TestResultDto)(IBaseDto)entity;
                        return new Ticket()
                        {
                            Id = dtoEntity.Id,
                            Mark = dtoEntity.Mark,
                            CartId = dtoEntity.TestId,
                            PassangerId = dtoEntity.StudentId
                        };
                    }
                default: throw new NotSupportedException();
            }
        }

        public IBaseDto MapToDto<T>(IEntity entity)
        {
            var dtoTypeName = entity.GetType().Name;
            switch (dtoTypeName)
            {
                case "Cart":
                    {
                        var groupDto = (Cart)entity;
                        return new GroupDto() { Id = groupDto.Id, GroupName = groupDto.Name, MaxStudents = groupDto.MaxCapacity, StudyYear = groupDto.TrainId };
                    }
                case "Student":
                    {
                        var dtoEntity = (Student)entity;
                        return new StudentDto() { Id = dtoEntity.Id, FirstName = dtoEntity.FirstName, LastName = dtoEntity.LastName, PhoneNumber = dtoEntity.PhoneNumber, GroupId = dtoEntity.GroupId };
                    }
                case "Train":
                    {
                        var dtoEntity = (Train)entity;
                        var enumInt = (int)dtoEntity.FinalTestType;
                        return new SubjectDto()
                        {
                            Id = dtoEntity.Id,
                            FinalTestType = (Dto.FinalTestType)enumInt,
                            Hours = dtoEntity.AmountOfCarts,
                            Name = dtoEntity.Name
                        };
                    }
                case "SubjectInGroup":
                    {
                        var dtoEntity = (SubjectInGroup)entity;
                        return new SubjectInGroupDto()
                        {
                            Id = dtoEntity.Id,
                            GroupId = dtoEntity.GroupId,
                            SubjectId = dtoEntity.SubjectId
                        };
                    }
                case "Passanger":
                    {
                        var dtoEntity = (Passanger)entity;
                        return new TeacherDto()
                        {
                            Id = dtoEntity.Id,
                            FirstName = dtoEntity.FirstName,
                            LastName = dtoEntity.LastName,
                            PhoneNumber = dtoEntity.PhoneNumber,
                            SubjectId = dtoEntity.SubjectId
                        };
                    }
                case "Test":
                    {
                        var dtoEntity = (Test)entity;
                        return new TestDto()
                        {
                            Id = dtoEntity.Id,
                            Date = dtoEntity.Date,
                            Name = dtoEntity.Name,
                            Theme = dtoEntity.Theme,
                            TeacherId = dtoEntity.TeacherId
                        };
                    }
                case "Ticket":
                    {
                        var dtoEntity = (Ticket)entity;
                        return new TestResultDto()
                        {
                            Id = dtoEntity.Id,
                            Mark = dtoEntity.Mark,
                            TestId = dtoEntity.CartId,
                            StudentId = dtoEntity.PassangerId
                        };
                    }
                default: throw new NotSupportedException();
            }
        }
    }
}