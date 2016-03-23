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
public class PokemonEletrico extends Pokemon {
    
    public void ChoqueDoTrovao(PokemonAgua inimigo){
        inimigo.Vida -= 40;
        System.out.println("O pokemon "
                + this.Nome
                + " usou o choque do trovão no Pokemon "
                + inimigo.Nome
                + "\nDano Critirco!"
                + "\n Sobrou " 
                + inimigo.Vida 
                + " de vida"
        );
    }
    
    public void ChoqueDoTrovao(PokemonPedra inimigo){
        inimigo.Vida -= 5;
                System.out.println("O pokemon "
                + this.Nome
                + " usou o choque do trovão no Pokemon "
                + inimigo.Nome
                + "\nNão é muito efetivo!"
                + "\n Sobrou " 
                + inimigo.Vida 
                + " de vida"
                        
        );
    }
    
    public void ChoqueDoTrovao(PokemonEletrico inimigo){
        inimigo.Vida -= 25;
                System.out.println("O pokemon "
                + this.Nome
                + " usou o choque do trovão no Pokemon "
                + inimigo.Nome
                + "\n Sobrou " 
                + inimigo.Vida 
                + " de vida"
                        
        );
    }

}
