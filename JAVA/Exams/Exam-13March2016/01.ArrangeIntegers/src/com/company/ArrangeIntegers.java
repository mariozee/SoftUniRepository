package com.company;

import java.util.*;

public class ArrangeIntegers {
    private static Map<String, ArrayList<String>> mapper = new TreeMap<>();

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] numbers = sc.nextLine().split("\\W+");
        initializeMap(numbers);
    }

    private static void initializeMap(String[] numbers) {
        for (int i = 0; i < numbers.length; i++){
            StringBuilder builder = new StringBuilder();
            String[] currentNum = numbers[i].split("");
            for (int j = 0; j < currentNum.length; j++) {
                switch (currentNum[j]){
                    case "0":
                        builder.append("zero");
                        break;
                    case "1":
                        builder.append("one");
                        break;
                    case "2":
                        builder.append("two");
                        break;
                    case "3":
                        builder.append("three");
                        break;
                    case "4":
                        builder.append("four");
                        break;
                    case "5":
                        builder.append("five");
                        break;
                    case "6":
                        builder.append("six");
                        break;
                    case "7":
                        builder.append("seven");
                        break;
                    case "8":
                        builder.append("eight");
                        break;
                    case "9":
                        builder.append("nine");
                        break;
                }
            }

            if (!mapper.containsKey(builder.toString())){
                mapper.put(builder.toString(), new ArrayList<String>());
            }

            mapper.get(builder.toString()).add(numbers[i]);

        }

        StringBuilder outputBuilder = new StringBuilder();
        for (Map.Entry<String, ArrayList<String>> strings : mapper.entrySet()) {
            for (String string : strings.getValue()) {
                outputBuilder.append(string + ", ");
            }
        }

        System.out.println(outputBuilder.toString()
                .substring(0, outputBuilder.length() - 2));
    }
}
