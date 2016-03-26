package com.company;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
	    Scanner scanner = new Scanner(System.in);
        List<String> digits = Arrays.asList(scanner.next().split(""));
        Collections.reverse(digits);

        int baseSevenNumber = 0;
        for (int i = 0; i < digits.size(); i++) {
            int number = Integer.parseInt(digits.get(i));
            baseSevenNumber += (number * Math.pow(7, i));
        }

        System.out.println(baseSevenNumber);
    }
}
