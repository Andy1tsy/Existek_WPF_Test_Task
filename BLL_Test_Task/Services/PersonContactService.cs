﻿using BLL_Test_Task.Abstract;
using DAL_Test_Task.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Test_Task.Services
{
    public class PersonContactService : IPersonContactService
    {
        private readonly ClientContext db;

        public PersonContactService(ClientContext db)
        {
            this.db = db;
        }

        public async Task<PersonContact> Add(PersonContact personContact)
        {
            var res = await db.PersonContact.AddAsync(personContact);

            await db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<PersonContact> Update(PersonContact personContact)
        {
            var res = db.PersonContact.Update(personContact);

            await db.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await db.PersonContact.FirstOrDefaultAsync(x => x.PersonContactId == id);

            db.Remove(model);

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<PersonContact> Get(int id)
        {
            return await db.PersonContact.FirstOrDefaultAsync(x => x.PersonContactId == id);
        }

        public IEnumerable<PersonContact> Get()
        {
            return db.PersonContact.AsEnumerable();
        }
    }
}
