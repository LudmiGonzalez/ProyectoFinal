using System;
using System.Collections;

namespace proyecto_final
{
	public class Categoria
	{
		private string tipo;
		private string nomEntr;
		private Deporte deporte;
		private Entrenador entre;
		private ArrayList inscriptos= new ArrayList();
		private DateTime entrDH;
		private float cuota;
		private int dniEntr;
		private int cupo;
		
		public Categoria( string t, int c,float cuo, DateTime Entr)
		{
			this.tipo=t;
			this.cupo=c;
			this.cuota=cuo;
			this.entrDH=Entr;
			
		}
		public string tipo_{
			get {return tipo;}
			set {tipo=value;}
		}
		public string nomEntr_{
			get {return nomEntr;}
			set {nomEntr=value;}
			
		}
		public int dniEntr_{
			get {return dniEntr;}
			set {dniEntr=value;}
		}
		public float cuota_{
			get {return cuota;}
			set {cuota=value;}
		}
		public int cupo_{
			get {return cupo;}
			set {cupo=value;}
		}
		public Deporte deporte_{
			get {return deporte;}
			set {deporte=value;}
		}
		public Entrenador entrenad_{
			get {return entre;}
			set {entre=value;}
		}
		
		
		
		public void agregarAlum(Alumno a){
			this.inscriptos.Add(a);
		}
		public void eliminarAlum(Alumno a){
			this.inscriptos.Remove(a);
		}
		public ArrayList verDatos(){
			return this.inscriptos;
		}
		public Alumno recuperarAlumno(int pos){
			return (Alumno)this.inscriptos[pos];
		}
		public Boolean existeAlumno(Alumno a){
			return this.inscriptos.Contains(a);
		}
		public int cantidadAlumn(){
			return this.inscriptos.Count;
		}
	}
}
