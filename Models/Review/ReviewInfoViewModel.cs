namespace CourseNet.Models.Review
{
    public class ReviewInfoViewModel
    {
        public ReviewInfoViewModel(Data.Entities.Review review)
        {
            Id = review.Id;
            CourseId = review.CourseId;
            UserId = review.UserId;
            Comment = review.Comment;
            Rating = review.Rating;
        }
        /// <summary>
        /// Review Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Review Course Identifier
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// Review User Identifier
        /// </summary>
        public int UserId { get; set; }
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
