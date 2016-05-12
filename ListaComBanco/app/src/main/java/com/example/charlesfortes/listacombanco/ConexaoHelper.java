package com.example.charlesfortes.listacombanco;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

/**
 * Created by charles.fortes on 11/05/2016.
 */
public class ConexaoHelper extends SQLiteOpenHelper {

    public ConexaoHelper(Context context) {
        super(context, "DBMarvel", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("Create table herois (nome text, poder text)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("drop table herois");
        onCreate(db);
    }
}
