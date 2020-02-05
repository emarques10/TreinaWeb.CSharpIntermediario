using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoGenerics
{
    public class RepositorioGenerico<T>
    {
        private List<T> list;

        public RepositorioGenerico()
        {
            list = new List<T>();
        }

        public List<T> Get()
        {
            return list;
        }

        public void Insert(T objeto)
        {
            list.Add(objeto);
        }
    }
}
