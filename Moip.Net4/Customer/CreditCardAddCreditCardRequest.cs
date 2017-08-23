namespace Moip.Net4
{
    public class CreditCardAddCreditCardRequest
    {
        public string Id { get; set; }

        /// <summary>
        /// Número do cartão de crédito. (Necessário estar dentro do escopo PCI para enviar esse campo sem criptografia) string(19)
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Mês de expiração do cartão. (Necessário estar dentro do escopo PCI para enviar esse campo sem criptografia) integer(2)
        /// </summary>
        public int? ExpirationMonth { get; set; }
        /// <summary>
        /// Ano de expiração do cartão. (Necessário estar dentro do escopo PCI para enviar esse campo sem criptografia) integer(4)
        /// </summary>
        public int? ExpirationYear { get; set; }

        /// <summary>
        /// Código de segurança do cartão. (Necessário estar dentro do escopo PCI para enviar esse campo sem criptografia)
        /// </summary>
        public int? Cvc { get; set; }
        public HolderDto Holder { get; set; }

    }



}
