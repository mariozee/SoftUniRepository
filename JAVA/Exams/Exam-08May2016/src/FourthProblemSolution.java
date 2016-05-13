import java.math.BigDecimal;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Zisov4eto on 08-May-16.
 */
public class FourthProblemSolution {

    static Map<String, Double> teamIncome = new HashMap<>();
    static Map<String, TreeSet<String>> teamMates = new HashMap<>();
    static Map<String, Integer> teammatesHours = new HashMap<>();
    static Map<String, Double> teammatesDaylyIncome = new HashMap<>();

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        String regex = "^([A-Za-z]+);(-?[0-9]+);(-?[0-9]+\\.[0-9]+|-?[0-9]+);([A-Za-z]+)$";
        String line = sc.nextLine();

        while (!line.equals("Pishi kuf i da si hodim")){
            Matcher matcher = Pattern.compile(regex).matcher(line);

            while (matcher.find()){
                String name = matcher.group(1);
                int workHours = Integer.parseInt(matcher.group(2));
                double payment = Double.parseDouble(matcher.group(3));
                String team = matcher.group(4);

                //!!!!!
                if (teammatesHours.containsKey(name)){
                    //line = sc.nextLine();
                    continue;
                }

                if (!teamMates.containsKey(team)){
                    teamMates.put(team, new TreeSet<>());
                }

                teamMates.get(team).add(name);

                teammatesHours.put(name, workHours);
                double dayIncome = (payment * workHours) / 24;
                teammatesDaylyIncome.put(name, dayIncome);

                if (!teamIncome.containsKey(team)){
                    teamIncome.put(team, 0.0);
                }

                double totalIncome = ((payment * workHours) / 24) * 30;
                teamIncome.put(team, teamIncome.get(team) + totalIncome);


            }

            line = sc.nextLine();
        }
//Double.compare(teamIncome.get(t2.getKey()), teamIncome.get(t1.getKey())))
        //Double.compare(teammatesDaylyIncome.get(e2), teammatesDaylyIncome.get(e1))
        teamMates.entrySet().stream().sorted((t1, t2) -> Double.compare(teamIncome.get(t2.getKey()), teamIncome.get(t1.getKey())))
                .forEach(t -> {
                    System.out.println("Team - " + t.getKey());
                    t.getValue().stream().sorted((e1, e2) -> Double.compare(teammatesDaylyIncome.get(e2), teammatesDaylyIncome.get(e1)))
                            .sorted((e1, e2) -> Double.compare(teammatesHours.get(e2), teammatesHours.get(e1)))
                            .forEach(employee -> {
                                System.out.printf("$$$%s - ", employee);
                                System.out.printf("%d - %.6f%n", teammatesHours.get(employee), teammatesDaylyIncome.get(employee));
                            });
                });
    }
}
