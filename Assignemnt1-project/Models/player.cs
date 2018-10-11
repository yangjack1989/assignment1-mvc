namespace Assignemnt1_project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int player_id { get; set; }

        [StringLength(40)]
        public string first_name { get; set; }

        [StringLength(40)]
        public string last_name { get; set; }

        public decimal? salary { get; set; }

        [StringLength(20)]
        public string position { get; set; }

        public decimal? points_per_game { get; set; }

        public decimal? rebonds_per_game { get; set; }

        [StringLength(50)]
        public string injury { get; set; }

        public int? team_id { get; set; }

        public virtual team team { get; set; }
    }
}
