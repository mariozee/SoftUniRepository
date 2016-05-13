import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Zisov4eto on 08-May-16.
 */
public class FirstProblemSolution {

    static List<String> royalists = new LinkedList<>();
    static List<String> nonRoyalists = new LinkedList<>();

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        String[] names = sc.nextLine().split(" ");

        for (int i = 0; i < names.length; i++) {
            char[] letters = names[i].toCharArray();
            putPersonInReligionGroup(letters, names[i]);
        }

        int royalistsCount = royalists.size();
        int nonRoyalistsCount = nonRoyalists.size();

        if (royalistsCount >= nonRoyalistsCount){
            System.out.println("Royalists - " + royalistsCount);
            for (String name : royalists) {
                System.out.println(name);
            }

            System.out.println("All hail Royal!");
        } else {
            for (String name : nonRoyalists) {
                System.out.println(name);
            }

            System.out.println("Royalism, Declined!");
        }
    }

    private static void putPersonInReligionGroup(char[] letters, String name) {
        int sum = 0;
        for (int i = 0; i < letters.length; i++) {
            sum += letters[i];
            while (sum > 26){
                sum -= 26;
            }
        }

        if (sum == 18){
            royalists.add(name);
        } else {
            nonRoyalists.add(name);
        }
    }
}
