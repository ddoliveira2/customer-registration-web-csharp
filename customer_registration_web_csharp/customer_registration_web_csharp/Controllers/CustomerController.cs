using customer_registration_web_csharp.Dal;
using customer_registration_web_csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace customer_registration_web_csharp.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDal _dal;
        private List<Customer> list;
        private Customer _objCustomer;

        public CustomerController()
        {
            _dal = new CustomerDal();
            list = new List<Customer>();
            _objCustomer = new Customer();
        }
        public IActionResult Index(string codigo, string name, string trigger)
        {
            Int64 _id = 0;
            Int64.TryParse(codigo, out _id);
            if (!string.IsNullOrEmpty(trigger))
            {
                if (_id > 0)
                {
                    if (trigger == "delete")
                    {
                        _dal.DeleteCustomer(_id);
                    }

                    if (trigger == "edit")
                    {
                        return RedirectToAction("Create", "Customer", new { codigo = _id });
                    }
                }
            }


            if (string.IsNullOrEmpty(name))
                name = "";

            list = _dal.GetListCustomer(name);

            return View(list);
        }

        public IActionResult Create(string codigo, IFormCollection form)
        {


            if (Int64.TryParse(codigo, out Int64 _id))
            {
                _objCustomer = _dal.GetOneCustome(codigo);
            }
            return View(_objCustomer);
        }


        [HttpPost]
        public IActionResult Salvar(IFormCollection form)
        {
            
            _objCustomer.name = form["nome"].ToString();
            _objCustomer.rg = form["rg"].ToString();
            _objCustomer.cpf = form["cpf"].ToString();

            if (Int64.TryParse(form["codigo"], out Int64 _id))
            {
                _objCustomer.id = Convert.ToInt64(form["codigo"]);
                 _dal.UpdateCustomer(_id, _objCustomer);
                TempData["Mensagem"] = "Cliente atualizado com sucesso!";
                TempData["TipoMensagem"] = "success";
                return RedirectToAction("Create", new { codigo = form["codigo"].ToString() });
            }
            else {

                Customer create =  _dal.CreateCustomer(_objCustomer);
                _objCustomer.id = create.id;
                TempData["Mensagem"] = "Cliente cadastrado com sucesso!";
                TempData["TipoMensagem"] = "success";
                return RedirectToAction("Create", new { codigo =  create.id.ToString()});
            }
            
        }

    }
}
