using System;
using System.Collections.Generic;

namespace AbcBank
{
    public class Bank
    {
        private List<Customer> customers;

        /// <summary>
        /// Creates a bank full of customers
        /// </summary>
        public Bank()
        {
            customers = new List<Customer>();
        }

        /// <summary>
        /// Adds a customer with a customer name to the bank
        /// </summary>
        /// <param name="customer"></param>
        public void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        /// <summary>
        /// Generates a customer summary with info like customer name, number of accounts opened, etc
        /// </summary>
        /// <returns></returns>
        public String customerSummary()
        {
            String summary = "Customer Summary";
            foreach (Customer c in customers)
                summary += "\n - " + c.getName() + " (" + CommonFunctions.pluralFormatter(c.getNumberOfAccounts(), "account") + ")";
            return summary;
        }



        public double totalInterestPaid()
        {
            double total = 0;
            foreach (Customer c in customers)
                total += c.totalInterestEarned();
            return total;
        }

    }
}
