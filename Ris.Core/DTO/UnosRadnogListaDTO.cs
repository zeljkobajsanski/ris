namespace Rs.Dnevnik.Ris.Core.DTO
{
    public class UnosRadnogListaDTO
    {
        public RubrikaDTO[] Rubrike { get; set; }
        public RadnikDTO[] Radnici { get; set; }
        public OcenaDTO[] Ocene { get; set; }
        public string[] TipoviAktivnosti { get; set; }
        public TipTekstaDTO[] TipoviTeksta { get; set; }
    }
}