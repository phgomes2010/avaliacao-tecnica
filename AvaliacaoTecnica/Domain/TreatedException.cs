using System;

namespace AvaliacaoTecnica.Domain
{
    public class TreatedException : Exception
    {
        public string Code { get; set; }

        public TreatedException(string code)
        {
            Code = code;
        }

        public string GetMessage()
        {
            switch (Code)
            {
                case "E1":
                    return "Mais de 2 filhos";
                case "E2":
                    return "Ciclo presente";
                case "E3":
                    return "Raízes múltiplas";
                default:
                    return string.Empty;
            }
        }
    }
}
