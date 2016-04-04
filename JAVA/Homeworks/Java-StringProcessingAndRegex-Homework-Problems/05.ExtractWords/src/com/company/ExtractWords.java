package com.company;

import org.omg.PortableInterceptor.SYSTEM_EXCEPTION;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ExtractWords {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();
        String regex = "([a-zA-Z]+)";
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(text);
        while (matcher.find()){
            System.out.print(matcher.group(1) + " ");
        }
    }
}
