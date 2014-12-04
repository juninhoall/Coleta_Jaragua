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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Tb_Cadastro_Coletores
    {
        public Tb_Cadastro_Coletores()
        {
            this.Tb_Box = new HashSet<Tb_Box>();
        }
        [Display(Name = "C�digo")]
        public int Codigo_Coletor { get; set; }
        [Display(Name = "Nome")]
        public string Nome_Coletor { get; set; }

        public string CPF { get; set; }
        public string RG { get; set; }
        [Display(Name = "Data")]
        public System.DateTime Data_Nascimento { get; set; }
        [Display(Name = "Sexo")]
        public int Codigo_Sexo_Coletor { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string UF { get; set; }
        public int Codigo_Estado_Civil { get; set; }
        public int Codigo_Tipo_Associado { get; set; }
        public string Telefone { get; set; }
        public int Codigo_Banco_Coletor { get; set; }
        [Display(Name = "Ag�ncia")]
        public string Agencia { get; set; }
        [Display(Name = "Conta Corrente")]
        public string Conta_Corrente { get; set; }
    
        public virtual Tb_Banco Tb_Banco { get; set; }
        public virtual ICollection<Tb_Box> Tb_Box { get; set; }
        public virtual Tb_Tipo_Civil Tb_Tipo_Civil { get; set; }
        public virtual Tb_Tipo_Sexo Tb_Tipo_Sexo { get; set; }
        public virtual Tb_Tipo_Associado Tb_Tipo_Associado { get; set; }
    }
}
