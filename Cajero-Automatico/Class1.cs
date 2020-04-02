using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
   public class Administrar_Usuario
   {
        Seccion_Administrador seccion_Administrador = new Seccion_Administrador();

        public static List<UsersA> _UsersAdmin = new List<UsersA>();

        public struct UsersA
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string TargetNumber { get; set; }
            public string Password { get; set; }
            public double Balance { get; set; }
        }
       
        public static void Add<T>(List<T> _List, T Element)
        {
            _List.Add(Element);
        }
        public static void Edit<T>(List<T> _List, int index, T Element)
        {
            _List[index] = Element;
        }
        public static void Delete<T>(List<T> _List, int index)
        {
            _List.RemoveAt(index);
        }
        public Administrar_Usuario()
        {

        }
        private enum menuadmin1
        {
            Crear_admin = 1,
            edit_admin,
            list_admin,
            delete_admin
        }
        public static void Menuadmin()
        {
            Console.Clear();
            Console.WriteLine("\t 1. Agregar Usuario.");
            Console.WriteLine("\t 2. Editar Usuario. ");
            Console.WriteLine("\t 3. Listar Usuarios. ");
            Console.WriteLine("\t 4. eliminar Usuario.");
            Console.WriteLine("\t 5.Reiniciar contraseña de cliente");
            Console.WriteLine("\t 6. Agregar saldo a cliente");
            Console.WriteLine("\t 7. Salir");

            int respuesta = Convert.ToInt32(Console.ReadLine());
            switch (respuesta)
            {
                case 1:
                    {
                        Add_UserAdmin();
                        break;
                    }
                case 2:
                    {
                        Edit_UserAdmin();
                        break;
                    }
                case 3:
                    {
                        List_UserAdmin();
                        break;
                    }
                case 4:
                    {
                        Delete_UserAdmin();
                        break;
                    }
                case 5:
                    {
                        Editpass_admin();
                        break;
                    }
                case 6:
                    {
                        break;
                    }
                case 7:
                    {
                        Exit();
                        break;
                    }

            }
        }
        private static void Add_UserAdmin()
        {
            Console.Write("\t Nombre: ");
            string nameUserAdmin = Console.ReadLine();
            Console.Write("\t Apellido: ");
            string lastnameUserAdmin = Console.ReadLine();
            Console.Write("\t Número de tarjeta: ");
            string targetNumberUserAdmin = Console.ReadLine();
            Console.Write("\t Contraseña: ");
            string PasswordUserAdmin = Console.ReadLine();
            Console.Write("\t Saldo: ");
            double BalanceUserAdmin = Convert.ToInt32(Console.ReadLine());
            UsersA UsersA = new UsersA();

            UsersA.Name = nameUserAdmin;
            UsersA.LastName = lastnameUserAdmin;
            UsersA.TargetNumber = targetNumberUserAdmin;
            UsersA.Password = PasswordUserAdmin;
            UsersA.Balance = BalanceUserAdmin;
            Add(_UsersAdmin, UsersA);
            if (_UsersAdmin.Count != 0)
            {
                Console.WriteLine("\tusuario Guardado Con Exito!!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\t :( usuario no guardado, verifique e intente nuevamente.");
                Console.ReadKey();
            }
        }
        public static void Edit_UserAdmin()
        {

            if (_UsersAdmin.Count == 0)
            {
                Console.WriteLine("\t Lista de Usuarios vacia ");
            }
            else
            {
                Console.Write("\t Introduzca el numero de la Tarjeta segun el usuario que desee editar: ");
                string targetUser = Console.ReadLine();
                var User = _UsersAdmin.Find(x => x.Name == targetUser);

                if (_UsersAdmin.Contains(User))
                {

                    Console.Clear();
                    Console.WriteLine("\t\t Introduzca los nuevos valores \n ");
                    Console.Write("\t Nombre: ");
                    string nameUser = Console.ReadLine();
                    Console.Write("\t Apellido: ");
                    string lastnameUser = Console.ReadLine();
                    UsersA UsersA = new UsersA();

                    UsersA.Name = nameUser;
                    UsersA.LastName = lastnameUser;


                    //Edit(_Users, (index - 1), Users);
                    Console.WriteLine("\t Usuario Editado Con Exito!!");
                    Console.ReadKey();

                }
            }
        }
        public static void List_UserAdmin()
        {
            if (_UsersAdmin.Count == 0)
            {
                Console.WriteLine("\t Listado de usuarios vacia");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("\t\t Listado de usuarios: ");
                int count = 1;
                foreach (UsersA Element in _UsersAdmin)
                {
                    Console.WriteLine(count + " - " + Element.Name + " " + Element.LastName);
                    count++;
                }
            }
        }
        public static void Delete_UserAdmin()
        {
            if (_UsersAdmin.Count == 0)
            {
                Console.WriteLine("\t\t Lista de usuarios vacia");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.Write("\t Introduzca el numero de la Tarjeta segun el usuario que desee editar: ");
                List_UserAdmin();
                string targetUser = Console.ReadLine();

                var User = _UsersAdmin.Find(x => x.TargetNumber == targetUser);
                if (targetNumber <= 1)
                {
                    Console.WriteLine("No se puede eliminar usuario ya que no hay mas usuarios administradores");
                }
                else
                {
                    Delete(_UsersAdmin, (UsersA.TargetNumber - 1));
                    Console.WriteLine("\t usuario eliminado! \n");
                    List_UserAdmin();
                    Console.ReadKey();
                }
            }
        }
        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("¿Esta seguro que desea salir?\n1-Si\n2-No");
            int resp = Convert.ToInt32(Console.ReadLine());
            switch (resp)
            {
                case 1:
                    {
                        Login._Login();
                        break;
                    }
                case 2:
                    {
                        Seccion_Administrador.Menu_Admin();
                        break;
                    }
            }
        }

        public static void Editpass_admin()
        {
            if (_UsersAdmin.Count == 0)
            {
                Console.WriteLine("\t Lista de Usuarios vacia ");
            }

            else
            {
                Console.Write("\t Introduzca el numero de la Tarjeta segun el usuario que desee editar: ");
                string targetUser = Console.ReadLine();
                var User = _UsersAdmin.Find(x => x.Name == targetUser);

                if (_UsersAdmin.Contains(User))
                {

                    Console.Clear();
                    Console.WriteLine("\tIntroduzca la nueva contraseña: ");
                    string newpassword = Console.ReadLine();
                    Console.Write("\t Introduzca la nueva contraseña de nuevo");
                    string newpassagain = Console.ReadLine();
                    if (newpassword == newpassagain)
                    {
                        Console.WriteLine("\t Escriba la antigua contraseña para validar que sea usted:");
                        string oldpass = Console.ReadLine();
                        if (oldpass == Password)
                        {
                            Console.WriteLine("\t Usuario Editado Con Exito!!");
                        }
                        else
                        {
                            Console.WriteLine("\t\tContraseña incorrecta intente de nuevo");
                            Editpass_admin();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Las contraseñas no coinciden, intentelo de nuevo");
                        Editpass_admin();
                    }
                    User.Password = newpassword;
                    Console.ReadKey();

                }

            }



        }

    }
}
