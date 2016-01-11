﻿using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace SMS.DAL
{
    public class Customers
    {
        OleDbConnection cm = new OleDbConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        public DataTable GetAllCustomers()
        {
            OleDbCommand cmd = new OleDbCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetAllCustomers",
                Connection = cm
            };
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public string CreateCustomer(string CustomerName, string Address, string PhoneNo, string Email, byte[] Photo)
        {
            string msg = null;
            OleDbCommand cmd = new OleDbCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "CreateCustomer",
                Connection = cm,
            };
            cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Photo", Photo);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally { cm.Close(); }
            return msg;
        }

        public string UpdateCustomer(string CustomerName, string Address, string PhoneNo, string Email, byte[] Photo, int ID)
        {
            string msg = null;
            OleDbCommand cmd = new OleDbCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateCustomer",
                Connection = cm,
            };
            cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Photo", Photo);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally { cm.Close(); }
            return msg;
        }

        public string UpdateCustomerWoPhoto(string CustomerName, string Address, string PhoneNo, string Email, int ID)
        {
            string msg = null;
            OleDbCommand cmd = new OleDbCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateCustomerWoPhoto",
                Connection = cm,
            };
            cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally { cm.Close(); }
            return msg;
        }

        public string DeleteCustomer(int ID)
        {
            string msg = null;
            OleDbCommand cmd = new OleDbCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteCustomer",
                Connection = cm,
            };
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally { cm.Close(); }
            return msg;
        }

        public string DeleteCustomers()
        {
            string msg = null;
            OleDbCommand cmd = new OleDbCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteCustomers",
                Connection = cm,
            };
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally { cm.Close(); }
            return msg;
        }
    }
}
