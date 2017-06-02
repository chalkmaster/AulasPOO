public class Carro {	
	private int numeroDePortas;
	private String cor;
	private int numeroMaximoDePassageiros;
	private boolean trancado;
	private boolean ligado;
	private String ManufactureKeyCode;
	private Motor motorFlex;
	
	public Carro(int numPortas, String cor, int numPass, String Code)
	{
		this.trancado = true;
		this.ligado = false;
		this.motorFlex = new Motor();
		this.numeroDePortas = numPass;
		this.cor = cor;
		this.numeroMaximoDePassageiros = numPass;
		this.ManufactureKeyCode = Code;
	}
	
	public Carro(String manufactureKeyCode){
		this(4, "Preto", 5, manufactureKeyCode);
	}
	
	
	public int getNumeroDePortas()
	{
		return this.numeroDePortas;
	}
	
	public void setNumeroDePortas(int novoNumero)
	{
		if (novoNumero < 5)
			this.numeroDePortas = novoNumero;
	}
	
	public boolean IsLigado()
	{
		return this.ligado;
	}
	
	public void Ligar(String keyCode){
		
		if (keyCode == ManufactureKeyCode)		
			ligado = true;
		
		this.LigarMotorDeArranque();
		
	}
	
	private void LigarMotorDeArranque()
	{}
	
	public Som LigarAlarme(){
		if (this.trancado){
			trancado = false;
			return Som.BipeSimples;
		}
		else{
			trancado = true;
			return Som.BipeDuplo;
		}
	}
}




