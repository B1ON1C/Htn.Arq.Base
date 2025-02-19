﻿namespace Htn.Arq.Base.Bll.Entities
{
    public class CategoriaProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateOnly FechaAlta { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}