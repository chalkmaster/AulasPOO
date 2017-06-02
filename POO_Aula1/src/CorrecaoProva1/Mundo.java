package CorrecaoProva1;

public class Mundo {

	public static void main(String[] args) {
		Homem Atirador = new Homem("Jão");
		Homem CaraQueVaiMorrer = new Homem("Cabloco");
		
		Revolver treisOitao = new Revolver("Preto", 6, 1, 4, "Mdeira", 1, true, false, 38);
		
		Atirador.SetRevolver(treisOitao);		
		Atirador.MatarCaboclo(CaraQueVaiMorrer);
		
	}

}
