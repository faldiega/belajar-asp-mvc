using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Provider
{
    public class CustomerProvider
    {
        protected readonly VIDLYEntities _dbContext;

        public CustomerProvider()
        {
            _dbContext = new VIDLYEntities();
        }


        private List<Customers> GetCustomers()
        {
            #region hardcode data
            //var customers = new List<Customer>
            //{
            //    new Customer(){ Id=1, Name = "John Smith" },
            //    new Customer(){ Id=2, Name = "Mary Williams" }
            //};
            #endregion

            return _dbContext.Customers.ToList();
        }

        public Customers GetSingleCustomer(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.CustomerID == id);
            return customer;
        }

        public List<CustomerMembershipVM> GetIndexCustomerMembership()
        {
            var query = from cus in GetCustomers()
                            join mem in GetMembershipTypes() on cus.MembershipTypeID equals mem.MembershipTypeID
                            select new CustomerMembershipVM
                            {
                                CustomerID = cus.CustomerID,
                                CustomerName = cus.CustomerName,
                                MembershipType = mem,
                                BirthDate = cus.BirthDate
                            };
            return query.ToList();
        }

        public CustomerMembershipVM GetSingleCustomerMembership(int customerId)
        {
            var customer = GetIndexCustomerMembership().SingleOrDefault(c => c.CustomerID == customerId);
            var viewModel = new CustomerMembershipVM()
            {
                CustomerID = customer.CustomerID,
                CustomerName = customer.CustomerName,
                MembershipType = customer.MembershipType,
                BirthDate = customer.BirthDate,
            };

            return viewModel;
        }

        


        private List<MembershipType> GetMembershipTypes()
        {
            return _dbContext.MembershipType.ToList();
        }


    }
}