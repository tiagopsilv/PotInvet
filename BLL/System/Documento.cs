///////////////////////////////////////////////////////////
//  Documento.cs
//  Implementation of the Class Documento
//  Generated by Enterprise Architect
//  Created on:      05-set-2012 22:02:45
//  Original author: Miza
///////////////////////////////////////////////////////////




namespace System {
	public class Documento {

		private int ID_Documento;
		private int _ID_Projeto;
		private string _EnderecoDocumento;
		private string _Titulo;

		public Documento(){

		}

		~Documento(){

		}

		public virtual void Dispose(){

		}

		public int ID_Projeto{
			get{
				return ID_Projeto;
			}
			set{
				ID_Projeto = value;
			}
		}

		public int EnderecoDocumento{
			get{
				return EnderecoDocumento;
			}
			set{
				EnderecoDocumento = value;
			}
		}

		public string Titulo{
			get{
				return Titulo;
			}
			set{
				Titulo = value;
			}
		}

		public void Incluir(){

		}

		public void Alterar(){

		}

		/// 
		/// <param name="ID_Documento"></param>
		public void Selecionar(int ID_Documento){

		}

		/// 
		/// <param name="ID_Documento"></param>
		public bool Excluir(int ID_Documento){

			return false;
		}

	}//end Documento

}//end namespace System