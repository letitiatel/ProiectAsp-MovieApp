using Proiectasp.Models.Base;

namespace Proiectasp.Models
{
    public class ProducerDetails : BaseEntity
    {
        public string? Known_for { get; set; }

        public string? Born { get; set; }

        public string? Spouse { get; set; }

        public Producer Producer { get; set; }
        public Guid ProducerId { get; set; }
    }
}
