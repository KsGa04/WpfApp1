//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public partial class coffee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public coffee()
        {
            this.order_coffee = new HashSet<order_coffee>();
        }
        public string GetPhoto
        {
            get
            {
                if (photo_coffee is null)
                    return null;
                return Directory.GetCurrentDirectory() + @"\Images\" + photo_coffee.Trim();
            }
        }
        public int id_coffee { get; set; }
        public string name_coffe { get; set; }
        public Nullable<int> id_type { get; set; }
        public string photo_coffee { get; set; }
        public string info_coffee { get; set; }
        public string coffee_two { get; set; }
        public string coffee_three { get; set; }
        public string coffe_four { get; set; }
        public int id_category { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_coffee> order_coffee { get; set; }
        public virtual product_category product_category { get; set; }
        public virtual type_coffe type_coffe { get; set; }
    }
}
