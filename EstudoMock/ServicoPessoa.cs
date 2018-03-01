using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoMock
{
    public class ServicoPessoa : IServicoPessoa
    {
        public Pessoa GetPessoa(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Pessoa> GetPessoas()
        {
            var lista = new List<Pessoa>();
            return lista;
        }


    }
}
