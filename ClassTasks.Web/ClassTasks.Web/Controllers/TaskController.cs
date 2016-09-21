using ClassTasks.Core.DomainObjects;
using ClassTasks.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassTasks.Web.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            var service = new TaskService();
            var tasks = service.GetAll();
            return View(tasks);
        }

        public ActionResult Create()
        {
            //... BONUS: Implementar o funcionamento coma matéria, colocando
            // na tela uma lista ou dropdownlist/combobox com a lista
            // de materias para o usuário escolher e associar a tarefa ...//
            return View();
        }

        public ActionResult Edit(int id)
        {
            //... arrume a edição ...//
            var service = new TaskService();            
            var taskToEdit = service.GetById(id);
            return View("create", taskToEdit);
        }

        public ActionResult Save(Task taskToSave)
        {
            var service = new TaskService();
            service.Save(taskToSave);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            //... implemente a função de excluir no serviço ...//
            return RedirectToAction("Index");

        }
    }
}