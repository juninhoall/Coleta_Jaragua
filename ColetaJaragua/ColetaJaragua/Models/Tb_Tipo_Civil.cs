//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ColetaJaragua.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tb_Tipo_Civil
    {
        public Tb_Tipo_Civil()
        {
            this.Tb_Cadastro_Coletores = new HashSet<Tb_Cadastro_Coletores>();
        }
    
        public int Codigo_Civil { get; set; }
        public string Descricao_Civil { get; set; }
    
        public virtual ICollection<Tb_Cadastro_Coletores> Tb_Cadastro_Coletores { get; set; }
    }
}
