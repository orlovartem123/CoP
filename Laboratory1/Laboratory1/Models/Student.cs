using System;

namespace Laboratory1.Models
{
    public class Student
    {
        public String Name { set; get; }
        public int Age { set; get; }
        public bool IsStuding { set; get; }
        override
        public String ToString() {
            String obj = Name + " " + Age + " years old; IsStuding: " + IsStuding;
            return obj;
        }
    }
}
