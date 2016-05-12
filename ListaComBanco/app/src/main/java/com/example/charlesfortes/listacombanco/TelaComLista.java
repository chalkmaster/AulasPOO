package com.example.charlesfortes.listacombanco;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;


public class TelaComLista extends ActionBarActivity {

    ListView listView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_com_lista);

        listView = (ListView)findViewById(R.id.listView);

        HeroRepository repositorio = new HeroRepository(getApplicationContext());

        Heroi thor = new Heroi();
        thor.nome = "Thor";
        thor.poder = "Trovão";

        Heroi viuvaNegra = new Heroi();
        viuvaNegra.nome = "Viuva Negra";
        viuvaNegra.poder = "Luta";

        repositorio.Salvar(thor);
        repositorio.Salvar(viuvaNegra);

        List<Heroi> avengers = repositorio.Listar();

        List<String> valoresDaLista = new ArrayList<String>();

        for(int i = 0; i < avengers.size(); i++) {
            valoresDaLista.add("Nome: " + avengers.get(i).nome
                             + " Poder: " + avengers.get(i).poder);
        }

        ArrayAdapter<String> adapter
                = new ArrayAdapter<String>(
                    getApplicationContext(),
                    android.R.layout.simple_list_item_1,
                    android.R.id.text1,
                    valoresDaLista
        );

        listView.setAdapter(adapter);

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_tela_com_lista, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
