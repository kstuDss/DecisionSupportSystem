//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DecisionSupportSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public Event()
        {
            this.Combinations = new HashSet<Combination>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Probability { get; set; }
    
        public virtual ICollection<Combination> Combinations { get; set; }
    }
}
