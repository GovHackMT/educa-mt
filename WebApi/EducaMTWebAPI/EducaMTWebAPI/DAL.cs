using EducaMTWebAPI.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace EducaMTWebAPI
{
    public class DAL
    {
        static string serverName = "govhack.cpghth3efxd9.sa-east-1.rds.amazonaws.com";                                          //localhost
        static string port = "5432";                                                            //porta default
        static string userName = "govhack";                                               //nome do administrador

        
        static string password = "govhackmt10";                                             //senha do administrador
        static string databaseName = "govhack";                                       //nome do banco de dados

        
        NpgsqlConnection pgsqlConnection = null;
        string connString = null;

        public DAL()
        {
            connString = string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                              serverName, port, userName, password, databaseName);
        }

        
        public void EnviarDiario(IEnumerable<Diario> dto, int disciplinaId)
        {
            foreach (var diario in dto)
            {
                GravarDiario(diario, disciplinaId);
            }
        }

        private void GravarDiario(Diario diario, int disciplinaId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    var presenca = diario.Faltou ? "N" : "S";
                    var dataAtual = DateTime.Today.ToString("yyyy-MM-dd");
                    string cmdInsert = "insert into diario_classe(id_disciplina, id_aluno, data_diario, presenca_aula)"+
                        $"values({disciplinaId},{diario.Id}, '{dataAtual}', '{presenca}')";

                    using (NpgsqlCommand command = new NpgsqlCommand(cmdInsert, pgsqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }



        //Pega todos os registros
        public IEnumerable<Aluno> GetTodosAlunos()
        {
            DataTable dt = new DataTable();
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "Select * from aluno order by ds_aluno";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            var alunos = new List<Aluno>();
            foreach (DataRow d in dt.Rows)
            {
                alunos.Add(new Aluno
                {
                    Id = (int)d["id_aluno"],
                    Nome = d["ds_aluno"].ToString(),
                    DataNascimento = (DateTime)d["data_nascimento"]
                });
            }
            return alunos;
        }

        public IEnumerable<Disciplina> GetTodasDisciplinas()
        {
            DataTable dt = new DataTable();
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "Select * from disciplina order by ds_disciplina";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            var disciplinas = new List<Disciplina>();
            foreach (DataRow d in dt.Rows)
            {
                disciplinas.Add(new Disciplina
                {
                    Id = (int)d["id_disciplina"],
                    Nome = d["ds_disciplina"].ToString(),
                    Turma = d["ds_turma"].ToString(),
                    Periodo = d["periodo"].ToString(),
                });
            }
            return disciplinas;
        }

        public IEnumerable<Disciplina> GetDisciplinasPorProfessor(int professorId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = $"Select * from disciplina where id_professor = {professorId} order by ds_disciplina";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            var disciplinas = new List<Disciplina>();
            foreach (DataRow d in dt.Rows)
            {
                disciplinas.Add(new Disciplina
                {
                    Id = (int)d["id_disciplina"],
                    Nome = d["ds_disciplina"].ToString(),
                    Turma = d["ds_turma"].ToString(),
                    Periodo = d["periodo"].ToString(),
                });
            }
            return disciplinas;
        }

        public IEnumerable<Diario> GetDiarioInicial(int professorId, int disciplinaId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = $"Select * from vw_diario_temp where id_professor = {professorId} and id_disciplina = {disciplinaId} order by ds_aluno";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            var diario = new List<Diario>();
            foreach (DataRow d in dt.Rows)
            {
                diario.Add(new Diario
                {
                    Id = (int)d["id_aluno"],
                    Nome = d["ds_aluno"].ToString(),
                    Faltou = false,                    
                });
            }
            return diario;
        }

        public IEnumerable<Filho> GetFilhosPorResponsavel(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = $"select a.ds_aluno, a.id_aluno " +
                                          "from aluno a " +
                                          "join rl_responsavel_aluno r on r.id_aluno = a.id_aluno " +
                                          $"where r.id_responsavel_aluno = {id}";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            var filhos = new List<Filho>();
            foreach (DataRow d in dt.Rows)
            {
                filhos.Add(new Filho
                {
                    Id = (int)d["id_aluno"],
                    Nome = d["ds_aluno"].ToString(),                    
                });
            }
            return filhos;
        }

        public IEnumerable<RelatorioPresenca> GetRelatoioPresenca(int alunoId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = $"select * from presenca_alunos_dia where id_aluno = {alunoId}";                    

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            var relatorio = new List<RelatorioPresenca>();
            foreach (DataRow d in dt.Rows)
            {
                relatorio.Add(new RelatorioPresenca
                {
                    Data = (DateTime)d["data_diario"],
                    Status = (int) d["status"],
                    Observacao = GetObservacao((int)d["status"])
                });
            }
            return relatorio;
        }

        private string GetObservacao(int status)
        {
            if (status == 1)
                return "Presente por período integral";
            else if (status == 2)
                return "Aluno não compareceu na escola";
            else if (status == 3)
                return "Aluno não assistiu todas as aulas";
            else
                return string.Empty;
        }

        public Aluno GetAluno(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = $"select * from aluno where id_aluno = {id}";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            Aluno aluno  = new Aluno();
            DataRow d = dt.Rows[0];
            if (d != null)
            {
                aluno = new Aluno
                {
                    Id = (int)d["id_aluno"],
                    Nome = d["ds_aluno"].ToString(),
                    DataNascimento = (DateTime)d["data_nascimento"]
                };
            }
            return aluno;
        }
    }
}