using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Top.Framework.Core.DomainObjects.Security;
using Top.Framework.Core.Extension;
using Top.Framework.Core.Infrastructure.Repository.Helper;
using Top.Framework.Core.Infrastructure.Repository.NHibernate;
using Top.Web.Models;

namespace Top.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View(GetUserList(null));
        }

        public ActionResult Edit(int id)
        {
            User usuario;
            using (var session = PersistenceHelper.OpenSession())
            {
                var userRepository = new UserRepository(session);
                usuario = userRepository.FindById(id);
            }

            return View(new UserViewData(usuario));

        }

        [HttpPost]
        public ActionResult Edit(UserViewData userViewData)
        {
            if (!ModelState.IsValid)
                return View(userViewData);

            var user = userViewData.GetUser();

            using (var session = PersistenceHelper.OpenSession())
            {
                var userRepository = new UserRepository(session);
                userRepository.CreateOrUpdate(user);
            }
            
            return RedirectToAction("Index");

        }

        public ActionResult GetFiltered(string filtered)
        {
            var model = GetUserList(filtered);
            return View("Index", model);
        }

        private static List<UserListViewDataItem> GetUserList(string filter)
        {
           IList<User> lista;

            using (var session = PersistenceHelper.OpenSession())
            {
                var userRepository = new UserRepository(session);
                lista = String.IsNullOrWhiteSpace(filter) ? userRepository.FindAll() : userRepository.FindByName(filter);
            }

            return lista.ToList().Select(user => new UserListViewDataItem
                                                {Id = user.Id,
                                                 Name = user.Name, 
                                                 Login = user.Login,
                                                 Email = user.Email,
                                                 Active = user.Active
                                                }).ToList();

        }

        public ActionResult Detail(int id)
        {
            User usuario;
            using (var session = PersistenceHelper.OpenSession())
            {
                var userRepository = new UserRepository(session);
                usuario = userRepository.FindById(id);
            }

            return View(new UserViewData(usuario));
        }

        public ActionResult Remove(int id)
        {
            using (var session = PersistenceHelper.OpenSession())
            {
                var userRepository = new UserRepository(session);
                var user = userRepository.FindById(id);
                userRepository.Remove(user);
            }

            return RedirectToAction("Index");
        }
    }
}
