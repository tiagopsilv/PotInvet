using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;
using GoogleChartSharp;

namespace Invest.Controller
{
    public class clsprojeto : ProjetoBLL
    {
        public CustoBLL _CustoBLL;
        public LucroBLL _LucroBLL;
        public EmpreendedorBLL _EmpreendedorBLL; 
        public ListaInvestidor _Projeto;
        private LoginBLL _LoginBLL;
        public Login _Login;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        public List<ListaROI> _ListaROI;
        public List<string> _ListaROI_Custo;
        public List<ListaROI> _ListaROI_Lucro;

        public clsprojeto()
        {
            _LoginBLL = new LoginBLL();
            _EmpreendedorBLL = new EmpreendedorBLL();
            _CustoBLL = new CustoBLL();
            _LucroBLL = new LucroBLL();
        }
        public string Usuario()
        {
            _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
            if (_Login != null)
                return _Login.LOGIN;
            else
                return null;
        }
        public bool VerificaLogin()
        {
            return _LoginBLL.VerificaLogado(_Login.LOGIN);
        }

        public void CarregaProjetosVisitados()
        {
            ListaProjetosVisitados TempProjetosVisitados;
            bool Achou = false;
            List<ProjetosVisitados> _ListTemp;

            _ListTemp = SeleciorProjetosVisitados(0, _Login.ID);
            _ProjetosVisitados = new List<ListaProjetosVisitados>();

            for (int i = 0; i < _ListTemp.Count; i++)
            {
                Achou = false;
                TempProjetosVisitados = new ListaProjetosVisitados();

                for (int j = 0; j < _ProjetosVisitados.Count; j++)
                {
                    if (_ListTemp[i].ID_Projeto == _ProjetosVisitados[j].ID_Projeto)
                    {
                        Achou = true;
                        break;
                    }
                }
                if (Achou == false)
                {
                    TempProjetosVisitados.ID_ProjetoVisitados = _ListTemp[i].ID_ProjetoVisitados;
                    TempProjetosVisitados.ID_Projeto = _ListTemp[i].ID_Projeto;
                    TempProjetosVisitados.ID_Investidor = _ListTemp[i].ID_Investidor;
                    TempProjetosVisitados.Data = _ListTemp[i].Data;
                    TempProjetosVisitados.Hora = _ListTemp[i].Hora;
                    TempProjetosVisitados.NomeProjeto = _ListTemp[i].NomeProjeto;

                    _ProjetosVisitados.Add(TempProjetosVisitados);
                }
            }
        }

        public void CarregaProjeto(int ID_Projeto)
        {
            Projeto _Proj = new Projeto();
            _Proj = Listar(ID_Projeto)[0];

            _Projeto = new ListaInvestidor();

            _Projeto = new ListaInvestidor();
            _Projeto.ID_Projeto = _Proj.ID_Projeto;
            _Projeto.NomeProjeto = _Proj.NomeProjeto;
            _Projeto.DescricaoProjeto = _Proj.DescricaoProjeto;
            _Projeto.ImagemProjeto = _Proj.ImagemProjeto;
            _Projeto.VideoProjeto = _Proj.VideoProjeto;
            _Projeto.PerfilProjeto = _Proj.PerfilProjeto;
            _Projeto.RamoAtividade = _Proj.RamoAtividade;
            _Projeto.Ranking = _Proj.Ranking;
            _Projeto.Custo_Projeto = _Proj.Custo_Projeto;
            _Projeto.Valor_Arrecadado = _Proj.Valor_Arrecadado;
            _Projeto.Porcentagem = _Proj.Porcentagem;
            _Projeto.Data = _Proj.Data;
            _Projeto.Email = _Proj.Email;
            _Projeto.DDD = _Proj.DDD;
            _Projeto.Telefone = _Proj.Telefone;
            _Projeto.Endereco = _Proj.Endereco;
            _Projeto.Cidade = _Proj.Cidade;
            _Projeto.Estado = _Proj.Estado;
            _Projeto.ID_Agente = _Proj.ID_Agente;
            _Projeto.star1 = MostraEstrela(_Proj.Ranking, 1);
            _Projeto.star2 = MostraEstrela(_Proj.Ranking, 2);
            _Projeto.star3 = MostraEstrela(_Proj.Ranking, 3);
            _Projeto.star4 = MostraEstrela(_Proj.Ranking, 4);
            _Projeto.star5 = MostraEstrela(_Proj.Ranking, 5);
            _Projeto.Porcentagem100 = Porcentagem100(_Proj.Porcentagem);
            _Projeto.Porcentagem0 = Porcentagem0(_Proj.Porcentagem);
            _Projeto.Url = "~/projeto.aspx?ID=" + Convert.ToString(_Proj.ID_Projeto);
        
        }

