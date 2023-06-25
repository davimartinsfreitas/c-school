namespace ProgramaEscola
{

    public class Matricula
    {

        private int faltas;

        private float nota;

        private Disciplina disciplina;

        public Matricula()
        {

        }

        public Matricula(int faltas, float nota, Disciplina disciplina)
        {
            this.faltas = faltas;
            this.nota = nota;
            this.disciplina = disciplina;
        }

        public int Faltas
        {
            get
            {
                return faltas;
            }

            set
            {
                faltas = value;
            }
        }

        public float Nota
        {
            get
            {
                return nota;
            }

            set
            {
                nota = value;
            }
        }
        public Disciplina Disciplina
        {
            get
            {
                return disciplina;
            }

            set
            {
                disciplina = value;
            }
        }

        public Boolean verificaReprovacaoAluno()
        {
            return this.faltas < this.disciplina.LimiteFaltas
            && this.nota >= this.disciplina.NotaMinimaAprovacao;
        }

        public String matricularAluno(Aluno aluno, Disciplina disciplina)
        {
            this.disciplina = disciplina;
            this.faltas = 0;
            this.nota = 0;

            Matricula m = aluno.findMatricula(disciplina.Codigo);
            if (m == null)
            {
                aluno.addMatricula(this);
                return "Matriculado com sucesso";
            }else{
                return "Aluno já matriculado nessa disciplina";
            }

        }

        public void lancarFaltas()
        {
            faltas++;
        }

        public override string ToString()
        {
            return "fuck";
        }
    }
}