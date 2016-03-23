/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bancocomerros;

import java.util.Scanner;

/**
 *
 * @author charles.fortes
 */
public class ViewConsole {
    private Controller _controller;
    public ViewConsole(Controller controller){
        _controller = controller;
    }
    
    public void Render(){
        ImprimeMenu();
        String opcao = "";
        Scanner scan = new Scanner(System.in);
        
        while(opcao != "5"){
            opcao = scan.nextLine();
            switch (opcao){
                case "1":
                    CadastroCorrentista();
                    break;
                case "2":
                    ConsultaSaldo();
                    break;
                case "3":
                    EfetuaDeposito();
                    break;
                case "4":
                    EfetuaDeposito();
                    break;
                case "5":
                    return;
            }
            ImprimeMenu();
        }
        
    }
    
    public void CadastroCorrentista(){
        Correntista cor = new Correntista();
        Scanner scan = new Scanner(System.in);
        
        System.out.println("Informe o nome:");
        cor.setNome(scan.nextLine())
        System.out.println("Informe o Sobrenome:");
        cor.setNome(scan.nextLine())
                        
        if (_controller.SalvaCorrentista(cor)){
            System.out.println("Correntista salvo com sucesso");
        } else {
            System.out.println("Correntista salvo com sucesso");
        }
    }

    public void EfetuaDeposito(){
        Scanner scan = new Scanner(System.in);
        
        System.out.println("Informe a agencia:");
        String agencia = scan.nextLine();
        System.out.println("Informe a conta:");
        String conta = scan.nextLine();                
        System.out.println("Informe a conta:");
        double valor = scan.nextDouble();                

        if(_controller.EfetuaDepoito(conta, agencia, valor)){
            System.out.println("Deposito Efetuado com Sucesso");   
        } else {
            System.out.println("Erro ao efetuar deposito");   
        }
   
    }
    
    public void EfetuaSaque(){
           Scanner scan = new Scanner(System.in);
        
        System.out.println("Informe a agencia:");
        String agencia = scan.nextLine();
        System.out.println("Informe a conta:");
        String conta = scan.nextLine();                
        System.out.println("Informe a conta:");
        double valor = scan.nextDouble();                

       if(_controller.EfetuaSaque(conta, agencia, valor)){
            System.out.println("Saque Efetuado com Sucesso");   
        } else {
            System.out.println("Erro ao efetuar saque");   
        }
    }
    
    public void ConsultaSaldo(){
        Scanner scan = new Scanner(System.in);
        
        System.out.println("Informe a agencia:");
        String agencia = scan.nextLine();
        System.out.println("Informe a conta:");
        String conta = scan.nextInt();                

        System.out.println("O Saldo é:");
        System.out.println(_controller.ConsultarSaldo(conta, agencia));
    }

        
    public void ImprimeMenu(){
        System.out.println("Seja bem vindo ao sistema de banco. Selecione uma das opções abaixpo");
        System.out.println("--------");
        System.out.println("1) Cadastrar Correntista");
        System.out.println("2) Consultar Saldo");
        System.out.println("3) Deposito");
        System.out.println("4) Saque");
        System.out.println("5) Sair");
    }
}
