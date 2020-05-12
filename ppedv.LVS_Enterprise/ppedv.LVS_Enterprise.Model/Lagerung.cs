namespace ppedv.LVS_Enterprise.Model
{
    public class Lagerung : Entity
    {
        public Lager Lager { get; set; }
        public Artikel Artikel { get; set; }
        public int Anzahl { get; set; }
    }
}
