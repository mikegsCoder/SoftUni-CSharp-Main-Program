using System;

namespace P05ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo( Person other)
        {
            int rezult = 0;

            if (this.Name.CompareTo(other.Name) > 0)
            {
                rezult = 1;
            }
            else if (this.Name.CompareTo(other.Name) < 0)
            {
                rezult = - 1;
            }
            else if(this.Name.CompareTo(other.Name) == 0)
            {
                if(this.Age > other.Age)
                {
                    rezult = 1;
                }
                else if(this.Age < other.Age)
                {
                    rezult = - 1;
                }
                else if(this.Age == other.Age)
                {
                    if (this.Town.CompareTo(other.Town) > 0)
                    {
                        rezult = 1;
                    }
                    else if(this.Town.CompareTo(other.Town) < 0)
                    {
                        rezult = - 1;
                    }
                    else if(this.Town.CompareTo(other.Town) == 0)
                    {
                        rezult = 0;
                    }
                }
            }

            return rezult;
        }
    }
}
