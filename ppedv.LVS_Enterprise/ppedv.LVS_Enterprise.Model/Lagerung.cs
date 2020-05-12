namespace ppedv.LVS_Enterprise.Model
{
    public class Lagerung : Entity
    {
        public virtual Lager Lager { get; set; }
        public virtual Artikel Artikel { get; set; }
        public int Anzahl { get; set; }
    }
}
