package com.company;

import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class ChampionsLeague {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\s\\|\\s");
        Map<String, Integer> teamWins = new TreeMap<>();
        Map<String, ArrayList<String>> teamOpponents = new HashMap<>();
        while (!input[0].equals("stop")) {
            String team1 = input[0];
            String team2 = input[1];
            int team1HomeScore = Integer.parseInt(input[2].split(":")[0]);
            int team2AwayScore = Integer.parseInt(input[2].split(":")[1]);
            int team1AwayScore = Integer.parseInt(input[3].split(":")[1]);
            int team2HomeScore = Integer.parseInt(input[3].split(":")[0]);
            String winner = getWinner
                    (team1, team2, team1AwayScore, team1HomeScore, team2AwayScore, team2HomeScore);
            if (!teamOpponents.containsKey(team1)) {
                teamOpponents.put(team1, new ArrayList<>());
                teamWins.put(team1, 0);
            }

            teamOpponents.get(team1).add(team2);


            if (!teamOpponents.containsKey(team2)) {
                teamOpponents.put(team2, new ArrayList<>());
                teamWins.put(team2, 0);
            }

            teamOpponents.get(team2).add(team1);

            teamWins.put(winner, teamWins.get(winner) + 1);

            input = sc.nextLine().split("\\s\\|\\s");

        }

        printResult(teamWins, teamOpponents);
    }

    private static void printResult(Map<String, Integer> teamWins, Map<String, ArrayList<String>> teamOpponents) {
        teamWins.entrySet().stream().sorted((x, y) -> y.getValue().compareTo(x.getValue())).forEach(pair -> {
            ArrayList<String> opponents = teamOpponents.get(pair.getKey());
            String allOpponents = opponents.stream().sorted((x, y) -> x.compareTo(y)).collect(Collectors.joining(", "));
            System.out.println(pair.getKey());
            System.out.println("- Wins: " + pair.getValue());
            System.out.println("- Opponents: " + allOpponents);
        });
    }

    private static String getWinner(
            String team1, String team2,
            int team1AwayScore, int team1HomeScore,
            int team2AwayScore, int team2HomeScore) {

        int team1totalScore = team1AwayScore + team1HomeScore;
        int team2totalScore = team2AwayScore + team2HomeScore;
        if (team1totalScore > team2totalScore) {
            return team1;
        } else if (team1totalScore < team2totalScore) {
            return team2;
        } else {
            if (team1AwayScore > team2AwayScore) {
                return team1;
            }

            return team2;
        }
    }
}
