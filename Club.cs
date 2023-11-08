/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 12/10/2023
 * Time: 23:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace proyecto_final
{
	/// <summary>
	/// Description of Club.
	/// </summary>
	public class Club
	{
		private string nombre;

		private ArrayList deportes= new ArrayList();
		
		public Club(string nom)
		{
			this.nombre=nom;
		}
		
		public string nombre_{
			get {return nombre;}
			set {nombre=value;}
		}
	

		public void agregarDeporte(Deporte d){
			this.deportes.Add(d);
		}
		public void eliminarDeporte(Deporte d){
			this.deportes.Remove(d);}
		public ArrayList verDatos(){
			return this.deportes;
		}
		public Deporte recuperarDeporte(int pos){
			return (Deporte)this.deportes[pos];
		}
		public Boolean existe(Deporte a){
			return this.deportes.Contains(a);
		}
		public int cantidadDeportes(){
			return this.deportes.Count;
		}
	}
}
