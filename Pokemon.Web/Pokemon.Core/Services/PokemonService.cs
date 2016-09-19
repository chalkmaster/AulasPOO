using Pokemon.Core.DomainObjects;
using Pokemon.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Core.Services
{    
    public class PokemonService
    {
        private static PokemonRepository _repositorio = new PokemonRepository();
        public void Save(PokemonModel pokemonToSave)
        {
            _repositorio.Save(pokemonToSave);
        }

        public List<PokemonModel> GetAll()
        {
            return _repositorio.ListAll();
        }
    }
}
