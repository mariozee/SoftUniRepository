package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int m = scanner.nextInt();
        if (m > n) {
            int z = n;
            n = m;
            m = z;
        }
        List<Integer> numbers = new ArrayList<Integer>();
        for (int i = m; i <= n; i++) {
            numbers.add(i);
        }

        Collections.shuffle(numbers);
        for (int number:
             numbers) {
            System.out.print(number + " ");
        }
    }
}
