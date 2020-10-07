using MyReview.Visao;
using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MyReview.Controle
{
    class ControleConfig
    {
        public Config conf = new Config();
        private String arquivo = "config.json";
        private JavaScriptSerializer serialJson = new JavaScriptSerializer();


        public void carregaConfig()
        {
            try
            {
                String arquivoLido = System.IO.File.ReadAllText(arquivo);
                conf = serialJson.Deserialize<Config>(arquivoLido);           
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro ao ler arquivo de configurações!\n" + "Mensagem de Erro:" + error.Message);
            }
        }
        public Boolean salvaConfig(Config aux)
        {
            Boolean _return = false;
            try
            {
                String configAtu = serialJson.Serialize(aux);
                System.IO.File.WriteAllText(arquivo, configAtu); 
                _return = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao salvar arquivo de configurações!\n" + "Mensagem de Erro:" + error.Message);
            }
            return _return;
        }
    }
}
