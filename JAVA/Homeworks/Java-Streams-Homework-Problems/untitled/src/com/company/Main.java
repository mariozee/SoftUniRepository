package com.company;

import com.sun.org.apache.bcel.internal.generic.IF_ACMPEQ;

import javax.script.ScriptContext;
import java.util.*;

public class Main {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        String[] commands = scanner.nextLine().split(" ");
        List<Integer> numbers = new ArrayList<Integer>();

        for (int i = 0; i < input.length; i++) {
            numbers.add(Integer.parseInt(input[i]));
        }


        System.out.println(getEvenOrOdd(numbers, commands));

    }

    public static List getEvenOrOdd(List<Integer> numbers, String[] commands) {
        int n = Integer.parseInt(commands[1]);
        List<Integer> results = new ArrayList<>();

        if (commands[2].equals("odd")) {

            for (int i = 0; i <= n; i++) {

                if (numbers.get(i) % 2 != 0) {
                    results.add(numbers.indexOf(i));
                } else {
                    continue;
                }
            }
        } else if (commands[2].equals("even")) {

            for (int i = 0; i <= n; i++) {

                if (numbers.indexOf(i) % 2 == 0) {

                    results.add(numbers.indexOf(i));
                } else {
                    continue;
                }
            }
        }

        return results;
    }

}


