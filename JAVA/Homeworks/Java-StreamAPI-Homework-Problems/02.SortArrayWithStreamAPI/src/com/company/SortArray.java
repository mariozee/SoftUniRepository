package com.company;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class SortArray {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] array = sc.nextLine().split(" ");
        String order = sc.nextLine();
        if (order.equals("Ascending")){
            Arrays.stream(array).sorted().forEach(x -> System.out.print(x + " "));
        } else {
            Arrays.stream(array).sorted((x, y) -> y.compareTo(x)).forEach(x -> System.out.print(x + " "));
        }
    }
}
