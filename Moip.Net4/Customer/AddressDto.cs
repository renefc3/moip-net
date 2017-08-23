namespace Moip.Net4
{
    public class AddressDto
    {
        /// <summary>
        /// REQUIRED Logradouro do endereço
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// REQUIRED Número
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Complemento do endereço.
        /// </summary>
        public string Complement { get; set; }
        /// <summary>
        /// REQUIRED Bairro
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// REQUIRED Cidade
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// REQUIRED Estado
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// REQUIRED País em formato ISO-alpha3, exemplo BRA.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// REQUIRED O CEP do endereço de cobrança
        /// </summary>
        public string ZipCode { get; set; }
    }



}
