using System;

namespace ppedv.LVS_Enterprise.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string LastUser { get; set; }
    }
}
