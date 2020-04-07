using AutoMapper;
using BLL_Test_Task.Abstract;
using DAL_Test_Task.Entities;

using DAL_Test_Task.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Test_Task.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ClientContext db;
        private IMapper _mapper;
        public CustomerService(ClientContext db, IMapper mapper)
        {
            this.db = db;
            _mapper = mapper;
        }

        //public async Task<Customer> Add(Customer customer)
        //{
        //    var res = await db.Country.AddAsync(country);

        //    await db.SaveChangesAsync();
        //    return res.Entity;
        //}

        //public async Task<Customer> Update(Customer customer)
        //{
        //    var res = db.Country.Update(country);

        //    await db.SaveChangesAsync();

        //    return res.Entity;
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    var model = await db.Country.FirstOrDefaultAsync(x => x.Id == id);

        //    db.Remove(model);

        //    await db.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<Customer> Get(string code)
        //{
        //    return await db.Country.FirstOrDefaultAsync(x => x.Code == code);
        //}

        public IEnumerable<Customer> Get()
        {
            var countries = db.Country.AsEnumerable();
            var greetings = db.Greeting.AsEnumerable();
            var persons = db.Person.AsEnumerable();
            var personContacts = db.PersonContact.AsEnumerable();
            var customers = new List<Customer>();
            foreach (var person in persons)
            {
                var customer = _mapper.Map<Customer>(person);
                customers.Add(customer);
            }
           IEnumerable<Customer> result = customers;
            return result;
        }

        public async Task<int> Save(IEnumerable<Customer> customers)
        {
            var persons = new List<Person>();
            var personContacts = new List<PersonContact>();

            foreach (var customer in customers)
            {
                var person = _mapper.Map<Person>(customer);
                persons.Add(person);
                foreach (var customerContact in customer.CustomerContacts)
                {
                    var contact = _mapper.Map<PersonContact>(customerContact);
                    personContacts.Add(contact);
                }
            }
            db.Person.UpdateRange(persons);
            db.PersonContact.UpdateRange(personContacts);
            return await db.SaveChangesAsync();
        }

    }
}

