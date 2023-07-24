using System.Text;

Console.WriteLine("Ввести новые данные - введите \"1\"");
Console.WriteLine("Вывести список сотрудников - введите \"2\"");

string staff_operation_selection = $"{Console.ReadLine()}";

string staff_data_string = string.Empty;
string[] staff_data_array = new string[staff_data_string.Length];

switch (staff_operation_selection)
{
    case "1":
        Console.WriteLine();        

        using (StreamWriter staff_stream_writer = new StreamWriter("staffFile.txt", true, Encoding.Unicode))
        {
            int staff_question_continuation;
            string staff_recording_date = string.Empty;            
            
            do
            {
                Console.WriteLine("Введите данные сотрудника");
                Console.WriteLine();                

                Console.WriteLine("Введите ID");
                staff_data_string += $"{Console.ReadLine()}#";

                staff_recording_date = DateTime.Now.ToString();
                staff_data_string += $"{staff_recording_date}#";

                Console.WriteLine("Ф.И.О. в формате \"Иванов Иван Иванович\"");
                staff_data_string += $"{Console.ReadLine()}#";

                Console.WriteLine("Возраст (в годах)");
                staff_data_string += $"{Console.ReadLine()}#";

                Console.WriteLine("Рост (в сантиметрах)");
                staff_data_string += $"{Console.ReadLine()}#";

                Console.WriteLine("Дата рождения в формате дд.мм.гггг");
                staff_data_string += $"{Console.ReadLine()}#";

                Console.WriteLine("Место рождения в формате \"город Москва\"");
                staff_data_string += $"{Console.ReadLine()}";

                staff_stream_writer.WriteLine(staff_data_string);

                staff_data_string = string.Empty;

                Console.WriteLine();
                Console.WriteLine("Введите \"1\" если хотите начать ввод данных нового сотрудника");
                Console.WriteLine("Введите любую цифру если хотите закончить ввод данных");
                staff_question_continuation = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            while (staff_question_continuation == 1);            
        }
        break;    
       
    case "2":
        Console.WriteLine();

        using (StreamReader staff_stream_reader = new StreamReader("staffFile.txt", Encoding.Unicode))
        {
            Console.WriteLine("Текущая информация о сотрудниках");
            Console.WriteLine();

            string staff_read_line = string.Empty;

            while ((staff_read_line = staff_stream_reader.ReadLine()) != null)
            {
                staff_data_array = staff_read_line.Split("#");                
                Console.WriteLine($"ID: {staff_data_array[0]}\n" +
                    $"Запись добавлена: {staff_data_array[1]}\n" +
                    $"Ф.И.О: {staff_data_array[2]}\n" +
                    $"Возраст, лет: {staff_data_array[3]}\n" +
                    $"Рост, см: {staff_data_array[4]}\n" +
                    $"Дата рождения: {staff_data_array[5]}\n" +
                    $"Место рождения: {staff_data_array[6]}");
                Console.WriteLine();
            }            
        }
        break;
    default:
        Console.WriteLine();
        Console.WriteLine("Введите 1 или 2");
        break;
}