package com.example.charlesfortes.listacombanco;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by charles.fortes on 11/05/2016.
 */
public class HeroRepository {

    private SQLiteDatabase db;

    public HeroRepository(Context context){
        ConexaoHelper cn = new ConexaoHelper(context);
        db = cn.getWritableDatabase();
    }

    public void Salvar(Heroi heroi){
        ContentValues valores = new ContentValues();
        valores.put("nome", heroi.nome);
        valores.put("poder", heroi.poder);

        db.insert("herois",null, valores);

    }

    public List<Heroi> Listar(){
        String sql = "Select * From herois";
        Cursor dados = db.rawQuery(sql, null);

        List<Heroi> retorno = new ArrayList<Heroi>();

        if(dados.moveToFirst()) {
            do{
                Heroi heroi = new Heroi();

                heroi.nome = dados.getString(0);
                heroi.poder= dados.getString(1);

                retorno.add(heroi);
            } while (dados.moveToNext());
        }

        return retorno;
    }

}
