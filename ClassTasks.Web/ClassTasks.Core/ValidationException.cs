using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTasks.Core
{
    /// <summary>
    /// Classe que especializa uma excessão de validação
    /// </summary>
    public class ValidationException: Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
