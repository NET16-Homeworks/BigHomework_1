using BigHomework_1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Loan
{
    internal class Loan
    {
        private double _loanAmount;
        private int _loanTerm;
        private double _loanRate;


        public Loan(double loanAmount, int loanTerm, double loanRate, string email)
        {
            LoanAmount = loanAmount;
            LoanTerm = loanTerm;
            LoanRate = loanRate;
            Email = email;
        }

        public double LoanAmount 
        {
            get { return _loanAmount; }
            set
            {
                if (value < 0)
                {
                    throw new IncorrectValueException<double>(value);
                }
                _loanAmount = value;
            }
        }

        public int LoanTerm
        {
            get { return _loanTerm; }
            set
            {
                if (value < 0)
                {
                    throw new IncorrectValueException<int>(value);
                }
                _loanTerm = value;
            }
        }
        public double LoanRate
        {
            get { return _loanRate; }
            set
            {
                if (value < 0)
                {
                    throw new IncorrectValueException<double>(value);
                }
                _loanRate = value;
            }
        }
        public string Email { get; set; }

    }
}
