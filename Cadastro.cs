namespace ProgramaEscola
{
    public class Cadastro
    {
        private static List<Aluno> alunos = new List<Aluno>();

        public void AdicionarAluno(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        public static List<Aluno> Alunos
        {
            get
            {
                return alunos;
            }
        }

        public void ExibirAlunos()
        {
            foreach (var aluno in alunos)
            {
                String matriculas = "";
                foreach(Matricula m in aluno.Matriculas){
                    matriculas += m.Disciplina.Nome + ", Faltas: " + m.Faltas + ", Nota: " + m.Nota;
                }

                Console.WriteLine
                ($"Código : {aluno.CodigoMatricula}\n, Nome: {aluno.Nome}\n, Email: {aluno.Email}\n, Disciplinas: {matriculas}\n, idade{aluno.Idade}");
            
            
            }
        }

        public Aluno BuscarAluno(int codigoMatricula)
        {
            return alunos.Find(a => a.CodigoMatricula == codigoMatricula);
        }
    }
}