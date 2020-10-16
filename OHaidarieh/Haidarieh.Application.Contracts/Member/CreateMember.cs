using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Haidarieh.Application.Contracts.Member
{
    public class CreateMember
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get;  set; }
    }
}