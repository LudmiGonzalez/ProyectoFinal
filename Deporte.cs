using System;
using System.Collections;

namespace proyecto_final
{
	public class Deporte
	{
		private string nombre;
		private ArrayList categorias= new ArrayList();
		private ArrayList alumnos= new ArrayList();
		public Deporte( string nom)
		{
			this.nombre=nom;
		}
		public string nombre_{
			get {return nombre;}
			set {nombre=value;}
		}
		
		
		public void agregarCategoria(Categoria a){
			this.categorias.Add(a);
		}
		public void eliminarCategoria(Categoria a){
			this.categorias.Remove(a);
		}
		public ArrayList verDatosCategoria(){
			return this.categorias;
		}
		public Categoria recuperarCategoria(int pos){
			return (Categoria)this.categorias[pos];
		}
		public Boolean existeCategoria(Categoria a){
			return this.categorias.Contains(a);
		}
		public int cantidadCategoria(){
			return this.categorias.Count;
		}
		
		public void agregarAlum(Alumno a){
			this.alumnos.Add(a);
		}
		public void eliminarAlum(Alumno a){
			this.alumnos.Remove(a);
		}
		public ArrayList verDatos(){
			return this.alumnos;
		}
		public Alumno recuperarAlumno(int pos){
			return (Alumno)this.alumnos[pos];
		}
		public Boolean existeAlumno(Alumno a){
			return this.alumnos.Contains(a);
		}
		public int cantidadAlumn(){
			return this.alumnos.Count;
		}
	}
}