        private bool MostraEstrela(int Raking, int Orgem)
        {
            int valor = (5 * Raking) / 10;
            bool Resultado = false;
            switch (Orgem)
            {
                case 1:
                    if (valor >= 1)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
                case 2:
                    if (valor >= 2)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
                case 3:
                    if (valor >= 3)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
                case 4:
                    if (valor >= 4)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
                case 5:
                    if (valor >= 5)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
            }
            return Resultado;
        }

        private int Porcentagem100(decimal Porcentagem)
        {
            return (600 * Convert.ToInt32(Porcentagem)) / 100;
        }

        private int Porcentagem0(decimal Porcentagem)
        {
            return 600 - Porcentagem100(Porcentagem);
        }

        public List<ListaEmpreendedor> ListaEmpreendedores(int ID_Projeto)
        {

            List<GrupoProjeto> _ListaGrupo;
            List<ListaEmpreendedor> tempLista = new List<ListaEmpreendedor>();
            ListaEmpreendedor _ListaEmpreendedor;

            _ListaGrupo = _EmpreendedorBLL.ListaGrupoProjetos(0, ID_Projeto);

            for (int i = 0; i < _ListaGrupo.Count; i++)
            {
                _ListaEmpreendedor = new ListaEmpreendedor();

                _ListaEmpreendedor.ID_Empreendedor = _ListaGrupo[i].ID_Empreendedor;
                _ListaEmpreendedor.CPF = _ListaGrupo[i].CPF;
                _ListaEmpreendedor.Nome = _ListaGrupo[i].Nome;
                _ListaEmpreendedor.WebPage = _ListaGrupo[i].WebPage;
                _ListaEmpreendedor.Foto = _ListaGrupo[i].Foto;
                _ListaEmpreendedor.Email = _ListaGrupo[i].Email;
                _ListaEmpreendedor.DDD = _ListaGrupo[i].DDD;
                _ListaEmpreendedor.Telefone = _ListaGrupo[i].Telefone;
                _ListaEmpreendedor.DDD_Celular = _ListaGrupo[i].DDD_Celular;
                _ListaEmpreendedor.Celular = _ListaGrupo[i].Celular;
                _ListaEmpreendedor.DataNascimento = _ListaGrupo[i].DataNascimento;
                _ListaEmpreendedor.Escolaridade = _ListaGrupo[i].Escolaridade;
                _ListaEmpreendedor.Formacao = _ListaGrupo[i].Formacao;
                _ListaEmpreendedor.Endereco = _ListaGrupo[i].Endereco;
                _ListaEmpreendedor.Complemento = _ListaGrupo[i].Complemento;
                _ListaEmpreendedor.CEP = _ListaGrupo[i].CEP;
                _ListaEmpreendedor.Cidade = _ListaGrupo[i].Cidade;
                _ListaEmpreendedor.UF = _ListaGrupo[i].UF;
                _ListaEmpreendedor.Sexo = _ListaGrupo[i].Sexo;
                _ListaEmpreendedor.Contato = _ListaGrupo[i].Contato;
                _ListaEmpreendedor.Descricao = _ListaGrupo[i].Descricao;
                _ListaEmpreendedor.Linkedin = _ListaGrupo[i].Linkedin;
                _ListaEmpreendedor.Facebook = _ListaGrupo[i].Facebook;
                _ListaEmpreendedor.GooglePlus = _ListaGrupo[i].GooglePlus;
                _ListaEmpreendedor.Skype = _ListaGrupo[i].Skype;
                _ListaEmpreendedor.Twitter = _ListaGrupo[i].Twitter;
                _ListaEmpreendedor.Msn = _ListaGrupo[i].Msn;
                _ListaEmpreendedor.ID_GrupoProjeto = _ListaGrupo[i].ID_GrupoProjeto;
                _ListaEmpreendedor.ID_Projeto = _ListaGrupo[i].ID_Projeto;
                _ListaEmpreendedor.ID_Empreendedor = _ListaGrupo[i].ID_Empreendedor;
                _ListaEmpreendedor.URL = "~/DetalheEmpreendedor.aspx?ID=" + Convert.ToString(_ListaGrupo[i].ID_Empreendedor) + "&ID_Projeto=" + ID_Projeto + "&Tipo=Projeto";

                tempLista.Add(_ListaEmpreendedor);

            }

            return tempLista;
        }

