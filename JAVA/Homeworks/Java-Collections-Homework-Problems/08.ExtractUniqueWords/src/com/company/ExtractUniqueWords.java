package com.company;

import java.util.Arrays;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class ExtractUniqueWords {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] textArgs = sc.nextLine().toLowerCase().split("\\W+");
        Set<String> set = new TreeSet<>(Arrays.asList(textArgs));
        System.out.print(set.toString().replaceAll("[\\[,\\]]", ""));
    }
}
