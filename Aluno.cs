namespace ProgramaEscola
{

    public class Aluno
    {

        private string nome;
        private int codigoMatricula;

        private int idade;

        private string email;

        private List<Matricula> matriculas;

        public Aluno()
        {
            this.codigoMatricula = geraCodigoMatricula();
            matriculas = new List<Matricula>();
        }

        public Aluno(string nome, int idade, string email)
        {
            this.nome = nome;
            this.email = email;
            this.codigoMatricula = geraCodigoMatricula();
            this.idade = idade;
            matriculas = new List<Matricula>();
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int CodigoMatricula
        {
            get { return codigoMatricula; }
            set { codigoMatricula = value; }
        }

        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public List<Matricula> Matriculas
        {
            get { return matriculas; }
            set { matriculas = value; }
        }

        public void addMatricula(Matricula matricula)
        {
            matriculas.Add(matricula);
        }

        public void removeMatricula(Matricula matricula)
        {
            this.matriculas.Remove(matricula);
        }

        public int geraCodigoMatricula()
        {
            return Cadastro.Alunos.Count + 1;
        }

        public String exibeMatriculas()
        {
            string dados = "";
            foreach (Matricula m in matriculas)
            {
                dados += "Código Disciplina : " + m.Disciplina.Codigo
                + " - Nome:  " + m.Disciplina.Nome + " Faltas: " + m.Faltas + " Nota: " + m.Nota + "/n";
            }
            return dados;
        }

        public Matricula findMatricula(int codigoDisciplina)
        {
            return matriculas.Find(m => m.Disciplina.Codigo == codigoDisciplina);
        }
    }
}