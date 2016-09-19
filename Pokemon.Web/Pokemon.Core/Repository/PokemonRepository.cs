using Pokemon.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Core.Repository
{
    public class PokemonRepository
    {
        private List<PokemonModel> _db = new List<PokemonModel>();

        public void Save(PokemonModel pokemonToSave)
        {
            _db.Add(pokemonToSave);
        }

        public List<PokemonModel> ListAll()
        {
            return _db;
        }
    }
}
