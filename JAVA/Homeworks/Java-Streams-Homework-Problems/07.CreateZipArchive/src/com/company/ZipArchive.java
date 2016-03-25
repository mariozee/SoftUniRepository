package com.company;

import java.io.*;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

public class ZipArchive {

    public static void main(String[] args) {
        try {
            FileOutputStream fos = new FileOutputStream("Archives/text-files.zip");
            ZipOutputStream zos = new ZipOutputStream(fos);

            String file1 = "count-chars.txt";
            String file2 = "lines.txt";
            String file3 = "words.txt";

            add(zos, file1);
            add(zos, file2);
            add(zos, file3);

            zos.close();
            fos.close();

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void add(ZipOutputStream zos, String fileName) throws IOException {

        File file = new File(fileName);
        FileInputStream fis = new FileInputStream(file);
        ZipEntry zipEntry = new ZipEntry(fileName);
        zos.putNextEntry(zipEntry);

        byte[] bytes = new byte[1024];
        int lengt;
        while ((lengt = fis.read(bytes)) >= 0){
            zos.write(bytes, 0, lengt);
        }

        zos.closeEntry();
        fis.close();
    }
}
