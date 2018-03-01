using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoMock
{
    public class SecretariaFaculdade
    {
        private IServicoPessoa _servicoPessoa;
        public SecretariaFaculdade(IServicoPessoa servicoPessoa)
        {
            _servicoPessoa = servicoPessoa;
        }

        public Pessoa GetPessoa(int id)
        {
            return _servicoPessoa.GetPessoa(id);
        }

        public IList<Pessoa> GetPessoas()
        {
            return _servicoPessoa.GetPessoas();
        }
    }
}
