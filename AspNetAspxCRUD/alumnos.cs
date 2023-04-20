using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspNetAspxCRUD
{
    public class Alumnos
    {
        public int id;
        public string nome;
        public int idade;
        public int altura;
        public string lastnamo;
        

        public bool gravarPessoa()
        {
            Conex bd = new Conex();

            SqlConnection cn = bd.abrirconexion();
            SqlTransaction tran = null;

            SqlCommand cmd = new SqlCommand();
            tran = cn.BeginTransaction();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into students2 values (@nombre, @edad, @altura, @lastname)";
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
            cmd.Parameters.Add("@edad", SqlDbType.Int);
            cmd.Parameters.Add("@altura", SqlDbType.Int);
            cmd.Parameters.Add("@lastname", SqlDbType.VarChar);
            cmd.Parameters[0].Value = nome;
            cmd.Parameters[1].Value = idade;
            cmd.Parameters[2].Value = altura;
            cmd.Parameters[3].Value = lastnamo;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.cerrarconexion();
            }
        }

        public bool excluirPessoa()
        {
            Conex bd = new Conex();

            SqlConnection cn = bd.abrirconexion();
            SqlTransaction tran = null;

            SqlCommand cmd = new SqlCommand();
            tran = cn.BeginTransaction();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from students2 where id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters[0].Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.cerrarconexion();
            }
        }

        public bool alterarPessoa()
        {
            Conex bd = new Conex();

            SqlConnection cn = bd.abrirconexion();
            SqlTransaction tran = null;

            SqlCommand cmd = new SqlCommand();
            tran = cn.BeginTransaction();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "update students2 set nombre = @nombre, edad = @edad, altura = @altura where id = @id";
            cmd.CommandText = "update students2 set nombre = @nombre, edad = @edad, altura = @altura, lastname = @lastname where id = @id";
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
            cmd.Parameters.Add("@edad", SqlDbType.Int);
            cmd.Parameters.Add("@altura", SqlDbType.Int);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters.Add("@lastname", SqlDbType.VarChar);
            cmd.Parameters[0].Value = nome;
            cmd.Parameters[1].Value = idade;
            cmd.Parameters[2].Value = altura;
            cmd.Parameters[3].Value = id;
            cmd.Parameters[4].Value = lastnamo;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.cerrarconexion();
            }
        }

        public Alumnos retornaPessoa(int id)
        {
            Conex bd = new Conex();

            try
            {
                SqlConnection cn = bd.abrirconexion();
                SqlDataReader rdr = null;

                SqlCommand sqlComm = new SqlCommand("select * from students2", cn);

                rdr = sqlComm.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr.GetInt32(0) == id)
                    {
                        id = 1;
                        nome = rdr.GetString(1);
                        idade = rdr.GetInt32(2);
                        altura = rdr.GetInt32(3);

                        return this;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                bd.cerrarconexion();
            }
        }
    }
}