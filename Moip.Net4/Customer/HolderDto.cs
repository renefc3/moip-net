namespace Moip.Net4
{
    public class HolderDto
    {
        /// <summary>
        /// Nome do portador impresso no cartão. string(90),
        /// </summary>
        public string Fullname { get; set; }
        /// <summary>
        /// Data de nascimento do cliente. date(AAAA-MM-DD),
        /// </summary>
        public string Birthdate { get; set; }
        public PhoneDto Phone { get; set; }
        public DocumentDto TaxDocument { get; set; }
    }



}
