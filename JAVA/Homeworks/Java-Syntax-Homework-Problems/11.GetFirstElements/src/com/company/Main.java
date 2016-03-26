package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] numbers = scanner.nextLine().split(" ");
        String[] commands = scanner.nextLine().split(" ");

        int numbersToGet = Integer.parseInt(commands[1]);
        int divideResult = commands[2].equals("odd") ? 1 : 0;

        PrintNumbers(numbers, numbersToGet, divideResult);
    }

    private static void PrintNumbers(String[] numbers, int n, int divideResult) {
        int numbersToGet = n;
        for (int i = 0; i < numbers.length; i++) {
            if (numbersToGet == 0) {
                break;
            }

            if (Integer.parseInt(numbers[i]) % 2 == divideResult) {
                System.out.print(numbers[i] + " ");
                numbersToGet--;
            }
        }
    }
}