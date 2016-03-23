package com.company;

import java.io.*;
import java.util.Arrays;

public class CopyJPGFile {

    //Внимание! Тази програма съдържа продуктово позициониране.
    public static void main(String[] args) {
        File file = new File("Images/bira.jpg");

        try {
            FileOutputStream os = new FileOutputStream("Images/my-copied-picture.jpg");
            FileInputStream is = new FileInputStream(file);
            byte[] buffer = new byte[1024];
            int len;
            while ((len = is.read(buffer)) != -1){
                os.write(buffer, 0, len);
            }
            os.close();
            is.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
