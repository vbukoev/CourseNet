﻿namespace CourseNet.Web.ViewModels.Review
{
    public class ReviewInfoViewModel
    {
        //public ReviewInfoViewModel(Data.Models.Entities.Review review)
        //{
        //    Id = review.Id;
        //    CourseId = review.CourseId;
        //    UserId = review.UserId;
        //    Comment = review.Comment;
        //    Rating = review.Rating;
        //}




        /// <summary>
        /// Review Identifier
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Review Course Identifier
        /// </summary>
        public Guid CourseId { get; set; }
        /// <summary>
        /// Review User Identifier
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Review Comment
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Review Rating
        /// </summary>
        public int Rating { get; set; }

    }
}
