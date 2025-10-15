namespace CashFlow.Communication.Responses
{
    public class ResponseErrorJson
    {
        public List<string> ErrorMessages { get; set; }

        // Construtor da Classe
        public ResponseErrorJson(string errorMessage)
        {
            //Cria uma lista como string para receber apenas uma mensagem e dar um erro a menos ^^

            ErrorMessages = new List<string> { errorMessage };
        }

        public ResponseErrorJson(List<string> errorMessage)
        {
            ErrorMessages = errorMessage;
        }
    }
}
