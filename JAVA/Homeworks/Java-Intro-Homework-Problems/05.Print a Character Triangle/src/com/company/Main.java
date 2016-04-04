package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        char ch = 'a';

        for (int i = 1; i <= n; i++) {

            for (int j = 0; j < i; j++) {
                System.out.print(ch + " ");
                ch++;
            }
            System.out.println();
            ch = 'a';
        }

        for (int i = n - 1; i >= 0; i--) {

            for (int j = 0; j < i; j++) {
                System.out.print(ch + " ");
                ch++;
            }
            System.out.println();
            ch = 'a';
        }
    }
}

