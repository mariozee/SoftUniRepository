package com.company;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class LongestIncreasingSequnece {
    private static int startIndex = 0;
    private static int endIndex = 0;
    private static int maxLenght = 0;
    private static int bestStartIndex;
    private static int bestEndIndex;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] numbers = sc.nextLine().split(" ");
        int[] array = new int[numbers.length];
        for (int i = 0; i < array.length; i++) {
            array[i] = Integer.parseInt(numbers[i]);
        }

        for (int i = 0; i < array.length - 1; i++) {
            if (array[i] >= array[i + 1]) {
                endIndex = i;
                printSequence(array);
                checkMaxLenght();
            }
        }

        endIndex = array.length - 1;
        printSequence(array);
        checkMaxLenght();
        printLongestSequence(array);
    }

    private static void printLongestSequence(int[] array) {
        System.out.print("Longest: ");
        for (int i = bestStartIndex; i <= bestEndIndex; i++){
            System.out.print(array[i] + " ");
        }
    }

    private static void printSequence(int[] array) {
        for (int i = startIndex; i <= endIndex; i++) {
            System.out.print(array[i] + " ");
        }

        System.out.println();
    }

    private static void checkMaxLenght() {
        if ((endIndex - startIndex) > maxLenght) {
            maxLenght = endIndex - startIndex;
            bestEndIndex = endIndex;
            bestStartIndex = startIndex;
        }

        startIndex = endIndex + 1;
    }
}
