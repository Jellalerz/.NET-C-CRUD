using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
namespace AspNetAspxCRUD
{
    public partial class Inicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Regex name = new Regex(@"^[a-zA-Z.+'-]+(?:\s[a-zA-Z.+'-]+)*\s?$");
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            //int n;
            //bool isNumeric = int.TryParse(txbIdade.Text, out n);

            int age;
            int? val = Int32.TryParse(txbIdade.Text, out age) ? Int32.Parse(txbIdade.Text) : (int?)null;
            int altura;
            int? valx = Int32.TryParse(txbAltura.Text, out altura) ? Int32.Parse(txbAltura.Text) : (int?)null;

            if (!name.IsMatch(txbNome.Text))
            {
                lblnombre.Text = "Nombre Incorrecto!";
            }
            else
            {
                lblnombre.Text = "";
            }
            if (txbIdade.Text == "" || txbIdade.Text == null || string.IsNullOrWhiteSpace(txbIdade.Text) || age <1 || age > 100)
            {
                lbledad.Text = "Edad no valida!";
            }
            else
            {
                lbledad.Text = "";
            }
            if (txbAltura.Text == "" || txbAltura.Text == null || string.IsNullOrWhiteSpace(txbAltura.Text) || altura < 60 || altura > 260)
            {
                lblaltura.Text = "Estatura en cm no valida!";
            }
            else
            {
                lblaltura.Text = "";
            }
            if (!name.IsMatch(txbLastname.Text))
            {
                lbllastname.Text = "Apellido incorrecto!";
            }
            else
            {
                lbllastname.Text = "";
            }

            if (name.IsMatch(txbNome.Text) && age >= 1 && age <= 100 && altura >= 60 && altura <= 260 && name.IsMatch(txbLastname.Text))
            {
                
                Alumnos p = new Alumnos();
                p.nome = txbNome.Text;
                p.idade = int.Parse(txbIdade.Text);
                p.altura = int.Parse(txbAltura.Text);
                p.lastnamo = txbLastname.Text;



                if (p.gravarPessoa())
                {
                    lblGravou.Text = "Success";
                }
                else
                {
                    lblGravou.Text = "Error";
                }
            }

            
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Conex bd = new Conex();

            dt = bd.executeQuery("select * from students2");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Alumnos p = new Alumnos();
            p.id = int.Parse(txbIdExcluir.Text);

            if (p.excluirPessoa())
            {
                lblGravou.Text = "Delete";
            }
            else
            {
                lblGravou.Text = "Error";
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Alumnos p = new Alumnos();
            p.id = int.Parse(txbIdAlt.Text);
            p.nome = txbNomeAlt.Text;
            p.idade = int.Parse(txbIdadeAlt.Text);
            p.altura = int.Parse(txbAlturaAlt.Text);
            p.lastnamo = txbApellido.Text;

            if (p.alterarPessoa())
            {
                lblAlterou.Text = "Updated";
            }
            else
            {
                lblAlterou.Text = "Error";
            }
        }

        protected void btnDataReader_Click(object sender, EventArgs e)
        {
            Alumnos p = new Alumnos();
            p = p.retornaPessoa(1);
            lblDataReader.Text = p.nome;
        }
    }
}