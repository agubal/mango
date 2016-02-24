using System.Web.Mvc;
using Mango.Common.General;

namespace Mango.Entities.Models
{
    public class ServiceModel : IIdentifier<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [AllowHtml]
        public string ShortDescription { get; set; }
        [AllowHtml]
        public string LongDescription { get; set; }
        public bool IsMain { get; set; }
        public int Order { get; set; }
    }
}
