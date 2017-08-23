namespace Moip.Net4
{
    public class DocumentDto
    {
        /// <summary>
        /// Tipo do documento. Valores possíveis: CPF, CNPJ. Limite de caracteres: (4)
        /// </summary>
        public DocumentType Type { get; set; }
        /// <summary>
        /// Número do documento. Limite de caracteres: (11)
        /// </summary>
        public string Number { get; set; }
    }



}
