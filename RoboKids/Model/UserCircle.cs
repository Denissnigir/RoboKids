//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoboKids.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserCircle
    {
        public int Id { get; set; }
        public Nullable<int> IdIUser { get; set; }
        public Nullable<int> IdCircle { get; set; }
    
        public virtual Circle Circle { get; set; }
        public virtual User User { get; set; }
    }
}
