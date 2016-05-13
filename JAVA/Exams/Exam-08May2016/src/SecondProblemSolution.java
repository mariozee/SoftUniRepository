import java.math.BigDecimal;
import java.util.Scanner;

/**
 * Created by Zisov4eto on 08-May-16.
 */
public class SecondProblemSolution {

    static int customersCount = 0;
    static BigDecimal royalIncome = new BigDecimal("0");
    static double lukankaPrice = 0;
    static double rakiqPrice = 0;

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        int r = sc.nextInt();
        int c = sc.nextInt();
        sc.nextLine();
        lukankaPrice = sc.nextDouble();
        rakiqPrice = sc.nextDouble();
        sc.nextLine();

        String line = sc.nextLine();
        while (!line.equals("Royal Close")) {
            customersCount++;
            int row = Integer.parseInt(line.split(" ")[0]);
            int col = Integer.parseInt(line.split(" ")[1]);

            if (row < col) {
                //goes up - left
                moveUpLeft(row, col);
            } else {
                moveLeftUp(row, col);
            }

            line = sc.nextLine();
        }

        System.out.printf("%f%n", royalIncome.setScale(6, BigDecimal.ROUND_HALF_UP));
        System.out.println(customersCount);
    }

    private static void moveLeftUp(int row, int col) {
        if (row % 2 == 0) {
            for (int currentCol = col; currentCol >= 0; currentCol--) {
                buyLukanka(row, currentCol);
            }
        } else {
            for (int currentCol = col; currentCol >= 0; currentCol--) {
                buyRakiq(row, currentCol);
            }
        }

        for (int currentRow = row - 1; currentRow > 0; currentRow--) {
            if (currentRow % 2 == 0) {
                buyLukanka(currentRow, 0);
            } else {
                buyRakiq(currentRow, 0);
            }
        }
    }

    private static void moveUpLeft(int row, int col) {

        for (int currentRow = row; currentRow >= 0; currentRow--) {
            if (currentRow % 2 == 0) {
                buyLukanka(currentRow, col);
            } else {
                buyRakiq(currentRow, col);
            }
        }

        for (int currentCol = col - 1; currentCol > 0; currentCol--) {
            buyLukanka(0, currentCol);
        }


    }

    private static void buyRakiq(int row, int col) {

        BigDecimal total = new BigDecimal("1");
        total = total.multiply(new BigDecimal(row + 1));
        total = total.multiply(new BigDecimal(col + 1));
        total = total.multiply(new BigDecimal(rakiqPrice));

        royalIncome = royalIncome.add(total);
    }

    private static void buyLukanka(int row, int col) {

        BigDecimal total = new BigDecimal("1");
        total = total.multiply(new BigDecimal(row + 1));
        total = total.multiply(new BigDecimal(col + 1));
        total = total.multiply(new BigDecimal(lukankaPrice));

        royalIncome = royalIncome.add(total);
    }
}
