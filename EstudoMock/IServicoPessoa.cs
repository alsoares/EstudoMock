using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoMock
{
    public interface IServicoPessoa
    {
        IList<Pessoa> GetPessoas();

        Pessoa GetPessoa(int id);
    }
}
