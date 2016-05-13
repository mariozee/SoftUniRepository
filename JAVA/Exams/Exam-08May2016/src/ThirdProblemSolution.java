import java.util.Scanner;

/**
 * Created by Zisov4eto on 08-May-16.
 */
public class ThirdProblemSolution {

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < n; i++) {
            sb.append(sc.nextLine());
        }

        String allCards = sb.toString();
        String[] faces = allCards.split("[a-z]");
        String[] suits = allCards.replaceAll("[A-Z0-9]+", "").split("");

        boolean flushFound = false;
        int counter = 0;

        for (int i = 0; i < faces.length; i++) {
            if (faces[i].equals("10")) {
                String currentCartSuit = suits[i];
                //start search for J
                    flushFound = false;

                for (int j = i + 1; j < faces.length; j++) {
                    if (flushFound) break;
                    if (faces[j].equals("J") && suits[j].equals(currentCartSuit)) {
                        //start search for Q
                        for (int k = j + 1; k < faces.length; k++) {
                            if (flushFound) break;
                            if (faces[k].equals("Q") && suits[k].equals(currentCartSuit)) {
                                //start search for K
                                for (int l = k + 1; l < faces.length; l++) {
                                    if (flushFound) break;
                                    if (faces[l].equals("K") && suits[l].equals(currentCartSuit)) {
                                        //start search for A
                                        for (int m = l + 1; m < faces.length; m++) {
                                            if (faces[m].equals("A") && suits[m].equals(currentCartSuit)) {
                                                String suit = getSuit(currentCartSuit);
                                                System.out.println("Royal Flush Found - " + suit);
                                                counter++;
                                                flushFound = true;
                                                break;
                                            } else if (!suits[m].equals(currentCartSuit)) {
                                                continue;
                                            } else if (suits[m].equals(currentCartSuit) && !faces[m].equals("A")) {
                                                flushFound = true;
                                                break;
                                            }
                                        }
                                    } else if (!suits[l].equals(currentCartSuit)) {
                                        continue;
                                    } else if (suits[l].equals(currentCartSuit) && !faces[l].equals("K")) {
                                        flushFound = true;
                                        break;
                                    }
                                }
                            } else if (!suits[k].equals(currentCartSuit)) {
                                continue;
                            } else if (suits[k].equals(currentCartSuit) && !faces[k].equals("Q")) {
                                flushFound = true;
                                break;
                            }
                        }
                    } else if (!suits[j].equals(currentCartSuit)) {
                        continue;
                    } else if (suits[j].equals(currentCartSuit) && !faces[j].equals("J")) {
                        flushFound = true;
                        break;
                    }
                }
            }
        }

        System.out.println("Royal's Royal Flushes - " + counter + ".");
    }

    private static String getSuit(String currentCartSuit) {

        if (currentCartSuit.equals("c")){
            return "Clubs";
        } else if (currentCartSuit.equals("d")){
            return "Diamonds";
        } else if (currentCartSuit.equals("h")){
            return "Hearts";
        } else {
            return "Spades";
        }
    }
}
