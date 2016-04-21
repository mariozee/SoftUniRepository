package com.company;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {

    static StringBuilder builder = new StringBuilder();

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        int inputCount = sc.nextInt();
        sc.nextLine();
        String regexIf = "if\\s\\((\\d+)([=><]+)(\\d+)\\)\\s(\\w+)\\s(\\d+)?[\\w+\\s]*\"(.+)\";"; //1,2,3,4,5(numbers), 6
        String regexElse = "else\\s(\\w+)\\s(\\d+)?[\\w+\\s]*\"(.+)\";"; //1, 2(number), 3
        Matcher matcher;
        boolean isCorrect = true;

        for (int i = 1; i <= inputCount; i++) {
            String input = sc.nextLine();
            if (!input.endsWith(";") || !input.contains("\"")){
                System.out.println("Compile time error @ line " + i);
                return;
            }

            if (input.startsWith("if")) {
                matcher = Pattern.compile(regexIf).matcher(input);
                while (matcher.find()) {
                    int num1 = Integer.parseInt(matcher.group(1));
                    int num2 = Integer.parseInt(matcher.group(3));
                    String action = matcher.group(2);

                    int loopCount = 1;
                    if (matcher.group(4).equals("loop")) {
                        loopCount = Integer.parseInt(matcher.group(5));
                    }

                    isCorrect = validate(num1, num2, action);

                    if (isCorrect) {
                        for (int j = 0; j < loopCount; j++) {
                            builder.append(String.format("%s%n", matcher.group(6)));
                        }
                    }
                }
            } else {
                if (!isCorrect){
                    matcher = Pattern.compile(regexElse).matcher(input);
                    while (matcher.find()){
                        int loopCount = 1;
                        if (matcher.group(1).equals("loop")) {
                            loopCount = Integer.parseInt(matcher.group(2));
                        }

                        for (int j = 0; j < loopCount; j++) {
                            builder.append(String.format("%s%n", matcher.group(3)));
                        }
                    }
                }
            }

        }

        System.out.println(builder.toString());
    }

    private static boolean validate(int num1, int num2, String action) {
        switch (action) {
            case "==":
                if (num1 == num2) {
                    return true;
                } else {
                    return false;
                }
            case "<":
                if (num1 < num2) {
                    return true;
                } else {
                    return false;
                }
            case ">":
                if (num1 > num2) {
                    return true;
                } else {
                    return false;
                }
            default:
                return false;
        }
    }
}
