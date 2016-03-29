package com.company;

import java.util.Scanner;

public class RecursiveBinarySearch {
    private static int currentIndex = 0;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int element = Integer.parseInt(sc.nextLine());
        String[] array = sc.nextLine().split(" ");
        int[] numbers = new int[array.length];
        for (int i = 0; i < array.length; i++) {
            numbers[i] = Integer.parseInt(array[i]);
        }

        int index = indexOf(element, numbers, 0, numbers.length - 1);
        System.out.print(index);
    }

    private static int indexOf(int element, int[] numbers, int startIndex, int lastIndex) {
        if  (lastIndex - startIndex <= 1){
            if (numbers[startIndex] == element){
                return startIndex;
            }
            if (numbers[lastIndex] == element){
                return lastIndex;
            }

            return  -1;
        }
        int midlleIndex = (lastIndex + startIndex) / 2;
        if (numbers[midlleIndex] > element){
            return indexOf(element, numbers, 0, midlleIndex);
        } else {
            return indexOf(element, numbers, midlleIndex, lastIndex);
        }
    }
}
