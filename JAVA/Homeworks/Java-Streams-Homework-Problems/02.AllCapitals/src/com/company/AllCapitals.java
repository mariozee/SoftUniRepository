package com.company;

import java.io.*;
import java.util.ArrayList;

public class AllCapitals {

    public static void main(String[] args) {
        String filePath = "Resources/lines.txt";
        File file = new File(filePath);
        BufferedReader reader = null;
        try {
            reader = new BufferedReader(new FileReader(file));
            ArrayList<String> list = new ArrayList<String>();
            String line = reader.readLine();
            boolean willAppend = false;
            while (line != null) {
                list.add(line.toUpperCase());
                line = reader.readLine();
            }

            reader.close();

            FileWriter writer = new FileWriter(file, false);
            for (String s : list) {
                writer.write(String.format("%s\r\n", s));
            }

            writer.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
