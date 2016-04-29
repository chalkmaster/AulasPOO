package com.example.charlesfortes.sqlite;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

/**
 * Created by charles.fortes on 28/05/2015.
 */
public class PersistenceHelper extends SQLiteOpenHelper {

    public static final String NOME_BANCO =  "ExemploVeiculo";
    public static final int VERSAO =  1;

    public PersistenceHelper(Context context) {
        super(context, NOME_BANCO, null, VERSAO);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(VeiculoRepository.SCRIPT_CRIACAO_TABELA_VEICULOS);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL(VeiculoRepository.SCRIPT_DELECAO_TABELA);
        onCreate(db);
    }

}