using System.ComponentModel.DataAnnotations;

namespace JanBatchCodeFirstApprochImpl.Models
{
    public class Managers
    {
        [Key]
        public int Mid { get; set; }
        public string Mname { get; set; }
        public string Dname { get; set; }

        public ICollection<Employees> employee { get; set; }  //one to many mapping

    }
}
