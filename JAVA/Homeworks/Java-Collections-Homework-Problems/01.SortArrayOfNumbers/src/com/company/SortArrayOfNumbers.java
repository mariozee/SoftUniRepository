package com.company;

import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class SortArrayOfNumbers {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        String[] numbers = sc.nextLine().split(" ");
        int[] array = new int[n];
        for (int i = 0; i < numbers.length; i++) {
            array[i] = Integer.parseInt(numbers[i]);
        }

        Arrays.sort(array);
        String result = Arrays.toString(array).replaceAll("[\\[,\\]]", "");
        System.out.println(result);
    }
}
