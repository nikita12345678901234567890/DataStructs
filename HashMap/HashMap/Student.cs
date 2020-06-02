using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    public class blah
    {

    }

    class Student : IComparable
    {
        public string name;
        public int grade;
        public string email;

        public Student(string name, int grade, string email)
        {
            this.name = name;
            this.grade = grade;
            this.email = email;
        }

        /// <summary>
        /// if (this < other) return -1
        /// if (this > other) return 1
        /// if (this == other) return 0
        /// 
        /// </other>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(object other)
        {
            if (other.GetType() == typeof(Student))
            {
                Student otherAsStudent = (Student)other;

                return name.CompareTo(otherAsStudent.name);
            }
            else if (other.GetType() == typeof(int))
            {
                int otherAsInt = (int)other;

                return grade.CompareTo(otherAsInt);
            }
            else
            {
                throw new Exception("we want a student");
            }
        }
    }
}