using System;

namespace proyecto_final
{
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
		
		
		
	}
}
