﻿using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Instructor;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data
{
    public class InstructorService : IInstructorService
    {
        private readonly CourseNetDbContext dbContext;

        public InstructorService(CourseNetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> InstructorExistsByUserId(string id)
        {
            bool result = await dbContext.Instructors.AnyAsync(instructor => instructor.UserId.ToString() == id);

            return result;
        }

        public async Task<bool> InstructorExistsByPhoneNumber(string phoneNumber)
        {
            bool result = dbContext.Instructors.Any(instructor => instructor.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> HasAppliedCoursesByUserIdAsync(string userId)
        {
            CourseUser? user = await dbContext
                .Users.Include(applicationUser => applicationUser.AppliedCourses)
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return false;
            }

            return user.AppliedCourses.Any();
        }

        public async Task Create(string userId, BecomeInstructorFormModel model)
        {
            Instructor instructor = new Instructor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                UserId = Guid.Parse(userId) 
            };

            await dbContext.Instructors.AddAsync(instructor);
            await dbContext.SaveChangesAsync();
        }

        public async Task<string> GetInstructorIdByUserId(string? userId)
        {
            var instructor = await dbContext.Instructors
                .FirstOrDefaultAsync(x => x.UserId.ToString() == userId);
            if (instructor is null)
            {
                return null;
            }

            return instructor.Id.ToString();
        }

        public async Task<bool> HasCourseWithIdAsync(string? userId, string courseId)
        {
            var instructor = await dbContext.Instructors
                .Include(instructor => instructor.CoursesTaught)
                .FirstOrDefaultAsync(i => i.UserId.ToString() == userId);
            if (instructor == null)
            {
                return false;
            }
            return instructor.CoursesTaught.Any(c => c.Id.ToString() == courseId.ToLower());
        }
    }
}
