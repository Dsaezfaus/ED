package org.serpis.instituto.acategoria;

/**
 * Created by mati on 1/06/16.
 */
public class Categoria {
public long id;
    public String nombre;

    public Categoria(long id, String nomrbe){
        this.id=id;
        this.nombre=nombre;
    }

    public String toString(){
        return String.format("[%d] %s", id, nombre);
    }
}
