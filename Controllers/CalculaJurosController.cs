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

            double totalDias = (dataCorreta - DateTime.UtcNow).TotalDays;
            int diasParaCalcular = (int)Math.Round(totalDias);

            decimal valorFinal = valorInicial * (decimal)System.Math.Pow(
                    (double)(1 + taxaJuros),
                    diasParaCalcular
            );

            decimal jurosTotal = valorFinal - valorInicial;
            var jurosArredondado = decimal.Round(jurosTotal, 2);

            return decimal.Round(jurosArredondado);
        }
    }
}
