using DAL_Test_Task.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Test_Task.Services
{
    public class PersonService : IPersonService
    {
        private readonly ClientContext db;

        public PersonService(ClientContext db)
        {
            this.db = db;
        }

        public async Task<Person> Add(Person person)
        {
            var res = await db.Person.AddAsync(person);

            await db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Person> Update(Person person)
        {
            var res = db.Person.Update(person);

            await db.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await db.Person.FirstOrDefaultAsync(x => x.Id == id);

            db.Remove(model);

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Person> Get(int id)
        {
            return await db.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Person> Get()
        {
            return db.Person.ToListAsync().Result;
        }
    }
}
