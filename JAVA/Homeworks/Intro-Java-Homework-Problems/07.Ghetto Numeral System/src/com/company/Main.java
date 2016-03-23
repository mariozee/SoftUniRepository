package com.company;

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Main {

    public static void main(String[] args) {

        TreeMap<String, String> mapper = new TreeMap<String, String>();
        mapper.put("0", "Gee");
        mapper.put("1", "Bro");
        mapper.put("2", "Zuz");
        mapper.put("3", "Ma");
        mapper.put("4", "Duh");
        mapper.put("5", "Yo");
        mapper.put("6", "Dis");
        mapper.put("7", "Hood");
        mapper.put("8", "Jam");
        mapper.put("9", "Mack");

        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.next().split("");
        StringBuilder builder = new StringBuilder();
                for (int i = 0; i < input.length; i++) {
            builder.append(mapper.get(input[i]));
        }

        System.out.println(builder.toString());
    }
}
