namespace GalEnWebberService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Raspberrypoop")]
    public partial class Raspberrypoop
    {
        public int Id { get; set; }

        public int? lys { get; set; }

        public int? temp { get; set; }
    }
}
