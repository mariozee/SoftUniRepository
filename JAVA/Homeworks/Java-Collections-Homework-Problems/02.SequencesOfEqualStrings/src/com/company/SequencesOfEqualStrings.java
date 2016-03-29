package com.company;

import java.util.Scanner;

public class SequencesOfEqualStrings {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] array = sc.nextLine().split(" ");
        for (int i = 0; i < array.length - 1; i++) {
            if (array[i].equals(array[i + 1])){
                System.out.print(array[i] + " ");
            } else {
                System.out.println(array[i]);
            }
        }
        System.out.print(array[array.length - 1]);
    }
}
