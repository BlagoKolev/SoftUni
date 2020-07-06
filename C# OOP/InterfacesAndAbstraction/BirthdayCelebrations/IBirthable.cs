using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IBirthable
    {
        public string Name { get; }
        public string Birthdate { get; }
    }
}
