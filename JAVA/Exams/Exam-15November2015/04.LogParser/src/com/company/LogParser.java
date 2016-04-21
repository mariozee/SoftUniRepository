package com.company;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class LogParser {

    static Map<String, Integer> projectErrors = new TreeMap<>();
    static Map<String, ArrayList<String>> criticalMessages = new HashMap<>();
    static Map<String, ArrayList<String>> warningMessages = new HashMap<>();
    static int iterationsCount = 0;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String regex = "\"Project\":\\s\\[\"(.+)\"\\],\\s\"Type\":\\s\\[\"(.+)\"\\],\\s\"Message\":\\s\\[\"(.+)\"\\]";

        String input = sc.nextLine();
        while (!input.equals("END")) {
            Matcher matcher = Pattern.compile(regex).matcher(input);
            while (matcher.find()) {
                String projectName = matcher.group(1);
                String errorType = matcher.group(2);
                String message = matcher.group(3);

                if (!projectErrors.containsKey(projectName)){
                    projectErrors.put(projectName, 0);
                }

                projectErrors.put(projectName, projectErrors.get(projectName) + 1);

                if (errorType.equals("Critical")){
                    if (!criticalMessages.containsKey(projectName)){
                        criticalMessages.put(projectName, new ArrayList<>());
                    }

                    criticalMessages.get(projectName).add(message);
                } else {
                    if (!warningMessages.containsKey(projectName)){
                        warningMessages.put(projectName, new ArrayList<>());
                    }

                    warningMessages.get(projectName).add(message);
                }
            }

            input = sc.nextLine();
        }
        projectErrors.entrySet().stream()
                .sorted((x, y) -> y.getValue().compareTo(x.getValue())).forEach(e -> {
            iterationsCount++;
            if (iterationsCount > 1){
                System.out.println();
            }

            System.out.println(e.getKey() + ":");
            System.out.println("Total Errors: " + e.getValue());
            System.out.printf("Critical: %d%n",
                    criticalMessages.containsKey(e.getKey()) ? criticalMessages.get(e.getKey()).size() : 0);
            System.out.printf("Warnings: %d%n",
                    warningMessages.containsKey(e.getKey()) ? warningMessages.get(e.getKey()).size() : 0);
            System.out.println("Critical Messages:");
            if (criticalMessages.containsKey(e.getKey())){
                criticalMessages.get(e.getKey()).stream()
                        .sorted((x, y) -> x.compareTo(y))
                        .sorted((x, y) -> x.length() - y.length())
                        .forEach(s -> {
                            System.out.println("--->" + s);
                        });
            } else {
                System.out.println("--->None");
            }
            System.out.println("Warning Messages:");
            if (warningMessages.containsKey(e.getKey())){
                warningMessages.get(e.getKey()).stream()
                        .sorted((x, y) -> x.compareTo(y))
                        .sorted((x, y) -> x.length() - y.length())
                        .forEach(s -> {
                            System.out.println("--->" + s);
                        });
            } else {
                System.out.println("--->None");
            }
        });
    }
}
