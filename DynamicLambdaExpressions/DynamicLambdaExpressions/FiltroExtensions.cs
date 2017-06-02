#define SIMPLIFICADO

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLambdaExpressions
{
    /// <summary>
    /// Classe que contém os métodos de extensão para filtro.
    /// </summary>
    public static class FiltroExtensions
    {
#if SIMPLIFICADO

        /// <summary>
        /// Filtra uma coleção a partir do texto informado.
        /// </summary>
        /// <typeparam name="T">Tipo do item da coleção.</typeparam>
        /// <param name="colecao">Coleção.</param>
        /// <param name="filtro">Filtro.</param>
        /// <returns>Coleção filtrada</returns>
        public static IEnumerable<T> Filtrar<T>(this IEnumerable<T> colecao, string filtro)
        {
            string[] args = filtro.Split(' ');
            
            string nomePropriedade = args[0];
            string operador = args[1];
            string valorTexto = args[2];

            Type type = typeof(T);

            ParameterExpression parameterExpression = Expression.Parameter(type, "it");

            PropertyInfo propriedade = type.GetProperty(nomePropriedade);

            MemberExpression memberExpression = Expression.Property(parameterExpression, propriedade);

            object valor = Convert.ChangeType(valorTexto, propriedade.PropertyType);
            
            ConstantExpression constantExpression = Expression.Constant(valor, propriedade.PropertyType);

            Expression body = null;
            var stringComparison = Expression.Constant(StringComparison.OrdinalIgnoreCase);

            switch (operador)
            {
                case "=":
                case "==":
                case "igual":
                    body = Expression.Equal(memberExpression, constantExpression);
                    break;
                case "!=":
                case "diferente":
                    body = Expression.NotEqual(memberExpression, constantExpression);
                    break;
                case ">":
                case "maior":
                    body = Expression.GreaterThan(memberExpression, constantExpression);
                    break;
                case ">=":
                case "maiorigual":
                    body = Expression.GreaterThanOrEqual(memberExpression, constantExpression);
                    break;
                case "<":
                case "menor":
                    body = Expression.LessThan(memberExpression, constantExpression);
                    break;
                case "<=":
                case "menorigual":
                    body = Expression.LessThanOrEqual(memberExpression, constantExpression);
                    break;
                case "comecacom":
                    var startsWith = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string), typeof(StringComparison) });
                    body = Expression.Call(memberExpression, startsWith, constantExpression, stringComparison);
                    break;
                case "contem":
                    var indexOf = typeof(string).GetMethod("IndexOf", new Type[] { typeof(string), typeof(StringComparison) });
                    body = Expression.Call(memberExpression, indexOf, constantExpression, stringComparison);
                    body = Expression.NotEqual(body, Expression.Constant(-1));
                    break;
                case "terminacom":
                    var endsWith = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string), typeof(StringComparison) });
                    body = Expression.Call(memberExpression, endsWith, constantExpression, stringComparison);
                    break;
                default:
                    throw new Exception("Operador informado é invalido");
            }

            Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(body, parameterExpression);
            Func<T, bool> func = expression.Compile();
            return colecao.Where(func);
        }


