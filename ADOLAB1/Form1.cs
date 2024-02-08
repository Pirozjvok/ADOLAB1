using System.Data.SqlClient;
using System.Data;

namespace ADOLAB1
{
    public partial class Form1 : Form
    {
        public string _connectionString;

        public Form1()
        {
            InitializeComponent();
            _connectionString = "Server=localhost;Database=ADOLAB;Trusted_Connection=True;";
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);

        private void button2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Tag)
            {
                case "A":
                    Add();
                    break;
                case "B":
                    IntDialog intDialog = new IntDialog("Введите зарплату");
                    if (DialogResult.OK == intDialog.ShowDialog())
                    {
                        CheckZaplata(intDialog.Result);
                    }
                    break;
                case "C":
                    IntDialog intDialog2 = new IntDialog("Введите кол-во посещений.");
                    if (DialogResult.OK == intDialog2.ShowDialog())
                    {
                        CheckAttend(intDialog2.Result);
                    }
                    break;
                case "D":
                    IntDialog intDialog3 = new IntDialog("Введите k");
                    if (DialogResult.OK == intDialog3.ShowDialog())
                    {
                        IntDialog intDialog4 = new IntDialog("Введите r");
                        if (DialogResult.OK == intDialog4.ShowDialog())
                        {
                           CheckEmployee(intDialog3.Result, intDialog4.Result);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            using SqlConnection connection = CreateConnection();
            connection.Open(); // синхронное подключение, требуется закрытие в конце блока
            SqlCommand command = new() // создаём команду
            {
                CommandText = "create table Employee(Num int NOT NULL,Name varchar(50),Sex varchar(50),Age int,Department varchar(50)) ",
                Connection = connection // определяем используемое подключение
            };
            command.CommandText += "create table Wage(No int NOT NULL,Amount money) ";
            command.CommandText += "create table Attend(Num int NOT NULL,No int,Attendance int) ";
            // --- Добавить первичный ключ ----
            command.CommandText += "alter table Employee add constraint PK_Num primary key(Num) ";
            command.CommandText += "alter table Wage add constraint PK_No primary key(No) ";
            command.CommandText += "alter table Attend add constraint PK_NumAttend primary key(Num) ";
            // --- Добавить внешний ключ ----
            command.CommandText += "alter table Attend add constraint FK_Num foreign key(Num) references Employee(Num) ";
            command.CommandText += "alter table Attend add constraint FK_No foreign key(No) references Wage(No) ";
            command.ExecuteNonQuery(); // выполнение команды
            connection.Close(); // закрытие синхронного подключения
        }

        public void Add()
        {
            using SqlConnection connection = CreateConnection();
            connection.Open(); // синхронное подключение, требуется закрытие в конце блока
            SqlCommand command = new() { Connection = connection };
            string employeeReadPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\employees.txt";
            List<string> txt = File.ReadLines(@employeeReadPath).ToList();
            txt.ForEach(t =>
            {
                string[] k = t.Split(',');
                command.CommandText += "INSERT INTO Employee VALUES ('" + k[0] + "','" + k[1] + "','" + k[2] + "','" + k[3] + "','" + k[4] + "') ";
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    WriteLog(ex);
                }
            });
            command.CommandText = null; // Прочтите информацию о заработной плате в файле
            string wagesReadPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\wages.txt";
            List<string> txt1 = File.ReadLines(@wagesReadPath).ToList();
            txt1.ForEach(t =>
            {
                string[] k = t.Split(','); command.CommandText += "INSERT INTO Wage VALUES ('" + k[0] + "','" + k[1] + "') ";
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    WriteLog(ex);
                }
            });
            command.CommandText = null;
            string attendReadPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\attendances.txt";
            List<string> txt2 = File.ReadLines(@attendReadPath).ToList();
            txt2.ForEach(t =>
            {
                string[] k = t.Split(','); command.CommandText += "INSERT INTO Attend VALUES ('" + k[0] + "','" + k[1] + "','" + k[2] + "') ";
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    WriteLog(ex);
                }
            });
            connection.Close();
        }

        public void CheckZaplata(int wage)
        {
            using SqlConnection connection = CreateConnection();
            connection.Open();
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = $@"select Employee.Num,Employee.Name from Employee left join Attend on(Attend.Num = Employee.Num) left join Wage on (Wage.No =Attend.No) where(Wage.Amount = {wage})"
            };
            try
            {
                SqlCheck(command);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
            connection.Close(); // закрытие синхронного подключения
        }

        public void CheckAttend(int att)
        {
            using SqlConnection connection = CreateConnection();
            connection.Open(); // синхронное подключение, требуется закрытие в конце блока
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = $"select Employee.Num,Employee.Name from Employee join Attend on(Attend.Num = Employee.Num) where (Attend.Attendance = {att})"
            };
            try
            {
                SqlCheck(command);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
            connection.Close(); // закрытие синхронного подключения
        }

        public void CheckEmployee(int k, int r)
        {
            using SqlConnection connection = CreateConnection();
            connection.Open(); // синхронное подключение, требуется закрытие в конце блока
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = $@"select * from Employee left join Attend on(Attend.Num = Employee.Num) left join Wage on(Wage.No = Attend.No) where (Wage.Amount <
                {k} AND Attend.Attendance = {r})"
            };
            try
            {
                SqlCheck(command);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
            connection.Close();
        }

        private void SqlCheck(SqlCommand command)
        {
            SqlDataAdapter sqlDA = new()
            {
                SelectCommand = command
            };
            DataSet ds = new();
            sqlDA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void WriteLog(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}