﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Subject
{
    public class SubjectsRepository : EFRepository<Entities.Subject>, ISubjectRepository
    {
        public SubjectsRepository(ScheduleContext context) : base(context)
        {
        }

        public override async Task<bool> Add(Entities.Subject item)
        {
            item.Id = 0;

            await Context.Subjects.AddAsync(item);

            return true;
        }

        public override async Task<bool> AddRange(IEnumerable<Entities.Subject> entities)
        {
            var list = entities as Entities.Subject[] ?? entities.ToArray();
            foreach (var item in list)
            {
                item.Id = 0;

                // TODO VALIDATIONS
            }

            await Context.Subjects.AddRangeAsync(list);

            return true;
        }

        public override IQueryable<Entities.Subject> Read()
        {
            return Context.Subjects.AsQueryable();
        }

        public override IQueryable<Entities.Subject> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Update(Entities.Subject item)
        {
            Context.Entry(item).State = EntityState.Modified;

            return Task.FromResult(true);
        }

        public override async Task<bool> Delete(int id)
        {
            var item = await Context.Subjects.Where(subject => subject.Id == id).FirstOrDefaultAsync();

            if (item != null)
            {
                Context.Subjects.Remove(item);
                return true;
            }

            return false;
        }

        public Task<bool> RemoveAll(int groupId)
        {
            throw new NotImplementedException();
        }
    }
}
