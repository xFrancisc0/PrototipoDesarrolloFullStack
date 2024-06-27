namespace PrototipoDevAPI.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public int PaisId { get; set; }

        // Propiedad de navegación a País
        public Pais Pais { get; set; }
    }
}
