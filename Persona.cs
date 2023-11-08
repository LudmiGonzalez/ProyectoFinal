/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 12/10/2023
 * Time: 23:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace proyecto_final
{
	/// <summary>
	/// Description of persona.
	/// </summary>
	public class Persona
	{
		private string nombre;
		private string apellido;
		private int dni;
		
		public Persona(string nom, string ape, int dni)
		{
			this.nombre= nom;
			this.apellido= ape;
			this.dni= dni;
		}
		public string nombre_{
			get {return nombre;}
			set {nombre=value;}
		}
		public string apellido_{
			get {return apellido;}
			set {apellido=value;}
		}
		public int dni_{
			get {return dni;}
		}
		
		
		public void imprimir(){
			Console.WriteLine("Nombre: "+nombre);
			Console.WriteLine("Apellido: "+apellido);
			Console.WriteLine("Dni: "+dni);
		}
	}
}
