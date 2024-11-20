namespace DSM.MJMLEditor.Domain.Models.BusinessResults
{
    public class ResultError
    {
        public string ErrorMessage { get; set; }

        public string Method { get; set; }

        public bool IsException { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="errorMessage">Texto del error.</param>
        /// <param name="isException">Indica si el error es controlado o es una excepción capturada.</param>
        /// <param name="method">Nombre de la clase y el médoto que ha generado el error (NombreClase.NombreMetodo)</param>
        public ResultError(string errorMessage, bool isException, string method)
        {
            ErrorMessage = errorMessage;
            IsException = isException;
            Method = method;
        }

        public ResultError()
        {
        }
    }
}