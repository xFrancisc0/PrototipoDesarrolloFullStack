namespace PrototipoDevAPI.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Telefono { get; set; }
        public int PaisId { get; set; }

        // Propiedad de navegación a País
        public Pais Pais { get; set; }
    }

    public class ClienteOutput
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string ClienteNombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Telefono { get; set; }
        public string PaisNombre { get; set; }
    }

    public class ClienteSP
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string ClienteNombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Telefono { get; set; }
        public string PaisNombre { get; set; }
        public int PaisId { get; set; }

        // Propiedad de navegación a País
        public Pais Pais { get; set; }
    }
}
