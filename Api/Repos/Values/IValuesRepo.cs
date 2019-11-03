using System.Collections.Generic;
using Api.Models;

namespace Api.Repos.Values
{
    public interface IValuesRepo
    {
        List<Valor> getValues();
    }
}