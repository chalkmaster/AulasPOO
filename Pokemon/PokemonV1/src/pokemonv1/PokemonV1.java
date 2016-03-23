/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pokemonv1;

/**
 *
 * @author charles.fortes
 */
public class PokemonV1 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        PokemonEletrico pikachu = new PokemonEletrico();
        pikachu.Nome = "Pikachu";
        
        PokemonAgua charmander = new PokemonAgua();
        charmander.Nome = "Foguinho";
              
        PokemonPedra onix = new PokemonPedra();
        onix.Nome = "Fofinho";

        pikachu.ChoqueDoTrovao(charmander);
        pikachu.ChoqueDoTrovao(onix);
        pikachu.ChoqueDoTrovao(pikachu);
        
        
    }
    
}
