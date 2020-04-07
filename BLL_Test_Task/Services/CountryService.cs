using BLL_Test_Task.Abstract;
using DAL_Test_Task.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Test_Task.Services
{
    public class CountryService : ICountryService
    {
        private readonly ClientContext db;

        public CountryService(ClientContext db)
        {
            this.db = db;
        }

        public async Task<Country> Add(Country country)
        {
            var res = await db.Country.AddAsync(country);

            await db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Country> Update(Country country)
        {
            var res = db.Country.Update(country);

            await db.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> Delete(string code)
        {
            var model = await db.Country.FirstOrDefaultAsync(x => x.Code == code);

            db.Remove(model);

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Country> Get(string code)
        {
            return await db.Country.FirstOrDefaultAsync(x => x.Code == code);
        }

        public IEnumerable<Country> Get()
        {
            return db.Country.AsEnumerable();
        }
    }
}
