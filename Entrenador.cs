using System;

namespace proyecto_final
{
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

