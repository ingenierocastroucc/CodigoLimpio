
      List<string> TaskList  = new List<string>();


            int MenuOption = 0;
            do
            {
                MenuOption = ShowMainMenu();
                if ((Menu)MenuOption == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)MenuOption == Menu.Remove)
                {
                    ShowMenuDelete();
                }
                else if ((Menu)MenuOption == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)MenuOption != Menu.Exit);
        /// <summary>
        /// Show the options for tasks, 1. Nueva tarea, 2. Remover tarea, 3. Tareas pendientes , 4. Salir 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        void ShowMenuDelete()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");

                ShowMenuTaskList();

                string line = Console.ReadLine();
                // Remove one position because the array starts in 0
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
                {
                    Console.WriteLine("El numero de tarea seleccionado no se encuentra registrado en el sistema");
                }
                else 
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un errro al eliminar la tarea");
            }
        }

        void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                if (task != "")
                {
                    TaskList.Add(task);
                    Console.WriteLine("Tarea registrada");
                }
                else 
                {
                    Console.WriteLine("La tarea no puede ser null");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ah ocurrido un error registrando la tarea");
            }
        }

        void ShowMenuTaskList()
        {
            if (TaskList?.Count <= 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                var indexTask = 1;
                TaskList.ForEach(p => Console.WriteLine($"{indexTask++} . {p}"));
                Console.WriteLine("----------------------------------------");
            }
        }

    public enum Menu
    {
        Add = 1,

        Remove = 2,

        List = 3,

        Exit = 4
    }

