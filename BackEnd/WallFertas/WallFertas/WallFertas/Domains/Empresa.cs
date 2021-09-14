using System;
using System.Collections.Generic;

#nullable disable

namespace WallFertas.Domains
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Cnpj { get; set; }
    }
}
