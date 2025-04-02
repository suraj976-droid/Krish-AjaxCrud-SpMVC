using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace JanBatchCodeFirstApprochImpl.Models
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }

        public string SName { get; set; }

        public string Scourse { get; set; }

        public double Sfees { get; set; }


    }
}
