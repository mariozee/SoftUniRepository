package com.company;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class MostFrequentWord {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] words = sc.nextLine().toLowerCase().split("\\W+");
        Map<String, Integer> wordsMap = new TreeMap<>();
        for (int i = 0; i < words.length; i++) {
            if (!wordsMap.containsKey(words[i])){
                wordsMap.put(words[i], 0);
            }

            wordsMap.put(words[i], wordsMap.get(words[i]) + 1);
        }

        int maxFrequent = wordsMap
                .entrySet()
                .stream()
                .max((x, y) -> x.getValue().compareTo(y.getValue()))
                .get()
                .getValue();

        for (Map.Entry<String,Integer> entry : wordsMap.entrySet()) {
            if (entry.getValue() == maxFrequent){
                System.out.println(entry.getKey() + " -> " + entry.getValue() + " times");
            }
        }
    }
}
