using ClassTasks.Core.DomainObjects;
using ClassTasks.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassTasks.Web.Controllers
{
    public class CourseController : Controller
    {
        /// <summary>
        /// Lista Incial
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Localiza e retorna todos os cursos já cadastrados
            //para que a tela possa listá-los
            var service = new CourseService();
            var courses = service.GetAll();
            return View(courses);
        }

        /// <summary>
        /// Cria uma nova matéria
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            //Apenas retorna a tela para criação de matéria com os campos em branco
            return View();
        }

        /// <summary>
        /// Edita os dados de uma matéria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            //recupera a matéria com o id informado e abre a tela 
            //com os campos preenchidos para ediçao
            // --> o campo id está como campo oculto no formulário
            // --> <input type=hidden/> na view
            var service = new CourseService();
            var courseToEdit = service.GetById(id);
            return View("create", courseToEdit);
        }

        /// <summary>
        /// Salva uma matéria criada ou editada
        /// </summary>
        /// <param name="courseToSave"></param>
        /// <returns></returns>
        public ActionResult Save(Course courseToSave)
        {
            //salva a matéria e retorna pra listagem
            var service = new CourseService();
            service.Save(courseToSave);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Remove uma matéria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var service = new CourseService();
            service.Remove(id);
            return RedirectToAction("Index");
        }
    }
}