using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTasks.Core.DomainObjects
{
    /// <summary>
    /// Tarefa
    /// </summary>
    public class Task: Entity
    {
        /// <summary>
        /// Assunto da Tarefa
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Descrição da Tarefa
        /// </summary>
        public string Description { get; set; }
        
        //... BONUS: Implementar o funcionamento coma matéria, colocando
        // na tela uma lista ou dropdownlist/combobox com a lista
        // de materias para o usuário escolher e associar a tarefa ...//
        /// <summary>
        /// Matéria da tarefa
        /// </summary>
        public Course Course { get; set; }

        //... impleemnte professor (teacher) ...//
    }
}
