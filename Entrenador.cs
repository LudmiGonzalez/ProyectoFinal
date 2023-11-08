/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 12/10/2023
 * Time: 23:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace proyecto_final
{
	/// <summary>
	/// Description of Entrenador.
	/// </summary>
	public class Entrenador:Persona
	{
		private float salario;
		public Entrenador(string nom, string ape, int dni, float s):base(nom,ape,dni)
		{
			this.salario=s;
		}
		public float salario_{
			get {return salario;}
			set {salario=value;}
		}
		
	}
}
