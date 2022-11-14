using Ardalis.Specification.EntityFrameworkCore;
using SBAPI.Application.Repository;
using SBAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Infraestructure.Repository
{
    public class CustomRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly SmartContext db;

        public CustomRepositoryAsync(SmartContext db) : base(db)
        {
            this.db = db;
        }
    }
}
