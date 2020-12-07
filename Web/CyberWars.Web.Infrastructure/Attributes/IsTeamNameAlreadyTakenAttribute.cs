namespace CyberWars.Web.Infrastructure.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class IsTeamNameAlreadyTakenAttribute : ValidationAttribute
    {
        public string Error { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var teamService = (ITeamService)validationContext.GetService(typeof(ITeamService));
            //var isTaken = teamService.IsGroupNameAlreadyTaken((string)value).GetAwaiter().GetResult();
            //if (isTaken)
            //{
            //    return new ValidationResult(this.Error);
            //}

            return ValidationResult.Success;
        }
    }
}
