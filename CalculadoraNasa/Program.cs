using System;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml.Linq;

namespace nasa
{
    class Program
    {
        static void Main(string[] args)
        {
            bool app = true;
            int action;

            //Estados
            bool login=false;
            int attemps = 0;

            Logo();
            Console.ReadKey();
            Console.Clear();

            Animacion();
            

            while (app)
            {
                //Menu

                Head();

                Console.Write("Programa de la Nasa: \n" +
                              "\t 1.Iniciar Sesion \n" +
                              "\t 2.Registrarse \n" +
                              "\t 3.Salir \n" +
                              "¿Que deseas hacer?: ");
                action = int.Parse(s: Console.ReadLine());

                switch (action)
                {
                    case 1: 
                        Console.Clear();
			            if(!login){
                        	if (attemps < 3)
                        	{
                            	login = SignIn();
                            	if (!login)
                            	{
                                	attemps++;
                                	break;
                            	}
                                login=Application();
                            	attemps=0;
                            	break;
                        	}
                        	Console.WriteLine("Se ha bloqueado tu cuenta, 3 intentos fallidos");
                            Exit();
                        	break;
			            }
			            Console.WriteLine("Ya has iniciado sesion");
                        login = Application();

                        break;
                    case 2: Console.Clear(); Console.WriteLine(SignUp()); break;
                    case 3: Exit(); break;
                    default: Console.Clear(); Console.WriteLine("Eleccion Incorrecta"); break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        static bool SignIn()
        {
            
            //Variables
            string user;
            string password;
            string path;
            string line;

            Console.Write("Ingrese su nombre de usuario: ");
            user = Console.ReadLine();
            Console.Write("Ingrese su contraseña de usuario: ");
            password = Console.ReadLine();


            path = Path.GetFullPath(@"..\..\Source\users.txt");
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line == user)
                        {
                            line = sr.ReadLine();
                            if(line == password)
                            {
                                Console.WriteLine("Se ha iniciado sesion correctamente");
                                return true;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("No se ha podido iniciar sesion");
            return false;
        }

        static bool SignUp()
        {
            string user;
            string password;
            string verifypassword;
            string path;
            string line;
            bool exist=false;

            Console.Write("Ingrese su nombre de usuario: ");
            user = Console.ReadLine();
            Console.Write("Ingrese su contraseña de usuario: ");
            password = Console.ReadLine();
            Console.Write("Ingrese su contraseña de usuario otra vez: ");
            verifypassword = Console.ReadLine();

            path = Path.GetFullPath(@"..\..\Source\users.txt");
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line == user)
                        {
                            Console.WriteLine("Este Usuario ya existe");
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            if (password == verifypassword)
                            {
                                sw.WriteLine("\n");
                                sw.WriteLine(user);
                                sw.Write(password);
                                Console.WriteLine("Se ha Registrado Correctamente");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Las contraseñas no coinciden");
                            }
                            
                        }
                    }
                }
            }
            Console.WriteLine("No se ha podido Registrar");
            return false;
        }

        static void Exit()
        {
            Console.WriteLine("Finalizando Aplicacion");
            Thread.Sleep(2000);
            Console.WriteLine("Finalizada Correctamente");
            Environment.Exit(0);
            
        }

