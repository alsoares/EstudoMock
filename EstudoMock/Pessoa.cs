using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoMock
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public byte Idade { get; set; }

        public bool Graduacao { get; set; }

        public bool MatriculadoPos { get; set; }

        public bool PossuiMaisDeDezoitoAnos()
        {
            return this.Idade >= 18;
        }

        public bool PossuiGraduacao()
        {
            return this.Graduacao;
        }

        public bool PodeSeMatricularNaPos()
        {
            return PossuiMaisDeDezoitoAnos() && PossuiGraduacao() && !EstaMatriculadaNaPos();
        }

        public void MatricularPos()
        {
            if (PodeSeMatricularNaPos())
                this.MatriculadoPos = true;
        }

        public bool EstaMatriculadaNaPos()
        {
            return this.MatriculadoPos;
        }

        public void TrancarPos()
        {
            if(EstaMatriculadaNaPos())
                this.MatriculadoPos = false;
        }

        



    }
}
