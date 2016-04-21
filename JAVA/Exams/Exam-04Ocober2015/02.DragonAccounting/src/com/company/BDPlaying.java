package com.company;

import java.math.BigDecimal;
import java.math.RoundingMode;

/**
 * Created by Zisov4eto on 16-Apr-16.
 */
public class BDPlaying {
    public static void main(String[] args) {
        BigDecimal dec1 = new BigDecimal("1000.0");
        BigDecimal dec2 = new BigDecimal("30.0");

        BigDecimal dec3 = new BigDecimal("0.0");
        dec3 = dec1.divide(dec2, 7, RoundingMode.DOWN);
        System.out.println(dec3);
    }
}
