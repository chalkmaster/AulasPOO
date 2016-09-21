using ClassTasks.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTasks.Core.Repository
{

    /// <summary>
    /// Repositório de Matérias
    /// Internal pois só é visível dentro da DLL core, não é possível acessar
    /// diretamente pelo projeto web, obriga a passar pelo serviço
    /// </summary>
    internal class CourseRepository
    {
        /// <summary>
        /// Representa nossa tabela no banco de dados
        /// </summary>
        private List<Course> _courseTable;
        
        /// <summary>
        /// Construtor
        /// </summary>
        internal CourseRepository()
        {
            //inicializa a lista em memória que representa uma tabela do banco de dados
            _courseTable = new List<Course>();
        }

        /// <summary>
        /// Retorna umq matéria com o id especificado
        /// </summary>
        /// <param name="id">id da matéria a ser encontrado</param>
        /// <returns>uma matéria do banco de dados</returns>
        internal Course GetById(int id)
        {
            //procura uma matéria que tenha o id indicado no parametro, se não achar ele retorna null
            return _courseTable.Where(course => course.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// Encontra todas as matérias que possuam o nome informado
        /// </summary>
        /// <param name="courseName">nome ou parte do nome da matéria</param>
        /// <returns>lista de matérias com o nome informado</returns>
        internal List<Course> FindByName(string courseName)
        {
            //procura na lista ums matéria cujo nome contenha a expressão passada por parâmetro
            //se por exemplo no banco tem um matéria chamada Programação Orientada a Objetos e você 
            //passar a palavra objeto como parametro ele vai retornar correto.
            return _courseTable.Where(course => course.Name.Contains(courseName)).ToList();
        }
        /// <summary>
        /// Remove uma matéria da lista
        /// </summary>
        /// <param name="id">id da matéria a ser removida</param>
        internal void Delete(int id)
        {
            //localiza a matéria com o id solcitiado pra exclusão
            var courseToDelete = _courseTable.FirstOrDefault(course => course.Id == id);
            //remove da lista
            _courseTable.Remove(courseToDelete);
        }

        /// <summary>
        /// Recupera todas as matérias de um determinado ano
        /// </summary>
        /// <param name="year">ano a ser procurado</param>
        /// <returns>lista de matérias do ano informado</returns>
        internal List<Course> FindByYear(short year)
        {
            //procura todas as matérias de um determinado ano
            return _courseTable.Where(course => course.Year == year).ToList();
        }

        /// <summary>
        /// atualiza uma matéria já existente
        /// </summary>
        /// <param name="courseToUpdate">matéria com dados atualizados</param>
        internal void Update(Course courseToUpdate)
        {
            //para atualizar ele vai localizar a matéria com o id indicado para poder
            //remover o existe e trocar pela nova
            var courseToRemove = GetById(courseToUpdate.Id);

            //se localizou a matéria com que foi atualizada, primeiro ele remove a antiga
            _courseTable.Remove(courseToRemove);

            //após remover a antiga, ele adiciona a nova
            _courseTable.Add(courseToUpdate);
        }

        internal List<Course> FindAll()
        {
            return _courseTable;
        }

        /// <summary>
        /// Adiciona um novo matéria na tabela
        /// </summary>
        /// <param name="courseToAdd">matéria a ser adicionado</param>
        internal void Add(Course courseToAdd)
        {
            //incrmenta o id na tabela. encontra qual o maior id usado e o incrementa
            courseToAdd.Id = _courseTable.Any() ? _courseTable.Max(course => course.Id) + 1 : 1;

            //novas matérias são apenas adicionadas, nenhuma verificação adicional será feita
            _courseTable.Add(courseToAdd);
        }
    }
}
