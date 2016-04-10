package com.company;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WeirdScript {

    public static void main(String[] args) {
       Scanner sc = new Scanner(System.in);
        int keyNumber = sc.nextInt();
        sc.nextLine();
        int index = (keyNumber - 1) / 26;
        int increeser = index % 2 == 0 ? 97 : 65;
        int asciiCode = ((keyNumber - 1) % 26) + increeser;
        char ch = (char)(asciiCode);
        String key = ch + "" + ch;
        StringBuilder builder = new StringBuilder();
        String input = sc.nextLine();
        while (!input.equals("End")){
            builder.append(input);
            input = sc.nextLine();
        }

        String regex = String.format("%s(.*?)%s", key, key);
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(builder.toString());
        while (matcher.find()){
            if (!matcher.group(1).equals("\\s+")){
                System.out.println(matcher.group(1));
            }
        }
    }
}
