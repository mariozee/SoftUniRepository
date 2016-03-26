package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int a = scanner.nextInt();
        double b = scanner.nextDouble();
        double c = scanner.nextDouble();

        String hexaA = Integer.toHexString(a);
        String binA = Integer.toBinaryString(a);

        String output = String.format("|%-10S|%010d|%10.2f|%10.3f|", hexaA, Integer.parseInt(binA), b, c);
        System.out.println(output);
    }
}
