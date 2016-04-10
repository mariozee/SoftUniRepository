package com.company;

import java.util.Scanner;

public class TinySporebat {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        char[] enemies;
        int health = 5800;
        int totalGlowcaps = 0;
        while (!input.equals("Sporeggar")) {
            enemies = input.toCharArray();
            int glowcaps = enemies[enemies.length - 1] - 48;
            for (int i = 0; i < enemies.length - 1; i++) {
                if (enemies[i] == 'L'){
                    health += 200;
                } else {
                    health -= enemies[i];
                }

                if (health <= 0){
                    System.out.println("Died. Glowcaps: " + totalGlowcaps);
                    return;
                }
            }

            totalGlowcaps += glowcaps;

            input = sc.nextLine();
        }

        if (totalGlowcaps >= 30){
            System.out.printf("Health left: %d%nBought the sporebat. " +
                    "Glowcaps left: %d%n", health, totalGlowcaps - 30);
        } else {
            System.out.printf("Health left: %d%n" +
                    "Safe in Sporeggar, but another %d Glowcaps needed.%n", health, 30 - totalGlowcaps);
        }
    }
}