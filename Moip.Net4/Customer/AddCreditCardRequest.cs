namespace Moip.Net4
{
    public class AddCreditCardRequest
    {
        /// <summary>
        /// Método do instrumento de cobrança. Valores possíveis: CREDIT_CARD
        /// </summary>
        public MethodType Method { get; set; }

        public CreditCardAddCreditCardRequest CreditCard { get; set; }
    }



}
