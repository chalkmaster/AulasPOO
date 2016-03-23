/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pokemonv2;

/**
 *
 * @author charles.fortes
 */
public class Eletrico extends Pokemon {
    
    public void ChoqueDoTrovao(Pokemon inimigo){
        inimigo.SofrerDano(this);
    }
    
}
