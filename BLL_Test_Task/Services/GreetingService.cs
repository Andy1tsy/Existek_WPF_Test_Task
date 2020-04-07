using DAL_Test_Task.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Test_Task.Services
{
    public class GreetingService : IGreetingService
    {
        private readonly ClientContext db;

        public GreetingService(ClientContext db)
        {
            this.db = db;
        }

        public async Task<Greeting> Add(Greeting greeting)
        {
            var res = await db.Greeting.AddAsync(greeting);

            await db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Greeting> Update(Greeting greeting)
        {
            var res = db.Greeting.Update(greeting);

            await db.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await db.Greeting.FirstOrDefaultAsync(x => x.Id == id);

            db.Remove(model);

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Greeting> Get(int id)
        {
            return await db.Greeting.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Greeting> Get()
        {
            return db.Greeting.AsEnumerable();
        }
    }
}

