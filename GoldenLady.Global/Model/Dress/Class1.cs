using System;

namespace GoldenLady.Global.Model.Dress
{
    [Serializable]
    public class Employee
    {
        //private Employee()
        //{
        //    DepartmentNO = ""; EmployeeNO = ""; EmployeePassword = ""; EmployeeName = ""; CardNO = ""; EmployeeSex = ""; EmployeeBirthday = ""; EmployeeLevel = ""; EmployeeDuty = ""; EmployeeDescribe = ""; EmployeePhoto = ""; Create = ""; CreateDate = ""; IsDelete = ""; 
        //}
        private string _DepartmentNO;
        public string DepartmentNO
        {
            set { _DepartmentNO = value; }
            get { return _DepartmentNO; }
        }
        private string _EmployeeNO;
        public string EmployeeNO
        {
            set { _EmployeeNO = value; }
            get { return _EmployeeNO; }
        }
        private string _EmployeePassword;
        public string EmployeePassword
        {
            set { _EmployeePassword = value; }
            get { return _EmployeePassword; }
        }
        private string _EmployeeName;
        public string EmployeeName
        {
            set { _EmployeeName = value; }
            get { return _EmployeeName; }
        }
        private string _CardNO;
        public string CardNO
        {
            set { _CardNO = value; }
            get { return _CardNO; }
        }
        private string _EmployeeSex;
        public string EmployeeSex
        {
            set { _EmployeeSex = value; }
            get { return _EmployeeSex; }
        }
        private string _EmployeeBirthday;
        public string EmployeeBirthday
        {
            set { _EmployeeBirthday = value; }
            get { return _EmployeeBirthday; }
        }
        private string _EmployeeLevel;
        public string EmployeeLevel
        {
            set { _EmployeeLevel = value; }
            get { return _EmployeeLevel; }
        }
        private string _EmployeeDuty;
        public string EmployeeDuty
        {
            set { _EmployeeDuty = value; }
            get { return _EmployeeDuty; }
        }
        private string _EmployeeDescribe;
        public string EmployeeDescribe
        {
            set { _EmployeeDescribe = value; }
            get { return _EmployeeDescribe; }
        }
        private string _EmployeePhoto;
        public string EmployeePhoto
        {
            set { _EmployeePhoto = value; }
            get { return _EmployeePhoto; }
        }
        private string _Create;
        public string Create
        {
            set { _Create = value; }
            get { return _Create; }
        }
        private string _CreateDate;
        public string CreateDate
        {
            set { _CreateDate = value; }
            get { return _CreateDate; }
        }
        private string _IsDelete;
        public string IsDelete
        {
            set { _IsDelete = value; }
            get { return _IsDelete; }
        }
    }
}
