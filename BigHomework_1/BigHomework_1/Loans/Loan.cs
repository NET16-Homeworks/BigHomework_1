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
        private double _loanAmount;
        private int _loanTerm;

        public double LoanAmount
        {
            get => _loanAmount;
            set
            {
                if (value >= 20)
                {
                    _loanAmount = value;
                }

                else
                {
                    throw new ArgumentException("Wrong sum. Must be more than 20 rubles.");
                }
            }
        }

        public int LoanTerm
        {
            get => _loanTerm;
            set
            {
                if (value <= 4)
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
        public string Email { get; set; }
    }
}
