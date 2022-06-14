using System;

namespace Repository.Models
{
    public class Darbuotojas
    {
        public string ASMENSKODAS { get; set; }
        public string VARDAS { get; set; }
        public string PAVARDE { get; set; }
        public DateTime DIRBANUO { get; set; }
        public DateTime GIMIMOMETAI { get; set; }
        public string PAREIGOS { get; set; }
        public string SKYRIUS_PAVADINIMAS { get; set; }
        public int PROJEKTAS_ID { get; set; }
    }
}
