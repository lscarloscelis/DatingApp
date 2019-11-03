using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Models;

namespace Api.Repos.Values
{
    public class ValuesRepo : IValuesRepo
    {
        private readonly DatingAppDbContext datingAppDbContext;
        public ValuesRepo(DatingAppDbContext datingAppDbContext)
        {
            this.datingAppDbContext = datingAppDbContext;
        }
        public List<Valor> getValues()
        {
            return datingAppDbContext.Valores.ToList();
        }
    }
}