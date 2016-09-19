using Pokemon.Core.DomainObjects;
using Pokemon.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pokemon.Web.Controllers
{
    public class PokemonController : Controller
    {
        // GET: Pokemon
        public ActionResult Index()
        {

            var pokemon = new PokemonModel();
            var outroPokemon = new PokemonModel();

            pokemon.Nome = "Pikachu";
            pokemon.Tipo = "Eletrico";
            pokemon.Nivel = 50;

            outroPokemon.Nome = "Eve";
            outroPokemon.Tipo = "Fogo";
            outroPokemon.Nivel = 30;

            var servico = new PokemonService();
            servico.Save(pokemon);
            servico.Save(outroPokemon);
            ////////////////////////
            var model = servico.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new PokemonModel();
            return View(model);

        }

        public ActionResult Save(PokemonModel pokemon)
        {
            var servico = new PokemonService();
            servico.Save(pokemon);

            return RedirectToAction("Index");
        }

    }
}


