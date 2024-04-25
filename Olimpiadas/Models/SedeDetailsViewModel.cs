namespace Olimpiadas.Models
{
    public class SedeDetailsViewModel
    {
        public int ID { get;set; }
        public string Nombre { get; set; }
        public int Presupuesto { get; set; }
        public List<ComplejoDeportivoModel> ComplejosDeportivos { get; set; }
    }
}
