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
    
    public partial class orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orders()
        {
            this.order_coffee = new HashSet<order_coffee>();
        }
    
        public int id_order { get; set; }
        public string name_user { get; set; }
        public string telephone { get; set; }
        public Nullable<int> id_cafe { get; set; }
        public Nullable<System.DateTime> delivery_date { get; set; }
        public string delivery_time { get; set; }
        public Nullable<int> id_status { get; set; }
    
        public virtual cafe cafe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_coffee> order_coffee { get; set; }
        public virtual status status { get; set; }
    }
}
