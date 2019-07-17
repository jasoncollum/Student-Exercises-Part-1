using System;
using System.Collections.Generic;

namespace StudentExercises
{
    public class Student : NSSPerson
    {
        // Properties
        public List<Exercise> Exercises = new List<Exercise>();

        // Constructor
        public Student(string firstName, string lastName, string slackHandle, int cohort)
        {
            FirstName = firstName;
            LastName = lastName;
            SlackHandle = slackHandle;
            Cohort = cohort;
        }
    }
}
