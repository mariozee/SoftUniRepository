package com.company;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.*;

public class DragonAccounting {

    static int daysPassed = 1 % 365;

    public static void main(String[] args) {
        //hire employees -> check for raise -> give salaries -> fire employees -> check for additional income/expense -> check for bankruptcy.
        Scanner sc = new Scanner(System.in);
        Company company = new Company();
        BigDecimal capital = sc.nextBigDecimal();

        BigDecimal expence = new BigDecimal("0.0");
        BigDecimal income = new BigDecimal("0.0");

        sc.nextLine();
        String[] inputArgs = sc.nextLine().split(";");
        while (!inputArgs[0].equals("END")) {
            long hired = Long.parseLong(inputArgs[0]);
            long fired = Long.parseLong(inputArgs[1]);
            BigDecimal salary = new BigDecimal(inputArgs[2]);

            //Hire employees
            for (long i = 0; i < hired; i++) {
                company.hireEmployee(new Employee(salary));
                company.getEmployees().addAll(new ArrayList<Employee>(50){n)})
            }

            //Check for raises
            for (Employee employee : company.getEmployees()) {
                employee.addDay();
                employee.checkForRaise();
                if (daysPassed % 30 == 0) {
                    expence = expence.add(employee.calculateSalary());
                    employee.resetDays();
                }
            }

            //Fire employees
            for (int i = 0; i < fired; i++) {
                company.fireEmployee();
            }

            //Check for additional income/expence
            for (int i = 3; i < inputArgs.length; i++) {
                if (inputArgs[i].startsWith("Product") || inputArgs[i].startsWith("Unconditional")) {
                    double in = Double.parseDouble(inputArgs[i].split(":")[1]);
                    income = BigDecimal.valueOf(in);
                    capital = capital.add(income);
                } else {
                    double in = Double.parseDouble(inputArgs[i].split(":")[1]);
                    expence = expence.add(BigDecimal.valueOf(in));
                }
            }

            if (expence.compareTo(capital) == 1) {
                System.out.printf("BANKRUPTCY: %s", expence.subtract(capital).setScale(4, RoundingMode.DOWN).toPlainString());
                return;
            }

            daysPassed++;
//            for (Employee employee : company.getEmployees()) {
//                employee.addDay();
//            }

            inputArgs = sc.nextLine().split(";");
        }
        capital = capital.subtract(expence);
        capital = capital.setScale(4, RoundingMode.DOWN);
        System.out.printf("%d %s", company.totalEmployee(), capital.toPlainString());
    }
}

class Employee {

    private final double TOTAL_DAYS_IN_MONTH = 30;
    private BigDecimal salary;
    private int daysInCompany = 0;
    private int montlyWorkedDays = 0;

    public Employee(BigDecimal salary) {
        this.salary = salary;
    }

    public void addDay() {
        daysInCompany++;
        montlyWorkedDays++;
    }

    public void resetDays() {
        montlyWorkedDays = 0;
    }


    public BigDecimal calculateSalary() {
        BigDecimal companyExpense = salary.divide(BigDecimal.valueOf(TOTAL_DAYS_IN_MONTH), 9, RoundingMode.UP).setScale(7, RoundingMode.DOWN);
        companyExpense = companyExpense.multiply(new BigDecimal(montlyWorkedDays));
        return companyExpense;
    }

    public void checkForRaise() {
        if (daysInCompany == 365) {
            salary = salary.multiply(new BigDecimal("1.006"));
            daysInCompany = 0;
        }
    }

}

class Company {

    private Queue<Employee> employees = new LinkedList<Employee>();

    public Queue<Employee> getEmployees() {
        return employees;
    }

    public void hireEmployee(Employee employee) {
        employees.add(employee);
    }

    public void fireEmployee() {
        employees.remove();
    }

    public long totalEmployee() {
        return employees.size();
    }
}
