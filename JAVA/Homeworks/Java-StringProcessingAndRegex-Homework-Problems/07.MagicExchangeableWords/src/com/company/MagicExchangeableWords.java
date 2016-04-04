package com.company;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class MagicExchangeableWords {

    private static Map<String, String> mapper = new HashMap<>();

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] words = sc.nextLine().split(" ");
        String[] first = words[0].split("");
        String[] second = words[1].split("");
        boolean areExchangeable = checkExchangeability(first, second);
        System.out.println(areExchangeable);
    }

    private static boolean checkExchangeability(String[] first, String[] second) {
        for (int i = 0; i < first.length; i++) {
            if (!mapper.containsKey(first[i])){
                mapper.put(first[i], second[i]);
            } else {
                if (!mapper.get(first[i]).equals(second[i])){
                    return false;
                }
            }
        }

        return true;
    }
}
