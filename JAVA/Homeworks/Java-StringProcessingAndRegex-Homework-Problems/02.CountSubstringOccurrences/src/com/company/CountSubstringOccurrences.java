package com.company;

import jdk.nashorn.internal.runtime.regexp.joni.Matcher;

import java.util.Scanner;
import java.util.regex.Pattern;

public class CountSubstringOccurrences {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine().toLowerCase();
        String substring = sc.nextLine().toLowerCase();
        int index = text.indexOf(substring);
        int count = 0;
        while (index != -1){
            count++;
            index = text.indexOf(substring, index + 1);
        }

        System.out.println(count);
    }
}
