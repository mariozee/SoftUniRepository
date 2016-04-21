package com.coqmpany;

import java.awt.*;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class SoftUniDefenseSystem {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String input = sc.nextLine();
        String regex = "([A-Z][a-z]+).*?([A-Z][a-z]*[A-Z]).*?([0-9]+)L";
        double softUniLiters = 0;
        while (!input.equals("OK KoftiShans")){
            Matcher matcher = Pattern.compile(regex).matcher(input);
            while (matcher.find()){
                System.out.printf("%s brought %s liters of %s!%n"
                        , matcher.group(1), matcher.group(3), matcher.group(2).toLowerCase());
                softUniLiters += Integer.parseInt(matcher.group(3));
            }

            input = sc.nextLine();
        }

        System.out.printf("%.3f softuni liters", softUniLiters / 1000);
    }
}
