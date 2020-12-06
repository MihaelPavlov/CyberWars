namespace CyberWars.Web.ViewModels.Team
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class RegisterTeamInputModel
    {
        [Required(ErrorMessage = "Group Name is required.")]
        [MaxLength(10, ErrorMessage = "Group Name should be max 10 characters.")]
        [MinLength(4, ErrorMessage = "Group Name should be min 4 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Motivational Motto is required.")]
        [MaxLength(60, ErrorMessage = "Motivationa Motto should be max 60 characters.")]
        [MinLength(10, ErrorMessage = "Motivational Motto should be min 10 characters.")]
        public string MotivationalMotto { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(100, ErrorMessage = "Description should be max 100 characters.")]
        public string Description { get; set; }
    }
}
