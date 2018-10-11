namespace Assignemnt1_project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public team()
        {
            players = new HashSet<player>();
        }

        [Key]
        public int team_id { get; set; }

        [StringLength(50)]
        public string team_name { get; set; }

        [StringLength(20)]
        public string conference { get; set; }

        [StringLength(50)]
        public string owner { get; set; }

        public int? win { get; set; }

        public int? lost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player> players { get; set; }
    }
}
