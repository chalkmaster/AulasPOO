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
public class ContaService {
     public boolean fillAgenciaConta(Correntista correntistaParaSalvar){ 
         //Vai no banco de dados, gera o proximo numero de agencia e conta e preenche para o correntista;
        return true;
    }
    
    public double ConsultarSaldo(String conta, String agencia ){
        //Consulta o Saldo no Banco de Dados
        return 0.0;
    }
    
    public boolean EfetuaDepoito(String conta, String agencia, double valor){
        valor += getTaxasDeposito();
        //vai no banco e salva
        return true;
    }
    
    public boolean EfetuaSaque(String conta, String agencia, double valor){
        valor += getTaxasSaque();
        //vai no banco e salva
        return true;
    }
    
    public double getTaxasDeposito(){
        return 0.38;
    }
    private double getTaxasSaque(){
        return 0.38;
    }
}
