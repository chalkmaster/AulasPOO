using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTasks.Core.DomainObjects
{
    /// <summary>
    /// Matérias de um Curso
    /// </summary>
    public class Course: Entity //herda de entidade
    {
        /// <summary>
        /// Nome da Matéria
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ano em que a matéria foi ofertada
        /// </summary>
        public short Year { get; set; }
    }
}
