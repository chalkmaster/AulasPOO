using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLambdaExpressions
{
    /// <summary>
    /// Lista de possíveis operadores.
    /// </summary>
    public enum TipoOperador
    {
        Igual,
        Diferente,
        Maior,
        MaiorIgual,
        Menor,
        MenorIgual,
        ComecaCom,
        Contem,
        TerminaCom
    }
}
