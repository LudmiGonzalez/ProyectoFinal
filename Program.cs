using System;

namespace proyecto_final
{
	class Program
	{
		public static void Main(string[] args)
		{
			string con,nom,nomAlum,apeAlum,cat,nomEn, apeEn,d,h,en;
			int dni,opcion,cupo,edad;
			float salario,cuota,montoCuota;
			bool continua=true, sigue=false, catego=false, al=false;;
			
			Console.WriteLine("Bienvenidos al Club deportivo Malu");
			
			// Precargamos algunos datos 
			Club club = new Club("Malu");
			Deporte deporte=new Deporte("Futbol");
			Deporte deporte2=new Deporte("Tenis");
			Deporte deporte3=new Deporte("Basquet");
			club.agregarDeporte(deporte);
			club.agregarDeporte(deporte2);
			club.agregarDeporte(deporte3);
			DateTime diaHoraEntr = DateTime.Parse("20/11/2023 17:00 PM");
			DateTime diaHoraEntr2 = DateTime.Parse("24/11/2023 14:00 PM");
			DateTime diaHoraEntr3 = DateTime.Parse("21/11/2023 18:00 PM");
			Categoria categoria= new Categoria("benjamin",25,3500,diaHoraEntr);
			Categoria categoria2= new Categoria("juvenil",15,5000,diaHoraEntr2);
			Categoria categoria3= new Categoria("infantil",12,3000,diaHoraEntr3);
			deporte.agregarCategoria(categoria);
			deporte2.agregarCategoria(categoria2);
			deporte3.agregarCategoria(categoria3);
			Entrenador entrenador= new Entrenador("Raul","Perez",36478125,120000);
			Entrenador entrenador2= new Entrenador("Sebastian","Torres",37985416,150000);
			Entrenador entrenador3= new Entrenador("Santiago","Banzas",40987562,100000);
			categoria.agregarEntrenador(entrenador);
			categoria2.agregarEntrenador(entrenador2);
			categoria3.agregarEntrenador(entrenador3);
			

			
			//Datos del club (club, deporte, categoria, entrenador)
			
			Console.WriteLine("Complete los datos requeridos por Club");
			Console.WriteLine();
			
			
			
			//------------------------------------------------------------------------------------------------------
			
			Console.WriteLine("_________________________________________________________________________________________________________");
			while(continua){
				Console.WriteLine("");
				Console.WriteLine("MENU");
				Console.WriteLine("1_ Dar de alta a un entrenador");
				Console.WriteLine("2_ Dar de baja a un entrenador");
				Console.WriteLine("3_ Dar de alta a un alumno/a en un deporte");
				Console.WriteLine("4_ Dar de baja a un alumno/a en un deporte");
				Console.WriteLine("5_ Realizar el pago de la cuota");
				Console.WriteLine("6_ Listado de Incriptos");
				Console.WriteLine("7_ Listado de deudores");
				Console.WriteLine("8_ Agregar un deporte");
				Console.WriteLine("9_ Eliminar un deporte");
				Console.WriteLine("10_ Finalizar");
				Console.WriteLine();
				
				try{
					
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
								Console.WriteLine("Error. El formato ingresado no es correcto");
								Console.ForegroundColor= ConsoleColor.White;
								Console.WriteLine();
								continue;
							}
							
							
							Console.Write("Deporte al que pertenece: ");
							nom= Console.ReadLine().ToUpper();
							
							
							foreach (Deporte e in club.deportes_) {
								
								if(nom == e.nombre_.ToUpper()){
									if(club.existe(e)){
										sigue=true;
										Console.ForegroundColor= ConsoleColor.DarkCyan;
										Console.WriteLine("");
										Console.WriteLine("Categorias");
										Console.WriteLine("Prebenjamin(5-7)");
										Console.WriteLine("Benjamin(8-10)");
										Console.WriteLine("Alevin (11-12)");
										Console.WriteLine("Infantil (13-14)");
										Console.WriteLine("Cadetes (15-16)");
										Console.WriteLine("Juvenil (17-19)");
										Console.WriteLine("");
										Console.ForegroundColor= ConsoleColor.White;
										Console.Write("Ingrese la categoria: ");
										cat= Console.ReadLine().ToUpper();
										
										foreach (Categoria categ in e.categorias_) {
											
											if(cat == categ.tipo_.ToUpper()){
												if(e.existeCategoria(categ)){
													catego=true;
													Entrenador entrenador4= new Entrenador(nomEn,apeEn,dni,salario);
													categ.agregarEntrenador(entrenador4);
													categ.nomEntr_=nom;
													categ.dniEntr_=dni;
													Console.WriteLine("");
													Console.ForegroundColor= ConsoleColor.Green;
													Console.WriteLine("Entrenador añadido con exito");
													Console.ForegroundColor= ConsoleColor.White;
													Console.WriteLine("");
												}
											}
											
											
										}
										if(catego==false){
											Console.WriteLine();
											Console.ForegroundColor= ConsoleColor.Red;
											Console.WriteLine("La categoria ingresada no existe");
											Console.ForegroundColor= ConsoleColor.White;
											
										}
										
									}
									
									
									
								}
								
							}
							
							if (sigue==false) {
								Console.ForegroundColor= ConsoleColor.Red;
								Console.WriteLine("El deporte ingresado no existe");
								Console.ForegroundColor= ConsoleColor.White;
							}
							
							catego=false;
							sigue=false;
							break;
							
							
						case 2:
							Console.Write("Deporte al que pertenece el entrenador: ");
							nom= Console.ReadLine().ToUpper();
							
							foreach (Deporte e in club.deportes_){
								
								if(nom == e.nombre_.ToUpper()){
									if(club.existe(e)){
										sigue=true;
										Console.ForegroundColor= ConsoleColor.DarkCyan;
										Console.WriteLine("");
										Console.WriteLine("Categorias");
										Console.WriteLine("Prebenjamin(5-7)");
										Console.WriteLine("Benjamin(8-10)");
										Console.WriteLine("Alevin (11-12)");
										Console.WriteLine("Infantil (13-14)");
										Console.WriteLine("Cadetes (15-16)");
										Console.WriteLine("Juvenil (17-19)");
										Console.WriteLine("");
										Console.ForegroundColor= ConsoleColor.White;
										
										Console.Write("Ingrese la categoria a la que pertenece el entrenador: ");
										cat= Console.ReadLine().ToUpper();
										foreach (Categoria categ in e.categorias_) {
											
											if(cat == categ.tipo_.ToUpper()){
												if(e.existeCategoria(categ)){
													catego=true;
													bool existe=false;
													Console.WriteLine("Ingrese el dni del entrenador");
													
													try{
														Console.Write("Dni: ");
														dni= int.Parse(Console.ReadLine());
														
													}
													catch(FormatException){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El formato ingresado no es correcto");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													
													foreach (Entrenador entrena in categ.entrenadores_) {
														if (dni == entrena.dni_) {
															existe=true;
															categ.eliminarEntrenador(entrena);
															categ.nomEntr_=null;
												        	        categ.dniEntr_=0;
												        	
															Console.WriteLine();
															Console.ForegroundColor= ConsoleColor.Green;
															Console.WriteLine("El entrenador se ha eliminado con exito");
															Console.ForegroundColor= ConsoleColor.White;
															Console.WriteLine();
															break;
														}
													}
													
													if(existe==false){
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("El dni no coincide con el de algun entrenador en esta categoria");
														Console.ForegroundColor= ConsoleColor.White;
														break;}
													
												}
											}
											
										}
										if(catego==false){
											Console.ForegroundColor= ConsoleColor.Red;
											Console.WriteLine("La categoria ingresada no existe");
											Console.ForegroundColor= ConsoleColor.White;
											break;
										}
										
									}
								}
								
								
								
							}
							if (sigue==false) {
								Console.ForegroundColor= ConsoleColor.Red;
								Console.WriteLine("El deporte no existe");
								Console.ForegroundColor= ConsoleColor.White;
							}
							catego=false;
							sigue=false;
							break;
							
						case 3:
							Console.WriteLine("Ingrese los datos del alumno");
							Console.Write("Nombre: ");
							nomAlum= Console.ReadLine();
							Console.Write("Apellido: ");
							apeAlum= Console.ReadLine();
							
							try{
								Console.Write("Dni: ");
								dni= int.Parse(Console.ReadLine());
								Console.Write("Edad: ");
								edad= int.Parse(Console.ReadLine());
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
							
							
							Console.Write("Deporte: ");
							nom= Console.ReadLine().ToUpper();
							foreach (Deporte e in club.deportes_){
								
								if(nom== e.nombre_.ToUpper() && club.existe(e)){
									sigue=true;
									Console.ForegroundColor= ConsoleColor.DarkCyan;
									Console.WriteLine("____________________________________________");
									Console.WriteLine("Categorias");
									Console.WriteLine("Prebenjamin(5-7)");
									Console.WriteLine("Benjamin(8-10)");
									Console.WriteLine("Alevin (11-12)");
									Console.WriteLine("Infantil (13-14)");
									Console.WriteLine("Cadetes (15-16)");
									Console.WriteLine("Juvenil (17-19)");
									Console.WriteLine("____________________________________________");
									Console.WriteLine();
									Console.ForegroundColor= ConsoleColor.White;
									
									Console.Write("Ingrese la categoria segun la edad del alumno: ");
									cat= Console.ReadLine().ToUpper();
									foreach (Categoria categ in e.categorias_) {
										
										
										if(cat == categ.tipo_.ToUpper() && e.existeCategoria(categ)){
											catego=true;
											try{
												
												if (categ.inscriptos_.Count != categ.cupo_) {
													Alumno alum = new Alumno(nomAlum,apeAlum,dni,edad);
													alum.depor_=e;
													alum.cate_=categ;
													categ.agregarAlum(alum);
													e.agregarAlum(alum);
													
													Console.Write("Quiere hacerse socio(S/N): ");
													con= Console.ReadLine().ToUpper();
													
													switch (con) {
														case "S":
															alum.socio_=true;
															Console.WriteLine();
															Console.ForegroundColor= ConsoleColor.Green;
															Console.WriteLine("Excelente. Ya es socio del club");
															break;
														case "N":
															alum.socio_=false;
															break;
														default:
															Console.ForegroundColor= ConsoleColor.Red;
															Console.WriteLine("La opcion en incorrecta. Ingrese nuevamente la opcion");
															Console.ForegroundColor= ConsoleColor.White;
															continue;
													}
													
													Console.WriteLine("");
													Console.ForegroundColor= ConsoleColor.Green;
													Console.WriteLine("El alumno fue inscripto con exito");
													Console.ForegroundColor= ConsoleColor.White;
													Console.WriteLine("");
													break;
													
												}
												if (categ.inscriptos_.Count == categ.cupo_) {
													throw new NoHayCupo();
												}
											}
											catch(NoHayCupo){
												Console.WriteLine("");
												Console.ForegroundColor= ConsoleColor.Red;
												Console.WriteLine("Lo sentimos, ya no hay mas cupos disponibles");
												Console.ForegroundColor= ConsoleColor.White;
												Console.WriteLine("");
												break;
											}
											
											
										}
										
										
										
									}
									if(catego==false){
										Console.ForegroundColor= ConsoleColor.Red;
										Console.WriteLine("Lo sentimos, actualmente no contamos con esa categoria");
										Console.ForegroundColor= ConsoleColor.White;
										break;
									}
									
								}
								
							}
							if (sigue==false) {
								Console.ForegroundColor= ConsoleColor.Red;
								Console.WriteLine("El deporte ingresado no existe");
								Console.ForegroundColor= ConsoleColor.White;
							}
							catego=false;
							sigue=false;
							
							break;
							
						case 4:
							
							
							Console.Write("Deporte al que se quiere dar de baja: ");
							nom= Console.ReadLine().ToUpper();
							foreach (Deporte e in club.deportes_){
								
								if(nom == e.nombre_.ToUpper()){
									if(club.existe(e)){
										sigue=true;
										Console.ForegroundColor= ConsoleColor.DarkCyan;
										Console.WriteLine("");
										Console.WriteLine("Categorias");
										Console.WriteLine("Prebenjamin(5-7)");
										Console.WriteLine("Benjamin(8-10)");
										Console.WriteLine("Alevin (11-12)");
										Console.WriteLine("Infantil (13-14)");
										Console.WriteLine("Cadetes (15-16)");
										Console.WriteLine("Juvenil (17-19)");
										Console.WriteLine("");
										Console.ForegroundColor= ConsoleColor.White;
										
										Console.Write("Ingrese la categoria a la que pertenece el alumno: ");
										cat= Console.ReadLine().ToUpper();
										
										foreach (Categoria categ in e.categorias_) {
											
											if(cat == categ.tipo_.ToUpper()){
												try{
													Console.Write("Dni del alumno: ");
													dni= int.Parse(Console.ReadLine());
													
												}
												catch(FormatException){
													Console.WriteLine();
													Console.ForegroundColor= ConsoleColor.Red;
													Console.WriteLine("Error. El formato ingresado no el correcto");
													Console.ForegroundColor= ConsoleColor.White;
													Console.WriteLine();
													continue;
												}
												if(e.existeCategoria(categ)){
													
													catego=true;
													foreach (Alumno alumn in categ.inscriptos_) {
														if (dni == alumn.dni_) {
															al =true;
															if(alumn.socio_ == true)
															{
																Console.Write("Quiere dejar de ser socio(S/N): ");
																con= Console.ReadLine().ToUpper();
																
																switch (con) {
																	case "S":
																		alumn.socio_=false;
																		Console.WriteLine("Ha dejado de ser socio");
																		break;
																	case "N":
																		alumn.socio_=true;
																		break;
																	default:
																		Console.ForegroundColor= ConsoleColor.Red;
																		Console.WriteLine("La opcion en incorrecta. Ingrese nuevamente la opcion");
																		Console.ForegroundColor= ConsoleColor.White;
																		continue;
																}
															}
															categ.eliminarAlum(alumn);
															e.eliminarAlum(alumn);
															alumn.cate_=null;
															alumn.depor_=null;
															
															
															Console.WriteLine();
															Console.ForegroundColor= ConsoleColor.Green;
															Console.WriteLine("El alumno se ha dado de baja con exito");
															Console.ForegroundColor= ConsoleColor.White;
															Console.WriteLine();
															break;
														}
														
													}
													if (al==false) {
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("No existe un alumno con ese dni");
														Console.ForegroundColor= ConsoleColor.White;
													}
												}
											}
											
										}
										if(catego==false){
											Console.ForegroundColor= ConsoleColor.Red;
											Console.WriteLine("La categoria ingresada no existe");
											Console.ForegroundColor= ConsoleColor.White;
											break;
										}
										
									}
								}
							}
							
							if (sigue==false) {
								Console.ForegroundColor= ConsoleColor.Red;
								Console.WriteLine("El deporte ingresado no existe");
								Console.ForegroundColor= ConsoleColor.White;
							}
							catego=false;
							sigue=false;
							al =false;
							
							
							
							break;
							
						case 5:
							Console.WriteLine("Para pagar la cuota complete los datos requeridos");
							
							
							Console.Write("Deporte al que esta inscripto: ");
							nom= Console.ReadLine().ToUpper();
							foreach (Deporte e in club.deportes_){
								
								if(nom == e.nombre_.ToUpper()){
									if(club.existe(e)){
										sigue=true;
										Console.ForegroundColor= ConsoleColor.DarkCyan;
										Console.WriteLine("");
										Console.WriteLine("Categorias");
										Console.WriteLine("Prebenjamin(5-7)");
										Console.WriteLine("Benjamin(8-10)");
										Console.WriteLine("Alevin (11-12)");
										Console.WriteLine("Infantil (13-14)");
										Console.WriteLine("Cadetes (15-16)");
										Console.WriteLine("Juvenil (17-19)");
										Console.WriteLine("");
										Console.ForegroundColor= ConsoleColor.White;
										
										Console.Write("Ingrese la categoria a la que pertenece el alumno: ");
										cat= Console.ReadLine().ToUpper();
										
										foreach (Categoria categ in e.categorias_) {
											
											if(cat == categ.tipo_.ToUpper()){
												if(e.existeCategoria(categ)){
													catego=true;
													try{
														Console.Write("Dni del alumno: ");
														dni= int.Parse(Console.ReadLine());
														
													}
													catch(FormatException){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El formato ingresado no el correcto");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													foreach (Alumno alumn in categ.inscriptos_) {
														
														if (dni == alumn.dni_) {
															al =true;
															Console.WriteLine();
															Console.WriteLine("----------------------------------------------------------");
															Console.WriteLine("Valor de la cuota: "+categ.cuota_);
															Console.WriteLine("----------------------------------------------------------");
															Console.WriteLine();
															
															
															try{
																Console.Write("Ingrese el monto a pagar: ");
																montoCuota= float.Parse(Console.ReadLine());
																
															}
															catch(FormatException){
																Console.WriteLine();
																Console.ForegroundColor= ConsoleColor.Red;
																Console.WriteLine("Error. El formato ingresado no es correcto");
																Console.ForegroundColor= ConsoleColor.White;
																Console.WriteLine();
																continue;
															}
															
															if(montoCuota== categ.cuota_){
																if (alumn.socio_== true) {
																	
																	float descuento,precioFinal;
																	descuento= (montoCuota * 30)/100;
																	precioFinal= montoCuota - descuento;
																	alumn.mesPago_= DateTime.Now;
																	
																	Console.WriteLine();
																	Console.ForegroundColor= ConsoleColor.Green;
																	Console.WriteLine("Se le ha aplicado un descuento del 30% por ser socio");
																	Console.WriteLine("Monto final pagado: "+precioFinal);
																}
																if (alumn.socio_== false) {
																	
																	alumn.mesPago_= DateTime.Now;
																	
																	Console.WriteLine();
																	Console.ForegroundColor= ConsoleColor.Green;
																	Console.WriteLine("No tiene descuento");
																	Console.WriteLine("Monto final pagado: "+montoCuota);
																}
																
																Console.WriteLine();
																Console.ForegroundColor= ConsoleColor.Green;
																Console.WriteLine("El pago se ha realizado con exito");
																Console.ForegroundColor= ConsoleColor.White;
																Console.WriteLine();
																break;
															}
															if(montoCuota != categ.cuota_){
																Console.ForegroundColor= ConsoleColor.Red;
																Console.WriteLine();
																Console.WriteLine("El monto ingresado no coincide con el de la cuota");
																Console.WriteLine();
																Console.ForegroundColor= ConsoleColor.White;
															}
														}
													}
													if (al==false) {
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("No existe un alumno con ese dni");
														Console.ForegroundColor= ConsoleColor.White;
													}
												}
											}
											
										}
										if(catego==false){
											Console.ForegroundColor= ConsoleColor.Red;
											Console.WriteLine("La categoria ingresada no existe");
											Console.ForegroundColor= ConsoleColor.White;
											break;
										}
										
									}
								}
							}
							
							if (sigue==false) {
								Console.ForegroundColor= ConsoleColor.Red;
								Console.WriteLine("El deporte ingresado no existe");
								Console.ForegroundColor= ConsoleColor.White;
							}
							catego=false;
							sigue=false;
							
							
							
							break;
							
							
						case 6:
							bool submenu=true;
							
							while(submenu){
								Console.WriteLine("");
								Console.WriteLine("SUBMENU");
								Console.WriteLine("1_ Por deporte");
								Console.WriteLine("2_ Por deporte categoria");
								Console.WriteLine("3_ Total");
								Console.WriteLine("4_ Volver al menu principal");
								try{
									Console.WriteLine();
									Console.Write("Ingrese una opcion: ");
									opcion= int.Parse(Console.ReadLine());
									
							}
							catch(FormatException){
								Console.WriteLine();
								Console.ForegroundColor= ConsoleColor.Red;
								Console.WriteLine("Error. El formato ingresado no es correcto");
								Console.ForegroundColor= ConsoleColor.White;
								Console.WriteLine();
								continue;
							}
							
							
							Console.WriteLine("");
							switch (opcion) {
								case 1:
									Console.WriteLine("Incriptos por deporte");
									
									foreach (Deporte de in club.deportes_) {
										Console.WriteLine();
										Console.BackgroundColor =ConsoleColor.DarkBlue;
										Console.WriteLine(de.nombre_.ToUpper());
										Console.BackgroundColor =ConsoleColor.Black;
										foreach (Alumno a in de.alumnos_) {
											Console.ForegroundColor= ConsoleColor.Magenta;
											a.imprimir();
											Console.WriteLine();
											Console.ForegroundColor= ConsoleColor.White;
										}
									}
									
									break;
								case 2:
									Console.WriteLine("Inscriptos por deporte y categoria");
									foreach (Deporte de in club.deportes_) {
										Console.WriteLine();
										Console.BackgroundColor =ConsoleColor.DarkBlue;
										Console.WriteLine(de.nombre_.ToUpper());
										Console.BackgroundColor =ConsoleColor.Black;
										foreach(Categoria cate in de.categorias_){
											Console.WriteLine();
											Console.WriteLine("- "+cate.tipo_.ToUpper());
											
											foreach (Alumno a in de.alumnos_) {
												Console.ForegroundColor= ConsoleColor.Magenta;
												if(a.cate_ == cate)
													a.imprimir();
												Console.WriteLine();
												Console.ForegroundColor= ConsoleColor.White;
											}
										}
									}
									break;
								case 3:
									Console.WriteLine("Total de inscriptos");
									foreach (Deporte de in club.deportes_) {
										foreach (Alumno a in de.alumnos_) {
											Console.ForegroundColor= ConsoleColor.Magenta;
											a.imprimir();
											Console.WriteLine();
											Console.ForegroundColor= ConsoleColor.White;
											
										}
										
									}
									
									
									break;
								case 4:
									Console.WriteLine();
									submenu=false;
									break;
									
								default:
									Console.ForegroundColor= ConsoleColor.Red;
									Console.WriteLine("Opcion incorrecta");
									Console.ForegroundColor= ConsoleColor.White;
									continue;
							}
					}
							break;
							
						case 7:
							Console.WriteLine("Lista de deudores");
							
							foreach (Deporte de in club.deportes_) {
								foreach (Alumno a in de.alumnos_) {
									
									DateTime fechaActual = DateTime.Now;
									//DateTime fechaActual = DateTime.Parse("14/12/2023");
									
									DateTime fechaLimite= a.mesPago_.AddMonths(1);
									bool pago= (fechaActual<=fechaLimite);
									
									
									if (pago== false) {
										Console.ForegroundColor= ConsoleColor.Red;
										a.imprimir();
										Console.WriteLine();
										Console.WriteLine("Ultimo mes pago: "+a.mesPago_);
										Console.WriteLine("Fecha limite: "+fechaLimite);
										Console.ForegroundColor= ConsoleColor.White;
										
									}
									
								}
								
							}
							
							break;
						case 8:
							Console.Write("Ingrese el nombre del deporte: ");
							nom= Console.ReadLine().ToUpper();
							
							
							foreach (Deporte e in club.deportes_) {
								
								if(nom == e.nombre_.ToUpper()){
									if(club.existe(e)){
										sigue=true;
										Console.WriteLine("");
										Console.WriteLine("El deporte ya existe");
										Console.WriteLine("");
										
										
										Console.Write("¿Desea agregar una categoria?(S/N): ");
										con= Console.ReadLine().ToUpper();
										
										switch (con) {
												
											case "S":
												
												Console.ForegroundColor= ConsoleColor.DarkCyan;
												Console.WriteLine("");
												Console.WriteLine("Categorias");
												Console.WriteLine("Prebenjamin(5-7)");
												Console.WriteLine("Benjamin(8-10)");
												Console.WriteLine("Alevin (11-12)");
												Console.WriteLine("Infantil (13-14)");
												Console.WriteLine("Cadetes (15-16)");
												Console.WriteLine("Juvenil (17-19)");
												Console.WriteLine("");
												Console.ForegroundColor= ConsoleColor.White;
												Console.Write("Ingrese a categoria: ");
												cat= Console.ReadLine().ToUpper();
												foreach (Categoria categ in e.categorias_) {
													
													if(cat == categ.tipo_.ToUpper()){
														if(e.existeCategoria(categ)){
															catego=true;
															Console.WriteLine("");
															Console.ForegroundColor= ConsoleColor.Green;
															Console.WriteLine("La categoria ya existe");
															Console.ForegroundColor= ConsoleColor.White;
															Console.WriteLine("");
															
															break;
														}
													}
													
													
												}
												if(catego==false){
													
													Console.Write("Cupo: ");
													try{
														cupo= int.Parse(Console.ReadLine());
														Console.Write("Valor de la cuota: ");
														cuota= float.Parse(Console.ReadLine());
														Console.Write("Ingrese el dia de entrenamiento (00/00/0000): ");
														d= Console.ReadLine();
														Console.Write("Ingrese el hora (00:00 AM): ");
														h= Console.ReadLine();
														
													}
													catch(FormatException){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El formato ingresado no es correcto");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													
													en=d+" "+h;
													
													DateTime diaHoraEntr4 = DateTime.Parse(en);
													
													Categoria categoria4= new Categoria(cat,cupo,cuota,diaHoraEntr4);
													e.agregarCategoria(categoria4);
													
													Console.WriteLine();
													Console.ForegroundColor= ConsoleColor.Green;
													Console.WriteLine("La categoria ha sido añadida con exito");
													Console.WriteLine("");
													Console.ForegroundColor= ConsoleColor.White;
													
												}
												break;
												
											case "N":
												Console.WriteLine();
												Console.ForegroundColor= ConsoleColor.Green;
												Console.WriteLine("finalizado");
												Console.ForegroundColor= ConsoleColor.White;
												break;
												
											default:
												Console.ForegroundColor= ConsoleColor.Red;
												Console.WriteLine("La opcion en incorrecta. Ingrese nuevamente una opcion");
												Console.ForegroundColor= ConsoleColor.White;
												continue;
										}
										Console.WriteLine();
										
										break;
										
										
									}
									
									
									
								}
								
							}
							
							if (sigue==false) {
								foreach (Deporte e in club.deportes_) {
									Deporte de = new Deporte(nom);
									
									club.agregarDeporte(de);
									Console.Write("¿Desea agregar una categoria?(S/N): ");
									con= Console.ReadLine().ToUpper();
									
									switch (con) {
											
										case "S":
											
											Console.ForegroundColor= ConsoleColor.DarkCyan;
											Console.WriteLine("");
											Console.WriteLine("Categorias");
											Console.WriteLine("Prebenjamin(5-7)");
											Console.WriteLine("Benjamin(8-10)");
											Console.WriteLine("Alevin (11-12)");
											Console.WriteLine("Infantil (13-14)");
											Console.WriteLine("Cadetes (15-16)");
											Console.WriteLine("Juvenil (17-19)");
											Console.WriteLine("");
											Console.ForegroundColor= ConsoleColor.White;
											Console.Write("Ingrese la categoria: ");
											cat= Console.ReadLine().ToUpper();
											
											
											sigue=true;
											Console.Write("Cupo: ");
											try{
												
												cupo= int.Parse(Console.ReadLine());
												Console.Write("Valor de la cuota: ");
												cuota= float.Parse(Console.ReadLine());
												Console.Write("Ingrese el dia de entrenamiento (00/00/0000): ");
												d= Console.ReadLine();
												Console.Write("Ingrese el hora (00:00 AM): ");
												h= Console.ReadLine();
												
											}
											catch(FormatException){
												Console.WriteLine();
												Console.ForegroundColor= ConsoleColor.Red;
												Console.WriteLine("Error. El formato ingresado no es correcto");
												Console.ForegroundColor= ConsoleColor.White;
												Console.WriteLine();
												continue;
											}
											en=d+" "+h;
											
											DateTime diaHoraEntr4 = DateTime.Parse(en);
											
											Categoria categoria4= new Categoria(cat,cupo,cuota,diaHoraEntr4);
											de.agregarCategoria(categoria4);
											
											Console.WriteLine();
											Console.ForegroundColor= ConsoleColor.Green;
											Console.WriteLine("El deporte y la categoria han sido añadidos con exito");
											Console.WriteLine("");
											Console.ForegroundColor= ConsoleColor.White;
											
											
											break;
											
										case "N":
											Console.WriteLine();
											Console.ForegroundColor= ConsoleColor.Green;
											Console.WriteLine("El deporte ha sido añadido con exito");
											Console.ForegroundColor= ConsoleColor.White;
											break;
											
										default:
											Console.ForegroundColor= ConsoleColor.Red;
											Console.WriteLine("La opcion en incorrecta. Ingrese nuevamente la opcion");
											Console.ForegroundColor= ConsoleColor.White;
											continue;
									}
									Console.WriteLine();
									
									break;
									
									
								}
								
								
								
								
							}
							
							catego=false;
							sigue=false;
							break;
							
						case 9:
							
							Console.Write("Nombre del deporte: ");
							nom= Console.ReadLine().ToUpper();
							
							foreach (Deporte depo in club.deportes_) {
								if(nom == depo.nombre_.ToUpper()){
									sigue=true;
									if(club.existe(depo)){
										
											if(depo.cantidadAlumn()==0){
												
												club.eliminarDeporte(depo);
												Console.WriteLine();
												Console.ForegroundColor= ConsoleColor.Green;
												Console.WriteLine("El deporte ha sido eliminado");
												Console.ForegroundColor= ConsoleColor.White;
												Console.WriteLine();
												break;
											}
										Console.WriteLine();
										Console.ForegroundColor= ConsoleColor.Red;
										Console.WriteLine("El deporte no puede ser eliminado, ya que cuenta con alumnos inscriptos");
										Console.ForegroundColor= ConsoleColor.White;
										Console.WriteLine();
										break;
										
									}
								}
							}
							
							if (sigue == false) {
								Console.WriteLine();
								Console.ForegroundColor= ConsoleColor.Red;
								Console.WriteLine("El deporte que desea eliminar no existe");
								Console.ForegroundColor= ConsoleColor.White;
								Console.WriteLine();
								break;}
							
							
							sigue=false;
							break;
							
						case 10:
							Console.WriteLine();
							Console.ForegroundColor= ConsoleColor.Green;
							Console.WriteLine("El proceso ha finalizado con exito");
							Console.ForegroundColor= ConsoleColor.White;
							Console.WriteLine();
							continua=false;
							break;
						default:
							Console.ForegroundColor= ConsoleColor.Red;
							Console.WriteLine("La opcion seleccionada no existe");
							Console.WriteLine("Ingrese nuevamente una opcion");
							Console.ForegroundColor= ConsoleColor.White;
							continue;
							
					}
				}
				catch(FormatException){
					Console.ForegroundColor= ConsoleColor.Red;
					Console.WriteLine("Error. El formato ingresado no es correcto");
					Console.ForegroundColor= ConsoleColor.White;
					continue;
				}
			}
			
			
			
			Console.ReadKey(true);
		}
		
	}
}
