package com.company;

import java.util.LinkedList;
import java.util.Scanner;
import java.util.jar.Pack200;

public class Main {

    static int[] a = new int[2];
    static int[] b = new int[2];
    static int[] c = new int[2];
    static int[] d = new int[2];
    static int largestArea = 0;

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        String line = sc.nextLine();
        LinkedList<String> lines = new LinkedList<>();
        while (!line.equals("END")){
            lines.add(line);
            line = sc.nextLine();
        }

        String[][] matrix = new String[lines.size()][];
        for (int i = 0; i < lines.size(); i++) {
            matrix[i] = lines.get(i).split(",");
        }

        String element = "";
        boolean isPointA = true;
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                if (isPointA) {
                    a[0] = i;
                    a[1] = j;
                    element = matrix[i][j];
                    isPointA = false;
                }

                if (!element.equals(matrix[i][j])
                        || (element.equals(matrix[i][j]) && j == matrix[0].length - 1)){

                    int currentCol = 0;
                    if (!element.equals(matrix[i][j])) {
                        currentCol = Math.max(j - 1, 0);
                        b[0] = i;
                        b[1] = currentCol;
                    } else {
                        currentCol = j;
                        b[0] = i;
                        b[1] = currentCol;
                    }

                    for (int k = i; k < matrix.length ; k++) {
                        if (!element.equals(matrix[k][currentCol])
                                || (element.equals(matrix[k][currentCol]) && k == matrix.length - 1)){

                            int currentRow = 0;
                            if (!element.equals(matrix[k][currentCol])){
                                currentRow = Math.max(k - 1, 0);
                                c[0] = currentRow;
                                c[1] = currentCol;
                            } else {
                                currentRow = k;
                                c[0] = currentRow;
                                c[1] = currentCol;
                            }

                            for (int l = currentCol; l >= 0; l--) {
                                if (!element.equals(matrix[currentRow][l])
                                        || (element.equals(matrix[currentRow][currentCol]) && l == 0)){

                                    currentCol = 0;
                                    if (!element.equals(matrix[currentRow][l])){
                                        currentCol = Math.min(matrix[0].length - 1, l + 1);
                                        d[0] = currentRow;
                                        d[1] = currentCol;
                                    } else {
                                        currentCol = l;
                                        d[0] = currentRow;
                                        d[1] = currentCol;
                                    }

                                    for (int m = currentRow; m >= 0 ; m++) {
                                        if (m == a[0] && currentCol)
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