        public void Visitar(int ID_Investidor, int ID_Projeto)
        {
            POCO.ProjetosVisitados _Proj = new POCO.ProjetosVisitados();
            _Proj.ID_Investidor = ID_Investidor;
            _Proj.ID_Projeto = ID_Projeto;

            _Proj = IncluirProjetosVisitados(_Proj, _Login.LOGIN);

        }

        public string Get_Tipo()
        {
            if (_Login != null)
            {
                _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
                if (_Login.LOGIN != null)
                    return _Login.Tipo;
                else
                    return "Investidor";
            }
            else
                return "Investidor";
        }

        //public string ROI()
        //{

        //    List<Custo> ListaCusto;
        //    List<Lucro> ListaLucro;
        //    int Diff = 0;
        //    int DiffTotal = 0;
        //    string Data = "";

        //    float[] set1x;
        //    float[] set1y;
        //    float[] set2x;
        //    float[] set2y;

        //    decimal[] Valores;
        //    DateTime[] Datas;

        //    bool achouValores = false;
        //    bool achouDatas = false;

        //    ListaCusto = _CustoBLL.Listar(_Projeto.ID_Projeto);
        //    ListaLucro = _LucroBLL.Listar(_Projeto.ID_Projeto);

        //    set1x = new float[ListaCusto.Count];
        //    set1y = new float[ListaCusto.Count];
        //    set2x = new float[ListaLucro.Count];
        //    set2y = new float[ListaLucro.Count];

        //    Valores = new decimal[ListaLucro.Count + ListaCusto.Count];
        //    Datas = new DateTime[ListaLucro.Count + ListaCusto.Count];

        //    for (int i = 0; i < ListaCusto.Count; i++)
        //    {
        //        achouValores = false;
        //        achouDatas = false;

        //        for (int j = 0; j < i; j++)
        //        {
        //            if (ListaCusto[i].CustoEstimado == Valores[j])
        //                achouValores = true;
        //        }
        //        if (achouValores == false)
        //            Valores[i] = ListaCusto[i].CustoEstimado;

        //        for (int l = 0; l < i; l++)
        //        {
        //            if (ListaCusto[i].Data == Datas[l])
        //                achouDatas = true;
        //        }

        //        if (achouDatas == false)
        //            Datas[i] = ListaCusto[i].Data;
        //    }

        //    for (int i = 0; i < ListaLucro.Count; i++)
        //    {
        //        for (int j = 0; j < i + ListaCusto.Count; j++)
        //        {
        //            if (ListaLucro[i].ValorEstimado == Valores[j])
        //                achouValores = true;
        //        }
        //        if (achouValores == false)
        //            Valores[i] = ListaLucro[i].ValorEstimado;

        //        for (int l = 0; l < i + ListaCusto.Count; l++)
        //        {
        //            if (ListaLucro[i].Data == Datas[l])
        //                achouDatas = true;
        //        }

        //        if (achouDatas == false)
        //            Datas[i] = ListaLucro[i].Data;
        //    }

        //    //Valores = Valores.Distinct().ToArray();
        //    //Datas = Datas.Distinct().ToArray();
            
        //    DateTime[] CopyDatas = Datas;
        //    int ContData = 0;

        //    for (int i = 0; i < Datas.Length - 1; i++)
        //    {
        //        if (Datas[i].Year != 0001)
        //        {
        //            ContData++;
        //        }
        //    }

        //    Datas = new DateTime[ContData];
        //    ContData = 0;

        //    for (int j = 0; j < Datas.Length - 1; j++)
        //    {
        //        if (CopyDatas[j].Year != 0001)
        //        {
        //            Datas[ContData] = CopyDatas[j];
        //            ContData++;
        //        }
        //    }

