package com.company;

import java.util.Scanner;
import java.util.regex.Pattern;

public class ExtractEmails {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();
        String regex =
                "(?<!\\S)((?:[a-zA-Z0-9]+[.\\-\\_]?){0,3}[a-zA-Z0-9]+@(?:[a-zA-Z0-9]+[\\.\\-\\_]?){0,3}\\.[a-z]+)[.,]?(?!\\S)";
        Pattern pattern = Pattern.compile(regex);
        java.util.regex.Matcher matcher = pattern.matcher(text);
        while (matcher.find()){
            System.out.println(matcher.group(1));
        }
    }
}

