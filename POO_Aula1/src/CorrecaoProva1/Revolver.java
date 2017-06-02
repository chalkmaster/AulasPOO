package CorrecaoProva1;

public class Revolver {
	private String Cor;
	private int QuantidadeMaximaDeMunicao;
	private int QuantidadeMunicaoCarregada;
	private int TamanhoDoCano;
	private String AcabamentoDaEncunhadura;
	private int RepeticaoDeDisparo = 1;
	private boolean EstaTravada;
	private boolean EstaEngatilhada;
	private int Calibre;
	
	public String getCor() {return this.Cor;}
	public int getQuantidadeMaximaDeMunicao() {return this.QuantidadeMaximaDeMunicao;}
	public int getQuantidadeMunicaoCarregada() { return this.QuantidadeMunicaoCarregada;}
	public int getTamanhoDoCano() {return this.TamanhoDoCano;}
	public String getAcabamentoDaEncunhadura() {return this.AcabamentoDaEncunhadura;}
	public int getRepeticaoDisparo() {return this.RepeticaoDeDisparo;}
	public boolean getEstaTravada() {return this.EstaTravada;}
	public boolean getEstaEngatilhado() {return this.EstaEngatilhada;}
	public int getCalibre() {return this.Calibre;}
	
	public Revolver(String Cor,	 int QuantidadeMaximaDeMunicao,	 int QuantidadeMunicaoCarregada,
			int TamanhoDoCano,	 String AcabamentoDaEncunhadura,	 int RepeticaoDeDisparo,	 
			boolean EstaTravada,	 boolean EstaEngatilhada,	 int Calibre)	{		
		this.Cor = Cor;
		this.QuantidadeMaximaDeMunicao = QuantidadeMaximaDeMunicao;
		//....... e por ai vai		
	}
	
	
	public boolean Disparar(){
		this.Engatilhar();
		this.Desengatilhar();
		//Bala sai da arma
		return true;
	}
	
	public void Carregar(int quantidadeCapsulas){
		this.QuantidadeMunicaoCarregada = quantidadeCapsulas;
	}
	
	public void Engatilhar(){
		//Coloca o gatilho pra tras, trava o gatilho, roda o tambor um pouco, faz barulho
	}
	
	
	public void Travar(){

	}
	public void Desengatilhar(){
		//Termina de rodar o tambor, destrava o gatilho
	}
	
	public void Destravar(){
	}
	
}
