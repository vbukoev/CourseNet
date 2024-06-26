﻿using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
using static CourseNet.Common.DataConstants.Lecture;

namespace CourseNet.Web.ViewModels.Lecture
{
    /// <summary>
    /// Lecture Selection Form View Model
    /// </summary>
    public class LectureSelectionFormViewModel
    {
        /// <summary>
        /// Title of the lecture
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Заглавие")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Description of the lecture
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Описание")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Date of the lecture
        /// </summary>
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Course Identifier
        /// </summary>
        public string CourseId { get; set; }

    }
}