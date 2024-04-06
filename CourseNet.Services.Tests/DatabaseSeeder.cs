using CourseNet.Data;
using CourseNet.Data.Models.Entities;

namespace CourseNet.Services.Tests
{
    public class DatabaseSeeder
    {
        public static CourseUser StudentUser;
        public static CourseUser InstructorUser;
        public static Instructor Instructor;

        public static void SeedDatabase(CourseNetDbContext dbContext)
        {
            StudentUser = new CourseUser
            {
                UserName = "ivanTheStudent@students.com",
                NormalizedUserName = "IVANTHESTUDENT@STUDENTS.COM",
                Email = "ivanTheStudent@students.com",
                NormalizedEmail = "IVANTHESTUDENT@STUDENTS.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEFwJ45w197CifliYnA30ZFKejC2f/NFpMrndh3luWckRpKEgKX9t/mrn/nNIojOzKw==",
                ConcurrencyStamp = "c48522e7-1752-4a51-9218-571fab7b1520",
                SecurityStamp = "CEWFGPNLLIMEJY24M7B2EMFI4QIXAQPL",
                TwoFactorEnabled = false,
                FirstName = "Ivan",
                LastName = "Ivanov"
            };
            InstructorUser = new CourseUser
            {
                UserName = "futureInstructor@instructors.com",
                NormalizedUserName = "FUTUREINSTRUCTOR@INSTRUCTORS.COM",
                Email = "futureInstructor@instructors.com",
                NormalizedEmail = "FUTUREINSTRUCTOR@INSTRUCTORS.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDLla1IkEe9tqOl+WlDP8cGFOThn8a9ajXn87VBR0GYLkK57J3/+8HD3x7y/U5+RMw==",
                ConcurrencyStamp = "5e250d88-7bff-4450-a760-85b4979b9fe6",
                SecurityStamp = "6ac9b051-54d9-486f-acd0-42b99c639fb5",
                TwoFactorEnabled = false,
                FirstName = "Future",
                LastName = "Instructor"
            };

            Instructor = new Instructor
            {
                PhoneNumber = "+359123456789",
                User = InstructorUser
            };


            dbContext.Users.Add(StudentUser);

            dbContext.Users.Add(InstructorUser);

            dbContext.Instructors.Add(Instructor);

            dbContext.SaveChanges();
        }
    }
}