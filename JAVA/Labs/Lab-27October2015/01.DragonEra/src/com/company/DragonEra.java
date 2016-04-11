package com.company;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class DragonEra {

    public static int dragonsCount = 0;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int dragonStart = Integer.parseInt(sc.nextLine());

        List<Dragon> dragons = new ArrayList<>();
        for (int i = 1; i <= dragonStart; i++) {
            Dragon dragon = new Dragon("Dragon_" + i, 0);

            int eggs = Integer.parseInt(sc.nextLine());
            for (int eggCount = 0; eggCount < eggs; eggCount++) {
                Egg egg = new Egg(0, dragon);
                dragon.lay(egg);
            }

            dragons.add(dragon);
        }

        dragonsCount = dragonStart + 1;

        int years = Integer.parseInt(sc.nextLine());
        for (int year = 1; year <= years ; year++) {
            String yearType = sc.nextLine();
        }
    }
}

class Dragon {
    private final int AGE_DEATH = 6;
    private final int AGE_LAT_EGGS_START = 3;
    private final int AGE_LAT_EGGS_END = 4;

    private String name;
    private int age;
    private List<Egg> eggs;
    private List<Dragon> children;
    private boolean isAlive;

    public Dragon(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public String getName() {
        return this.name;
    }

    public void lay(Egg egg){
        this.eggs.add(egg);
    }

    public void lay() {
        if (this.age >= AGE_LAT_EGGS_START && this.age <= AGE_LAT_EGGS_END){
            Egg egg = new Egg(0, this);
            this.eggs.add(egg);
        }
    }

    public void age(){
        if (this.isAlive){
            this.age++;
        }
        if (this.age == AGE_DEATH){
            this.isAlive = false;
        }
    }

    public void increaseOffspring(Dragon baby) {
        children.add(baby);
    }
}

class Egg {
    private final int AGE_HATCH = 2;

    private int age;
    private Dragon parent;

    public Egg(int age, Dragon parent) {
        this.age = age;
        this.parent = parent;
    }

    public void age(){
        this.age++;
    }

    public void hatch(){
        if (this.age == AGE_HATCH){
            Dragon baby = new Dragon(
                    this.parent.getName() + "/" + "Dragon_" + DragonEra.dragonsCount, 0);

            this.parent.increaseOffspring(baby);
            DragonEra.dragonsCount ++;
        }
    }
}
