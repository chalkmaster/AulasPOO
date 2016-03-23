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
public class Correntista {
    private String nome;
    private String sobrenome;
    private String agencia;
    private String conta;    
    private double Saldo;

    /**
     * @return the Saldo
     */
    public double getSaldo() {
        return Saldo;
    }

    /**
     * @param Saldo the Saldo to set
     */
    public void setSaldo(double Saldo) {
        this.Saldo = Saldo;
    }
    
}
