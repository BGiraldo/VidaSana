//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eam.Ingenieria.Matagym
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonRoutine
    {
        public System.Guid id { get; set; }
        public Nullable<System.Guid> routineid { get; set; }
        public Nullable<System.Guid> trainerid { get; set; }
        public Nullable<System.Guid> userid { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Person Person1 { get; set; }
        public virtual Routine Routine { get; set; }
    }
}
