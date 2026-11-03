
using customer_registration_web_csharp.Dal.Dao;
using customer_registration_web_csharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace customer_registration_web_csharp.Dal
{
    public class CustomerDal
    {
        private SqlServerConnection _conn;
        private string _sql;
        public CustomerDal()
        {
            _conn = new SqlServerConnection();

        }

        public Customer GetOneCustome(string id)
        {
            try
            {
                _sql = "Select * from customer where id =" + id;

                List<Customer> data = _conn.GetTable<Customer>(_sql);
                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Customer> GetListCustomer(string name)
        {
            try
            {
                _sql = "Select * from customer where name like '%" + name + "%'";

                return  _conn.GetTable<Customer>(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer CreateCustomer(Customer obj)
        {
            try
            {
                obj.status = true;
                _sql = "Insert Into customer (name,rg,cpf,status) values (@name,@rg,@cpf,@status)";
                _conn.ExecuteSql(_sql, obj);

                _sql = "SELECT TOP 1 * FROM Customer ORDER BY id DESC";
                List<Customer> data = _conn.GetTable<Customer>(_sql);
                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Customer UpdateCustomer(Int64 id, Customer obj)
        {

            try
            {
                obj.status = true;
                obj.id = id;
                _sql = "Update customer set name=@name,rg=@rg,cpf=@cpf,status=@status where id = @id";
                _conn.ExecuteSql(_sql, obj);

                _sql = "SELECT TOP 1 * FROM Customer where id = " + id.ToString();
                List<Customer> data = _conn.GetTable<Customer>(_sql);
                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public Customer DeleteCustomer(Int64 id)
        {
            try
            {
                _sql = "Delete from customer where id = @id";
                _conn.ExecuteSql(_sql, new Customer { id=id});

                _sql = "SELECT TOP 1 * FROM Customer where id = " + id.ToString();
                List<Customer> data = _conn.GetTable<Customer>(_sql);
                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
