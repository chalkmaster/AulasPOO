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
public class PokemonPedra extends Pokemon{
    public void Cavar(Pokemon inimigo){
                 System.out.println("O pokemon "
                + this.Nome
                + " usou  'cavar' no Pokemon "
                + inimigo.Nome
        );       
    }
}
