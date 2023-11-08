using System;

namespace proyecto_final
{
	class Program
	{
		public static void Main(string[] args)
		{
			string con,nom,cat,nomEn, apeEn, c="S",d,h,en;
			int dni,opcion,cupo;
			float salario,cuota;
			bool continua=true, fin=true;
			DateTime entrena;
			Console.WriteLine("Bienvenidos al Club deportivo Malu");
			Club club = new Club("Malu");
			Deporte deporte;
			Categoria categoria;
			Entrenador entrenador;

			
			//Datos del club (club, deporte, categoria, entrenador)
			
			Console.WriteLine("Complete los datos requeridos del Club");
			Console.WriteLine();
			
			
			
			while(fin){
				Console.Write("¿Desea ingresar un deporte?(s/n): ");
				con= Console.ReadLine().ToUpper();
				try{

					switch (con) {
							
							case "S": { while(continua){
									
									
									Console.Write("Ingrese nombre del deporte: ");
									nom= Console.ReadLine().ToUpper();
									
									deporte =new Deporte(nom);
									club.agregarDeporte(deporte);
									
									if(nom == " "){
											Console.ForegroundColor= ConsoleColor.Red;
											Console.WriteLine("Debe ingresar un deporte");
											Console.ForegroundColor= ConsoleColor.White;
											Console.WriteLine();continue;
											
										}
									Console.WriteLine();
									Console.WriteLine("Ingrese datos de la categoria");
									
									while (c=="S") {

										Console.Write("Tipo de categoria: ");
										cat = Console.ReadLine().ToUpper();
										
										if(cat == ""){
											Console.ForegroundColor= ConsoleColor.Red;
											Console.WriteLine("Debe ingresar al menos una categoria");
											Console.ForegroundColor= ConsoleColor.White;
											Console.WriteLine();continue;
											
										}
										Console.Write("Cupo: ");
										cupo= int.Parse(Console.ReadLine());
										Console.Write("Valor de la cuota: ");
										cuota= float.Parse(Console.ReadLine());
										Console.Write("Ingrese el dia de entrenamiento (00/00/0000): ");
			                            d= Console.ReadLine();
			                            Console.Write("Ingrese el hora (00:00): ");
			                            h= Console.ReadLine();
			                            en=d+" "+h;
			                            entrena= DateTime.Parse(en);
			                            
			                            Console.Write(" ");
										Console.WriteLine("Datos del entrenador");
										Console.Write("");
										Console.Write("Nombre: ");
										nomEn= Console.ReadLine();
										Console.Write("Apellido: ");
										apeEn= Console.ReadLine();
										
										try{
											Console.Write("Dni: ");
											dni= int.Parse(Console.ReadLine());
											Console.Write("Salario: ");
											salario= float.Parse(Console.ReadLine());
											Console.WriteLine();
										}
										catch(FormatException){
											Console.WriteLine();
											Console.ForegroundColor= ConsoleColor.Red;
											Console.WriteLine("Error. El formato ingresado no el correcto");
											Console.ForegroundColor= ConsoleColor.White;
											Console.WriteLine();
											continue;
										}
										
										entrenador= new Entrenador(nomEn,apeEn,dni,salario);
										categoria= new Categoria(cat,nomEn,dni,cupo,cuota,entrena);
										
										categoria.agregarEntrenador(entrenador);
										deporte.agregarCategoria(categoria);
										
										Console.Write("¿Desea ingresar otra categoria?(S/N): ");
										c= Console.ReadLine().ToUpper();
										
									}
									Console.Write("¿Desea ingresar otro deporte?: ");
									con= Console.ReadLine().ToUpper();
									
									if(con=="S"){
										continua=true;
										c="S";
									}
									if(con !="S"){
										continua= false;
										Console.ForegroundColor= ConsoleColor.Green;
										Console.WriteLine("Proceso finalizado");
										Console.ForegroundColor= ConsoleColor.White;
										fin=false;
										
									}
									
									
								}
							}
							break;
							case "N": 
							Console.ForegroundColor= ConsoleColor.Green;
							Console.WriteLine("Proceso finalizado");
							Console.ForegroundColor= ConsoleColor.White;
							fin=false;
							break;
							
							
						default:
							throw new OpcionIncorrecta();
					}

				}
				catch(OpcionIncorrecta){
					Console.ForegroundColor= ConsoleColor.Red;
					Console.WriteLine("La opcion en incorrecta. Ingrese nuevamente la opcion");
					Console.ForegroundColor= ConsoleColor.White;
					
					Console.WriteLine("");
					
					continue;
					
					
				}
			}
			
			//------------------------------------------------------------------------------------------------------
			
			Console.WriteLine("_________________________________________________________________________________________________________");
			while(continua= true){
				Console.WriteLine("");
				Console.WriteLine("MENU");
				Console.WriteLine("1_ Dar de alta a un entrenador");
				Console.WriteLine("2_ Dar de baja a un entrenador");
				Console.WriteLine("3_ Dar de alta a un alumno/a en un deporte");
				Console.WriteLine("4_ Dar de alta a un alumno/a en un deporte");
				Console.WriteLine("5_ Realizar el pago de la cuota");
				Console.WriteLine("6_ Listado de Incriptos");
				Console.WriteLine("7_ Listado de deudores");
				Console.WriteLine("8_ Agregar un deporte");
				Console.WriteLine("9_ Eliminar un deporte");
				Console.WriteLine();
				Console.Write("Opcion: ");
				opcion= int.Parse(Console.ReadLine());
				
				switch(opcion){
						case 1: Console.WriteLine("Datos del entrenador");
						Console.Write("");
						Console.Write("Nombre: ");
						nomEn= Console.ReadLine();
						Console.Write("Apellido: ");
						apeEn= Console.ReadLine();
						
						try{
							Console.Write("Dni: ");
							dni= int.Parse(Console.ReadLine());
							Console.Write("Salario: ");
							salario= float.Parse(Console.ReadLine());
							Console.WriteLine();
						}
						catch(FormatException){
							Console.WriteLine();
							Console.ForegroundColor= ConsoleColor.Red;
							Console.WriteLine("Error. El formato ingresado no el correcto");
							Console.ForegroundColor= ConsoleColor.White;
							Console.WriteLine();
							continue;
						}
						
						
						
						Console.Write("Deporte al que pertenece: ");
						nom= Console.ReadLine().ToUpper();
						
						if(nom == deporte.nombre_){
							Console.Write("Ingrese la categoria: ");
							cat= Console.ReadLine().ToUpper();
							
							if(cat == categoria.tipo_){
								entrenador= new Entrenador(nomEn,apeEn,dni,salario);
								categoria.agregarEntrenador(entrenador);
							}
							
							
							if(cat != categoria.tipo_ ){
								Console.WriteLine();
								Console.ForegroundColor= ConsoleColor.Red;
								Console.WriteLine("La categoria ingresada no existe");
								Console.ForegroundColor= ConsoleColor.White;
								Console.Write("¿Desea agregarla?(S/N): ");
								
								
								con= Console.ReadLine().ToUpper();
								switch (con) {
										
									case "S":
										Console.Write("Tipo de categoria: ");
										cat = Console.ReadLine().ToUpper();
										Console.Write("Cupo: ");
										cupo= int.Parse(Console.ReadLine());
										Console.Write("Valor de la cuota: ");
										cuota= float.Parse(Console.ReadLine());
										Console.Write("Ingrese el dia de entrenamiento (00/00/0000): ");
										d= Console.ReadLine();
										Console.Write("Ingrese el hora (00:00): ");
										h= Console.ReadLine();
										en=d+" "+h;
										entrena= DateTime.Parse(en);
										
										entrenador= new Entrenador(nomEn,apeEn,dni,salario);
										categoria= new Categoria(cat,nomEn,dni,cupo,cuota,entrena);
										categoria.agregarEntrenador(entrenador);
										deporte.agregarCategoria(categoria);
										
										Console.WriteLine();
										Console.ForegroundColor= ConsoleColor.Green;
										Console.WriteLine("Entrenador y categoria añadidos correctamente");
										Console.WriteLine("");
										Console.ForegroundColor= ConsoleColor.White;
										break;
										
									case "N":
										Console.WriteLine();
										Console.ForegroundColor= ConsoleColor.Red;
										Console.WriteLine("Lo sentimos, no se puede agregar un entrenador si no existe la categoria");
										Console.ForegroundColor= ConsoleColor.White;
										break;
										
									default:
										Console.ForegroundColor= ConsoleColor.Red;
										Console.WriteLine("La opcion en incorrecta. Ingrese nuevamente la opcion");
										Console.ForegroundColor= ConsoleColor.White;
										continue;
								}
								
								
								Console.WriteLine();
								continue;
							}
						}
						
						
						if(nom != deporte.nombre_){
							Console.WriteLine();
							Console.ForegroundColor= ConsoleColor.Red;
							Console.WriteLine("El deporte ingresado no existe. No podemos agregar al entrenador");
							Console.WriteLine("Ingrese el deporte seleccionando en el menu");
							Console.ForegroundColor= ConsoleColor.White;
							Console.WriteLine();
							continue;
						}
						
						
						
						break;
						
						
						
				}
				
			}
			
			
			
			Console.ReadKey(true);
		}
		
	}
}