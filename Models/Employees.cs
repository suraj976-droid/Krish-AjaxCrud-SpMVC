using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JanBatchCodeFirstApprochImpl.Models
{
    public class Employees
    {
        [Key]
        public int eid { get; set; }
        public string ename { get; set; }
        public double esalary { get; set; }

        [ForeignKey("mng")]
        public int Mid { get; set; }
        public Managers mng { get; set; }

        
    }
}
