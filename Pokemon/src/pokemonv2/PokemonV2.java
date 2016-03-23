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
public class PokemonV2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Eletrico pikachu = new Eletrico();
        Agua squartle = new Agua();
        
        Treinador ash = new Treinador();
        ash.setPk1(pikachu);
        ash.setPk2(squartle);
        
        pikachu.ChoqueDoTrovao(squartle);
        
        System.out.println(squartle.getVida());
    }
    
}
