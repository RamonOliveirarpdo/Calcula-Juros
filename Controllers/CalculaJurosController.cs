using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Atividade3.Controllers
{
    public class CalculaJurosController
    {
        [HttpGet("calculajuros")]
        public decimal CalcularJuros(decimal valorInicial, string dataVencimento)
        {
            const decimal taxaJuros = 0.025m;

            DateTime dataCorreta = DateTime.ParseExact(
                dataVencimento,
                "dd/MM/yyyy",
                CultureInfo.GetCultureInfo("pt-BR"));

            double totalDias = (dataCorreta.Date - DateTime.UtcNow.Date).TotalDays;
            int diasParaCalcular = (int)Math.Round(totalDias);

            decimal valorFinal = valorInicial * (1m + (taxaJuros * (decimal)diasParaCalcular));

            decimal jurosTotal = valorFinal - valorInicial;

            return jurosTotal;
        }
    }
}
