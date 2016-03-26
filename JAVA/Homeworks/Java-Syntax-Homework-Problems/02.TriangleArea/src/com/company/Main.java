package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
	    Scanner scanner = new Scanner(System.in);
        String[] coordinates = scanner.nextLine().split(" ");
        double coordinateAx = Double.valueOf(coordinates[0]);
        double coordinateAy = Double.valueOf(coordinates[1]);
        coordinates = null;
        coordinates = scanner.nextLine().split(" ");
        double coordinateBx = Double.valueOf(coordinates[0]);
        double coordinateBy = Double.valueOf(coordinates[1]);
        coordinates = null;
        coordinates = scanner.nextLine().split(" ");
        double coordinateCx = Double.valueOf(coordinates[0]);
        double coordinateCy = Double.valueOf(coordinates[1]);

        double area = (coordinateAx * (coordinateBy - coordinateCy) +
                coordinateBx * (coordinateCy - coordinateAy) + coordinateCx * (coordinateAy - coordinateBy)) / 2;

        System.out.println((int)Math.abs(area));
    }
}
