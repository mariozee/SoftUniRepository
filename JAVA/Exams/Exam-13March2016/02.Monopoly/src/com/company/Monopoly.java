package com.company;

import java.util.Scanner;

public class Monopoly {

    private static int money = 50;
    private static int turns;
    private static int hotelsCount = 0;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = sc.nextInt();
        int columns = sc.nextInt();
        sc.nextLine();
        for (int i = 0; i < rows; i++) {
            String[] currenRow = sc.nextLine().split("");
            if (i % 2 == 0){
                for (int j = 0; j < columns; j++) {

                    money += hotelsCount * 10;
                    update(currenRow[j], i, j);
                    turns++;
                }
            } else {
                for (int j = columns - 1; j >= 0; j--) {

                    money += hotelsCount * 10;
                    update(currenRow[j], i, j);
                    turns++;
                }
            }
        }
        money += hotelsCount * 10;
        System.out.println("Turns " + turns);
        System.out.println("Money " + money);
    }

    private static void update(String object, int row, int col) {
        if (object.equals("H")){
            String message = "Bought a hotel for " + money + ". ";
            money = 0;
            hotelsCount++;
            message += "Total hotels: " + hotelsCount + ".";
            System.out.println(message);
        } else if (object.equals("J")){
            System.out.println("Gone to jail at turn " + turns + ".");
            money += hotelsCount * 20;
            turns += 2;
        } else if (object.equals("S")){
            int moneyToSpend = (row + 1) * (col + 1);
            if (money < moneyToSpend){
                System.out.println("Spent " + money + " money at the shop.");
                money = 0;
            } else {
                System.out.println("Spent " + moneyToSpend + " money at the shop.");
                money -= moneyToSpend;
            }
        }
    }
}