#else
        /// <summary>
        /// Método StartsWith.
        /// </summary>
        private static readonly MethodInfo StartsWith = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string), typeof(StringComparison) });

        /// <summary>
        /// Método EndsWith.
        /// </summary>
        private static readonly MethodInfo EndsWith = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string), typeof(StringComparison) });

        /// <summary>
        /// Método IndexOf.
        /// </summary>
        private static readonly MethodInfo IndexOf = typeof(string).GetMethod("IndexOf", new Type[] { typeof(string), typeof(StringComparison) });

        /// <summary>
        /// Armazena a constante para ignorar case;
        /// </summary>
        private static readonly Expression OrdinalIgnoreCase = Expression.Constant(StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Filtra uma coleção a partir do filtro informado.
        /// </summary>
        /// <typeparam name="T">Tipo do item da coleção.</typeparam>
        /// <param name="colecao">Coleção.</param>
        /// <param name="filtro">Filtro a ser aplicado.</param>
        /// <returns>Coleção filtrada.</returns>
        public static IEnumerable<T> Filtrar<T>(this IEnumerable<T> colecao, string filtro)
        {
            PropertyInfo propriedade;
            object valor;
            TipoOperador operador;

            ExtrairParametros<T>(filtro, out propriedade, out operador, out valor);

            // executa a outra sobrecarga do método
            return colecao.Filtrar(propriedade, operador, valor);
        }

        /// <summary>
        /// Filtra uma coleção a partir dos parâmetros informados.
        /// </summary>
        /// <typeparam name="T">Tipo do item da coleção.</typeparam>
        /// <param name="colecao">Coleção.</param>
        /// <param name="propriedade">Propriedade para filtro.</param>
        /// <param name="operador">Operador para comparação.</param>
        /// <param name="valor">Valor para comparação.</param>
        /// <returns>Coleção filtrada.</returns>
        public static IEnumerable<T> Filtrar<T>(this IEnumerable<T> colecao, PropertyInfo propriedade, TipoOperador operador, object valor)
        {
            Expression<Func<T, bool>> expression = CriarExpressao<T>(propriedade, operador, valor);

            // compila a lambda expression para utilizar como parâmetro do método Where
            Func<T, bool> func = expression.Compile();

            // executa o método where
            return colecao.Where(func);
        }

        /// <summary>
        /// Filtra uma coleção a partir do filtro informado.
        /// </summary>
        /// <typeparam name="T">Tipo do item da coleção.</typeparam>
        /// <param name="colecao">Coleção.</param>
        /// <param name="filtro">Filtro a ser aplicado.</param>
        /// <returns>Coleção filtrada.</returns>
        public static IQueryable<T> Filtrar<T>(this IQueryable<T> colecao, string filtro)
        {
            PropertyInfo propriedade;
            object valor;
            TipoOperador operador;

            ExtrairParametros<T>(filtro, out propriedade, out operador, out valor);

            // executa a outra sobrecarga do método
            return colecao.Filtrar(propriedade, operador, valor);
        }

        /// <summary>
        /// Filtra uma coleção a partir dos parâmetros informados.
        /// </summary>
        /// <typeparam name="T">Tipo do item da coleção.</typeparam>
        /// <param name="colecao">Coleção.</param>
        /// <param name="propriedade">Propriedade para filtro.</param>
        /// <param name="operador">Operador para comparação.</param>
        /// <param name="valor">Valor para comparação.</param>
        /// <returns>Coleção filtrada.</returns>
        public static IQueryable<T> Filtrar<T>(this IQueryable<T> colecao, PropertyInfo propriedade, TipoOperador operador, object valor)
        {
            Expression<Func<T, bool>> expression = CriarExpressao<T>(propriedade, operador, valor);

            // executa o método where
            return colecao.Where(expression);
        }

        /// <summary>
        /// Extrai os parâmetros utilizados para criar a lambda expression.
        /// </summary>
        /// <typeparam name="T">Tipo do item.</typeparam>
        /// <param name="filtro">Filtro.</param>
        /// <param name="propriedade">Propriedade do filtro.</param>
        /// <param name="operador">Operador do filtro.</param>
        /// <param name="valor">Valor do filtro.</param>
        private static void ExtrairParametros<T>(string filtro, out PropertyInfo propriedade, out TipoOperador operador, out object valor)
        {
            // verifica o parâmetro filtro
            if (string.IsNullOrWhiteSpace(filtro))
                throw new Exception("Filtro não pode ser nulo");

            // separa os parâmetros por espaço
            string[] args = filtro.Split(' ');
            if (args.Length != 3)
                throw new Exception("Filtro deve conter três parâmetros");

            // recupera os valores separadamente
            string nomePropriedade = args[0];
            string nomeOperador = args[1];
            string valorTexto = args[2];

            // tipo do item da coleção
            Type type = typeof(T);

            // recupera a propriedade pelo nome
            propriedade = type.GetProperty(nomePropriedade);
            if (propriedade == null)
                throw new Exception("Propriedade não encontrada");

            // converte o valor textual do filtro para o mesmo tipo da propriedade
            valor = ConverterValor(valorTexto, propriedade.PropertyType);

            // recupera o tipo de operador pelo nome
            operador = BuscarOperador(nomeOperador);
        }

        /// <summary>
        /// Cria a expressão dinamicamente.
        /// </summary>
        /// <typeparam name="T">Tipo do item.</typeparam>
        /// <param name="propriedade">Propriedade.</param>
        /// <param name="operador">Operador.</param>
        /// <param name="valor">Valor.</param>
        /// <returns>Expressão criada dinamicamente pelos dados informados.</returns>
        private static Expression<Func<T, bool>> CriarExpressao<T>(PropertyInfo propriedade, TipoOperador operador, object valor)
        {
            // tipo do item
            Type type = typeof(T);

            // parametro da lambda expression
            ParameterExpression parameterExpression = Expression.Parameter(type, "it");

            // expressão de acesso à propriedade
            MemberExpression memberExpression = Expression.Property(parameterExpression, propriedade);

            // constante para o valor a ser comparado
            ConstantExpression constantExpression = Expression.Constant(valor);

            // corpo da lambda expression
            Expression body = BuscarCorpo(memberExpression, operador, constantExpression);

            // cria a lambda expression
            Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(body, parameterExpression);
            return expression;
        }

        /// <summary>
        /// Converte um valor texto para o tipo da propriedade.
        /// </summary>
        /// <param name="valorTexto">Texto.</param>
        /// <param name="tipo">Tipo a ser convertido.</param>
        /// <returns>Valor convertido.</returns>
        private static object ConverterValor(string valorTexto, Type tipo)
        {
            try
            {
                return Convert.ChangeType(valorTexto, tipo);
            }
            catch
            {
                throw new Exception("Valor informado não pode ser convertido para o tipo da propriedade");
            }
        }

        /// <summary>
        /// Cria o corpo da lambda expression de acordo com os filtros informados.
        /// </summary>
        /// <param name="memberExpression">Expressão que acessa a propriedade.</param>
        /// <param name="operador">Operador a ser utilizado.</param>
        /// <param name="constantExpression">Valor para comparação.</param>
        /// <returns>Corpo da lambda expression criada dinamicamente.</returns>
        private static Expression BuscarCorpo(MemberExpression memberExpression, TipoOperador operador, ConstantExpression constantExpression)
        {
            switch (operador)
            {
                case TipoOperador.Igual:
                    return Expression.Equal(memberExpression, constantExpression);
                case TipoOperador.Diferente:
                    return Expression.NotEqual(memberExpression, constantExpression);
                case TipoOperador.Maior:
                    return Expression.GreaterThan(memberExpression, constantExpression);
                case TipoOperador.MaiorIgual:
                    return Expression.GreaterThanOrEqual(memberExpression, constantExpression);
                case TipoOperador.Menor:
                    return Expression.LessThan(memberExpression, constantExpression);
                case TipoOperador.MenorIgual:
                    return Expression.LessThanOrEqual(memberExpression, constantExpression);
                case TipoOperador.ComecaCom:
                    return Expression.Call(memberExpression, StartsWith, constantExpression, OrdinalIgnoreCase);
                case TipoOperador.Contem:
                    var body = Expression.Call(memberExpression, IndexOf, constantExpression, OrdinalIgnoreCase);
                    var menos1 = Expression.Constant(-1);
                    return Expression.NotEqual(body, menos1);
                case TipoOperador.TerminaCom:
                    return Expression.Call(memberExpression, EndsWith, constantExpression, OrdinalIgnoreCase);
                default:
                    throw new Exception("Operador informado é invalido");
            }
        }

        /// <summary>
        /// Recupera o operador pelo nome informado como parâmetro.
        /// </summary>
        /// <param name="nomeOperador">Nome do operador.</param>
        /// <returns>Operador que possui o nome informado.</returns>
        private static TipoOperador BuscarOperador(string nomeOperador)
        {
            if (string.IsNullOrWhiteSpace(nomeOperador))
                throw new Exception("Nome do operador não pode ser nulo");

            switch (nomeOperador.ToLower())
            {
                case "=":
                case "==":
                case "igual":
                    return TipoOperador.Igual;
                case "!=":
                case "diferente":
                    return TipoOperador.Diferente;
                case ">":
                case "maior":
                    return TipoOperador.Maior;
                case ">=":
                case "maiorigual":
                    return TipoOperador.MaiorIgual;
                case "<":
                case "menor":
                    return TipoOperador.Menor;
                case "<=":
                case "menorigual":
                    return TipoOperador.MenorIgual;
                case "comecacom":
                    return TipoOperador.ComecaCom;
                case "contem":
                    return TipoOperador.Contem;
                case "terminacom":
                    return TipoOperador.TerminaCom;
                default:
                    throw new Exception("Operador informado é invalido");
            }
        }
#endif
    }
}
