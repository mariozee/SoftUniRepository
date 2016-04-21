package com.company;

import java.util.Scanner;

public class SoftUniPalatkaConf {

    public static void main(String[] args) {

	    Scanner sc = new Scanner(System.in);
        int peoples = Integer.parseInt(sc.nextLine());
        int end = Integer.parseInt(sc.nextLine());
        int food = 0;
        int beds = 0;

        for (int i = 0; i < end; i++) {
            String[] inputArgs = sc.nextLine().split(" ");

            if (inputArgs[0].equals("tents")){
                int multiplier = Integer.parseInt(inputArgs[1]);
                if (inputArgs[2].equals("normal")){
                    beds += multiplier * 2;
                } else {
                    beds += multiplier * 3;
                }
            } else if (inputArgs[0].equals("food")){
                int multiplier = Integer.parseInt(inputArgs[1]);
                if (inputArgs[2].equals("musaka")){
                    food += multiplier * 2;
                }
            } else {
                int multiplier = Integer.parseInt(inputArgs[1]);
                if (inputArgs[2].equals("single")){
                    beds += multiplier * 1;
                } else if (inputArgs[2].equals("double")){
                    beds += multiplier * 2;
                } else {
                    beds += multiplier * 3;
                }
            }
        }

        if (beds >= peoples){
            System.out.printf("Everyone is happy and sleeping well. Beds left: %d%n"
                    , beds - peoples);
        } else {
            System.out.printf("Some people are freezing cold. Beds needed: %d%n"
                    ,peoples - beds);
        }

        if (food >= peoples){
            System.out.printf("Nobody left hungry. Meals left: %d", food - peoples);
        } else {
            System.out.printf("People are starving. Meals needed: %d", peoples - food);
        }
    }
}