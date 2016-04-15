package com.company;

import java.util.*;

public class LegendaryFarming {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Map<String,Integer> materialsQunatity = new TreeMap<>();
        materialsQunatity.put("shards", 0);
        materialsQunatity.put("fragments", 0);
        materialsQunatity.put("motes", 0);

        Map<String, String> legendaryMap = new HashMap<>();
        legendaryMap.put("shards", "Shadowmourne");
        legendaryMap.put("fragments", "Valanyr");
        legendaryMap.put("motes", "Dragonwrath");

        while (true){
            String input = sc.nextLine().toLowerCase();
            String[] pairs = input.split(" ");
            for (int i = 1; i < pairs.length; i+=2) {
                String material = pairs[i];
                int quantity = Integer.parseInt(pairs[i - 1]);
                if (!materialsQunatity.containsKey(material)){
                    materialsQunatity.put(material, 0);
                }

                materialsQunatity.put(material, materialsQunatity.get(material) + quantity);

                if (materialsQunatity.get(material) >= 250
                        && (material.equals("shards")
                        || material.equals("fragments")
                        || material.equals("motes"))){

                    System.out.printf("%s obtained!%n", legendaryMap.get(material));
                    materialsQunatity.put(material, materialsQunatity.get(material) - 250);
                    printOutput(materialsQunatity);
                    return;
                }
            }
        }
    }

    private static void printOutput(Map<String, Integer> materialsQunatity) {
        materialsQunatity
                .entrySet()
                .stream()
                .filter(e -> e.getKey().equals("shards")
                          || e.getKey().equals("fragments")
                          || e.getKey().equals("motes"))
                .sorted((v1, v2) -> v2.getValue().compareTo(v1.getValue()))
                .forEach(e -> System.out.printf("%s: %d%n", e.getKey(), e.getValue()));

        materialsQunatity
                .entrySet()
                .stream()
                .filter(e -> !e.getKey().equals("shards")
                          && !e.getKey().equals("fragments")
                          && !e.getKey().equals("motes"))
                .forEach(e -> System.out.printf("%s: %d%n", e.getKey(), e.getValue()));
    }
}