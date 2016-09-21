using ClassTasks.Core.DomainObjects;
using ClassTasks.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTasks.Core.Services
{
    /// <summary>
    /// Serviço de Matérias de um Curso
    /// </summary>
    public class CourseService
    {
        /// <summary>
        /// repositório de matérias - statico pois todas as instancias de serviço
        /// compartilham o mesmo.
        /// </summary>
        private static CourseRepository _repository = new CourseRepository();

        /// <summary>
        /// Salva a matéria na tabela
        /// </summary>
        /// <param name="courseToSave">matéria que será salvo</param>
        public void Save(Course courseToSave)
        {
            //validações
            if (string.IsNullOrWhiteSpace(courseToSave.Name)) //nome não pode ser nulo ou em branco
                throw new ValidationException("O nome da matéria não pode estar em branco");

            if (courseToSave.Year < 2016) //O ano não pode ser menor que 2016
                throw new ValidationException("O ano deve ser maior ou igual 2016");

            //matérias que possuem o Id zero serão adiconados, se o id
            //é diferente de zero, será atualizado, pois quer dizer que é uma
            //matéria antiga
            if (courseToSave.Id == 0)
            {
                _repository.Add(courseToSave);
            }
            else
            {
                _repository.Update(courseToSave);
            }
        }

        /// <summary>
        /// Remove uma matéria
        /// </summary>
        /// <param name="id">id da matéra a ser removida</param>
        public void Remove(int id)
        {
            _repository.Delete(id);
        }

        /// <summary>
        /// Recupera a mmatéria pelo seu ID
        /// </summary>
        /// <param name="Id">Id da Matéria</param>
        /// <returns>Matéria</returns>
        public Course GetById(int id)
        {
            return _repository.GetById(id);
        }

        /// <summary>
        /// Encontra os cursos pelo nome informado
        /// </summary>
        /// <param name="courseName">parte do nome a ser licalizado</param>
        /// <returns>cursos que possuem o nome solicitado</returns>
        public List<Course> FindByName(string courseName) {
            if (courseName.Length <= 3)
                throw new ValidationException("Informe pelo menos 3 letras para realizar a busca");

            return _repository.FindByName(courseName);
        }

        /// <summary>
        /// recupera todos os cursos de um ano
        /// </summary>
        /// <param name="year">ano dos cursos</param>
        /// <returns>Lista de Cursos de um ano</returns>
        public List<Course> FindByYear(short year)
        {
            return _repository.FindByYear(year);
        }

        /// <summary>
        /// Retorna todas as matérias
        /// </summary>
        /// <returns></returns>
        public List<Course> GetAll()
        {
            return _repository.FindAll();
        }
    }
}
