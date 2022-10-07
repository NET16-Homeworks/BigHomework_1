using BigHomework_1.Exceptions;
using BigHomework_1.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Loans
{
   
    internal class Loan
    {
        private static UserServ userService = new UserServ();
        private double _loanAmount;
        private int _loanTerm;
        private double _loanRate;
        private string _email;

        public double LoanAmount
        {
            get => _loanAmount;
            set
            {
                if (_loanAmount <= 20)
                {
                    throw new ArgumentException("Wrong sum. Must be more than 20 rubles.");
                }

                else
                {
                    _loanAmount = value;
                }
            }
        }
        public int LoanTerm
        {
            get => _loanTerm;
            set
            {
                if (_loanTerm <= 4)
                {
                    throw new ArgumentException("Wrong term. Must be from 4 months");
                }

                else
                {
                    _loanTerm = value;
                }
            }
        }
            
        public double LoanRate { get; set; }
        public string Email
        {
            get => _email;
            set
            {
                if (!userService.DoesUserExist(value))
                {
                    throw new ObjectNotFoundException(value);
                }
                else
                {
                    _email = value;
                }
            }
        }
    }
}