        static void Logo()
        {
            Console.WriteLine(" ");
            Console.WriteLine("                                          ...'''''...                         .'''''',,,,...                         ..........                                                                                                     ..',;;::::;,'..                                                         ");
            Console.WriteLine("                                      ..;codxxkxxxdol:;'.......              .lxdddddddxo:,.                     ..;cloddxxddolc:'.....                          ..',,;;;;;;::::::::::::::::::::::::::::::'                      .':loddddddddddooc:,....                                                   ");
            Console.WriteLine("                                    .;ldxkkkkkkkkkkkxddoc;..........         .lkxxdddddxd;'.                   .;lddddxxxxxxxxdddoc;........                  .,:lodddddddddddddddddddddddddddddddddoooodo,                    .;ldddddddxxxxxddddoolc;.....                                                ");
            Console.WriteLine("                                  .:dkkkkkkkkkkkkkkkkxxxdoc,..........       .lkxxxddddxd:'.                 .;oxxxxxxxxxxxxxxxxxxdlc;........             .':oddddddddddddddddddddddddddddddddddddddddddo,                  .;odxxxddddddxxxxxxxxxxdol:'.                                                  ");
            Console.WriteLine("                                 'okkkkkkkxxxxxxxxxxxxxxxdlc,..........       ckxxxxxxxxd:'.                .ldxxxxxxxxxxxxxxxxxdxxdoc;........           'codddddddddddddddddddddddddddddddddddddoooooooo,                 .cddxxxxddddddddddxxxxxxxdoc;.                                                  ");
            Console.WriteLine("                                'dOOkkkkkkkkxxkkkkkkkkkkkkxlc,..........      ckxxxxxxxxx:'.               'oxxxxxxddxxxxxxxxxxxxxxxxo:,.      .        .:oddddddddddddddddddddddddddddddddddddddddddooooo,                .cdxxddxxddddddxxddxxxxddddddc'.                                                 ");
            Console.WriteLine("                               .lOOkkkkkkkkkkxxdxkkkkkkkkkkxc,.....  ...      :kkkkxkkkkxc'.              .lxxxxxxxxxxxxxxxxxxxxxxxxxxl,.              .ldxxxxxxxddddddddddddddddddddddddddddddddddddddodo,               .cxdxddxxxxddddddxxxxdxxxxxdddd:.                                                 ");
            Console.WriteLine("                               'kOkOOkkkkkkdc:;;:cdkkkkkkkkko,......          ;kkkkkkkkkkc'.             .:xkkkkkkkxxkkkxxkkxxxxxxkkxxx:..           .:oxxxxxxxxdddxddooooooooooooooooooooooooooooooooolol'               ;dxxxxxxxxxxxxdxdxxxxxxxxxxxxxxo,.                                                ");
            Console.WriteLine("                               .x0OOkkkkkkd:',;;;;:dOOOOOOkkkc..........      ,xkkkkkkkkkl,.             'dkkkkkkkkkkxolccldxkkxxkxxkkkd,..         .cxxxxxxxxxddddl:;;::cccc:,...................................       .oxxxxxxxxxxxdolccclodxxxxxxxxxxxc..                                               ");
            Console.WriteLine("                               .dOOkkkkkkkl'.......ckOOkOkkkOd,..........     ,xkkkkkkkkkl,.            .lkkkkkkkkkkdc;:ccc:lxkxkxxkkkkkc...        ,dkxxxxxxxxddo:,,:loodddc..                                         .:xxxxxxxxxxxdc,;:cc::cdxxxxxxxxdxd;.                                               ");
            Console.WriteLine("                               .oOkkkkkkkkl'.......'oOkkkkOOOkc...........    'xkkkkkkkkOl,.            ;xkkkkkkkkkxl,,::::::lkkkxkkxxkkd;..       .lkxxxxxxxxxxo;';::::ccc,                                            ,dxxxxxxxxxxxc,,;;;::;;lxxxxxxxdxxxl'.                                              ");
            Console.WriteLine("                               .lkkkkkkkkkl,........:xkkkkOOkkd;...........   .dkkkkkkkkkl,.           .okkkkkkkkkkd;,;::::c::dkkkkxxxkkkl'..      .okxxxxxxxxxxc'.........                                            .lxxxxxxxxxxxo;';::::::;:dxxxxddddxxd:..                                             ");
            Console.WriteLine("                               .ckkkkkkkkkl,.........okkkkkkkkkl...........   .okkkkkkkkko,.          .:xkxkxkkkkkxc,;::ccccc:cxkxxxxxxkkx:..      .cxxxxxxxxxxxc'.                                                    ;xxxxxxxkxxxd:';:::::::,.cxxxxdxdddddo,.                                             ");
            Console.WriteLine("                                :xkkxxxxxkl,.........;xkkxkkkkkd;...........  .lkxkkkkkxko,.         .,dxxxxxxxxxxl,,:ccccccc:;lxxxxxxxxxxo'..      ;dkxxxxxxxxxdc,.                                                  .oxxxxxxxxxxxl,,:cccccc;. 'oddddddddddo:..                                            ");
            Console.WriteLine("                                ;xxxxxxxxxl,..........cxxxxxxxxxl............ .lxxxxxxxxxl,.         .cxxxxxxxxxxo:,:cccccccc,.,dxxxxxxxxxx:..      .lxxdxxxddddddoc;'......................                         .:dddddddddddo;':cccccc:'  .;oddddooooool,..                                           ");
            Console.WriteLine("                                ,dxddddddxl,..........,oxxxxxxxxd;.. ........ .cxddddddddl,.        .;dddddddddddc,;cccccccc:. .cddddddddddo,..      ':lddddddddodddoollllllllllllllllllllllcc:;'..                  'oddddddddddoc,;ccccccc;.   .coooooooooooc'.                                           ");
            Console.WriteLine("                                ,oddddddddl,...........cdddddddddc.. ..........cdddddddddl,..       .ldoodddddddl;,:cccccccc'   'lddddddddddc..      ..'loooooooooooooooooooooooooooooooooooooooolc;,..             .cdooooooooool,,:lllccc:.     ,looollllllll;..                                          ");
            Console.WriteLine("                                'oooddooodl,...........'lddddooddo;.. .........:dooooooool,.       .:doooooooodo:,;cccccccc;.   .;ooooooooooo;....      .:oooooooooooooooooooooooooooooooollllllloollc:'.           ;oloooooooool;';clllllc,      .:ollllllllllc'.                                          ");
            Console.WriteLine("                                'looooooooc,............;oooooooooc..  ........:oooooooool,..      'looooooooooc,,cccccccc:.     .cooooooolooc.....      .,clolllllllooolooooooooooollllllllllllllllllcc;.         .llllllllloolc,,cllllcl:.       'cllllccccccc;..                                         ");
            Console.WriteLine("                                .lolooooooc,............'cooooooooo;.. ........;oooooooool,..     .collollooool;,:cccccccc,.      ,lollllollll;....        .':clllllllllllllllllllllllllllllllllcllllllc:,.       .:lllllllllllc;,:llllllc'        .;llcccccccccc'..                                        ");
            Console.WriteLine("                                .cllllllllc,.............;oooooooooc'. ........;oooloollll,.      ,oolllllooloc,;cccccccc:.       .:olllllllllc'...           .';:cllllllllllllllllllllllllllllclllllclll:..      ,llllllllllll:,;lllllll;          .:ccccccccccc:..                                        ");
            Console.WriteLine("                                .cllllllllc,..............cooooooool;..........;ooolllllll,.     .lolllllllool;,:cccccccc'         'lllllllllll:...              ....'',,,,,,,,,,,,,,,,,,,,;:cccccllcccclc;..    .clllllllllllc,,cllllll:.           ,cccccccccccc,..                                       ");
            Console.WriteLine("                                .clllllllll,............ .,looooooooc'.........,loooooolol,.    .;oolllloolol:,;cccccccc;.         .;lllllllllll,..                                         ..;clcccllccccc,..  .;lllllllllllc;,:lllllll'            .:ccccccccccc:'..                                      ");
            Console.WriteLine("                                .clllllllll,............. .:olooooooo;.........,looooooool;.    'lolooooooolc,,:cccccccc.           .colllllllllc..                                           .,cllllccllcl;'.  'lollllllllll:,;cllllll;.             'clcccccccccc;..                                      ");
            Console.WriteLine("                                .collllllll;.............  ,looooooool'.....  .'looooooooo;..  .cdoooooooool;,;cccccccc,.            ,lollollllll;.                                            .:lllllcclcl:'. .:ollllllllllc;,:llllllc.              .;llcccccccccc,..                                     ");
            Console.WriteLine(";;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,;looolooool;..............',cooooooooo:.....  .,oooooooooo;.   ,oooooooooooc,;:ccccccc:'..............coooollllllc'.                                           .:olllllllllc,. ,loooolloolll:';lllllll,                .:llccccccccl:..                                     ");
            Console.WriteLine("oooooooooooooooooooooooollllllllloooooooooo;.............,llclooooooool;'......cdooooooooo:.. .ldoooooooool;,;::ccccccccc:c::::::::::::looollllllo:.           .,;;;;;;;;;;;;,,,,,,,,,,,,,,,,'',lolllllllllc,..coloooooooooc,,clllllll,.................;clcllllcclll;..                                    ");
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxdoooooooooo:.............:dxolooooooooolllc:;:looooooooooo:.  :doooooooooo:,,::::::ccldxdddddddddddddxoclolllllolol;''''.........'''''''''''''''''''',,,,,',;::lollllllllll:'.;oooooooooool;,:lllllllllccccccccccccccccc::lllllllllllc'..       .;;;;;;;;;;;;;;;,,,,,,,,,,,,");
            Console.WriteLine("kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkdooooooooo:.............ckOkdlooooooooooooooooooooooooool;. 'odoooooooooc,,;:::::::cdkkkkkkkkkkkkkkkOkolollolloooolllllllllccc:::;;;;;;;;;;;;;;,,,,,,,,,,,;:cllllllllllllc,.,looooooooool:,;cllllllodxxddddddddddddddxxdcclllllllllll:...      .ldoododdooooooooooooooooooo");
            Console.WriteLine("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO0Odooooooooo:'............cO00Odloooodoooooooooooooooooool:. .ldoooooooool;',;;;:::::oO000000000000000O0kllolllllloooooolllllllllllllllllllllllllllllllllollllllllllllllllc;.'coooooooooool;,:cccllloxOkkkkkkkkkkkkkkkkkkkdcclllllllllll;..       ;xkkkkxkxxxxxxxxxxxxxxxxxxx");
            Console.WriteLine("000000000000000000000000000000000xooooooooo:'............c0K0K0kolodddoooooooooooooooool;...;dooooooooooc,',,,;;;;:lkK000000000000000000xlloolloloolloooloolloolloolllooolllllllllllllllllllllllllllllllc;'':oooooooooool:,;:cccllldO0000000OOOOOOOOOOOOOOoclllllllllllc'..      .oOOOOOOOOOOOOOOOOOOOkkkkkk");
            Console.WriteLine("00000000000KKKKKKKKK00000000000K0xoooooooooc'............c0KKKKK0xlloooooooooooooooool:,...'odoooooooool;''',,,,;;:dKKKKKKKKKKKKKKKKKKKK0dlooooooooooooooolllllloooooooooooollllllllllllllllllllllllllc:'',:loooooooooooc,,;:::cccoO0000000000000000000000klclllllllllll;...      ;k0OO00000OOOOOOOOOOOOOOOO");
            Console.WriteLine("KKKKKKKKKKKKKKKKKKKKKKKKKK0000000xoooooooooc'...........'ck0OO0000kdlccllooooooolllc;'..  .cdoooooooool:'....''',;lOKKKKKKKKKKKKKKKKKKK0Kkllooooooooolllllllllllllllloooooolllllllllllllllllllllllllc:,..,:cooollolloool;',;;;::ccxKK0000000000000000000000xcclllllllllll,..      .l00000000000000000OOOO000");
            Console.WriteLine("KKKKKKKKKKKKKKKKKKKK0000000000000kdddooooolc:;;;;;:::cclloddddddddoooc:;:::::::;;,...     ,ollllllllll:,.......'';oxxxkkkkkkkkkkkkkkkkkkkkoclllllllllllllllllllllllllllllllllllllllllllllllllllllc:,....:lclollllllllol:'..'',;;:oO000000000000000000000000Ooclllllllllll:...      'x00000000000000000000000");
            Console.WriteLine("KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKXXXKKKKKKK000000K000000000000000O0OOOOOkkkkkkxxxddddddddkkxkxxxxxxxxdoooooodddxxxxxxxxkkxxxxxxxxxxxxxxxxdlcccccccccc::::::::::::::::::::::::::::::::::::::;;,'...  .';cclollllllllllc,......'':dkkkkkkkkkkOOOOOOOOOOOOOOOOxcclllllllllll,...     .:O0000000000000000000000");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXNXXNNNNXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXNNXXXXXXXXXXXXXKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK0000000000OOOOOOOOkkkkkkkkkxxxxxxxxxddddddddoooolllccccllllodxdddddddddoocc:cccccllooodddddddddddddxxxdddddddddc:ccccccccccc:'......',ck0000000000000000000000");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXNNNNNNNNNXXXXXXXXXXXXXXXXXXXXXXXXNNNNNNNNNNNNNNNNNXXXXXXXXXNNNNNNNNNXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXKKXXXXXXXXXXKKKKKKKKKKKKK000000000000000OOOOOOOOOOOOOkkkxxxxxxxxxxxdooodxkO0000000000000000000000000");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXNNNNNNNNNNXXXXXXXXXXXXXXXXXXXXXXNNNNNNNNNNNNNNNNNNNNNNNXXXXNNNNNNNNNNXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXNNNNNNNNNNNNNNXXNNNNNNNNNNNNNNNNNNNXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXKKXKKKKKKKKKKKKKKKKKKKKKKKKKKXXXXXXXXXXXXXXKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
        }

