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
    
    public partial class provider_products
    {
        public int id_provider_products { get; set; }
        public Nullable<int> id_provider { get; set; }
        public Nullable<int> id_products { get; set; }
    
        public virtual products products { get; set; }
        public virtual provider provider { get; set; }
    }
}
