
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
        public Customer GetOneCustome(Int64 id)
        {
            try
            {
                using (var conn = new SqlServerContext())
                {

                    return conn.Customer.FirstOrDefault(i => i.id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Customer> GetListCustomer(string name, string rg, string cpf)
        {
            try
            {
                using (var conn = new SqlServerContext())
                {
                    return conn.Customer.Where(i => i.name.Contains(name) && i.rg.Contains(rg) && cpf.Contains(cpf)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer CreateCustomer(Customer obj)
        {
            Customer insert = new Customer();
            using (var conn = new SqlServerContext())
            {
                insert.name = obj.name;
                insert.rg = obj.rg;
                insert.cpf = obj.cpf;
                insert.status = true;
                conn.Customer.Add(insert);
                conn.SaveChanges();
                return insert;
            }

        }


        public Customer UpdateCustomer(Int64 id, Customer obj)
        {
            using (var conn = new SqlServerContext())
            {
                Customer selected = conn.Customer.FirstOrDefault(i => i.id == id);
                if (selected != null)
                {
                    selected.name = obj.name;
                    selected.rg = obj.rg;
                    selected.cpf = obj.cpf;
                    selected.status = obj.status;
                    conn.SaveChanges();
                }
                return selected;
            }

        }

        public Customer DeleteCustomer(Int64 id)
        {
            using (var conn = new SqlServerContext())
            {
                Customer delete = conn.Customer.FirstOrDefault(i => i.id == id);
                if (delete != null)
                {
                    conn.Customer.Remove(delete);
                    conn.SaveChanges();
                }
                return delete;
            }
        }
    }
}
