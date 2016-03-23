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
public class Pokemon {
    protected int vida = 100;
    private String nome;
    protected int forca = 10;
    
    public int getForca(){
        return forca;
    }
    
    public int getVida(){
        return vida;
    }
    
    public void SofrerDano(Pokemon inimigo){
        vida -= inimigo.getForca();
    }
    
    
    
    
    
}
