namespace Moip.Net4
{
    public class PhoneDto
    {
        /// <summary>
        /// REQUIRED
        /// DDI (código internacional) do telefone. Valores possíveis: 55. Limite de caracteres: 2
        /// </summary>
        public int CountryCode { get; set; }
        /// <summary>
        /// REQUIRED
        /// Código de área do cliente. Limite de caracteres: (2)
        /// </summary>
        public int AreaCode { get; set; }
        /// <summary>
        /// REQUIRED
        /// Número de telefone do cliente. Limite de caracteres: 9
        /// </summary>
        public int Number { get; set; }
    }



}
