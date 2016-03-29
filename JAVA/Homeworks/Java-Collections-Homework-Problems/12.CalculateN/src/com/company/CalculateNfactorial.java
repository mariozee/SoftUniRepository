package com.company;

import java.util.Scanner;

public class CalculateNfactorial {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        long factorial = factorial(n);
        System.out.print(factorial);
    }

    private static long factorial(int n) {
        if (n == 0){
            return 1;
        } else {
            return n * factorial(n - 1);
        }
    }
}