        //    Array.Sort(Valores);
        //    Array.Sort(Datas);

        //    string[] txtValores = new string[ListaLucro.Count + ListaCusto.Count];
        //    string[] txtDatas = new string[ListaLucro.Count + ListaCusto.Count];

        //    ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);

        //    for (int i = 0; i < Datas.Length; i++)
        //    {
        //        txtValores[i] = Convert.ToString(Valores[i]);
        //    }

        //    for (int i = 0; i < Datas.Length; i++)
        //    {
        //        if (Datas.Count() - 1 != i)
        //        {
        //            DiffTotal = DiffTotal + GetDiffDays(Datas[i], Datas[i + 1]);
        //            Diff = GetDiffDays(Datas[i], Datas[i + 1]);
        //        }
        //        else
        //            DiffTotal = DiffTotal + Datas[i].Day;

        //        if (Diff > 10 || i == 0 || i == Datas.Count() - 1)
        //        {
        //            Data = Convert.ToString(Datas[i].Day) + "/" + Convert.ToString(Datas[i].Month) + "/" + Convert.ToString(Datas[i].Year);
        //            bottomAxis.AddLabel(new ChartAxisLabel(Data, DiffTotal));
        //        }
        //    }

        //    ChartAxis leftAxis = new ChartAxis(ChartAxisType.Left, txtValores);

        //    DiffTotal = 0;
        //    Diff = 0;

        //    for (int i = 0; i < ListaCusto.Count; i++)
        //    {

        //        if (ListaCusto.Count != i + 1)
        //        {
        //            DiffTotal = DiffTotal + GetDiffDays(ListaCusto[i].Data, ListaCusto[i + 1].Data);
        //        }
        //        else
        //            DiffTotal = DiffTotal + ListaCusto[i].Data.Day;

        //        set1y[i] = (float)ListaCusto[i].CustoEstimado;
        //        set1x[i] = DiffTotal;


        //    }

        //    DiffTotal = 0;
        //    Diff = 0;

        //    for (int i = 0; i < ListaLucro.Count; i++)
        //    {
        //        if (ListaLucro.Count != i + 1)
        //        {
        //            DiffTotal = DiffTotal + GetDiffDays(ListaLucro[i].Data, ListaLucro[i + 1].Data);
        //        }
        //        else
        //            DiffTotal = DiffTotal + ListaLucro[i].Data.Day;

        //        set2y[i] = (float)ListaLucro[i].ValorEstimado;
        //        set2x[i] = DiffTotal;

        //    }

        //    //começo ----------------------------


        //    List<float[]> dataList = new List<float[]>();
        //    dataList.Add(set1x);
        //    dataList.Add(set1y);
        //    dataList.Add(set2x);
        //    dataList.Add(set2y);

        //    LineChart lineChart = new LineChart(495, 249, LineChartType.MultiDataSet);
        //    lineChart.AddAxis(bottomAxis);
        //    lineChart.AddAxis(leftAxis);
        //    lineChart.SetTitle("Lucro x Custo", "000000", 14);
        //    lineChart.SetData(dataList);

        //    // Optional : Provide a hex color for each pair of data sets
        //    lineChart.SetDatasetColors(new string[] { "FF0000", "00FF00" });

        //    // Optional : Provide a label for each pair of data sets
        //    lineChart.SetLegend(new string[] { "Custo", "Lucro" });

        //    return lineChart.GetUrl();
        //}

