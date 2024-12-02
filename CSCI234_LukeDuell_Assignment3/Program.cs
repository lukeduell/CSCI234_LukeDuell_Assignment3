/* Luke Duell
 * Instructor: Professor Hanoudi
 * CSCI 234: Object Oriented Programming w/C#
 * Assignment 3
 * Description: This program is the rewritten version
 *              of another code using inheritance. This
 *              program uses composition rather than
 *              inheritance.
 */


using System;
using System.ComponentModel;

public class CommissionEmployee
{
    private string firstName;
    private string lastName;
    private string socialSecurityNumber;
    private decimal grossSales;
    private decimal commissionRate;

    
    public CommissionEmployee(string first, string last, string ssn,
    decimal sales, decimal rate)
    {
        //setting calues for function
        firstName = first;
        lastName = last;
        socialSecurityNumber = ssn;
        GrossSales = sales;
        CommissionRate = rate;
    }

    //FirstName string call
    public string FirstName
    {
        get
        {
            return firstName;
        }
    }

    //LastName string call
    public string LastName
    {
        get
        {
            return lastName;
        }
    }
    public string SocialSecurityNumber
    {
        get
        {
            return socialSecurityNumber;
        }
    }

    //set calculates the commission rate for employee
    public decimal CommissionRate
    {
        get
        {
            return commissionRate;
        }
        set
        {
            if (value > 0 && value < 10)
                commissionRate = value;
            else
                throw new ArgumentOutOfRangeException("CommissionRate",
                value, "CommissionRate must be > 0 and < 1");
        }
    }
    //gross sales decimal call
    public decimal GrossSales
    {
        get
        {
            return grossSales;
        }
        set
        {
            if (value >= 0)
                grossSales = value;
            else
                throw new ArgumentOutOfRangeException("GrossSales", value, "GrossSales must be >= 0");
        }
    }

    public decimal Earnings()
    {
        return commissionRate * grossSales;
    } 

    // return string representation of CommissionEmployee object
    public override string ToString()
    {
        return string.Format(
        "{0}: {1} {2}\n{3}: {4}\n{5}: {6:C}\n{7}: {8:F2}",
        "Employee:", FirstName, LastName,
        "SSN:", SocialSecurityNumber,
        "Gross Sales:", GrossSales, "Commission Rate:", CommissionRate);
    }
}

public class BasePlusCommissionEmployee
{
    private decimal baseSalary;
    private CommissionEmployee commissionEmployee;
    public BasePlusCommissionEmployee(string first, string last,
    string ssn, decimal sales, decimal rate, decimal salary)

    {
        commissionEmployee = new CommissionEmployee(first, last, ssn, sales, rate);
        BaseSalary = salary;
    }

    public decimal BaseSalary
    {
        get
        {
            return baseSalary;
        }
        set
        {
            if (value >= 0)
                baseSalary = value;
            else
                throw new ArgumentOutOfRangeException("BaseSalary",
                value, "BaseSalary must be >= 0");
        }
    }

    public override string ToString()
    {
        return string.Format("Base-Salaried {0}; Base Salary: {1:C}",
        commissionEmployee.ToString(), BaseSalary);
    }

    public decimal Earnings()
    {
        return BaseSalary + commissionEmployee.Earnings();
    }


}

class CommissionEmployeeTest
{
    static void Main()
    {
        BasePlusCommissionEmployee basePlusCommissionEmployee = new BasePlusCommissionEmployee("Luke", "Duell", "254-6497", 5500, 1.2m, 3512);
        Console.WriteLine(basePlusCommissionEmployee);
        Console.WriteLine("Total Earnings: {0}", basePlusCommissionEmployee.Earnings());
    }
}