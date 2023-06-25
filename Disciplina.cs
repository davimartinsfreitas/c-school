namespace ProgramaEscola
{
    public class Disciplina
    {

        private static List<Disciplina> listaDisciplinas = new List<Disciplina>();

        private int codigo;

        private string nome;

        private int limiteFaltas;

        private float notaMinimaAprovacao;

        public Disciplina()
        {
            this.codigo = incrementaCodigo();
        }

        public Disciplina(string nome, int limiteFaltas, float notaMinimaAprovacao)
        {
            this.nome = nome;
            this.limiteFaltas = limiteFaltas;
            this.notaMinimaAprovacao = notaMinimaAprovacao;
            this.codigo = incrementaCodigo();
        }

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

         public int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }


        public int LimiteFaltas
        {
            get
            {
                return limiteFaltas;
            }
            set
            {
                limiteFaltas = value;
            }
        }

        public float NotaMinimaAprovacao
        {
            get
            {
                return notaMinimaAprovacao;
            }
            set
            {
                notaMinimaAprovacao = value;
            }
        }

        public static List<Disciplina> ListaDisciplinas{
            get{
                return listaDisciplinas;
            }
        }

        private int incrementaCodigo()
        {
            return listaDisciplinas.Count + 1;
        }

        public static void adicionarDisciplina(Disciplina disciplina)
        {
            listaDisciplinas.Add(disciplina);
        }

        public String retornaDadosDisciplina()
        {
            return "Esta é a disciplina de + " + this.nome + ", que possui frequência mínima de " + limiteFaltas
            + " e nota mínima para aprovação de" + this.notaMinimaAprovacao;
        }

        public static String imprimeTodasDisciplinas(){
            String dados = "";
            foreach(Disciplina d in listaDisciplinas){
                dados +=  
                "Código " + d.codigo + " Nome: " + d.nome;
            }
            return dados;
        }

        public static Disciplina encontrarDisciplina(int codigo)
        {
            return listaDisciplinas.Find(d => d.codigo == codigo);
        }
    }
}