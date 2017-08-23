namespace Moip.Net4
{
    public class CreateCustomersRequest
    {
        /// <summary>
        /// REQUIRED
        /// Id próprio do cliente.Referência externa.Limite de caracteres: (65).
        /// </summary>
        public string OwnId { get; set; }
        /// <summary>
        /// REQUIRED
        /// Nome completo do cliente.Limite de caracteres: (90)
        /// </summary>
        public string Fullname { get; set; }
        /// <summary>
        /// REQUIRED
        /// Email do cliente. Limite de caracteres: (45)
        /// </summary>
        public string Email { get; set; }

        public PhoneDto Phone { get; set; }

        /// <summary>
        /// Data de nascimento do cliente. date (AAAA-MM-DD)
        /// </summary>
        public string BirthDate { get; set; }


        public DocumentDto TaxDocument { get; set; }
        public AddressDto ShippingAddress { get; set; }

        public override string ToString()
        {
            return OwnId;
        }

    }



}
