package com.company;

import java.io.*;
import java.util.*;

public class CSVDatabase {

    public static BufferedReader reader;
    public static FileWriter writer;
    public static HashMap<String, String> studentsInfoData = new HashMap<>();
    public static HashMap<Integer, HashMap<String, ArrayList<String>>> idGradesData = new HashMap<>();
    public static HashMap<Integer, String> idStudentData = new HashMap<>();

    public static void main(String[] args) throws IOException {
        String studentsPath = "students.txt";
        String graesPath = "grades.txt";
        File studetnsFile = new File(studentsPath);
        File gradesFile = new File(graesPath);
        try {
            reader = new BufferedReader(new FileReader(studetnsFile));
            String lineOfStudents = reader.readLine();
            while (lineOfStudents != null) {
                initStudentsInfoData(lineOfStudents);
                lineOfStudents = reader.readLine();
            }

            reader.close();

            reader = new BufferedReader(new FileReader(gradesFile));
            String lineOfGrades = reader.readLine();
            while (lineOfGrades != null) {
                initStudentsGradeData(lineOfGrades);
                lineOfGrades = reader.readLine();
            }

            reader.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        String command = "";
        Scanner sc = new Scanner(System.in);
        while (command != "exit") {
            command = sc.nextLine();
            String message = CommandDispatcher(command);
            System.out.println(message);
        }
    }

    private static String CommandDispatcher(String command) throws IOException {

        String actionName = command.split(" ")[0];
        int id;
        switch (actionName) {
            case "Search-by-full-name":
                String fullName = command.split(" ")[1] + " " + command.split(" ")[2];
                return searchByName(fullName);
            case "Search-by-id":
                id = Integer.parseInt(command.split(" ")[1]);
                return searchById(id);
            case "Delete-by-id":
                id = Integer.parseInt(command.split(" ")[1]);
                return deleteById(id);
            case "Update-by-id":
                return updateById();
            case "Insert-student":
                String studentsDetails = command.substring(15);
                return insertStudent(studentsDetails);
            case "Insert-grade-by-id":
                String detatails = command.substring(19);
                return insertGradeById(detatails);
                default:
                    return "Invalid Command";
        }


    }

    private static String insertGradeById(String detatails) throws IOException {

        String[] detailsArgs = detatails.split(" ");
        int id = Integer.parseInt(detailsArgs[0]);
        String subject = detailsArgs[1];
        String grade = detailsArgs[2];

        if (!idGradesData.containsKey(id)){
            return "Student does not exist";
        }

        if (!idGradesData.get(id).containsKey(subject)){
            idGradesData.get(id).put(subject, new ArrayList<String>());
        }

        idGradesData.get(id).get(subject).add(grade);

        writer = new FileWriter("grades.txt", false);
        String gradesInfo;
        for (Integer integer : idGradesData.keySet()) {
            gradesInfo = integer.toString();
            for (String sub : idGradesData.get(integer).keySet()) {
                gradesInfo += "," + sub + " ";
                gradesInfo += String.join(" ", idGradesData.get(integer).get(sub));
            }
            writer.write(gradesInfo + "\r\n");
        }

        writer.close();

        return String.format("Current grade has been inserted to Student with ID: %d", id);
    }

    private static String insertStudent(String details) throws IOException {

        String[] detailsArgs = details.split(" ");
        int newId = Collections.max(idStudentData.keySet()) + 1;
        idStudentData.put(newId, detailsArgs[0] + " " + detailsArgs[1]);
        String info = String.format("(age: %s, town: %s)", detailsArgs[2], detailsArgs[3]);
        studentsInfoData.put(detailsArgs[0] + " " + detailsArgs[1], info);

        String studentInfoToStorage = String.format("%n%d,%s,%s,%s,%s", newId, detailsArgs[0],
                detailsArgs[1], detailsArgs[2], detailsArgs[3]);
        writer = new FileWriter("students.txt", true);
        writer.write(studentInfoToStorage);
        writer.close();

        return String.format("Student: %s %s has been added to the system", detailsArgs[0], detailsArgs[1]);
    }

    private static String updateById() {
        return "Im not sure what to do here";
    }

    private static String deleteById(int id) throws IOException {
        if (!idStudentData.containsKey(id)){
            return "Student does not exist";
        }
        String name = idStudentData.get(id);
        idGradesData.remove(id);
        idStudentData.remove(id);
        studentsInfoData.remove(name);
        //String info =
        writer = new FileWriter("students.txt", false);
        boolean keepingOldData = false;
        String deletedStudent;
        for (Integer integer : idStudentData.keySet()) {
            //builder.append(String.format("%d,%s", ))
            String studentName = idStudentData.get(integer);
            String info = studentsInfoData.get(studentName);
            info = info.replace("(age: ", "");
            info = info.replace(" town: ", "");
            info = info.replace(")", "");
            studentName = studentName.replace(" ", ",");
            deletedStudent = String.format("%d,%s,%s%n", integer, studentName, info);
            writer.write(deletedStudent);
        }

        writer.close();

        writer = new FileWriter("grades.txt", false);
        String gradesInfo;
        for (Integer integer : idGradesData.keySet()) {
            gradesInfo = integer.toString();
            for (String subject : idGradesData.get(integer).keySet()) {
                gradesInfo += "," + subject + " ";
                gradesInfo += String.join(" ", idGradesData.get(integer).get(subject));
            }
            writer.write(gradesInfo + "\r\n");
        }

        writer.close();

        return String.format("User with ID: %d has beem removed", id);
    }

    private static String searchById(int id) {
        if (!idStudentData.containsKey(id)) {
            return "Student does not exist";
        }

        StringBuilder builder = new StringBuilder();
        String fullName = idStudentData.get(id);

        builder.append(String.format("%s %s%n", fullName, studentsInfoData.get(fullName)));
        for (Map.Entry<String, ArrayList<String>> gradesData : idGradesData.get(id).entrySet()) {
            builder.append(("#" + gradesData.getKey() + ": "));
            builder.append(String.join(", ", gradesData.getValue()) + "\r\n");

        }
        return builder.toString();
    }

    private static String searchByName(String fullName) {

        if (!studentsInfoData.containsKey(fullName)) {
            return "Student does not exist";
        }

        int id = 0;
        for (Integer integer : idStudentData.keySet()) {
            if (idStudentData.get(integer).equals(fullName)) {
                id = integer;
                break;
            }
        }

        StringBuilder builder = new StringBuilder();
        builder.append(String.format("%s %s%n", fullName, studentsInfoData.get(fullName)));
        for (Map.Entry<String, ArrayList<String>> gradesData : idGradesData.get(id).entrySet()) {
            builder.append(("#" + gradesData.getKey() + ": "));
            builder.append(String.join(", ", gradesData.getValue()) + "\r\n");

        }
        return builder.toString();
    }

    private static void initStudentsGradeData(String line) {
        String[] gradesArgs = line.split(",");
        int id = Integer.parseInt(gradesArgs[0]);
        String subject = "";
        ArrayList<String> grades = null;
        for (int i = 1; i < gradesArgs.length; i++) {
            subject = gradesArgs[i].split(" ")[0];
            grades = new ArrayList<>();
            for (int j = 1; j < gradesArgs[i].split(" ").length; j++) {
                grades.add(gradesArgs[i].split(" ")[j]);
            }
            if (!idGradesData.containsKey(id)) {
                idGradesData.put(id, new HashMap<String, ArrayList<String>>());
            }

            idGradesData.get(id).put(subject, grades);
        }
    }

    private static void initStudentsInfoData(String line){
        String[] studentsArgs = line.split(",");
        int id = Integer.parseInt(studentsArgs[0]);
        String name = studentsArgs[1] + " " + studentsArgs[2];
        String info = String.format("(age: %s, town: %s)", studentsArgs[3], studentsArgs[4]);

        studentsInfoData.put(name, info);
        idStudentData.put(id, name);
    }
}