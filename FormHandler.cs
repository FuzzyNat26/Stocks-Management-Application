using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyek_UAS
{
    class FormHandler
    {
        //For saving user login info
        public static string Username
        { get; set; }

        private static Home _getHome; private static Login _getLogin; private static Sales _getSales;
        private static Sales_History _getSales_History; private static Sales_Report _getSales_Report; private static Team_Member _getTeam_Member;
        private static Stocks_List _getStocks_List; private static Dealers _getDealers; private static Purchase_Stocks _getPurchase_Stocks;
        private static Users _getUsers;

        public static Home Home
        {
            get
            {
                if (_getHome == null)
                {
                    _getHome = new Home();
                }
                return _getHome;
            }
        }

        public static Login Login
        {
            get
            {
                if (_getLogin == null)
                {
                    _getLogin = new Login();
                }

                return _getLogin;
            }
        }

        public static Sales Sales
        {
            get
            {
                if (_getSales == null)
                {
                    _getSales = new Sales();
                }
                return _getSales;
            }
        }

        public static Sales_History Sales_History
        {
            get
            {
                if (_getSales_History == null)
                {
                    _getSales_History = new Sales_History();
                }
                return _getSales_History;
            }
        }

        public static Sales_Report Sales_Report
        {
            get
            {
                if (_getSales_Report == null)
                {
                    _getSales_Report = new Sales_Report();
                }
                return _getSales_Report;
            }
        }

        public static Team_Member Team_Member
        {
            get
            {
                if (_getTeam_Member == null)
                {
                    _getTeam_Member = new Team_Member();
                }
                return _getTeam_Member;
            }
        }

        public static Stocks_List Stocks_List
        {
            get
            {
                if (_getStocks_List == null)
                {
                    _getStocks_List = new Stocks_List();
                }
                return _getStocks_List;
            }
        }

        public static Dealers Dealers
        {
            get
            {
                if (_getDealers == null)
                {
                    _getDealers = new Dealers();
                }
                return _getDealers;
            }
        }

        public static Purchase_Stocks Purchase_Stocks
        {
            get
            {
                if (_getPurchase_Stocks == null)
                {
                    _getPurchase_Stocks = new Purchase_Stocks();
                }
                return _getPurchase_Stocks;
            }
        }

        public static Users Users
        {
            get
            {
                if (_getUsers == null)
                {
                    _getUsers = new Users();
                }
                return _getUsers;
            }
        }
    }
}
