package com.company;

import java.util.Scanner;

public class LargestSequenceOfEqualNumbers {

    private static int max = 0;
    private static int counter = 0;
    private static String largestSeqElement;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] array = sc.nextLine().split(" ");
        for (int i = 0; i < array.length - 1; i++) {
            if (array[i].equals(array[i + 1])){
                counter++;
            } else {
                counter++;
                checkMax(array[i]);
                counter = 0;
            }
        }

        counter++;
        checkMax(array[array.length - 1]);
        printResult();
    }

    private static void checkMax(String element) {
        if (counter > max){
            max = counter;
            largestSeqElement = element;
        }
    }

    private static void printResult() {
        for (int i = 0; i < max; i++) {
            System.out.print(largestSeqElement + " ");
        }
    }
}
