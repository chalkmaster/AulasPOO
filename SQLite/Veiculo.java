package com.example.charlesfortes.sqlite;

/**
 * Created by charles.fortes on 28/05/2015.
 */
public class Veiculo {

    private int id;
    private String marca;
    private String modelo;
    private String placa;

    public Veiculo() {

    }

    public Veiculo(int id, String marca, String modelo, String placa) {
        this.id = id;
        this.marca = marca;
        this.modelo = modelo;
        this.placa = placa;
    }



    public String getMarca() {
        return marca;
    }

    public void setMarca(String marca) {
        this.marca = marca;
    }

    public String getModelo() {
        return modelo;
    }

    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    public String getPlaca() {
        return placa;
    }

    public void setPlaca(String placa) {
        this.placa = placa;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Override
    public String toString() {
        return placa + " " +  modelo + " " + marca;
    }
}
