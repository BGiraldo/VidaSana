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
    
    public partial class RoutineStage
    {
        public System.Guid id { get; set; }
        public Nullable<System.Guid> routineid { get; set; }
        public Nullable<System.Guid> stageid { get; set; }
    
        public virtual Routine Routine { get; set; }
        public virtual Stage Stage { get; set; }
    }
}