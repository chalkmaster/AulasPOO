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
public class Pokemon {
    public String Nome;
    public int Vida = 100;
    
    public void Atacar(Pokemon inimigo){
        
        inimigo.Vida -=10;
        
        System.out.println("Pokemon " 
                + this.Nome 
                + " atacou o pokemon "
                + inimigo.Nome
                );
    }
}
