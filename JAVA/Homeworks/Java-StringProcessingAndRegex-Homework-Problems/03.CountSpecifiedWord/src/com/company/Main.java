package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] words = sc.nextLine().split("\\W+");
        String searchedWord = sc.nextLine();
        int counter = 0;
        for (String word : words) {
            if (word.equalsIgnoreCase(searchedWord)){
                counter++;
            }
        }

        System.out.println(counter);
    }
}
