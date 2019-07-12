using System;
using System.Collections.Generic;
using System.Linq;

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
            var cSharpExerciseLinq = new Exercise("C Sharp LINQ", "C Sharp");

            // Cohorts
            var cohort31 = new Cohort("Day Cohort 31");
            var cohort32 = new Cohort("Day Cohort 32");
            var cohort33 = new Cohort("Day Cohort 33");

            // Students
            var nateFleming = new Student("Nate", "Fleming", "Nathaniel Fleming", 31);
            var jasonCollum = new Student("Jason", "Collum", "Jason Collum", 32);
            var colinSandlin = new Student("Colin", "Sandlin", "Colin Sandlin", 32);
            var josephPoolhiemer = new Student("Joseph", "Poolheimer", "jp2112", 33);

            // Instructors
            var jisieDavid = new Instructor("Jisie", "David", "Jisie David", 32, "Lighting");
            var adamScheaffer = new Instructor("Adam", "Scheaffer", "Adam Scheaffer", 32, "Hats");
            var brendaLong = new Instructor("Brenda", "Long", "Brenda Long", 32, "Jeeps");

            // Add Students To Cohort
            cohort31.Students.Add(nateFleming);
            cohort32.Students.Add(jasonCollum);
            cohort32.Students.Add(colinSandlin);
            cohort33.Students.Add(josephPoolhiemer);

            // Instructors Assining Exercises
            brendaLong.assignExercise(cohort32.Students, jsExerciseArrays);
            adamScheaffer.assignExercise(cohort32.Students, jsExerciseObjects);
            adamScheaffer.assignExercise(cohort32.Students, jsExerciseAsyncAwait);
            jisieDavid.assignExercise(cohort32.Students, csharpExerciseClasses);

            // Create List Of All Exercises
            // cohort32.AllExercises.AddRange(new Exercise[]{
            //     jsExerciseArrays, jsExerciseObjects, jsExerciseAsyncAwait, csharpExerciseClasses
            // });

            // Generate Report Of Students Are Working On Each Exercise
            // foreach (Exercise exercise in cohort32.AllExercises)
            // {
            //     Console.WriteLine("");
            //     Console.WriteLine(exercise.Name);
            //     Console.WriteLine("---------------");
            //     foreach (Student student in cohort32.Students)
            //     {
            //         if (student.Exercises.Contains(exercise))
            //         {
            //             Console.WriteLine($"{student.FirstName} {student.LastName}");
            //         }
            //     }
            // }

            // Part 2
            List<Student> students = new List<Student>() {
                jasonCollum,
                nateFleming,
                colinSandlin,
                josephPoolhiemer
            };

            List<Exercise> exercises = new List<Exercise>() {
                jsExerciseArrays,
                jsExerciseObjects,
                jsExerciseAsyncAwait,
                csharpExerciseClasses
            };

            List<Instructor> instructors = new List<Instructor>() {
                brendaLong,
                adamScheaffer,
                jisieDavid
            };

            List<Cohort> cohorts = new List<Cohort>() {
                cohort31,
                cohort32,
                cohort33
            };

            // List exercises for the JavaScript language by using the Where() LINQ method.
            var jsExercises = (from exercise in exercises
                               where exercise.Language == "Javascript"
                               select exercise).ToList();

            Console.WriteLine("");
            Console.WriteLine("JS Exercises:");
            Console.WriteLine("---------------");
            jsExercises.ForEach(exercise =>
            {
                Console.WriteLine(exercise.Name);
            });


            // List students in a particular cohort by using the Where() LINQ method.
            List<Student> cohort32Students = (from student in students
                                              where student.Cohort == 32
                                              select student).ToList();

            Console.WriteLine("");
            Console.WriteLine("C32 Students:");
            Console.WriteLine("---------------");
            cohort32Students.ForEach(student =>
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            });


            // List instructors in a particular cohort by using the Where() LINQ method.
            List<Instructor> cohort32Instructors = (from instructor in instructors
                                                    where instructor.Cohort == 32
                                                    select instructor).ToList();

            Console.WriteLine("");
            Console.WriteLine("C32 Instructors:");
            Console.WriteLine("---------------");
            cohort32Instructors.ForEach(instructor =>
            {
                Console.WriteLine($"{instructor.FirstName} {instructor.LastName}");
            });


            // Sort the students by their last name.
            List<Student> orderedStudents = students.OrderBy(student => student.LastName).ToList();

            Console.WriteLine("");
            Console.WriteLine("Ordered Students:");
            Console.WriteLine("---------------");
            orderedStudents.ForEach(student => Console.WriteLine($"{student.FirstName} {student.LastName}"));


            // Display any students that aren't working on any exercises (Make sure one of your student instances don't have any exercises. Create a new student if you need to.)
            List<Student> noExStudents = (from student in students
                                          where student.Exercises.Count == 0
                                          select student).ToList();

            Console.WriteLine("");
            Console.WriteLine("No Exercises Students:");
            Console.WriteLine("---------------");
            noExStudents.ForEach(student => Console.WriteLine($"{student.FirstName} {student.LastName}"));


            // Which student is working on the most exercises? Make sure one of your students has more exercises than the others.

            jasonCollum.Exercises.Add(cSharpExerciseLinq);

            List<Student> mostExercises = (from student in students
                                           orderby student.Exercises.Count descending
                                           select student).ToList();

            Console.WriteLine("");
            Console.WriteLine($"Most Exercises:  {mostExercises[0].FirstName} {mostExercises[0].LastName}");

            // How many students in each cohort?
            Console.WriteLine("");
            Console.WriteLine("Student Numbers:");
            Console.WriteLine("---------------");
            cohorts.ForEach(cohort => Console.WriteLine($"{cohort.Name} - {cohort.Students.Count}"));
        }
    }
}
