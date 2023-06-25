namespace ProgramaEscola
{
    class Program
    {
        static void Main(string[] args)
        {
            var cadastro = new Cadastro();
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar aluno");
                Console.WriteLine("2 - Matricular aluno em disciplina");
                Console.WriteLine("3 - Exibir alunos");
                Console.WriteLine("4 - Verificar aprovação em disciplina");
                Console.WriteLine("5 - Adicionar disciplina");
                Console.WriteLine("6 - Lançar notas e faltas do aluno em disciplina");
                Console.WriteLine("7 - Sair");
                var opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        cadastraAluno(cadastro);
                        break;
                    case "2":
                        matriculaAluno(cadastro);
                        break;
                    case "3":
                        cadastro.ExibirAlunos();
                        break;
                    case "4":
                        verificaNotasEFaltas(cadastro);
                        break;
                    case "5":
                        adicionaDisciplina();
                        break;
                    case "7":
                        lancaNotasEFaltas(cadastro);
                        break;
                    case "8":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

        public static void cadastraAluno(Cadastro cadastro)
        {
            var aluno = new Aluno();
            Console.WriteLine("Nome: ");

            aluno.Nome = Console.ReadLine();
            Console.WriteLine("Email: ");

            aluno.Email = Console.ReadLine();
            Console.WriteLine("Idade: ");

            aluno.Idade = int.Parse(Console.ReadLine());
            cadastro.AdicionarAluno(aluno);
            Console.WriteLine("Aluno adicionado");
        }

        public static void matriculaAluno(Cadastro cadastro)
        {
            Console.WriteLine("Selecione um aluno pelo código");
            cadastro.ExibirAlunos();
            int codigo = int.Parse(Console.ReadLine());
            Aluno alunoEncontrado = cadastro.BuscarAluno(codigo);

            if (alunoEncontrado != null)
            {
                if (Disciplina.ListaDisciplinas.Count() > 0)
                {
                    Console.WriteLine("Agora selecione uma disciplina pelo codigo");
                    Console.WriteLine(Disciplina.imprimeTodasDisciplinas());
                    int codigoDisciplina = int.Parse(Console.ReadLine());
                    Disciplina disciplinaParaMatricula = new Disciplina();
                    disciplinaParaMatricula = Disciplina.encontrarDisciplina(codigoDisciplina);

                    if (disciplinaParaMatricula != null)
                    {
                        disciplinaParaMatricula.LimiteFaltas = 30;
                        disciplinaParaMatricula.NotaMinimaAprovacao = 60;

                        Matricula matricula = new Matricula();
                        String resultadoMatricula = matricula.matricularAluno(alunoEncontrado, disciplinaParaMatricula);
                        Console.WriteLine(resultadoMatricula);
                    }
                    else
                    {
                        Console.WriteLine("Disciplina não encontrada");
                    }

                }
                else
                {
                    Console.WriteLine("Não há disciplinas cadastradas. Utilize a opção 6.");
                }

            }
            else
            {
                Console.WriteLine("Aluno não encontrado");
            }
        }

        public static void verificaNotasEFaltas(Cadastro cadastro)
        {
            Console.Write("Digite o código do aluno: ");
            cadastro.ExibirAlunos();
            var codigoAluno = int.Parse(Console.ReadLine());
            var aluno1 = cadastro.BuscarAluno(codigoAluno);
            if (aluno1 != null)
            {
                if (aluno1.Matriculas.Count() > 0)
                {
                    Console.WriteLine("Agora seleciona uma matrícula: ");
                    Console.WriteLine(aluno1.exibeMatriculas());

                    int codigoDisciplina = int.Parse(Console.ReadLine());
                    Matricula m = aluno1.findMatricula(codigoDisciplina);

                    if (m != null)
                    {
                        if (m.verificaReprovacaoAluno())
                        {
                            Console.WriteLine("Aluno aprovado");
                        }
                        else
                        {
                            Console.WriteLine("Aluno reprovado");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Matrícula não encontrada !");
                    }


                }
                else
                {
                    Console.WriteLine("Aluno não possui matrículas");
                }
            }
            else
            {
                Console.WriteLine("Aluno não encontrado");
            }
        }

        public static void adicionaDisciplina()
        {
            Console.WriteLine("Informe os dados da disciplina: ");

            Console.WriteLine("Nome:");
            string nomeD = Console.ReadLine();

            Console.WriteLine("Nota Mínima Aprovação:");
            float notaMinimaAprovacao = float.Parse(Console.ReadLine());

            Console.WriteLine("Limite de faltas:");
            int limiteFaltas = int.Parse(Console.ReadLine());
            Disciplina disciplina = new Disciplina(nomeD, limiteFaltas, notaMinimaAprovacao);
            Disciplina.adicionarDisciplina(disciplina);
            Console.WriteLine("Disciplina adicionada");
        }

        public static void lancaNotasEFaltas(Cadastro cadastro)
        {
            Console.Write("Digite o código do aluno: ");
            cadastro.ExibirAlunos();
            var codigoAluno1 = int.Parse(Console.ReadLine());
            var aluno2 = cadastro.BuscarAluno(codigoAluno1);
            if (aluno2 != null)
            {
                if (aluno2.Matriculas.Count() > 0)
                {
                    Console.WriteLine("Agora seleciona uma matrícula: ");
                    Console.WriteLine(aluno2.exibeMatriculas());

                    int codigoDisciplina = int.Parse(Console.ReadLine());
                    Matricula m = aluno2.findMatricula(codigoDisciplina);
                    Console.WriteLine("Faltas:");
                    m.Faltas = int.Parse(Console.ReadLine());

                    Console.WriteLine("Nota:");
                    m.Nota = float.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Aluno não possui matrículas");
                }
            }
            else
            {
                Console.WriteLine("Aluno não encontrado");
            }
        }
    }
}