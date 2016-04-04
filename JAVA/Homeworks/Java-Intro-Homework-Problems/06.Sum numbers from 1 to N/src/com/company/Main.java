package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = scanner.nextInt();

        number = ((number + 1) * number) / 2;
        System.out.println(number);
    }
}
