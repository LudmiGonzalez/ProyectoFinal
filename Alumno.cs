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
	/// Description of Alumno.
	/// </summary>
	public class Alumno:Persona
	{
		private int edad;
		private bool socio;
		private DateTime mesPago;
		private Deporte depor;
		private Categoria cate;
		
		public Alumno(string nom, string ape, int dni, int edad):base(nom,ape,dni)
		{
			this.edad=edad;
		}
	
	public int edad_{
			get {return edad;}
			set {edad=value;}
		}
			public bool socio_{
			get {return socio;}
			set {socio=value;}
		}
			public DateTime mesPago_{
			get {return mesPago;}
			set {mesPago=value;}
		}
			public Deporte depor_{
			get {return depor;}
			set {depor=value;}
		}

			public Categoria cate_{
			get {return cate;}
			set {cate=value;}
		}
		
		
}
}