using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenLadyWS.Customer
{
    public class CustomerProblem
    {
        string orderNO;

        public string OrderNO
        {
            get { return orderNO; }
            set { orderNO = value; }
        }
        string customerNO;

        public string CustomerNO
        {
            get { return customerNO; }
            set { customerNO = value; }
        }
        string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        string problemLink;

        public string ProblemLink
        {
            get { return problemLink; }
            set { problemLink = value; }
        }
        int problemGrade;

        public int ProblemGrade
        {
            get { return problemGrade; }
            set { problemGrade = value; }
        }
        string problemDescription;

        public string ProblemDescription
        {
            get { return problemDescription; }
            set { problemDescription = value; }
        }
        string result;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
        string problemDate;

        public string ProblemDate
        {
            get { return problemDate; }
            set { problemDate = value; }
        }
        string customService;

        public string CustomService
        {
            get { return customService; }
            set { customService = value; }
        }
        int CurrentLink;

        public int CurrentLink1
        {
            get { return CurrentLink; }
            set { CurrentLink = value; }
        }
    }
}
