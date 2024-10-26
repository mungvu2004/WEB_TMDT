namespace Web_Double.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tshirt
    {
        public int id { get; set; }

        public int? shirt_id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string img { get; set; }

        public int? price { get; set; }

        public decimal? discount { get; set; }

        public int? final_price { get; set; }

        public virtual Shirt Shirt { get; set; }
    }
}
