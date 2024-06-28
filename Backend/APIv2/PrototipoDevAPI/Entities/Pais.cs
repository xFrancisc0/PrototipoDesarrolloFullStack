namespace PrototipoDevAPI.Entities
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ContinenteId { get; set; }
        public int CantidadHabitantes { get; set; }

        // Propiedad de navegación a Continente
        public Continente Continente { get; set; }
    }
}
