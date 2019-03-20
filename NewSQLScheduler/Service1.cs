using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace NewSQLScheduler_Energia
{
    public partial class NewSQLScheduler_Energia : ServiceBase
    {

        Timer timer1;
        string SQLServerHost = "localhost";

        public NewSQLScheduler_Energia()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            // atraso de inicialização / timer
           timer1 = new Timer(new TimerCallback(timer1_Tick), null, 20000, 60000);
           SQLServerHost = getSQLServerName();
           Util.logInFile("PROJETO PILOTO --> Sistema Iniciado... Verificando novos arquivos a cada 1 minuto - Servidor SQL: " + SQLServerHost, "Info");

        }

        protected override void OnStop()
        {
        }


        private void timer1_Tick(object sender)
        {


            string diretorio = "c://FTP//";

            //pega os arquivos da pasta c:\ FTP
            DirectoryInfo di = new DirectoryInfo(diretorio);
            FileInfo[] rgFiles = di.GetFiles("VMU-*.csv");

            //variaveis lidas do arquivo
            DateTime timestamp = DateTime.UtcNow;
            double VMU_CONSUMO_KWH;
            double VMU_TENSAO_FASE1;
            double VMU_TENSAO_FASE2;
            double VMU_TENSAO_FASE3;
            double VMU_CORRENTE_FASE1;
            double VMU_CORRENTE_FASE2;
            double VMU_CORRENTE_FASE3;
            double VMU_TENSAO_DC;
            double VMU_CORRENTE_DC;
            double VMU_POTENCIA_DC;
            double VMU_TEMPERATURA_AMBIENTE;
            double VMU_TEMPERATURA_PLACA;


            string line = string.Empty;
            string path = string.Empty;
            string[] fields;


            bool acRead;
            bool dcRead;
            bool enRead;
            int ponto;
            int tamanho;

            foreach (FileInfo fi in rgFiles)
            {

                try
                {
                    path = diretorio + fi.Name;

                    using (StreamReader inputFile = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                    {

                        //zera variaveis ao ler o arquivo. Em alguns arquivos não vem as variáveis.
                        VMU_CONSUMO_KWH = 0;
                        VMU_TENSAO_FASE1 = 0;
                        VMU_TENSAO_FASE2 = 0;
                        VMU_TENSAO_FASE3 = 0;
                        VMU_CORRENTE_FASE1 = 0;
                        VMU_CORRENTE_FASE2 = 0;
                        VMU_CORRENTE_FASE3 = 0;
                        VMU_TENSAO_DC = 0;
                        VMU_CORRENTE_DC = 0;
                        VMU_POTENCIA_DC = 0;
                        VMU_TEMPERATURA_AMBIENTE = 0;
                        VMU_TEMPERATURA_PLACA = 0;
                        acRead = true;
                        dcRead = true;
                        enRead = true;

                        while (!inputFile.EndOfStream)
                        {
                            line = inputFile.ReadLine();
                            fields = line.Split(';');

                            if (fields.Length > 1)
                            {
                                if ((fields[0].Equals("AC")) && fields[3].Equals("ABB") && acRead) //le variaveis AC
                                {

                                    ponto = fields[8].LastIndexOf(".");
                                    tamanho = fields[8].Length;

                                    if (((tamanho - ponto) != 3) && tamanho > 0) //pega o dado, senão o dado é inválido.
                                    {
                                        VMU_CONSUMO_KWH = Convert.ToDouble(fields[8].Replace(".", ""));
                                    }
                                    else
                                    {
                                        VMU_CONSUMO_KWH = -1;
                                    }
 
                                    VMU_TENSAO_FASE1 = Convert.ToDouble(fields[10]);
                                    VMU_TENSAO_FASE2 = Convert.ToDouble(fields[11]);
                                    VMU_TENSAO_FASE3 = Convert.ToDouble(fields[12]);
                                    VMU_CORRENTE_FASE1 = Convert.ToDouble(fields[17]);
                                    VMU_CORRENTE_FASE2 = Convert.ToDouble(fields[18]);
                                    VMU_CORRENTE_FASE3 = Convert.ToDouble(fields[19]);
                                    timestamp = stringToUTCDatetime(fields[7]);
                                    acRead = false;
                                }


                                if ((fields[0].Equals("DC")) && fields[3].Equals("ABB")  && dcRead) //le variaveis DC
                                {
                                    VMU_TENSAO_DC = Convert.ToDouble(fields[9]);
                                    VMU_CORRENTE_DC = Convert.ToDouble(fields[10]);
                                    VMU_POTENCIA_DC = Convert.ToDouble(fields[11]);
                                    timestamp = stringToUTCDatetime(fields[7]);
                                    dcRead = false;
                                }

                                if ((fields[0].Equals("EN")) && enRead)   //le variaveis EN
                                {
                                    VMU_TEMPERATURA_AMBIENTE = Convert.ToDouble(fields[8]);
                                    VMU_TEMPERATURA_PLACA = Convert.ToDouble(fields[9]);
                                    timestamp = stringToUTCDatetime(fields[7]);
                                    enRead = false;
                                }
                            }
                        }
                    }

                    //terminou de ler o arquivo, joga para as tags do Plantsuite.

                    if (VMU_CONSUMO_KWH > -1)
                    {
                        inserveValorTabelaTag("VMU_CONSUMO_KWH", timestamp, VMU_CONSUMO_KWH);
                    }

                    inserveValorTabelaTag("VMU_TENSAO_FASE1-N", timestamp, VMU_TENSAO_FASE1);
                    inserveValorTabelaTag("VMU_TENSAO_FASE2-N", timestamp, VMU_TENSAO_FASE2);
                    inserveValorTabelaTag("VMU_TENSAO_FASE3-N", timestamp, VMU_TENSAO_FASE3);
                    inserveValorTabelaTag("VMU_CORRENTE_FASE1", timestamp, VMU_CORRENTE_FASE1);
                    inserveValorTabelaTag("VMU_CORRENTE_FASE2", timestamp, VMU_CORRENTE_FASE2);
                    inserveValorTabelaTag("VMU_CORRENTE_FASE3", timestamp, VMU_CORRENTE_FASE3);
                    inserveValorTabelaTag("VMU_TENSAO_DC", timestamp, VMU_TENSAO_DC);
                    inserveValorTabelaTag("VMU_CORRENTE_DC", timestamp, VMU_CORRENTE_DC);
                    inserveValorTabelaTag("VMU_POTENCIA_DC", timestamp, VMU_POTENCIA_DC);
                    inserveValorTabelaTag("VMU_TEMPERATURA_AMBIENTE", timestamp, VMU_TEMPERATURA_AMBIENTE);
                    inserveValorTabelaTag("VMU_TEMPERATURA_PLACA", timestamp, VMU_TEMPERATURA_PLACA);


                    //move o arquivo lido para a pasta "Processados"
                    System.IO.File.Move(path, diretorio + "Processados//" + fi.Name);
                    Util.logInFile(fi.Name.ToString() + " Processado!", "Info");



                }
                catch (Exception e)
                {
                    //System.IO.File.Move(path, diretorio + "Processados//" + fi.Name);
                    Util.logInFile("---------------> ERRO ao processar o arquivo CSV - " + fi.Name.ToString() + " --> " + e.Message.ToString(), "Info");
                }               
            }

        }


        private DateTime stringToUTCDatetime(string data)  // Formato de entrada: 2019-01-29T09:50:00-02:00
        {
            DateTime ret = Convert.ToDateTime(data);
            return TimeZoneInfo.ConvertTimeToUtc(ret, TimeZoneInfo.Local);
        }




        private void inserveValorTabelaTag(string nomeTag, DateTime timestamp, double valor)
        {

            string nomeTabela = string.Empty;

            //pega o nome da tabela
            using (SqlConnection _con = new SqlConnection("Data Source=" + SQLServerHost + ";User ID=ps_server; Password=@PS$Adm; Connect Timeout=30"))
            {
                try
                {
                    _con.Open();

                    SqlCommand _cmd = _con.CreateCommand();
                    _cmd.CommandType = CommandType.Text;
                    _cmd.CommandText = "select top 1 TT.vc_table from psserver4.dbo.tb_ps_tag TG inner join psserver4.dbo.tb_PS_Tag_Table TT on TG.i_tag_table_id = TT.i_tag_table_id where TG.vc_tag ='" + nomeTag + "'";

                    using (IDataReader dr = _cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            nomeTabela = dr["vc_table"].ToString();

                        dr.Close();
                    }

                    _cmd.CommandText = "insert into PSServer4Datastorage.dbo." + nomeTabela + " (dt_tag, value) values('" + timestamp.ToString("yyyy-MM-dd HH:mm:ss") + "'," + valor.ToString() + ")";
                    _cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Util.logInFile("------------------> Erro ao inserir o dado no banco de dados SQL Server -> Timestamp: "+ timestamp.ToString() + " TAG:" + nomeTag + " Valor:" + valor.ToString() + " Tabela: " + nomeTabela , "Info");
                    Util.logInFile("------------------> Informações do erro: " + e.Message.ToString(), "Info");
                }

            }

        }


        private string getSQLServerName()
        {

            string line;
            string[] fields;
            string ret = "localhost";

            try
            {
                using (StreamReader inputFile = new StreamReader(new FileStream(AppDomain.CurrentDomain.BaseDirectory + "//Config.ini", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();
                        fields = line.Split('=');

                        if (fields.Length > 0)
                        {
                            ret = fields[1];
                        }

                    }
                }

            }
            catch (Exception e)
            {
                ret = "localhost";
                Util.logInFile("------------------> Erro ao ler o arquivo de configuração do SQL SERVER (Assumindo LOCALHOST): " + e.Message.ToString(), "Info");
                
            }

            return ret;

        }



    }
}