        static void Animacion()
        {
            string path = Path.GetFullPath(@"..\..\Source\animacion.txt");
            
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (line == "break")
                            {
                                Thread.Sleep(25);
                                Console.Clear();
                                continue;
                            }
                            Console.WriteLine(line);
                        }
                    }
                }
        }

        static void Head()
        {
            Console.WriteLine("");
            Console.WriteLine("MNOl;,,,:dKWMMMMMW0occlkNMMMMWXxc;,,;lkXWMMMMMMWNKxolcccccccccccdXMMMMMWXxc;,,;ckXWMMMMMMM");
            Console.WriteLine("Xx:,,,,,,;cONMMMMWO:,,,dNMMMW0l;,,,,',;dKWMMMMW0d:;,,,,',,,,,,,,c0WMMMW0o;,',,,,;oKWMMMMMM");
            Console.WriteLine("d;,,,:c;,,,:OWMMMWO:,,,oNMMW0c,,';cc,,,,oKWMNXk:,,,,;:::::::::::oKWMMW0l,,,;cc;,,,lKWMMMMM");
            Console.WriteLine("c,,,:OXk;,,,oXWMMWO:,,,oXMMXo,,,;dXKo,,,;xNW0xc,,,:x0KXXXXXXKKKXXWMMMXd,,,;dKKo,,,;dNMMMMM");
            Console.WriteLine("c,,,c0WXo,,,;kWMMWO:,,,oXWWk;,,,lKWW0c,,,c0W0dc,,,cONWWWWWWWWMMMMMMMWk:,,,lKWW0c,,,:OWMMMM");
            Console.WriteLine("c,,,c0WWO:,,,lKWMWO:,,,oXW0c,,,:OWMMNx;',,oXXKd;'',:llllolloodOXWMMWKl,,,:OWMMNk;,,,oXWMMM");
            Console.WriteLine("c,,,c0WMNd,,,;xNMWO:,,,oXXd,,,;dNMMMWKo,,,;kNWXxc,,,,,,,,,',,',cxXWNd,,,,dXMMMWXo,,,;xNMMM");
            Console.WriteLine("c,,,c0WMW0c,,,c0WWO:,,,oXk:,,,lKWMMMMWO:,,,c0WWWXOxoolllllll:,,,,oKk:,,,lKWMMMMW0c,,,c0WMM");
            Console.WriteLine("c,,,c0WMMNd;,,,dNWO:,,,oOl,,,:kWMMMMMMNx;,,,o0XMMMWWWWWWWWWN0c,,':dl,,,:kWMMMMMMNx;,,,oXWM");
            Console.WriteLine("c,,,c0MMMWKl,,,:OXx;,,,ll;',,dNMMMMMMMWKl,,,:cxKKKKKKKKKKKK0x:,,,;:;,,,oXMMMMMMMMXo,,,;xNM");
            Console.WriteLine("c,,,c0MMMMWk;,,,:c:,,,;:;,,,cKWMMMMMMMMWO:,,,,;;:::::::::::;,,,,;:;,,,c0WMMMMMMMMWO:,,,c0W");
            Console.WriteLine("c,,,c0WMMMMNkc,,,,,,,co:,,,:kNMMMMMMMMMMNd;,,,,,,,,,,,,,,,,,,,:odc,,,;kWMMMMMMMMMMNx;,,,dX");
            Console.WriteLine("xllldKMMMMMMN0o:,,,:o0OolllxXWMMMMMMMMMMMKolllllllllllllllllox0X0dllldXMMMMMMMMMMMWKdllldK");
            Console.WriteLine("");
        }

        static bool Application()
        {
            int action;
            bool app=true;

            while (app)
            {
                Head();

                Console.Write("Programa de la Nasa: \n" +
                              "\t 1.Calcular Energia Potencial \n" +
                              "\t 2.Cerrar Sesion \n" +
                              "\t 3.Voler al Menu Principal \n" +
                              "¿Que deseas hacer?: ");
                action = int.Parse(s: Console.ReadLine());

                switch (action)
                {
                    case 1: Console.Clear(); EnergiaPotencial(); break;
                    case 2: Console.Clear(); Console.WriteLine("Cerrando Sesion"); return false; break;
                    case 3: Console.Clear(); Console.WriteLine("Volviendo al Menu Principal"); app = false; break;
                    default: Console.Clear();  Console.WriteLine("Eleccion Incorrecta"); break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
            return true;
        }

        static void EnergiaPotencial()
        {
            string name, animal, address, planet;
            int age, SLplanet, SLanimal;
            double mass, EP, height, gravity;

            Console.WriteLine("Ingrese su nombre: ");
            name = Console.ReadLine();

            Console.WriteLine("Ingrese su edad: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Animales: \n" +
                              "\t 1.Can \n" +
                              "\t 2.Felino \n" +
                              "\t 3.Hominido \n" +
                              "\t 4.Vulpino \n" +
                              "\t 5.Ofidios \n" +
                              "\t 6.Quiroptero \n" +
                              "\t 7.Ornitorrinco \n" +
                              "\t 8.Humano \n" +
                          "Ingrese el numero del animal que desee: ");
            SLanimal = int.Parse(Console.ReadLine());

            /*
            string[] animals = { "Can", "Felino", "Hominido", "Vulpino", "Ofidios", "Quiroptero", "Ornitorrinco", "Humano" };
            if (SLanimal <= animals.Length) {
                animal = animals[SLanimal];
            }else{
                animal = animals[6];
            }
            */

            switch (SLanimal)
            {
                case 1: animal = "Can"; break;
                case 2: animal = "Felino"; break;
                case 3: animal = "Hominido"; break;
                case 4: animal = "Vulpino"; break;
                case 5: animal = "Ofidios"; break;
                case 6: animal = "Quiroptero"; break;
                case 7: animal = "Ornitorrinco"; break;
                case 8: animal = "Humano"; break;
                default:
                    animal = "Humano";
                    Console.WriteLine("Eres un Humano");
                    break;
            }

            Console.Write("Ingrese su direccion: ");
            address = Console.ReadLine();

            Console.Write("Planetas: \n" +
                              "\t 1.Mercurio \n" +
                              "\t 2.Venus \n" +
                              "\t 3.Marte \n" +
                              "\t 4.Jupiter \n" +
                              "\t 5.Saturno \n" +
                              "\t 6.Urano \n" +
                              "\t 7.Neptuno \n" +
                              "\t 8.Tierra \n" +
                          "Ingrese el numero del planeta de residencia: ");
            SLplanet = int.Parse(Console.ReadLine());

            switch (SLplanet)
            {
                case 1: gravity = 3.7; planet = "Mercurio"; break;
                case 2: gravity = 8.87; planet = "Venus"; break;
                case 3: gravity = 3.71; planet = "Marte"; break;
                case 4: gravity = 24.79; planet = "Jupiter"; break;
                case 5: gravity = 10.44; planet = "Saturno"; break;
                case 6: gravity = 8.87; planet = "Urano"; break;
                case 7: gravity = 11.15; planet = "Neptuno"; break;
                case 8: gravity = 9.8; planet = "Tierra"; break;
                default:
                    gravity = 9.8;
                    planet = "Tierra";
                    Console.WriteLine("Estas en la tierra");
                    break;
            }

            Console.WriteLine("Ingrese la Altura en Metros: ");
            height = Double.Parse(Console.ReadLine());

            if(SLplanet==6 || SLplanet==7 || SLplanet==1)
            {
                if(SLplanet==6 && height < 25) { 
                    Console.WriteLine("Ingrese su masa en Kg : ");
                    mass = double.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Ingrese un masa mayor a 40 Kg : ");
                    mass = double.Parse(Console.ReadLine());
                    if (mass < 40)
                    {
                        Console.WriteLine("Su masa es de 40 Kg");
                        mass = 40;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ingrese su masa en Kg : ");
                mass = double.Parse(Console.ReadLine());
            }

            if (mass > 100 && height < 10)
            {
                Console.WriteLine("Alerta: Nivel de Peso Excesivo");
            }

            EP = mass * height * gravity;
            if(EP > 1000 && planet=="Tierra") 
            {
                Console.WriteLine("Tienes mucha energia potencial,se está afectando el medio ambiente ");
            }

            Console.Write("Hola "+name+
                          " tienes "+age+
                          " años, eres un "+animal+
                          " vives en "+address+
                          " ubicado en el planeta "+planet+
                          " obteninedo una energia potencial de "+EP);
            Console.ReadKey();
        }
    }
}