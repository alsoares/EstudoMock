using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace EstudoMock.Tests
{
    //Problema:
    //Buscar as pessoas e verificar se 
    //podem se inscrever no curso de de pos graduação pois
    //concluiram uma graduação e tem mais de 18 anos

    [TestClass]
    public class PessoaTest
    {
        private Mock<IServicoPessoa> mockServicoPessoa;
        private SecretariaFaculdade secretariaFaculdade;
        private IList<Pessoa> pessoas = new List<Pessoa>();

        private const int PESSOA_APTA_SEM_MATRICULA = 1;
        private const int PESSOA_INAPTA = 2;
        private const int PESSOA_APTA_COM_MATRICULA = 3;


        public PessoaTest()
        {
            mockServicoPessoa = new Mock<IServicoPessoa>();
            secretariaFaculdade = new SecretariaFaculdade(mockServicoPessoa.Object);

          

            CriarListaPessoas();

            //mockServicoPessoa.Setup(s => s.GetPessoas()).Returns(mockServicoPessoa.Object);

            mockServicoPessoa.Setup(s => s.GetPessoa(PESSOA_APTA_SEM_MATRICULA)).Returns(() => pessoas.Where(w => w.Id == PESSOA_APTA_SEM_MATRICULA).FirstOrDefault());
            mockServicoPessoa.Setup(s => s.GetPessoa(PESSOA_INAPTA)).Returns(() => pessoas.Where(w => w.Id == PESSOA_INAPTA).FirstOrDefault());
            mockServicoPessoa.Setup(s => s.GetPessoa(PESSOA_APTA_COM_MATRICULA)).Returns(() => pessoas.Where(w => w.Id == PESSOA_APTA_COM_MATRICULA).FirstOrDefault());

        }


        [TestMethod]
        public void DeveriaRetornarPessoasTest()
        {

            // arrange
            //IComponentB componentB = new MockComponentB(); // manual approach
            var componentB = MockRepository<IServicoPessoa>(); // Rhino Mocks approach
            var componentA = new SecretariaFaculdade(componentB);


            IServicoPessoa mockServicoPessoaNew = new ServicoPessoa();

            SecretariaFaculdade secretariaFaculdadeNew = new SecretariaFaculdade(mockServicoPessoaNew);


            var pessoas = secretariaFaculdadeNew.GetPessoas();

            Assert.IsNotNull(pessoas, "Deveria retornar uma lista de Pessoas");

        }

        [TestMethod]
        public void DeveriaRetornarUmaPessoaTest()
        {
            var pessoa = secretariaFaculdade.GetPessoa(1);

            Assert.IsNotNull(pessoa, "Deveria retornar uma Pessoa");
        }

        [TestMethod]
        public void DeveriaVerificarSePessoaPossuiMaisDeDezoitoAnos()
        {
            var pessoa = secretariaFaculdade.GetPessoa(PESSOA_APTA_SEM_MATRICULA);

            Assert.IsTrue(pessoa.PossuiMaisDeDezoitoAnos(), "A Pessoa deveria ter 18 anos ou mais");
        }

        [TestMethod]
        public void DeveriaVerificarSePessoaPossuiGraduacao()
        {
            var pessoa = secretariaFaculdade.GetPessoa(PESSOA_APTA_SEM_MATRICULA);

            Assert.IsTrue(pessoa.PossuiGraduacao(), "A Pessoa deveria possuir graduação");
        }

        [TestMethod]
        public void DeverificarVerificarSePessoaPodeSeMatricularNaPosGraduacaoTest()
        {
            var pessoa = secretariaFaculdade.GetPessoa(PESSOA_APTA_SEM_MATRICULA);

            Assert.IsTrue(pessoa.PodeSeMatricularNaPos(), "A Pessoa deveria conseguir se matricular");
        }

        [TestMethod]
        public void DeveriaMatricularPessoaNaPosGraduacaoTest()
        {
            var pessoa = secretariaFaculdade.GetPessoa(PESSOA_APTA_SEM_MATRICULA);

            pessoa.MatricularPos();

            Assert.IsTrue(pessoa.MatriculadoPos, "A Pessoa deveria ter sido matriculada");

        }

        [TestMethod]
        public void DeveriaVerificarSePessoaEstaMatriculadaPosGraduacao()
        {
            var pessoa = secretariaFaculdade.GetPessoa(PESSOA_APTA_COM_MATRICULA);

            Assert.IsTrue(pessoa.EstaMatriculadaNaPos(), "Deveria verificar se a pessoa está matriculada");

        }

        [TestMethod]
        public void DeveriaTrancarMatriculaPosGraduacao()
        {
            var pessoa = secretariaFaculdade.GetPessoa(PESSOA_APTA_COM_MATRICULA);

            pessoa.TrancarPos();

            Assert.IsTrue(!pessoa.MatriculadoPos, "A matricula da Pessoa deveria ter sido trancada");

        }

        private void CriarListaPessoas()
        {

            pessoas.Add(new Pessoa()
            {
                Id = 1,
                Idade = 24,
                Nome = "André Soares",
                Graduacao = true
            });

            pessoas.Add(new Pessoa()
            {
                Id = 2,
                Idade = 17,
                Nome = "João Soares",
                Graduacao = false
            });

            pessoas.Add(new Pessoa()
            {
                Id = 3,
                Idade = 60,
                Nome = "Lúcio Soares",
                Graduacao = true,
                MatriculadoPos = true
            });

          
        }
    }
}
