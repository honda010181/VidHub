//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VidHub.Infrastructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class ROLE
    {
        public ROLE()
        {
            this.PERSON_ROLE = new HashSet<PERSON_ROLE>();
        }
    
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
    
        public virtual ICollection<PERSON_ROLE> PERSON_ROLE { get; set; }
    }
}