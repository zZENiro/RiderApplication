using System;
using System.Collections.Generic;
using System.Text;
using RiderApplication.ViewModels;
using RiderApplication.scenarios.ScenariosModels;

namespace RiderApplication.scenarios.ScenariosViewModels
{
    public class RiderAccountViewModel : ModelView
    {
        private string _hashCode;
        private string _carNum;
        private string _carModel;
        private string _name;
        private Organization _organization;
        private int _id;
        private string _login;
        private string _pwd;

        public RiderAccountViewModel()
        {
            
        }

        public string Password
        {
            get { return _pwd; }
            set { SetValue(ref _pwd, value); }
        }

        public string Login
        {
            get { return _login; }
            set { SetValue(ref _login, value); }
        }

        public int ID
        {
            get { return _id; }
            set { SetValue(ref _id, value); }
        }

        public Organization Organization
        {
            get { return _organization; }
            set { SetValue(ref _organization, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        public string CarNumber
        {
            get { return _carNum; }
            set { SetValue(ref _carNum, value); }
        }

        public string CarModel
        {
            get { return _carModel; }
            set { SetValue(ref _carModel, value); }
        }

        public string HashCode
        {
            get { return _hashCode; }
            set { SetValue(ref _hashCode, value); }
        }
    }
}
