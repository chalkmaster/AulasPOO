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
public class Controller {
    private ContaService service;
    public Controller (){
        service = new ContaServiceCerto();
    }
    public boolean SalvaCorrentista(Correntista correntistaParaSalvar){
        service.fillAgenciaConta(correntistaParaSalvar);
        //salva no banco de dados
        return true;
    }
    
    public double ConsultarSaldo(String conta, String agencia ){
        return service.ConsultarSaldo(conta, agencia);
    }
    
    public boolean EfetuaDepoito(String conta, String agencia, double valor){
        return service.EfetuaDepoito(conta, agencia, valor);
    }
    
    public boolean EfetuaSaque(String conta, String agencia, double valor){
        return service.EfetuaSaque(conta, agencia, valor);
    }
}
