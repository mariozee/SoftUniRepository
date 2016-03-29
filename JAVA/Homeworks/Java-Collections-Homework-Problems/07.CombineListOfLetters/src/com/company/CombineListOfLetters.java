package com.company;

import com.sun.xml.internal.fastinfoset.util.CharArray;
import com.sun.xml.internal.ws.commons.xmlutil.Converter;

import javax.xml.stream.events.Characters;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class CombineListOfLetters {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        char[] arr1 = sc.nextLine().replace(" ", "").toCharArray();
        char[] arr2 = sc.nextLine().replace(" ", "").toCharArray();
        ArrayList<Character> list1 = new ArrayList<Character>();
        ArrayList<Character> list2 = new ArrayList<Character>();
        list1 = initializeList(list1, arr1);
        list2 = initializeList(list2, arr2);
        //Copy "list1" to new list - "result"
        ArrayList<Character> result = new ArrayList<Character>(list1);
        for (Character ch : list2) {
            if (!list1.contains(ch)){
                result.add(ch);
            }
        }
        //In .replaceAll method the regex removes all "[", "," and "]" from original .toString method
        System.out.print(result.toString().replaceAll("[\\[,\\]]", ""));
    }

    private static ArrayList<Character> initializeList(ArrayList<Character> list, char[] arr) {
        for (Character c : arr) {
            list.add(c);
        }

        return list;
    }
}
