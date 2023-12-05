using System;

namespace proyecto_final
{
	class Program
	{
		public static void Main(string[] args)
		{
			string con,nom,nomAlum,apeAlum,cat,nomEn, apeEn,d,h,en;
			int dni,opcion,cupo,edad,id, idCat;
			float salario,cuota,montoCuota;
			bool continua=true, sigue=false, catego=false, al=false;;
			
			
			
			Console.WriteLine("Bienvenidos al Club deportivo Malu");
			Console.WriteLine("   para niños y adolescentes");
			
			// Precargamos algunos datos 
			Club club = new Club("Malu");
			Deporte deporte=new Deporte(1211,"Futbol");
			Deporte deporte2=new Deporte(2313,"Tenis");
			Deporte deporte3=new Deporte(3221,"Basquet");
			club.agregarDeporte(deporte);
			club.agregarDeporte(deporte2);
			club.agregarDeporte(deporte3);
			DateTime diaHoraEntr = DateTime.Parse("20/11/2023 17:00 PM");
			DateTime diaHoraEntr2 = DateTime.Parse("24/11/2023 14:00 PM");
			DateTime diaHoraEntr3 = DateTime.Parse("21/11/2023 18:00 PM");
			Categoria categoria= new Categoria(810,"benjamin",25,3500,diaHoraEntr);
			Categoria categoria2= new Categoria(1719,"juvenil",15,5000,diaHoraEntr2);
			Categoria categoria3= new Categoria(1314,"infantil",12,3000,diaHoraEntr3);
			deporte.agregarCategoria(categoria);
			deporte2.agregarCategoria(categoria2);
			deporte3.agregarCategoria(categoria3);
			Entrenador entrenador= new Entrenador("Raul","Perez",36478125,120000);
			categoria.entrenad_=entrenador;
			categoria.nomEntr_=entrenador.nombre_;
			categoria.dniEntr_=entrenador.dni_;
			Entrenador entrenador2= new Entrenador("Sebastian","Torres",37985416,150000);
			categoria2.entrenad_=entrenador2;
			categoria2.nomEntr_=entrenador2.nombre_;
			categoria2.dniEntr_=entrenador2.dni_;
			Entrenador entrenador3= new Entrenador("Santiago","Banzas",40987562,100000);
			categoria3.entrenad_=entrenador3;
			categoria3.nomEntr_=entrenador3.nombre_;
			categoria3.dniEntr_=entrenador3.dni_;
			

			
			//Datos del club (club, deporte, categoria, entrenador)
			
			
			
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
				Console.WriteLine("8_ Listado de entrenadores");
				Console.WriteLine("9_ Agregar un deporte");
				Console.WriteLine("10_ Eliminar un deporte");
				Console.WriteLine("11_ Finalizar");
				Console.WriteLine();
				
				try{
					
					Console.Write("Opcion: ");
					opcion= int.Parse(Console.ReadLine());
					Console.WriteLine();
					switch(opcion){
							case 1: 
							Console.Clear();
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine("Deportes existentes en el club");
							Console.WriteLine();
							foreach (Deporte de in club.verDatos()) {
								
								Console.ForegroundColor= ConsoleColor.Magenta;
								Console.WriteLine(de.nombre_.ToUpper()+"("+de.identificador_+") ");
								Console.ForegroundColor= ConsoleColor.White;
								
							}
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine();
							
							Console.Write("Deporte del que sera entrenador (ingrese solo el identificador): ");
							id= int.Parse(Console.ReadLine());
							
							
							foreach (Deporte e in club.verDatos()) {
								
								if(id == e.identificador_){
									if(club.existe(e)){
										sigue=true;

										Console.WriteLine("");
										Console.WriteLine("----------------------------------------------------------");
										Console.WriteLine("Categorias");
										Console.WriteLine();
										foreach (Categoria c in e.verDatosCategoria()) {
											Console.ForegroundColor= ConsoleColor.DarkCyan;
											Console.WriteLine(c.tipo_.ToUpper()+" ("+c.identificador_+") ");
											Console.ForegroundColor= ConsoleColor.White;
										}
										Console.WriteLine("----------------------------------------------------------");
										Console.WriteLine("");
										
										Console.Write("Ingrese la categoria (ingrese solo el identificador): ");
										idCat= int.Parse(Console.ReadLine());
										
										foreach (Categoria categ in e.verDatosCategoria()) {
											
											if(idCat == categ.identificador_){
												if(e.existeCategoria(categ)){
													
													catego=true;
													bool enT=false;
													Console.WriteLine("Datos del entrenador");
													Console.Write("");
													Console.Write("Nombre: ");
													nomEn= Console.ReadLine();
													Console.Write("Apellido: ");
													apeEn= Console.ReadLine();
													
													try{
														Console.Write("Dni: ");
														dni= int.Parse(Console.ReadLine());
														if (dni==0) {
															throw new dniCero();
														}
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
													catch(dniCero){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El dni no puede valer 0");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													if(categ.dniEntr_==0 && categ.nomEntr_ == null){
														enT=true;
													Entrenador entrenador4= new Entrenador(nomEn,apeEn,dni,salario);
													categ.entrenad_=entrenador4;
													categ.nomEntr_=nomEn;
													categ.dniEntr_=dni;
													
													Console.WriteLine("");
													Console.ForegroundColor= ConsoleColor.Green;
													Console.WriteLine("Entrenador añadido con exito");
													Console.ForegroundColor= ConsoleColor.White;
													Console.WriteLine("");
												}
													if (categ.dniEntr_!=0 && categ.nomEntr_ != null && enT==false) {
														Console.WriteLine("Ya existe un entrenador en esta categoria");
														Console.Write("¿Desea modificarlo?(S/N): ");
														con= Console.ReadLine().ToUpper();
														
														switch (con) {
															case "S":
																Entrenador entrenador4= new Entrenador(nomEn,apeEn,dni,salario);
																categ.entrenad_=entrenador4;
																categ.nomEntr_=nomEn;
																categ.dniEntr_=dni;
																
																Console.ForegroundColor= ConsoleColor.Green;
																Console.WriteLine("Entrenador se ha modificado con exito");
																Console.ForegroundColor= ConsoleColor.White;
																break;
																
															case "N":
																Console.ForegroundColor= ConsoleColor.Green;
																Console.WriteLine("No se ha modificado el entrenador");
																Console.ForegroundColor= ConsoleColor.White;
																break;
															default:
																Console.ForegroundColor= ConsoleColor.Red;
																Console.WriteLine("Opcion incorrecta");
																Console.ForegroundColor= ConsoleColor.White;
																continue;
														}
													}
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
							Console.Clear();
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine("Deportes existentes en el club");
							Console.WriteLine();
							foreach (Deporte de in club.verDatos()) {
								
								Console.ForegroundColor= ConsoleColor.Magenta;
								Console.WriteLine(de.nombre_.ToUpper()+"("+de.identificador_+") ");
								Console.ForegroundColor= ConsoleColor.White;
								
							}
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine();
							Console.Write("Deporte al que pertenece el entrenador (ingrese solo el identificador): ");
							id= int.Parse(Console.ReadLine());
							
							foreach (Deporte e in club.verDatos()){
								
								if(id == e.identificador_){
									if(club.existe(e)){
										sigue=true;
										
										Console.WriteLine("");
										Console.WriteLine("----------------------------------------------------------");
										Console.WriteLine("Categorias");
										Console.WriteLine();
										foreach (Categoria c in e.verDatosCategoria()) {
											Console.ForegroundColor= ConsoleColor.DarkCyan;
											Console.WriteLine(c.tipo_.ToUpper()+"("+c.identificador_+") ");
											Console.ForegroundColor= ConsoleColor.White;
										}
										Console.WriteLine("----------------------------------------------------------");
										Console.WriteLine("");
										Console.Write("Ingrese la categoria a la que pertenece el entrenador (ingrese solo el identificador): ");
										idCat= int.Parse(Console.ReadLine());
										foreach (Categoria categ in e.verDatosCategoria()) {
											
											
											
											if(idCat == categ.identificador_){
												Console.WriteLine();
												catego=true;
												if(categ.entrenad_!=null){
												Console.WriteLine("Entrenador de la categoria");
												Console.WriteLine();
												Console.ForegroundColor= ConsoleColor.Magenta;
												
												categ.entrenad_.imprimir();
												
												Console.ForegroundColor= ConsoleColor.White;
												Console.WriteLine();
												if(e.existeCategoria(categ)){
													
													
													bool existe=false;
													
													Console.WriteLine("Ingrese el dni del entrenador para eliminarlo");
													
													try{
														Console.Write("Dni: ");
														dni= int.Parse(Console.ReadLine());
														if (dni == 0) {
															throw new dniCero();
														}
														
													}
													catch(FormatException){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El formato ingresado no es correcto");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													catch(dniCero){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El dni no puede valer 0");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													
													
													if (dni == categ.dniEntr_) {
														existe=true;
														categ.entrenad_=null;
														categ.nomEntr_=null;
														categ.dniEntr_=0;
														
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Green;
														Console.WriteLine("El entrenador se ha eliminado con exito");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														break;
													}
													
													
													if(existe==false){
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("El dni no coincide con el del entrenador de esta categoria");
														Console.ForegroundColor= ConsoleColor.White;
														break;}
													
												}
												}
												else{
													Console.ForegroundColor= ConsoleColor.Red;
													Console.WriteLine("No hay entrenador en esta categoria");
													Console.ForegroundColor= ConsoleColor.White;
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
							Console.Clear();
							Console.Clear();
							Console.WriteLine("Ingrese los datos del alumno");
							Console.Write("Nombre: ");
							nomAlum= Console.ReadLine();
							Console.Write("Apellido: ");
							apeAlum= Console.ReadLine();
							
							try{
								Console.Write("Dni: ");
								dni= int.Parse(Console.ReadLine());
								if (dni==0) {
									throw new dniCero();
								}
								Console.Write("Edad: ");
								edad= int.Parse(Console.ReadLine());
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
							catch(dniCero){
								Console.WriteLine();
								Console.ForegroundColor= ConsoleColor.Red;
								Console.WriteLine("Error. El dni no puede valer 0");
								Console.ForegroundColor= ConsoleColor.White;
								Console.WriteLine();
								continue;
							}
							
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine("Deportes existentes en el club");
							Console.WriteLine();
							foreach (Deporte de in club.verDatos()) {
								
								Console.ForegroundColor= ConsoleColor.Magenta;
								Console.WriteLine(de.nombre_.ToUpper()+"("+de.identificador_+") ");
								Console.ForegroundColor= ConsoleColor.White;
								
							}
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine();
							Console.Write("Deporte (ingrese solo el identificador): ");
							id= int.Parse(Console.ReadLine());
							
							foreach (Deporte e in club.verDatos()){
								
								if(id== e.identificador_ && club.existe(e)){
									sigue=true;
									Console.WriteLine("");
									Console.WriteLine("----------------------------------------------------------");
									Console.WriteLine("Categorias");
									Console.WriteLine();
									foreach (Categoria c in e.verDatosCategoria()) {
										Console.ForegroundColor= ConsoleColor.DarkCyan;
										Console.WriteLine(c.tipo_.ToUpper()+"("+c.identificador_+") ");
										Console.ForegroundColor= ConsoleColor.White;
									}
									Console.WriteLine("----------------------------------------------------------");
									Console.WriteLine("");
									
									Console.Write("Ingrese la categoria segun la edad del alumno (ingrese solo el identificador): ");
									idCat= int.Parse(Console.ReadLine());
									
									foreach (Categoria categ in e.verDatosCategoria()) {
										
										
										if(idCat == categ.identificador_ && e.existeCategoria(categ)){
											catego=true;
											bool existe= false;
											foreach (Alumno alumno in categ.verDatos()) {
												if (dni==alumno.dni_) {
													existe =true;
													Console.WriteLine();
													Console.ForegroundColor= ConsoleColor.Red;
													Console.WriteLine("Ya existe un alumno inscripto con ese DNI en esta categoria");
													Console.ForegroundColor= ConsoleColor.White;
													Console.WriteLine();
												}
											}
											
											if(existe == false){
											
											try{
												
													if (categ.verDatos().Count != categ.cupo_) {
													
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
															Console.WriteLine("La opcion en incorrecta. Ingrese nuevamente una opcion");
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
													if (categ.verDatos().Count == categ.cupo_) {
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
									}
									if(catego==false){
										Console.ForegroundColor= ConsoleColor.Red;
										Console.WriteLine("Lo sentimos, actualmente no contamos con esta categoria");
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
							Console.Clear();
							
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine("Deportes existentes en el club");
							Console.WriteLine();
							foreach (Deporte de in club.verDatos()) {
								
								Console.ForegroundColor= ConsoleColor.Magenta;
								Console.WriteLine(de.nombre_+"("+de.identificador_+") ");
								Console.ForegroundColor= ConsoleColor.White;
								
							}
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine();
							Console.Write("Deporte al que se quiere dar de baja el alumno (ingrese solo el identificador): ");
							id= int.Parse(Console.ReadLine());
							foreach (Deporte e in club.verDatos()){
								
								if(id == e.identificador_){
									if(club.existe(e)){
										sigue=true;
										Console.WriteLine("");
										Console.WriteLine("----------------------------------------------------------");
										Console.WriteLine("Categorias");
										Console.WriteLine();
										foreach (Categoria c in e.verDatosCategoria()) {
											Console.ForegroundColor= ConsoleColor.DarkCyan;
											Console.WriteLine(c.tipo_.ToUpper()+"("+c.identificador_+") ");
											Console.ForegroundColor= ConsoleColor.White;
										}
										Console.WriteLine("----------------------------------------------------------");
										Console.WriteLine("");
										
										Console.Write("Ingrese la categoria a la que pertenece el alumno (ingrese solo el identificador): ");
										idCat= int.Parse(Console.ReadLine());
										
										foreach (Categoria categ in e.verDatosCategoria()) {
											
											if(idCat == categ.identificador_){
												
												if(e.existeCategoria(categ)){
													
													catego=true;
													al =false;
													Console.WriteLine("----------------------------------------------------------");
													Console.WriteLine("Alumnos inscriptos en esta categoria");
													Console.WriteLine();
													foreach (Alumno a in categ.verDatos()) {
														
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Magenta;
														a.imprimir();
														Console.WriteLine("Deporte: "+a.depor_.nombre_);
														Console.WriteLine("Categoria: "+a.cate_.tipo_);
														
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
													}
													
													Console.WriteLine("----------------------------------------------------------");
													Console.WriteLine();
													try{
														Console.Write("Dni del alumno: ");
														dni= int.Parse(Console.ReadLine());
														if (dni ==0) {
															
															throw new dniCero();
														}
														
													}
													catch(FormatException){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El formato ingresado no el correcto");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													catch(dniCero){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El dni no puede valer 0");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													foreach (Alumno alumn in categ.verDatos()) {
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
																		Console.WriteLine("La opcion es incorrecta. Ingrese nuevamente una opcion");
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
														Console.WriteLine("No existe un alumno con ese dni en esta categoria");
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
							
						case 5:
							Console.Clear();
							Console.WriteLine("Para pagar la cuota complete los datos requeridos");
							Console.WriteLine();
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine("Deportes existentes en el club");
							Console.WriteLine();
							foreach (Deporte de in club.verDatos()) {
								
								Console.ForegroundColor= ConsoleColor.Magenta;
								Console.WriteLine(de.nombre_.ToUpper()+"("+de.identificador_+") ");
								Console.ForegroundColor= ConsoleColor.White;
								
							}
							Console.WriteLine("----------------------------------------------------------");
							Console.Write("Deporte al que esta inscripto (ingrese solo el identificador): ");
							id= int.Parse(Console.ReadLine());
							foreach (Deporte e in club.verDatos()){
								
								if(id == e.identificador_){
									if(club.existe(e)){
										sigue=true;
										Console.WriteLine("");
										Console.WriteLine("----------------------------------------------------------");
										Console.WriteLine("Categorias");
										Console.WriteLine();
										foreach (Categoria c in e.verDatosCategoria()) {
											Console.ForegroundColor= ConsoleColor.DarkCyan;
											Console.WriteLine(c.tipo_.ToUpper()+"("+c.identificador_+") ");
											Console.ForegroundColor= ConsoleColor.White;
										}
										Console.WriteLine("----------------------------------------------------------");
										Console.WriteLine("");
										
										Console.Write("Ingrese la categoria a la que pertenece el alumno (ingrese solo el identificador): ");
										idCat= int.Parse(Console.ReadLine());
										
										foreach (Categoria categ in e.verDatosCategoria()) {
											
											if(idCat == categ.identificador_){
												
												if(e.existeCategoria(categ)){
													catego=true;
													al =false;
													Console.WriteLine("----------------------------------------------------------");
													Console.WriteLine("Alumnos inscriptos en esta categoria");
													Console.WriteLine();
													foreach (Alumno a in categ.verDatos()) {
														
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Magenta;
														a.imprimir();
														Console.WriteLine("Deporte: "+a.depor_.nombre_);
														Console.WriteLine("Categoria: "+a.cate_.tipo_);
														
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
													}
													
													Console.WriteLine("----------------------------------------------------------");
													Console.WriteLine();
													try{
														Console.Write("Dni del alumno: ");
														dni= int.Parse(Console.ReadLine());
														if (dni ==0) {
															throw new dniCero();
														}
														
													}
													catch(FormatException){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El formato ingresado no es correcto");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													catch(dniCero){
														Console.WriteLine();
														Console.ForegroundColor= ConsoleColor.Red;
														Console.WriteLine("Error. El dni no puede valer 0");
														Console.ForegroundColor= ConsoleColor.White;
														Console.WriteLine();
														continue;
													}
													foreach (Alumno alumn in categ.verDatos()) {
														
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
																	// alumn.mesPago_= DateTime.Parse("16/11/2023"); //para la simulacion
																	
																	
																	Console.WriteLine();
																	Console.ForegroundColor= ConsoleColor.Green;
																	Console.WriteLine("Se le ha aplicado un descuento del 30% por ser socio");
																	Console.WriteLine("Monto final pagado: "+precioFinal);
																	
																}
																if (alumn.socio_== false) {
																	
																	alumn.mesPago_= DateTime.Now;
																	//alumn.mesPago_= DateTime.Parse("16/11/2023"); //para la simulacion
																	
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
														Console.WriteLine("No existe un alumno con ese dni en la categoria que desea efectuar el pago");
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
							Console.Clear();
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
									
									foreach (Deporte de in club.verDatos()) {
										Console.WriteLine();
										Console.BackgroundColor =ConsoleColor.DarkBlue;
										Console.WriteLine(de.nombre_.ToUpper());
										Console.BackgroundColor =ConsoleColor.Black;
										foreach (Alumno a in de.verDatos()) {
											Console.ForegroundColor= ConsoleColor.Magenta;
											a.imprimir();
											Console.WriteLine();
											Console.ForegroundColor= ConsoleColor.White;
										}
									}
									
									break;
								case 2:
									Console.WriteLine("Inscriptos por deporte y categoria");
									foreach (Deporte de in club.verDatos()) {
										Console.WriteLine();
										Console.BackgroundColor =ConsoleColor.DarkBlue;
										Console.WriteLine(de.nombre_.ToUpper());
										Console.BackgroundColor =ConsoleColor.Black;
										foreach(Categoria cate in de.verDatosCategoria()){
											Console.WriteLine();
											Console.WriteLine("- "+cate.tipo_.ToUpper());
											
											foreach (Alumno a in de.verDatos()) {
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
									int cont=0;
									Console.WriteLine("Lista de inscriptos");
									foreach (Deporte de in club.verDatos()) {
										foreach (Alumno a in de.verDatos()) {
											Console.WriteLine();
											Console.ForegroundColor= ConsoleColor.Magenta;
											a.imprimir();
											cont ++;
											Console.ForegroundColor= ConsoleColor.White;
											Console.WriteLine();
										}
									}
									Console.WriteLine("----------------------------------------------------------");
									Console.WriteLine("Cantidad de inscriptos: "+cont);
									Console.WriteLine("----------------------------------------------------------");
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
							Console.Clear();
							bool noDato=true,deuda=false;
							DateTime fecha= DateTime.Parse("1/1/0001 00:00:00");
							
							Console.WriteLine("Lista de deudores");
							
							foreach (Deporte de in club.verDatos()) {
								foreach (Alumno a in de.verDatos()) {
									
									noDato=false;
									if(a.mesPago_ !=fecha){
									//DateTime fechaActual = DateTime.Now;
									DateTime fechaActual = DateTime.Parse("24/12/2023"); //para la simulacion
									
									DateTime fechaLimite= a.mesPago_.AddMonths(1);
									bool pago= (fechaActual<fechaLimite);
									
									
									if (pago == false) {
										deuda=true;
										Console.ForegroundColor= ConsoleColor.Red;
										a.imprimir();
										Console.WriteLine();
										Console.WriteLine("Ultimo mes pago: "+a.mesPago_);
										Console.WriteLine("Fecha limite: "+fechaLimite);
										Console.WriteLine();
										Console.ForegroundColor= ConsoleColor.White;
										
										
									}
									}
								}
								
							}
							
							if(noDato== false && deuda == false){
								Console.WriteLine();
								Console.ForegroundColor= ConsoleColor.Green;
								Console.WriteLine("No hay deudores");
								Console.ForegroundColor= ConsoleColor.White;
								Console.WriteLine();
							}
							if (noDato== true) {
								Console.WriteLine();
								Console.ForegroundColor= ConsoleColor.Magenta;
								Console.WriteLine("Aun no hay datos cargados");
								Console.ForegroundColor= ConsoleColor.White;
								Console.WriteLine();
							}
							
							break;
							
							
						case 8:
							bool vacio= true;
							Console.WriteLine("Listado de entrenadores");
							Console.WriteLine();
							Console.WriteLine("----------------------------------------------------------");
							foreach (Deporte de in club.verDatos()) {
								Console.BackgroundColor =ConsoleColor.DarkBlue;
								Console.WriteLine(de.nombre_.ToUpper());
								Console.BackgroundColor =ConsoleColor.Black;
								Console.WriteLine();
								foreach (Categoria c in de.verDatosCategoria()) {
									if(c.entrenad_!=null){
										vacio=false;
										
										Console.WriteLine("- "+c.tipo_.ToUpper());
										Console.WriteLine();
										Console.ForegroundColor= ConsoleColor.Magenta;
										Console.WriteLine("Datos del entrenador");
										Console.ForegroundColor= ConsoleColor.White;
										c.entrenad_.imprimir();
										Console.WriteLine();
										
									
									}
								}
							}
							Console.WriteLine("----------------------------------------------------------");
							if (vacio ==true) {
								Console.WriteLine("No hay entrenadores");
							}
							
							break;
							
							
							
							
						case 9:
							Console.Clear();
							Console.Write("Ingrese el nombre del deporte: ");
							nom= Console.ReadLine().ToUpper();
							Console.Write("Ingrese un identificador: ");
							id= int.Parse(Console.ReadLine());
							
							foreach (Deporte e in club.verDatos()) {
								
								if(id == e.identificador_){
									if(club.existe(e)){
										sigue=true;
										Console.WriteLine("");
										Console.ForegroundColor= ConsoleColor.Magenta;
										Console.WriteLine("Ya existe un deporte con ese identificador");
										Console.ForegroundColor= ConsoleColor.White;
										Console.WriteLine("");
										Console.WriteLine("Deporte: "+e.nombre_+" ("+e.identificador_+") ");
										
										Console.Write("¿Desea agregar una categoria?(S/N): ");
										con= Console.ReadLine().ToUpper();
										
										switch (con) {
												
											case "S":
												
												Console.ForegroundColor= ConsoleColor.DarkCyan;
												Console.WriteLine("");
												Console.WriteLine("Categorias");
												Console.WriteLine("Prebenjamin (5-7). ID: 57");
												Console.WriteLine("Benjamin (8-10). ID 810");
												Console.WriteLine("Alevin (11-12). ID 1112");
												Console.WriteLine("Infantil (13-14). ID 1314");
												Console.WriteLine("Cadetes (15-16). ID 1516");
												Console.WriteLine("Juvenil (17-19). ID 1719");
												Console.WriteLine("");
												Console.ForegroundColor= ConsoleColor.White;
												Console.Write("Ingrese el nombre de la categoria (solo el nombre): ");
												cat= Console.ReadLine();
												Console.Write("Ingrese el ID de la categoria: ");
												idCat= int.Parse(Console.ReadLine());
												
												foreach (Categoria categ in e.verDatosCategoria()) {
													
													if(idCat == categ.identificador_){
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
												if(catego==false ){
													
													Console.Write("Cupo: ");
													try{
														cupo= int.Parse(Console.ReadLine());
														Console.Write("Valor de la cuota: ");
														cuota= float.Parse(Console.ReadLine());
														Console.Write("Ingrese el dia de entrenamiento (00/00/0000): ");
														d= Console.ReadLine();
														Console.Write("Ingrese la hora (00:00 AM): ");
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
													
													Categoria categoria4= new Categoria(idCat,cat,cupo,cuota,diaHoraEntr4);
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
												Console.WriteLine("La opcion es incorrecta. Ingrese nuevamente una opcion");
												Console.ForegroundColor= ConsoleColor.White;
												continue;
										}
										Console.WriteLine();
										
										break;
										
										
									}
									
									
									
								}
								
							}
							
							if (sigue==false || club.verDatos()==null) {
								Deporte de = new Deporte(id,nom);
								
								club.agregarDeporte(de);
								Console.Write("¿Desea agregar una categoria?(S/N): ");
								con= Console.ReadLine().ToUpper();
								
								switch (con) {
										
									case "S":
										
										Console.ForegroundColor= ConsoleColor.DarkCyan;
										Console.WriteLine("");
										Console.WriteLine("Categorias");
										Console.WriteLine("Prebenjamin(5-7). ID: 57");
										Console.WriteLine("Benjamin(8-10). ID 810");
										Console.WriteLine("Alevin (11-12). ID 1112");
										Console.WriteLine("Infantil (13-14). ID 1314");
										Console.WriteLine("Cadetes (15-16). ID 1516");
										Console.WriteLine("Juvenil (17-19). ID 1719");
										Console.WriteLine("");
										Console.ForegroundColor= ConsoleColor.White;
										Console.Write("Ingrese el nombre de la categoria (solo el nombre): ");
										cat= Console.ReadLine();
										Console.Write("Ingrese el ID de la categoria: ");
										idCat= int.Parse(Console.ReadLine());
										
										sigue=true;
										Console.Write("Cupo: ");
										try{
											
											cupo= int.Parse(Console.ReadLine());
											Console.Write("Valor de la cuota: ");
												cuota= float.Parse(Console.ReadLine());
												Console.Write("Ingrese el dia de entrenamiento (00/00/0000): ");
												d= Console.ReadLine();
												Console.Write("Ingrese la hora (00:00 AM): ");
												h= Console.ReadLine();
												en=d+" "+h;
											}
											catch(FormatException){
												Console.WriteLine();
												Console.ForegroundColor= ConsoleColor.Red;
												Console.WriteLine("Error. El formato ingresado no es correcto");
												Console.ForegroundColor= ConsoleColor.White;
												Console.WriteLine();
												continue;
											}
											
											
											DateTime diaHoraEntr4 = DateTime.Parse(en);
											
											Categoria categoria4= new Categoria(idCat,cat,cupo,cuota,diaHoraEntr4);
											de.agregarCategoria(categoria4);
											
											Console.WriteLine();
											Console.ForegroundColor= ConsoleColor.Green;
											Console.WriteLine("El deporte y la categoria han sido añadido con exito");
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
											Console.WriteLine("La opcion es incorrecta. Ingrese nuevamente una opcion");
											Console.ForegroundColor= ConsoleColor.White;
											continue;
									}
									Console.WriteLine();
									
									break;
									
								
							}
							
							catego=false;
							sigue=false;
							break;
							
						case 10:
							Console.Clear();
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine("Deportes existentes en el club");
							Console.WriteLine();
							foreach (Deporte de in club.verDatos()) {
								
								Console.ForegroundColor= ConsoleColor.Magenta;
								Console.WriteLine(de.nombre_+"("+de.identificador_+") ");
								Console.ForegroundColor= ConsoleColor.White;
								
							}
							Console.WriteLine("----------------------------------------------------------");
							Console.WriteLine();
							Console.Write("Identificador del deporte que desea eliminar: ");
							id= int.Parse(Console.ReadLine());
							
							foreach (Deporte depo in club.verDatos()) {
								if(id == depo.identificador_){
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
							
						case 11:
							Console.Clear();
							Console.WriteLine();
							Console.ForegroundColor= ConsoleColor.Gray;
							Console.WriteLine("Esperamos verlo pronto, un saludo. Club Deportivo MALU");
							Console.WriteLine();
							Console.WriteLine("MMMMMMMMMWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMMMMMMMMMW0     KWMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMMMMMMMMWO       KMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMMMMMMMMWx       OMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMMMMMMMMMXdc   ckNMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMMMMMMMMMMWXK0KNMMMMMMMMM");
							Console.WriteLine("MMMMMMWKxdkXMWKkddxOKNMMMMMMMMMMMN0k0NMM");
							Console.WriteLine("MMMMMM0c   kNx       lKMMMMMMMWXkl   xNM");
							Console.WriteLine("MMMMMNd   c00c        xWMMMMWKdc    l0WM");
							Console.WriteLine("MMMMWk    xWNd       c0MWNKko     o0NMMM");
							Console.WriteLine("MMMMKc    xKXKOxdddxxkOxoc     cxKWMMMMM");
							Console.WriteLine("MMMWk        cloddoc        ldkXWMMMMMMM");
							Console.WriteLine("MMMMXkdolc              oxOKNMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMWNXXKOkxo        xWMMMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMWO        OWMMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMWk       lKMMMMMMMMMMMMM"); //Decorativo
							Console.WriteLine("MMMMMMMMMMMMMMMMMNd       kWMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMMMO       oNMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMMM0c      oXMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMMMO       oNMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMMNd       kWMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMWk        0MMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMMMMKc        0MMMMMMMMMMMMM");
							Console.WriteLine("MMMMMNXXKK0OOkxxl         0MMMMMMMMMMMMM");
							Console.WriteLine("MMMNklc             c     0MMMMMMMMMMMMM");
							Console.WriteLine("MMMNd      cclooddxOKd    0MMMMMMMMMMMMM");
							Console.WriteLine("MMMMNK00KKXXNWWMWKkol    cKMMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMMMMMN0ko       oONMMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMWN0xl     cldkKWMMMMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMNOdc     lxOXWWMMMMMMMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMNd     ox0NMMMMMMMMMMMMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMWKdodkKWMMMMMMMMMMMMMMMMMMMMMMMMMM");
							Console.WriteLine("MMMMMMMMMWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM");

							Console.WriteLine();
							Console.ForegroundColor= ConsoleColor.White;
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
