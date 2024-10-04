using WhiteWebTech.API.Entities;

namespace WhiteWebTech.API.Models
{
    public class ApplicantDTO
    {
        public int? Id { get; set; }

        public int? JobId { get; set; }

        public string? ApplicantName { get; set; }

        public string? ApplicantDescription { get; set; }

        public int? ApplicantState { get; set; }

        public byte[]? Cv { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual JobsDTO? Job { get; set; }
    }
}
