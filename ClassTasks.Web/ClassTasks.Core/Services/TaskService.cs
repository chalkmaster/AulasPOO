using ClassTasks.Core.DomainObjects;
using ClassTasks.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassTasks.Core.Services
{
    public class TaskService
    {
        private static TaskRepository _repository = new TaskRepository();

        public void Save(Task taskToSave)
        {

            //... BONUS: Implementar o funcionamento coma matéria, colocando
            // na tela uma lista ou dropdownlist/combobox com a lista
            // de materias para o usuário escolher e associar a tarefa ...//
            //if (taskToSave.Course == null)
            //    throw new ValidationException("A tarefa deve estar associada a uma matéria");

            //... adicionar validações para descrição e para assunto ...//

            if (taskToSave.Id == 0)
            {
                _repository.Add(taskToSave);
            }
            else
            {
                _repository.Update(taskToSave);
            }
        }

        public Task GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Task> GetAll()
        {
            return _repository.FindAll();
        }

        public List<Task> FindByCourse(Course course)
        {
            if (course == null)
                throw new ValidationException("informe pelo menos um curso");

            return _repository.FindByCourse(course);
        }

        public List<Task> Find(string searchExpression)
        {
            //... adicionar validação de pelo menos 3 letras ...//

            var findedBySubject = _repository.FindBySubject(searchExpression);
            var findedByDescription = _repository.FindByDescription(searchExpression);

            return findedBySubject.Union(findedByDescription).ToList();
        }

        //... adicionar busca por assunto - validar se o usuário informou pelo menos 3 letras ...//

        //... adicionar busca por descrição - validar se o usuário informou pelo menos 5 letras ...//


    }
}
