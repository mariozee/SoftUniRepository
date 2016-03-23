package com.company;

import com.sun.javafx.binding.StringFormatter;

import java.io.Serializable;

/**
 * Created by Zisov4eto on 23-Mar-16.
 */
public class Course implements Serializable{
    private String name;
    private int studensNumber;

    public Course(String name, int studentsNumber){
        this.name = name;
        this.studensNumber = studentsNumber;
    }

    public String toString(){
        String result = String.format("Course: %s\r\nStudent count: %d", this.name, this.studensNumber);
        return result;
    }
}
