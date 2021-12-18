using System;
using System.Collections.Generic;

namespace WebServiceBlazorCrud.ModelsEntityFramework
{
    public partial class Cerveza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
    }
}
