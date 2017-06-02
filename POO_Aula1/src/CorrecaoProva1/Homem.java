package CorrecaoProva1;

public class Homem {
	private String Nome;
	private Revolver TreisOitao;
	
	public Homem(String nome){
		this.Nome = nome;
	}
	
	public String getNome() {return this.Nome;}
	
	public void SetRevolver(Revolver revolver)
	{
		this.TreisOitao = revolver;
	}
	
	public void correr()
	{
		
	}
	
	
	public void Ameaçar(Homem quemVaiSerAmaeaçado)
	{		
		this.Mirar(quemVaiSerAmaeaçado, ParteDoCorpo.Cabeca);		
	}
	
	public void MatarCaboclo(Homem cabocloASeMatar){
		
		this.Ver(TreisOitao.getCor());
		this.Ver(TreisOitao.getCalibre());
		this.Ver(TreisOitao.getRepeticaoDisparo());
		this.Ver(TreisOitao.getTamanhoDoCano());
		
		int numBalasRevolver = TreisOitao.getQuantidadeMaximaDeMunicao();
		int numBalasDisponivies = TreisOitao.getQuantidadeMunicaoCarregada();
		int numBalasQuePreciso = 2;
		
		if (numBalasDisponivies < numBalasQuePreciso)
			TreisOitao.Carregar(numBalasDisponivies - numBalasRevolver);
		
		if (TreisOitao.getEstaTravada()){
			TreisOitao.Destravar();
		}
		if (TreisOitao.getEstaEngatilhado() == false){
			TreisOitao.Engatilhar();
		}
		
		this.FalarPara(cabocloASeMatar, "Asta La Vista Baby!");
		
		this.Mirar(cabocloASeMatar, ParteDoCorpo.Cabeca);
		
		TreisOitao.Disparar();		
		
	}

	private void Mirar(Homem cablocoASeMatar, ParteDoCorpo cabeca) {
		// TODO Auto-generated method stub
		
	}

	private void FalarPara(Homem cablocoASeMatar, String string) {
		// TODO Auto-generated method stub
		
	}

	private void Ver(Object caracteristicaDuBejeto) {
		
	}

}
