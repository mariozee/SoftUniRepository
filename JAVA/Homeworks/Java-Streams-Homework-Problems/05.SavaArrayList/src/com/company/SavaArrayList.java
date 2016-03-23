package com.company;

import java.io.*;
import java.util.ArrayList;
import java.util.Objects;

public class SavaArrayList {

    public static void main(String[] args) {
        ArrayList<Double> doublesList = new ArrayList<Double>();
        doublesList.add(4.5);
        doublesList.add(3.5);
        doublesList.add(1234.56);
        File file = new File("Resources/doubles.list");
        ObjectOutputStream oos = null;
        ObjectInputStream ois = null;
        try {
            oos = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream(file)));
            oos.writeObject(doublesList);
            oos.close();
            ois = new ObjectInputStream(new BufferedInputStream(new FileInputStream(file)));
            System.out.println(ois.readObject());
            ois.close();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
}
