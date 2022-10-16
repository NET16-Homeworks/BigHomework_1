using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigHomework_1.Exceptions;

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
        public string Email { get; set; }
        public double LoanAmount
        {
            get { return _loanAmount; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidValueException<double>(value);
                }
                else
                {
                    _loanAmount = value;
                }
            }
        }
        public int LoanTerm
        {
            get { return _loanTerm; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidValueException<int>(value);
                }
                else
                {
                    _loanTerm = value;
                }
            }
        }
        public double LoanRate
        {
            get { return _loanRate; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidValueException<double>(value);
                }
                else
                {
                    _loanRate = value;
                }
            }
        }
       
    }
}
