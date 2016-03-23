package com.company;

import jdk.nashorn.internal.ir.WhileNode;

import java.io.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CountCharactersTypes {

    public static void main(String[] args) {

        File file = new File("Resources/words.txt");
        StringBuilder sb = new StringBuilder();
        try {
            BufferedReader reader = new BufferedReader(new FileReader(file));
            String line = reader.readLine();
            while (line != null) {
                sb.append(line);
                line = reader.readLine();
            }

            reader.close();

            String text = sb.toString();
            Pattern p = Pattern.compile("([bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ])?([aueioAUEIO])?([.?,!])?");
            Matcher m = p.matcher(text);

            int consonants = 0;
            int vowels = 0;
            int punctuation = 0;
            while (m.find()) {
                if (m.group(1) != null) {
                    consonants++;
                }
                if (m.group(2) != null) {
                    vowels++;
                }
                if (m.group(3) != null) {
                    punctuation++;
                }
            }
            FileWriter writer = new FileWriter("Resources/count-chars.txt", true);
            writer.write(String.format("Vowels: %d\r\nConsonants: %d\r\nPunctuation: %d\r\n",
                    vowels, consonants, punctuation));
            writer.close();

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
