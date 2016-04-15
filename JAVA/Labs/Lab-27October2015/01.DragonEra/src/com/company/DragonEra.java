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
        for (int year = 1; year <= years; year++) {
            String yearType = sc.nextLine();
            YearType yearFactor = YearType.valueOf(yearType);

            for (Dragon dragon : dragons) {
                passAge(dragon, yearFactor);
            }
        }

        for (Dragon dragon : dragons) {
            printOutput(dragon, 0);
        }
    }

    public static void passAge(Dragon dragon, YearType yearFactor) {
        dragon.age();
        dragon.lay();

        if (dragon.isAlive()) {
            for (Egg egg : dragon.getEggs()) {
                egg.setYearFactor(yearFactor);

                egg.age();
                egg.hatch();
            }
        }

        for (Dragon child : dragon.getChildren()) {
            passAge(child, yearFactor);
        }
    }

    public static void printOutput(Dragon dragon, int index) {
        String output = "";
        for (int i = 0; i < index; i++) {
            output += " ";
        }

        if (dragon.isAlive()){
            System.out.println(output + dragon.getName());
        }

        index += 2;

        for (Dragon child : dragon.getChildren()) {
            printOutput(child, index);
        }
    }
}

class Dragon {
    private final int AGE_DEATH = 6;
    private final int AGE_LAY_EGGS_START = 3;
    private final int AGE_LAY_EGGS_END = 4;

    private String name;
    private int age;
    private List<Egg> eggs;
    private List<Dragon> children;
    private boolean isAlive;

    public Dragon(String name, int age) {
        this.name = name;
        this.age = age;
        this.eggs = new ArrayList<>();
        this.children = new ArrayList<>();
        this.isAlive = true;
    }

    public String getName() {
        return this.name;
    }

    public boolean isAlive() {
        return isAlive;
    }

    public Iterable<Egg> getEggs() {
        return this.eggs;
    }

    public Iterable<Dragon> getChildren() {
        return this.children;
    }

    public void lay(Egg egg) {
        this.eggs.add(egg);
    }

    public void lay() {
        if (this.age >= AGE_LAY_EGGS_START && this.age <= AGE_LAY_EGGS_END) {
            Egg egg = new Egg(-1, this);
            this.eggs.add(egg);
        }
    }

    public void age() {
        if (this.isAlive) {
            this.age++;
        }
        if (this.age == AGE_DEATH) {
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
    private YearType yearFactor;

    public Egg(int age, Dragon parent) {
        this.age = age;
        this.parent = parent;
    }

    public void setYearFactor(YearType yearFactor) {
        this.yearFactor = yearFactor;
    }

    public void age() {
        this.age++;
    }

    public void hatch() {
        if (this.age == AGE_HATCH) {
            int yearFactor = this.yearFactor.ordinal();
            for (int i = 0; i < yearFactor; i++) {
                Dragon baby = new Dragon(
                        this.parent.getName() + "/" + "Dragon_" + DragonEra.dragonsCount, -1);

                this.parent.increaseOffspring(baby);
                DragonEra.dragonsCount++;
            }
        }
    }
}

enum YearType {
    Bad,
    Normal,
    Good
}
