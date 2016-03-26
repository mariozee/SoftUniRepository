package com.company;

import java.util.Random;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] line = scanner.nextLine().split(" ");

        for (int i = 0; i < line.length - 1; i += 2) {
            if (line.length % 2 != 0) {
                System.out.println("Invalid lenght");
                break;
            }

            int num1 = Integer.parseInt(line[i]);
            int num2 = Integer.parseInt(line[i + 1]);
            printPairInfo(num1, num2);
            System.out.println();
        }

        Random rnd = new Random();
    }

    private static void printPairInfo(int num1, int num2) {
        if (num1 % 2 == 0 && num2 % 2 == 0) {
            System.out.printf("%d, %d -> both are even", num1, num2);
        } else if (num1 % 2 == 1 && num2 % 2 == 1) {
            System.out.printf("%d, %d -> both are odd", num1, num2);
        } else {
            System.out.printf("%d, %d -> different", num1, num2);
        }
    }
}
