package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String first = scanner.next();
        String second = scanner.next();

        int result = 0;
        int minLenght = Math.min(first.length(), second.length());
        for (int i = 0; i < minLenght; i++) {
            result += CharacterMultiplier(first.charAt(i), second.charAt(i));
        }

        String longest = first.length() > second.length() ? first : second;
        for (int i = minLenght; i < longest.length(); i++) {
            result += longest.charAt(i);
        }

        System.out.println(result);
    }

    private static int CharacterMultiplier(char ch1, char ch2) {
        int sum = 0;
        sum += (ch1 * ch2);

        return  sum;
    }
}

