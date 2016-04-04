package com.company;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class FilterArray {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] array = sc.nextLine().split(" ");
        array = Arrays.stream(array).filter(word -> word.length() > 3).toArray(arrSize -> new String[arrSize]);
        if (array.length == 0){
            System.out.print("(empty)");
        }
        for (String s : array) {

            System.out.print(s + " ");
        }
    }
}