        public string ROI2()
        {
            List<Custo> _ListaCusto;
            List<Lucro> _ListaLucro;
            ListaROI _ROI;
            int DiffTotal = 0;

            _ListaCusto = _CustoBLL.Listar(_Projeto.ID_Projeto);
            _ListaLucro = _LucroBLL.Listar(_Projeto.ID_Projeto);

            _ListaROI = new List<ListaROI>();
            _ListaROI_Custo = new List<string>();

            float[] set1x = new float[_ListaCusto.Count];
            float[] set1y = new float[_ListaCusto.Count];

            for (int i = 0; i < _ListaCusto.Count; i++)
            {
                _ROI = new ListaROI();
                _ROI.Valor = _ListaCusto[i].CustoEstimado;
                _ROI.setX = ValorTransfor(Convert.ToInt32(_ListaCusto[i].CustoEstimado));

                set1y[i] = ValorTransfor(Convert.ToInt32(_ListaCusto[i].CustoEstimado));

                if (i != 0)
                {
                    DiffTotal = DiffTotal + GetDiffDays(_ListaCusto[i - 1].Data, _ListaCusto[i].Data);
                }

                set1x[i] = Convert.ToSingle(DiffTotal);
                _ListaROI_Custo.Add(_ROI.Valor.ToString());
            }


            float[] set2x = new float[_ListaLucro.Count];
            float[] set2y = new float[_ListaLucro.Count];

            DiffTotal = 0;

            for (int i = 0; i < _ListaLucro.Count; i++)
            {
                _ROI = new ListaROI();
                _ROI.Valor = _ListaCusto[i].CustoEstimado;
                _ROI.setX = ValorTransfor(Convert.ToInt32(_ListaLucro[i].ValorEstimado));

                set2y[i] = ValorTransfor(Convert.ToInt32(_ListaLucro[i].ValorEstimado));

                if (i != 0)
                {
                    DiffTotal = DiffTotal + GetDiffDays(_ListaLucro[i - 1].Data, _ListaLucro[i].Data);
                }

                set2x[i] = Convert.ToSingle(DiffTotal);
                _ListaROI_Custo.Add(Convert.ToString(_ROI.Valor));
            }

            _ListaROI_Custo = _ListaROI_Custo.OrderBy(c => c.Count()).ToList();
            _ListaROI_Custo = _ListaROI_Custo.Distinct().ToList();
                        
            string[] txtValores = new string[_ListaROI_Custo.Count];

            for (int i = 0; i < _ListaROI_Custo.Count; i++)
            {
                txtValores[i] = _ListaROI_Custo[i];
            }

            ChartAxis leftAxis = new ChartAxis(ChartAxisType.Left, txtValores);

            List<float[]> dataList = new List<float[]>();
            dataList.Add(set1x);
            dataList.Add(set1y);
            dataList.Add(set2x);
            dataList.Add(set2y);

            //ChartAxis leftAxis = new ChartAxis(ChartAxisType.Left, txtValores);

            LineChart lineChart = new LineChart(495, 249, LineChartType.MultiDataSet);
            //lineChart.AddAxis(bottomAxis);
            lineChart.AddAxis(leftAxis);
            lineChart.SetTitle("Lucro x Custo", "000000", 14);
            lineChart.SetData(dataList);

            // Optional : Provide a hex color for each pair of data sets
            lineChart.SetDatasetColors(new string[] { "FF0000", "00FF00" });

            // Optional : Provide a label for each pair of data sets
            lineChart.SetLegend(new string[] { "Custo", "Lucro" });

            return lineChart.GetUrl();
        }

        public string ROI()
        {
            ListaROI _ROI;
            List<Custo> _ListaCusto;
            List<Lucro> _ListaLucro;
            int Diff = 0;
            int DiffTotal = 0;
            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);

            _ListaROI = new List<ListaROI>();

            _ListaCusto = _CustoBLL.Listar(_Projeto.ID_Projeto);
            _ListaLucro = _LucroBLL.Listar(_Projeto.ID_Projeto);

            float[] set1x;
            float[] set1y;
            float[] set2x;
            float[] set2y;

            set1x = new float[_ListaCusto.Count];
            set1y = new float[_ListaCusto.Count];
            set2x = new float[_ListaLucro.Count];
            set2y = new float[_ListaLucro.Count];

            for (int i = 0; i < _ListaCusto.Count - 1; i++)
            {
                _ROI = new ListaROI();
                _ROI.tipo = "Custo";
                _ROI.Data = _ListaCusto[i].Data;
                _ROI.Valor = _ListaCusto[i].CustoEstimado;
                _ROI.setX = ValorTransfor(Convert.ToInt32(_ListaCusto[i].CustoEstimado));
                set1y[i] = ValorTransfor(Convert.ToInt32(_ListaCusto[i].CustoEstimado));

                if (_ListaCusto.Count != i + 1)
                {
                    DiffTotal = DiffTotal + GetDiffDays(_ListaCusto[i].Data, _ListaCusto[i + 1].Data);
                }
                else
                    DiffTotal = DiffTotal + _ListaCusto[i].Data.Day;

                _ROI.setY = DiffTotal;
                set1x[i] = DiffTotal;
                _ListaROI.Add(_ROI);
            }

