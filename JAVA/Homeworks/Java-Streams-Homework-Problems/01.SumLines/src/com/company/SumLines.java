package com.company;

import com.sun.xml.internal.fastinfoset.util.CharArray;

import java.io.*;

public class SumLines {

    public static void main(String[] args) {
        File file = new File("Resources/lines.txt");
        BufferedReader reader = null;
        try {
            reader = new BufferedReader(new FileReader(file));
            String line = reader.readLine();
            while (line != null) {
                int sum = 0;
                char[] array = line.toCharArray();
                for (int i = 0; i < array.length; i++) {
                    sum += array[i];
                }

                System.out.println(sum);
                line = reader.readLine();
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}

