package com.company;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class CardFrequencies {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] faces = sc.nextLine().split("\\W+");
        double allCartsNumber = faces.length;
        Map<String, Integer> cardsCount = new LinkedHashMap<>();
        for (int i = 0; i < allCartsNumber; i++) {
            if (!cardsCount.containsKey(faces[i])){
                cardsCount.put(faces[i], 0);
            }

            cardsCount.put(faces[i], cardsCount.get(faces[i]) + 1);
        }

        for (Map.Entry<String,Integer> entry : cardsCount.entrySet()) {
            System.out.println(String.format("%s -> %.2f%s",
                    entry.getKey(),
                    (entry.getValue() / allCartsNumber) * 100,
                    "%"));
        }
    }
}
