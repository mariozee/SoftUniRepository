package com.company;

import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

public class DragonTrap {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        String[][] matrix = new String[n][];
        for (int i = 0; i < n; i++) {
            matrix[i] = sc.nextLine().split("");
        }

        String[][] matrixCopy = matrix;
        //checkMatrix(matrix, n);

        List<String> elements = new LinkedList<>();
        String[] commandArgs = sc.nextLine().split("[\\(\\)\\s]+");
        while (!commandArgs[0].equals("End")) {
            int rowCenter = Integer.parseInt(commandArgs[1]);
            int colCenter = Integer.parseInt(commandArgs[2]);
            int radius = Integer.parseInt(commandArgs[3]);
            int rotations = Integer.parseInt(commandArgs[4]);

            int maxRow = rowCenter + radius;
            int minRow = rowCenter - radius;
            int maxCol = colCenter + radius;
            int minCol = colCenter - radius;

            String temp = "";
            for (int i = minCol; i <= maxCol; i++) {
                try {
                    elements.add(matrix[minRow][i]);
                } catch (IndexOutOfBoundsException e) {
                    continue;
                }
            }

            for (int i = minRow + 1; i <= maxRow; i++) {
                try {
                    elements.add(matrix[i][maxCol]);
                } catch (IndexOutOfBoundsException e){
                    continue;
                }
            }

            for (int i = maxCol - 1; i >= minCol; i--) {
                try {
                    elements.add(matrix[maxRow][i]);
                } catch (IndexOutOfBoundsException e){
                    continue;
                }
            }

            for (int i = maxRow - 1; i >= minRow + 1; i--) {
                try {
                    elements.add(matrix[i][minCol]);
                } catch (IndexOutOfBoundsException e) {
                    continue;
                }
            }
        }
    }



    private static void checkMatrix(String[][] matrix, int n) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                System.out.print(matrix[i][j]);
            }
            System.out.println();
        }
    }
}
