using System;
using System.Collections.Generic;
using WebApplication1.Common.Contracts;

namespace WebApplication1.Common
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }

        public Student() { }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Id == student.Id &&
                   Name == student.Name &&
                   Lastname == student.Lastname &&
                   BirthDate == student.BirthDate;
        }

        public override int GetHashCode()
        {
            var hashCode = -732507406;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Lastname);
            hashCode = hashCode * -1521134295 + BirthDate.GetHashCode();
            return hashCode;
        }
    }
}
