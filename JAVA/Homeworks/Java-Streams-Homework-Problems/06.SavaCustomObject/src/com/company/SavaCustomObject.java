package com.company;

import java.io.*;

public class SavaCustomObject {

    public static void main(String[] args) {
        ObjectInputStream in = null;
        ObjectOutputStream out = null;
        Course course = new Course("Java Streams", 150);

        try {
            out = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream("Data/course.save")));
            out.writeObject(course);
            out.close();
            in = new ObjectInputStream(new BufferedInputStream(new FileInputStream("Data/course.save")));
            System.out.println(in.readObject());
            in.close();
        } catch (FileNotFoundException ffx){
            ffx.printStackTrace();
        } catch (EOFException e){
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
}
