///////////////////////////////////////////////////////////
//  Empreendedor.cs
//  Implementation of the Class Empreendedor
//  Generated by Enterprise Architect
//  Created on:      05-set-2012 22:07:37
///////////////////////////////////////////////////////////




using System;
namespace System {
	public class Empreendedor {

		private int ID_Empreendedor;
		private string _CPF;
		private string _Nome;
		private string _WebPage;
		private string _Foto;
		private string _Email;
		private int _DDD;
		private string _Telefone;
		private int _DDD_Celular;
		private string _Celular;
		private date _DataNascimento;
		private string _Escolaridade;
		private string _Formacao;
		private string _Endereco;
		private string _Complemento;
		private string _CEP;
		private string _Cidade;
		private string _UF;
		private string _Sexo;
		public Projeto m_Projeto;

		public Empreendedor(){

		}

		~Empreendedor(){

		}

		public virtual void Dispose(){

		}

		public string CPF{
			get{
				return CPF;
			}
			set{
				CPF = value;
			}
		}

		public string Nome{
			get{
				return _Nome;
			}
			set{
				_Nome = value;
			}
		}

		public string WebPage{
			get{
				return _WebPage;
			}
			set{
				_WebPage = value;
			}
		}

		public string Foto{
			get{
				return Foto;
			}
			set{
				Foto = value;
			}
		}

		public string Email{
			get{
				return _Email;
			}
			set{
				_Email = value;
			}
		}

		public int DDD{
			get{
				return _DDD;
			}
			set{
				_DDD = value;
			}
		}

		public string Telefone{
			get{
				return _Telefone;
			}
			set{
				_Telefone = value;
			}
		}

		public int DDD_Celular{
			get{
				return _DDD_Celular;
			}
			set{
				_DDD_Celular = value;
			}
		}

		public string Celular{
			get{
				return Celular;
			}
			set{
				Celular = value;
			}
		}

		public date DataNascimento{
			get{
				return _DataNascimento;
			}
			set{
				_DataNascimento = value;
			}
		}

		public string Escolaridade{
			get{
				return _Escolaridade;
			}
			set{
				_Escolaridade = value;
			}
		}

		public string Formacao{
			get{
				return _Formacao;
			}
			set{
				_Formacao = value;
			}
		}

		public string Endereco{
			get{
				return _Endereco;
			}
			set{
				_Endereco = value;
			}
		}

		public string Complemento{
			get{
				return _Complemento;
			}
			set{
				_Complemento = value;
			}
		}

		public string CEP{
			get{
				return _CEP;
			}
			set{
				_CEP = value;
			}
		}

		public string Cidade{
			get{
				return _Cidade;
			}
			set{
				_Cidade = value;
			}
		}

		public string UF{
			get{
				return _UF;
			}
			set{
				_UF = value;
			}
		}

		public string Sexo{
			get{
				return _Sexo;
			}
			set{
				_Sexo = value;
			}
		}

		public void Incluir(){

		}

		public void Alterar(){

		}

		/// 
		/// <param name="ID_Empreendedor"></param>
		public void Selecionar(int ID_Empreendedor){

		}

		/// 
		/// <param name="ID_Empreendedor"></param>
		public bool Excluir(int ID_Empreendedor){

			return false;
		}

		/// 
		/// <param name="ID_Projeto"></param>
		public void Listar(int ID_Projeto){

		}

	}//end Empreendedor

}//end namespace System