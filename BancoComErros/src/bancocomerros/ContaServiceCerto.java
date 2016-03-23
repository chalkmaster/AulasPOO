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
public class ContaServiceCerto extends ContaService{
    @Override
    public double getTaxasDeposito(){
        super.EfetuaDepoito("0001", "00123423", 0.01);
        return 0.37;
    }
}
