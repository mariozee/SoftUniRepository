package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int decimalNumber = scanner.nextInt();
        int quitient = 1;
        int remainder = 0;
        int result = 0;
        int multiplier = 1;
        while (decimalNumber != 0){
            quitient = decimalNumber / 7;
            remainder = decimalNumber % 7;
            result += remainder * multiplier;
            decimalNumber = quitient;
            multiplier *= 10;
        }

        System.out.println(result);
    }
}
