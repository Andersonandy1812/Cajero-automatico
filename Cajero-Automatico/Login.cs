

using System;
namespace CajeroAutomatico
{
    public class Login
    {
        Seccion_Administrador seccion_Administrador = new Seccion_Administrador();
        Administrar_Usuario Administrar_Usuario = new Administrar_Usuario();
        public Login()
        {
           

        }

        public static void _Login()
        {
            int MaxAttempts = 3;

                Console.Clear();
                Console.WriteLine("\t\t Bienvenido al Cajero Automático");

                Console.Write("\t Numero de tarjeta: ");
                string User = Console.ReadLine();

                Console.Write("\t Contraseña: ");
            string pass = "";
                ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    if (info.Key != ConsoleKey.RightArrow)
                    {
                        if (info.Key != ConsoleKey.LeftArrow)
                        {
                            if (info.Key != ConsoleKey.UpArrow)
                            {
                                if (info.Key != ConsoleKey.DownArrow)
                                {
                                    Console.Write("#");
                                    pass += info.KeyChar;
                                }
                            }
                        }
                    }
                } 
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(pass))
                    {
                        //remove one character from the list of pass characters
                        pass = pass.Substring(0, pass.Length - 1);
                        // get the location of the cursor
                        int position = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(position - 1, Console.CursorTop);
                        //remplace it with space
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(position - 1, Console.CursorTop);


                    }
                }
                info = Console.ReadKey(true);
            }



                string UserAdmin = "1234-1234-1234-1234";
                string PassCorrect = "Admin123";


            if (User != UserAdmin || Pass != PassCorrect)
            {

                Console.WriteLine("\tMENSAJE DE PUREBA!!-USUARIO NO ADMIN");

            }



            else
            {

                Seccion_Administrador.Menu_Admin();
            }
            if (User == UserAdmin || Pass != PassCorrect)
            {
                Console.WriteLine("\t\t#########################################################");
                Console.WriteLine("\t\t#La contraseña no es correcta, intentelo una nueva vez###\n\t\t#OJO Tiene 3 intentos antes de que se active el bloqueo##");
                Console.WriteLine("\t\t#########################################################");
            }
            if (i == MaxAttempts)
            {
                Console.WriteLine("Se activo el bloqueo a su cuenta");
            }

            Console.ReadKey();

    }
    }
}
