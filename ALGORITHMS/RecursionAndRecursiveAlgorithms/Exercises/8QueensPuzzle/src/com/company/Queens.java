package com.company;

public class Queens {

    final static int SIZE = 8;
    static boolean[][] chessboard = new boolean[SIZE][SIZE];

    static boolean[] attackedColumns = new boolean[SIZE];
    static boolean[] attackedLeftDiagonals = new boolean[SIZE * 2 - 1];
    static boolean[] attackedRightDiagonals = new boolean[SIZE * 2 - 1];

    static int solutionFound = 0;

    public static void main(String[] args) {

        putQueens(0);
        System.out.println(solutionFound);
    }

    static void putQueens(int row) {

        if (row == SIZE) {
            printSolution();
        } else {
            for (int col = 0; col < SIZE; col++) {
                if (canPlaceQueen(row, col)) {
                    markAllAttackedPositions(row, col);
                    putQueens(row + 1);
                    unmarkAllAttackedPositions(row, col);
                }
            }
        }
    }

    private static boolean canPlaceQueen(int row, int col) {
        boolean positionOccupied = attackedColumns[col]
                || attackedLeftDiagonals[(col - row) + 7]
                || attackedRightDiagonals[row + col];

        return !positionOccupied;
    }

    private static void markAllAttackedPositions(int row, int col) {

        attackedColumns[col] = true;
        attackedLeftDiagonals[(col - row) + 7] = true;
        attackedRightDiagonals[row + col] = true;
        chessboard[row][col] = true;
    }

    private static void unmarkAllAttackedPositions(int row, int col) {
        attackedColumns[col] = false;
        attackedLeftDiagonals[(col - row) + 7] = false;
        attackedRightDiagonals[row + col] = false;
        chessboard[row][col] = false;
    }

    private static void printSolution() {
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                if (chessboard[i][j]){
                    System.out.print("* ");
                } else {
                    System.out.print("- ");
                }
            }

            System.out.println();
        }

        System.out.println();
        solutionFound++;
    }
}