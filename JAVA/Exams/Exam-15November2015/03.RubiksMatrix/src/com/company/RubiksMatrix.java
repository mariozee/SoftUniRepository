package com.company;

import java.util.Scanner;

public class RubiksMatrix {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int r = sc.nextInt();
        int c = sc.nextInt();
        int value = 1;
        int[][] rubikMatrix = new int[r][c];
        for (int i = 0; i < r; i++) {
            for (int j = 0; j < c; j++) {
                rubikMatrix[i][j] = value++;
            }
        }

        sc.nextLine();
        int n = sc.nextInt();
        sc.nextLine();
        String command = "";
        for (int i = 0; i < n; i++) {
            command = sc.nextLine();
            String[] commandArgs = command.split(" ");
            shuffle(commandArgs, rubikMatrix, r, c);
        }

        rearrange(rubikMatrix);
    }

    private static void shuffle(String[] commandArgs, int[][] rubikMatrix, int r, int c) {

        int moves = Integer.parseInt(commandArgs[2]) % c;
        String direction = commandArgs[1];

        if (direction.equals("up") || direction.equals("down")) {
            int col = Integer.parseInt(commandArgs[0]);

            for (int i = 0; i < moves; i++) {
                if (direction.equals("up")){
                    int temp = rubikMatrix[0][col];
                    for (int j = 0; j < r - 1; j++) {
                        rubikMatrix[j][col] = rubikMatrix[j + 1][col];
                    }
                    rubikMatrix[r - 1][col] = temp;
                } else {
                    int temp = rubikMatrix[r - 1][col];
                    for (int j = r - 1; j > 0; j--) {
                        rubikMatrix[j][col] = rubikMatrix[j - 1][col];
                    }
                    rubikMatrix[0][col] = temp;
                }
            }
        } else {
            int row = Integer.parseInt(commandArgs[0]);

            for (int i = 0; i < moves; i++) {
                if (direction.equals("left")){
                    int temp = rubikMatrix[row][0];
                    for (int j = 0; j < c - 1; j++) {
                        rubikMatrix[row][j] = rubikMatrix[row][j + 1];
                    }
                    rubikMatrix[row][c - 1] = temp;
                } else {
                    int temp = rubikMatrix[row][c - 1];
                    for (int j = c - 1; j > 0; j--) {
                        rubikMatrix[row][j] = rubikMatrix[row][j - 1];
                    }
                    rubikMatrix[row][0] = temp;
                }
            }
        }

    }

    private static void rearrange(int[][] rubikMatrix) {

        int value = 1;
        for (int i = 0; i < rubikMatrix.length; i++) {
            for (int j = 0; j < rubikMatrix[0].length; j++) {
                if (rubikMatrix[i][j] != value) {
                    int[] coordinates = findCoordinates(rubikMatrix, value);
                    System.out.printf("Swap (%d, %d) with (%d, %d)%n", i, j, coordinates[0], coordinates[1]);
                    rubikMatrix[coordinates[0]][coordinates[1]] = rubikMatrix[i][j];
                    rubikMatrix[i][j] = value;
                    value++;
                } else {
                    System.out.println("No swap required");
                    value++;
                }
            }
        }
    }

    private static int[] findCoordinates(int[][] rubikMatrix, int value) {
        for (int i = 0; i < rubikMatrix.length; i++) {
            for (int j = 0; j < rubikMatrix[0].length; j++) {
                if (rubikMatrix[i][j] == value) {
                    return new int[]{i, j};
                }
            }
        }
        return new int[]{-1, -1};
    }
}