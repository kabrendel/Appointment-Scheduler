﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Appointment_Scheduler
{
    public class Repository
    {
        //  Statics
        static User User;
        //  Access Database and list/table builders.
        private readonly DBObjects _dbObjects;
        private readonly DataTables _dataTables;
        public Repository()
        {
            _dbObjects = new DBObjects();
            _dataTables = new DataTables(_dbObjects);
        }
        //
        public string GetUserPassword(string user)
        {
            return _dbObjects.UserPassword(user);
        }
        public User GetUserObject(string user)
        {
            return _dbObjects.UserObject(user);
        }
        //
        public DataTable CustomerReport()
        {
            return _dbObjects.CustomerReport();
        }
        public DataTable MonthlyReport()
        {
            return _dbObjects.MonthlyReport();
        }
        public DataTable GetAppointmentTable()
        {
            var user = Tuple.Create(false,User.UserId);
            return _dataTables.BuildAppointmentTable(user);
        }
        public DataTable GetAppointmentTableAll()
        {
            var user = Tuple.Create(true, 0);
            return _dataTables.BuildAppointmentTable(user);
        }
        public DataTable GetCustomerTable()
        {
            return _dataTables.BuildCustomerTable();
        }
        internal List<string> GetTypeList()
        {
            return _dataTables.TypeList();
        }
        internal DataTable GetCustomerList()
        {
            return _dataTables.CustomerList();
        }
        internal DataTable GetUserList(bool all)
        {
            return _dataTables.UserList(all, User.UserId);
        }
        internal void SetUser(User user)
        {
            User = user;
        }
        internal string GetUserName()
        {
            return User.UserName;
        }
        internal BindingList<Appointment> GetUserAppointments()
        {
            return _dbObjects.GetAppointments(User.UserId);
        }
    }// End of class.
}
