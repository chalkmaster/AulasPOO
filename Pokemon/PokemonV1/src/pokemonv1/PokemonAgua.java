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
public class PokemonAgua extends Pokemon{
    public void Hidrobomb(Pokemon inimigo){
        System.out.println("O pokemon "
                + this.Nome
                + " usou a Hidrobomba no Pokemon "
                + inimigo.Nome
        );
    }    
}
