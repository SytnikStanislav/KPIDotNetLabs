﻿using System;

namespace DataAccess.Models
{
    public class TestResult:IEntity
    {
        public Guid Id { get; set; }
        public int Mark { get; set; }

        public Guid TestId { get; set; }
        public Test Test
        {
            get => ObjectLists.Tests.Find(o => o.Id == TestId);
            set
            {
                TestId = ObjectLists.Subjects.Exists(s => s.Id == value.Id)
                    ? value.Id
                    : throw new FormatException("Test with specified Id not exists");
            }
        }

        public Guid StudentId { get; set; }
        public Student Student
        {
            get => ObjectLists.Students.Find(o => o.Id == StudentId);
            set
            {
                StudentId = ObjectLists.Subjects.Exists(s => s.Id == value.Id)
                    ? value.Id
                    : throw new FormatException("Student with specified Id not exists");
            }
        }
    }
}