            Diff = 0;
            DiffTotal = 0;

            for (int i = 0; i < _ListaLucro.Count - 1; i++)
            {
                _ROI = new ListaROI();
                _ROI.tipo = "Lucro";
                _ROI.Data = _ListaLucro[i].Data;
                _ROI.Valor = _ListaLucro[i].ValorEstimado;
                _ROI.setX = ValorTransfor(Convert.ToInt32(_ListaLucro[i].ValorEstimado));
                set2y[i] = ValorTransfor(Convert.ToInt32(_ListaLucro[i].ValorEstimado));

                if (_ListaLucro.Count != i + 1)
                {
                    DiffTotal = DiffTotal + GetDiffDays(_ListaLucro[i].Data, _ListaLucro[i + 1].Data);
                }
                else
                    DiffTotal = DiffTotal + _ListaLucro[i].Data.Day;

                _ROI.setY = DiffTotal;
                set2x[i] = DiffTotal;
                _ListaROI.Add(_ROI);
            }

            _ListaROI = _ListaROI.OrderBy(c => c.Data).ToList();

            string[] txtValores = new string[_ListaROI.Count];
            string[] txtDatas = new string[_ListaROI.Count];

            Diff = 0;
            DiffTotal = 0;

            for (int i = 0; i < _ListaROI.Count - 1; i++)
            {
                if (_ListaROI.Count != i + 1)
                {
                    DiffTotal = DiffTotal + GetDiffDays(_ListaROI[i].Data, _ListaROI[i + 1].Data);
                }
                else
                    DiffTotal = DiffTotal + _ListaROI[i].Data.Day;

                txtValores[i] = Convert.ToString(_ListaROI[i].Valor);

                bottomAxis.AddLabel(new ChartAxisLabel(_ListaROI[i].Data.ToString("dd/MM/yyyy"), DiffTotal));
            }

            List<float[]> dataList = new List<float[]>();
            dataList.Add(set1x);
            dataList.Add(set1y);
            dataList.Add(set2x);
            dataList.Add(set2y);

            ChartAxis leftAxis = new ChartAxis(ChartAxisType.Left, txtValores);

            LineChart lineChart = new LineChart(495, 249, LineChartType.MultiDataSet);
            lineChart.AddAxis(bottomAxis);
            lineChart.AddAxis(leftAxis);
            lineChart.SetTitle("Lucro x Custo", "000000", 14);
            lineChart.SetData(dataList);

            // Optional : Provide a hex color for each pair of data sets
            lineChart.SetDatasetColors(new string[] { "FF0000", "00FF00" });

            // Optional : Provide a label for each pair of data sets
            lineChart.SetLegend(new string[] { "Custo", "Lucro" });

            return lineChart.GetUrl();
        }

        public int GetDiffDays(DateTime initialDate, DateTime finalDate)
        {

        int daysCount = 1;


        while (initialDate.Date != finalDate.Date)
        {

            initialDate = initialDate.AddDays(1);
            //Conta apenas dias da semana.
            daysCount++;

        }

        return daysCount;

        }

        public void SairLogin()
        {
            _LoginBLL.SairLogin(_Login.LOGIN);
        }

        public void CarregarLogin(string Login, bool Logado)
        {
            _LoginBLL.CarregarLogin(Login, Logado);
            _Login = _LoginBLL.ConsultarLogin(Login);
        }

        public void Incluir_Log(string IP, string Pagina, string PaginaAnt)
        {
            string _Log = null;
            if (_Login != null)
                _Log = _Login.LOGIN;
            _LoginBLL.Incluir_Log(IP, Pagina, PaginaAnt, _Log);
        }

        public float ValorTransfor(int Valor)
        {
            string sValor = Convert.ToString(Valor);
            if (Valor >= 100)
            {
                sValor = sValor.Substring(0, sValor.Length - 2);
            }
            else
            {
                if (Valor >= 10)
                {
                    sValor = "0," + sValor;
                }
                else
                {
                    if (Valor < 10)
                    {
                        sValor = "0,0" + sValor;
                    }
                }
            }

            return Convert.ToSingle(sValor);
        }

    }
}