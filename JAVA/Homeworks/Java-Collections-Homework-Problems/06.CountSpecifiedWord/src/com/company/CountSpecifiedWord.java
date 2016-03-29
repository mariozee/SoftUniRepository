package com.company;

import java.util.Arrays;
import java.util.Scanner;

public class CountSpecifiedWord {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] textArgs = sc.nextLine().split("\\W+");
        String seachedWord = sc.nextLine();
        int counter = 0;
        for (String word : textArgs) {
            if (word.equalsIgnoreCase(seachedWord)){
                counter++;
            }
        }

        System.out.print(counter);
    }
}
