public class UsaCarro{
	
	private String CarManufactureKeyCode =  "dfghjkl";
	private Carro meuCarro = new Carro(CarManufactureKeyCode);
	private int[] list;
	private void usa()
	{
		meuCarro.Ligar(CarManufactureKeyCode);
		
		if (meuCarro.IsLigado()){
			//do something
		}
		
		
	}
}