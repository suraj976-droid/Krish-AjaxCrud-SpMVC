using System.ComponentModel.DataAnnotations;

namespace JanBatchCodeFirstApprochImpl.Models
{
    public class Emp
    {
        [Key]
        public int eid { get; set; }
        [Required]
        public string ename { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public double esalary { get; set; }

        public string eimg { get; set; }
    }
}
