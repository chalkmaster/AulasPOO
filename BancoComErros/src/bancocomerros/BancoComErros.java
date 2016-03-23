/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bancocomerros;

/**
 *
 * @author charles.fortes
 */
public class BancoComErros {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Controller controllerPrincipal = new Controller();
        ViewConsole viewPrincipal = new ViewConsole(controllerPrincipal);
        viewPrincipal.Render();
    }
    
}
