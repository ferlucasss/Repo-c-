using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook1
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject , IBook
    {
        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public virtual void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public virtual Statistics GetStatistics()
        {
            var result = new Statistics();
           
            for(var index=0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
                
            }

            

            return result;
        }

        private List<double> grades;

    }
}
