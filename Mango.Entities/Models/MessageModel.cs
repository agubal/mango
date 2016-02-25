using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mango.Common.General;

namespace Mango.Entities.Models
{
    public class MessageModel : IIdentifier<int>
    {
        [DisplayName("First and Last Name")]
        public string Name { get; set; }

        [DisplayName("Business E-mail or Phone")]
        [Required]
        public string Contact { get; set; }

        [DisplayName("Write your message")]
        public string MessageBody { get; set; }

        public int Id { get; set; }
    }
}
