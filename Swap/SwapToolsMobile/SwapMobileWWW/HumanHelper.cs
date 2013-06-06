using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Globalization;
using System.Data;

namespace SwapMobileWWW
{
    public class HumanHelper
    {
        public static int ObterUltimoID()
        {
            int idHuman = 0;

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DbConnection"].ToString());
            SqlCommand cmd = new SqlCommand("proc_ObterIdHuman", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter pIdHuman = new SqlParameter("@idHuman", System.Data.SqlDbType.Int);
            pIdHuman.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(pIdHuman);
            try
            {
                con.Open();
                int numLinhas = cmd.ExecuteNonQuery();
                idHuman = (int)pIdHuman.Value;
            }
            catch (Exception exx)
            {

            }
            finally
            {
                con.Close();
            }
            return idHuman;
        }

        public static bool SalvarMO(MOHuman mo)
        {
            bool retorno = false;

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DbConnection"].ToString());
            SqlCommand cmd = new SqlCommand("udp_RetornoZenvia_ups", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter idRetorno = new SqlParameter("@idRetorno", System.Data.SqlDbType.Int);
            SqlParameter ZenviaId = new SqlParameter("@ZenviaId", System.Data.SqlDbType.VarChar);
            SqlParameter ZenviaFrom = new SqlParameter("@ZenviaFrom", System.Data.SqlDbType.VarChar);
            SqlParameter ZenviaTo = new SqlParameter("@ZenviaTo", System.Data.SqlDbType.VarChar);
            SqlParameter ZenviaMsg = new SqlParameter("@ZenviaMsg", System.Data.SqlDbType.VarChar);
            SqlParameter ZenviaDate = new SqlParameter("@ZenviaDate", System.Data.SqlDbType.VarChar);
            SqlParameter ZenviaAccount = new SqlParameter("@ZenviaAccount", System.Data.SqlDbType.VarChar);
            SqlParameter dataHoraRecebimento = new SqlParameter("@dataHoraRecebimento", System.Data.SqlDbType.DateTime);
            idRetorno.Value = 0;
            ZenviaId.Value = mo.Id;
            ZenviaFrom.Value = mo.From;
            ZenviaTo.Value = mo.To;
            ZenviaMsg.Value = mo.Msg;
            ZenviaDate.Value = mo.Date_;
            ZenviaAccount.Value = mo.Account;
            dataHoraRecebimento.Value = DateTime.Now;
            cmd.Parameters.Add(idRetorno);
            cmd.Parameters.Add(ZenviaId);
            cmd.Parameters.Add(ZenviaFrom);
            cmd.Parameters.Add(ZenviaTo);
            cmd.Parameters.Add(ZenviaMsg);
            cmd.Parameters.Add(ZenviaDate);
            cmd.Parameters.Add(ZenviaAccount);
            cmd.Parameters.Add(dataHoraRecebimento);


            try
            {
                con.Open();
                int numLinhas = cmd.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception exx)
            {
                retorno = false;
            }
            finally
            {
                con.Close();
            }
            return retorno;
        }

        public static string RemoverAcentos(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString();
        }

        public static DataSet ListaMos()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DbConnection"].ToString());
            SqlCommand cmd = new SqlCommand("udp_RetornoZenvia_lst", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception exx)
            {
                ds = null;
            }
            finally
            {
                con.Close();
            }
            return ds;

        }

        public static DataSet ListaContatos(int idUsuario)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DbConnection"].ToString());
            SqlCommand cmd = new SqlCommand("udp_Contatos_sel_byIdUsuario", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception exx)
            {
                ds = null;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public static bool CriaContato(int _idUsuario, string _Nome, string _Sobrenome, string _DDD, string _Pais, string _Celular,
                                        string _Empresa, string _Email)
        {
            bool retorno = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DbConnection"].ToString());
            SqlCommand cmd = new SqlCommand("udp_Contatos_ups", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter idContato = new SqlParameter("@idContato", System.Data.SqlDbType.Int);
            SqlParameter idUsuario = new SqlParameter("@idUsuario", System.Data.SqlDbType.Int);
            SqlParameter Nome = new SqlParameter("@Nome", System.Data.SqlDbType.VarChar);
            SqlParameter Sobrenome = new SqlParameter("@Sobrenome", System.Data.SqlDbType.VarChar);
            SqlParameter DDD = new SqlParameter("@DDD", System.Data.SqlDbType.VarChar);
            SqlParameter Pais = new SqlParameter("@Pais", System.Data.SqlDbType.VarChar);
            SqlParameter Celular = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
            SqlParameter DataCadastro = new SqlParameter("@DataCadastro", System.Data.SqlDbType.DateTime);
            SqlParameter Empresa = new SqlParameter("@Empresa", System.Data.SqlDbType.VarChar);
            SqlParameter Email = new SqlParameter("@Email", System.Data.SqlDbType.DateTime);
            idContato.Value = 0; // Indica para criação de um novo contato
            idUsuario.Value = _idUsuario;
            Nome.Value = _Nome;
            Sobrenome.Value = _Sobrenome;
            DDD.Value = _DDD;
            Pais.Value = _Pais;
            Celular.Value = _Celular;
            Empresa.Value = _Empresa;
            Email.Value = _Email;
            DataCadastro.Value = DateTime.Now;

            cmd.Parameters.Add(idContato);
            cmd.Parameters.Add(idUsuario);
            cmd.Parameters.Add(Nome);
            cmd.Parameters.Add(Sobrenome);
            cmd.Parameters.Add(DDD);
            cmd.Parameters.Add(Pais);
            cmd.Parameters.Add(Celular);
            cmd.Parameters.Add(DataCadastro);
            cmd.Parameters.Add(Empresa);
            cmd.Parameters.Add(Email);
            try
            {
                con.Open();
                int numLinhas = cmd.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception exx)
            {
                retorno = false;
            }
            finally
            {
                con.Close();
            }
            return retorno;
        }

    }
}