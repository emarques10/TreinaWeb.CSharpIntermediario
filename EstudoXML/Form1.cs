using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EstudoXML
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CriarContato();
            lblTitulo.Text = CarregarTitulo();
            CarregarContatos();
        }

        private string CarregarTitulo()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"c:\users\local_8pejg1\documents\visual studio 2015\Projects\Treinaweb.CSharpIntermediario\EstudoXML\Agenda.xml");
            XmlNode noTitulo = documentoXml.SelectSingleNode("/agenda/titulo");
            return noTitulo.InnerText;
        }

        private void CarregarContatos()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"c:\users\local_8pejg1\documents\visual studio 2015\Projects\Treinaweb.CSharpIntermediario\EstudoXML\Agenda.xml");
            XmlNodeList contatos = documentoXml.SelectNodes("/agenda/contatos/contato");
            foreach(XmlNode contato in contatos)
            {
                string representacaoContato = "";
                string id = contato.Attributes["id"].Value;
                string nome = contato.Attributes["nome"].Value;
                string idade = contato.Attributes["idade"].Value;
                representacaoContato = nome + ", " + idade + " ," + id;
                lbxContatos.Items.Add(representacaoContato);
            }

        }

        private void CriarContato()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"c:\users\local_8pejg1\documents\visual studio 2015\Projects\Treinaweb.CSharpIntermediario\EstudoXML\Agenda.xml");
            XmlAttribute atributoId = documentoXml.CreateAttribute("id");
            atributoId.Value = "5";

            XmlAttribute atributoNome = documentoXml.CreateAttribute("nome");
            atributoNome.Value = "Teste";

            XmlAttribute atributoIdade = documentoXml.CreateAttribute("idade");
            atributoIdade.Value = "31";

            XmlNode novoContato = documentoXml.CreateElement("contato");
            novoContato.Attributes.Append(atributoId);
            novoContato.Attributes.Append(atributoNome);
            novoContato.Attributes.Append(atributoIdade);

            XmlNode contatos = documentoXml.SelectSingleNode("/agenda/contatos");
            contatos.AppendChild(novoContato);

            documentoXml.Save(@"c: \users\local_8pejg1\documents\visual studio 2015\Projects\Treinaweb.CSharpIntermediario\EstudoXML\Agenda.xml");
        }
    }
}
