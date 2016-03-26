package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
	    Scanner scanner = new Scanner(System.in);
        double a = scanner.nextDouble();
        double b = scanner.nextDouble();
        double c = scanner.nextDouble();

        double formulaOne = (a * a + b * b) / (a * a - b * b);
        formulaOne = Math.pow(formulaOne, (a + b + c) / Math.sqrt(c));
        double formulaTwo = Math.pow(a * a + b * b - c * c * c, (a - b));
        double threeNumbersAvg = (a + b + c) / 3;
        double formulasAvg = (formulaOne + formulaTwo) / 2;
        double diff = Math.abs(threeNumbersAvg - formulasAvg);

        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f", formulaOne, formulaTwo, diff);
    }
}
