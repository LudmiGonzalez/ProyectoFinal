/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 12/10/2023
 * Time: 23:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace proyecto_final
{
	/// <summary>
	/// Description of Categoria.
	/// </summary>
	public class Categoria
	{
		private string tipo;
		private string nomEntr;
		private Deporte deporte;
		private ArrayList entrenadores= new ArrayList();
		private ArrayList inscriptos= new ArrayList();
		private DateTime entrDH;
		private float cuota;
		private int dniEntr;
		private int cupo;
		
		public Categoria( string t, string nomEn, int dniEn, int c,float cuo, DateTime Entr)
		{
			this.tipo=t;
			this.nomEntr=nomEn;
			this.dniEntr=dniEn;
			this.cupo=c;
			this.cuota=cuo;
			this.entrDH=Entr;

			//this.entrenador=e;
			
		}
		public string tipo_{
			get {return tipo;}
			set {tipo=value;}
		}
		public Deporte deporte_{
			get {return deporte;}
			set {deporte=value;}
		}
		public int cantidadInscriptos(){
			return this.inscriptos.Count;
		}
		
		public void agregarEntrenador(Entrenador e){
			this.entrenadores.Add(e);
		}
		public void eliminarEntrenador(Entrenador e){
			this.entrenadores.Remove(e);
		}
		public ArrayList verDatosEntrenador(){
			return this.entrenadores;
		}
		public Entrenador recuperarEntrenador(int pos){
			return (Entrenador)this.entrenadores[pos];
		}
		public Boolean existe(Entrenador e){
			return this.entrenadores.Contains(e);
		}
		public int cantidadEntrenador(){
			return this.entrenadores.Count;
		}
	}
}
