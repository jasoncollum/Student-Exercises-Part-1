using System;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercises
            var jsExerciseArrays = new Exercise("Javascript Arrays", "Javascript");
            var jsExerciseObjects = new Exercise("Javascript Objects", "Javascript");
            var jsExerciseAsyncAwait = new Exercise("Javascript AsyncAwait", "Javascript");
            var csharpExerciseClasses = new Exercise("C Sharp Classes", "C Sharp");

            // Cohorts
            var cohort31 = new Cohort("Day Cohort 31");
            var cohort32 = new Cohort("Day Cohort 32");
            var cohort33 = new Cohort("Day Cohort 33");

            // Students
            var nateFleming = new Student("Nate", "Fleming", "Nathaniel Fleming", 32);
            var jasonCollum = new Student("Jason", "Collum", "Jason Collum", 32);
            var colinSandlin = new Student("Colin", "Sandlin", "Colin Sandlin", 32);
            var josephPoolhiemer = new Student("Joseph", "Poolheimer", "jp2112", 32);

            // Instructors
            var jisieDavid = new Instructor("Jisie", "David", "Jisie David", 32, "Lighting");
            var adamScheaffer = new Instructor("Adam", "Scheaffer", "Adam Scheaffer", 32, "Hats");
            var brendaLong = new Instructor("Brenda", "Long", "Brenda Long", 32, "Jeeps");

            // Add Students To Cohort
            cohort32.Students.Add(nateFleming);
            cohort32.Students.Add(jasonCollum);
            cohort32.Students.Add(colinSandlin);
            cohort32.Students.Add(josephPoolhiemer);

            // Instructors Assining Exercises
            brendaLong.assignExercise(cohort32.Students, jsExerciseArrays);
            adamScheaffer.assignExercise(cohort32.Students, jsExerciseObjects);
            adamScheaffer.assignExercise(cohort32.Students, jsExerciseAsyncAwait);
            jisieDavid.assignExercise(cohort32.Students, csharpExerciseClasses);

            // Create List Of All Exercises
            cohort32.AllExercises.AddRange(new Exercise[]{
                jsExerciseArrays, jsExerciseObjects, jsExerciseAsyncAwait, csharpExerciseClasses
            });

            // Generate Report Of Students Are Working On Each Exercise
            foreach (Exercise exercise in cohort32.AllExercises)
            {
                Console.WriteLine("");
                Console.WriteLine(exercise.Name);
                Console.WriteLine("---------------");
                foreach (Student student in cohort32.Students)
                {
                    if (student.Exercises.Contains(exercise))
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                    }
                }
            }
        }
    }
}
