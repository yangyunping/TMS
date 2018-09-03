using System.Collections.Generic;

namespace GoldenLady.Dress.Utils
{
    public class RentDressesInfo
    {
        string _batch;
        string _address;
        string _department;
        string _customerName;
        string _phone;
        string _marryDate;
        string _notes;
        string _dressStylist;
         List<List<string>> _dresses;

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public  string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public  string MarryDate
        {
            get { return _marryDate; }
            set { _marryDate = value; }
        }

        public  string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public  string DressStylist
        {
            get { return _dressStylist; }
            set { _dressStylist = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Batch
        {
            get { return _batch; }
            set { _batch = value; }
        }

        public List<List<string>> Dresses
        {
            get { return _dresses; }
            set { _dresses = value; }
        }
    }
}