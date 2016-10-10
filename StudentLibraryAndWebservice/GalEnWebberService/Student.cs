namespace GalEnWebberService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int Id { get; set; }

        [StringLength(40)]
        public string name { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        public DateTime? ts { get; set; }
    }
}
