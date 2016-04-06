package com.company;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class BasicMarkupLanguage {
    private static int inputCounter = 1;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        Pattern pattern =
                Pattern.compile("<(\\s+)?(\\w+)\\s+\\w+(\\s+)?=(\\s+)?\"(.+?)\"(\\s+\\w+(\\s+)?=(\\s+)?\"(.+?)\")?");
        while (!input.equals("<stop/>")) {
            Matcher regex = pattern.matcher(input);
            while (regex.find()) {
                String command = regex.group(2);
                if (command.equals("inverse")) {
                    inverse(regex.group(5));
                } else if (command.equals("reverse")){
                    reverse(regex.group(5));
                } else {
                    repeat(regex.group(5), regex.group(9));
                }
            }

            input = sc.nextLine();
        }
    }

    private static void repeat(String repeats, String content) {

        int reps = Integer.parseInt(repeats);
        for (int i = 0; i < reps; i++) {
            System.out.printf("%d. %s%n", inputCounter, content);
            inputCounter++;
        }
    }

    private static void reverse(String content) {
        String reversedContent = new StringBuffer(content).reverse().toString();
        System.out.printf("%d. %s%n", inputCounter, reversedContent);
        inputCounter++;
    }

    private static void inverse(String content) {
        char[] array = content.toCharArray();
        StringBuilder contentBuilder = new StringBuilder();
        for (char ch : array) {
            if (Character.isLowerCase(ch)){
                contentBuilder.append(Character.toUpperCase(ch));
            } else {
                contentBuilder.append(Character.toLowerCase(ch));
            }
        }

        System.out.printf("%d. %s%n", inputCounter, contentBuilder.toString());
        inputCounter++;
    }
}
