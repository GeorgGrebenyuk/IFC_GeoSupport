using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;

namespace DesktopVersion
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
	



		private void textBox1_TextChanged(object sender, EventArgs e) //С1
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e) //С2
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e) //С3
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e) //Н1
		{

		}

		private void textBox5_TextChanged(object sender, EventArgs e) //Н2
		{

		}

		private void textBox6_TextChanged(object sender, EventArgs e) //Н3
		{

		}


		private void textBox7_TextChanged(object sender, EventArgs e) //Консоль
		{

		}

		private void button5_Click(object sender, EventArgs e) //Кнопка сохранения результатов расчета
		{
			saveFileDialog2.Filter = "Файлы XML(*.xml)|*.xml";
			if (saveFileDialog2.CheckFileExists == true) Path.ChangeExtension(saveFileDialog2.FileName, ".xml");

			if (saveFileDialog2.ShowDialog() == DialogResult.Cancel) return;
			else
			{
				//Создаем файл XML
				XDocument SaveResults = new XDocument();
				//Создаем корневой элемент, который будет хранить параметры трансформации
				XElement Transformation = new XElement("TransformationParameters");
				//Создаем атрибут названия данного преобразования
				XAttribute Transformation_Name = new XAttribute("Name", "1");
				XAttribute Value_Units1 = new XAttribute("Units", "meters");
				XAttribute Value_Units2 = new XAttribute("Units", "radians");
				//Создаем элементы для параметров трансформации и вносим их значения
				XElement Value_dX = new XElement("Value_dX", $"{ΔX}");
				XElement Value_dY = new XElement("Value_dY", $"{ΔY}");
				XElement Value_dZ = new XElement("Value_dZ", $"{ΔZ}");
				XElement Value_ωz = new XElement("Value_ωz", $"{ωz}");
				XElement Value_Error = new XElement("Accuracy", $"{error}");
				//Заносим параметры в документ
				SaveResults.Add(Transformation);
				Transformation.Add(Transformation_Name);
				Transformation.Add(Value_dX);
				Transformation.Add(Value_dY);
				Transformation.Add(Value_dZ);
				Transformation.Add(Value_ωz);
				Transformation.Add(Value_Error);
				Value_dX.Add(Value_Units1);
				Value_dY.Add(Value_Units1);
				Value_dZ.Add(Value_Units1);
				Value_ωz.Add(Value_Units2);
				SaveResults.Save(saveFileDialog2.FileName);
				//textBox7.Text = DateTime.Now + " " + "Запись в файл завершена!";
			}
		}

		private void button6_Click(object sender, EventArgs e) //Кнопка загрузки результата прежнего расчета
		{
			if (openFileDialog4.ShowDialog() == DialogResult.Cancel) return;
			else
			{
				XmlDocument LoadResults = new XmlDocument();
				LoadResults.Load(openFileDialog4.FileName);
				//Прогружаем корневой элемент - Transformation
				XmlElement Transformation = LoadResults.DocumentElement;
				foreach (XmlNode Values in Transformation.ChildNodes)
				{
					if (Values.Name == "Value_dX")
					{
						ΔX = Convert.ToDouble(Values.InnerText);
					}
					else if (Values.Name == "Value_dY")
					{
						ΔY = Convert.ToDouble(Values.InnerText);
					}
					else if (Values.Name == "Value_dZ")
					{
						ΔZ = Convert.ToDouble(Values.InnerText);
					}
					else if (Values.Name == "Value_ωz")
					{
						ωz = Convert.ToDouble(Values.InnerText);
					}
				}
				textBox7.Text = $"dX принят = {ΔX} м" + Environment.NewLine + $"dY принят = {ΔY} м" + Environment.NewLine
				+ $"dZ принят = {ΔZ} м" + Environment.NewLine + $"ωz принят = {-ωz*180/Math.PI} градусов" + Environment.NewLine;
				//Блокируем строки воода данных
				textBox1.Enabled = false;
				textBox2.Enabled = false;
				textBox3.Enabled = false;
				textBox4.Enabled = false;
				textBox5.Enabled = false;
				textBox6.Enabled = false;

			}
		}
		private string[] Data = new string[6];
		//private string IFC_ParentApplication = null;
		private bool WriteOrEdit = true; //True = create new
		StringBuilder ChangingFile = new StringBuilder();

		private void button8_Click(object sender, EventArgs e) //Только расчет
		{
			if (textBox1.Enabled == true) //Вообще говоря надо проверить все поля, но функция загрузки параметров блокирует все итак - поэтому достаточно проверить факт блокировки лишь одного из полей
			{
				//Если не сработало исключение загрузки данных - значит считаем параметры
				//Получение массива данных и передача в расчетный метод
				Data[0] = textBox1.Text;
				Data[1] = textBox2.Text;
				Data[2] = textBox3.Text;
				Data[3] = textBox4.Text;
				Data[4] = textBox5.Text;
				Data[5] = textBox6.Text;
				FindParameters(Data);
			}
			//Запись в консоль результата расчета
			textBox7.Text ="Расчет параметров трансформации для Navisworks закончен!" + Environment.NewLine + $"dX принят = {ΔX} м" + Environment.NewLine + $"dY принят = {ΔY} м" + Environment.NewLine
	+ $"dZ принят = {ΔZ} м" + Environment.NewLine + $"ωz принят = {-ωz * 180 / Math.PI} градусов" + Environment.NewLine;
		}
		
		/* Код ниже будет выполняеть расчетные функции приложения. 
		 * Теоретические основы алгоритма и справочная литература изложена в Docs и на GitBook
		 * Приложение использует пакет Nuget Maths.Numeric ver 4.12
		 */

			//Элементы трансформации и вспомогательные переменные
		public double ΔX = 0d;
		public double ΔY = 0d;
		public double ΔZ = 0d;
		//double ωx = 0d;
		//double ωy = 0d;
		public double ωz = 0d;
		//double M = 1.0d;
		public double error = 0d;


		public Dictionary<string, object> FindParameters(string[] Data) //Получение на вход массива строк (1-6) с основной формы
		{
			string OldCSPoint1 = Data[0];
			string[] OldCSPoint1_str = OldCSPoint1.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XC1 = Convert.ToDouble(OldCSPoint1_str[0]);
			double YC1 = Convert.ToDouble(OldCSPoint1_str[1]);
			double ZC1 = Convert.ToDouble(OldCSPoint1_str[2]);
			//Создание матрицы mC1 3х1 из исходных данных
			var mC1 = CreateMatrix.Dense(3, 1, new double[] { XC1, YC1, ZC1 });

			string OldCSPoint2 = Data[1];
			string[] OldCSPoint2_str = OldCSPoint2.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XC2 = Convert.ToDouble(OldCSPoint2_str[0]);
			double YC2 = Convert.ToDouble(OldCSPoint2_str[1]);
			double ZC2 = Convert.ToDouble(OldCSPoint2_str[2]);
			//Создание матрицы mC2 3х1 из исходных данных
			var mC2 = CreateMatrix.Dense(3, 1, new double[] { XC2, YC2, ZC2 });

			string OldCSPoint3 = Data[2];
			string[] OldCSPoint3_str = OldCSPoint3.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XC3 = Convert.ToDouble(OldCSPoint3_str[0]);
			double YC3 = Convert.ToDouble(OldCSPoint3_str[1]);
			double ZC3 = Convert.ToDouble(OldCSPoint3_str[2]);
			//Создание матрицы mC3 3х1 из исходных данных
			var mC3 = CreateMatrix.Dense(3, 1, new double[] { XC3, YC3, ZC3 });

			string NewCSPoint1 = Data[3];
			string[] NewCSPoint1_str = NewCSPoint1.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XN1 = Convert.ToDouble(NewCSPoint1_str[0]);
			double YN1 = Convert.ToDouble(NewCSPoint1_str[1]);
			double ZN1 = Convert.ToDouble(NewCSPoint1_str[2]);

			string NewCSPoint2 = Data[4];
			string[] NewCSPoint2_str = NewCSPoint2.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XN2 = Convert.ToDouble(NewCSPoint2_str[0]);
			double YN2 = Convert.ToDouble(NewCSPoint2_str[1]);
			double ZN2 = Convert.ToDouble(NewCSPoint2_str[2]);

			string NewCSPoint3 = Data[5];
			string[] NewCSPoint3_str = NewCSPoint3.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XN3 = Convert.ToDouble(NewCSPoint3_str[0]);
			double YN3 = Convert.ToDouble(NewCSPoint3_str[1]);
			double ZN3 = Convert.ToDouble(NewCSPoint3_str[2]);

			//Разности координат
			double dXC1 = XC2 - XC1;
			double dYC1 = YC2 - YC1;
			double dZC1 = ZC2 - ZC1;
			double dXC2 = XC3 - XC2;
			double dYC2 = YC3 - YC2;
			double dZC2 = ZC3 - ZC2;
			double dXC3 = XC3 - XC1;
			double dYC3 = YC3 - YC1;
			double dZC3 = ZC3 - ZC1;

			double dXN1 = XN2 - XN1;
			double dYN1 = YN2 - YN1;
			double dZN1 = ZN2 - ZN1;
			double dXN2 = XN3 - XN2;
			double dYN2 = YN3 - YN2;
			double dZN2 = ZN3 - ZN2;
			double dXN3 = XN3 - XN1;
			double dYN3 = YN3 - YN1;
			double dZN3 = ZN3 - ZN1;
			//Элементы ортогональной матрицы вращения
			double a11 = 0d;
			double a12 = 0d;
			double a13 = 0d;
			double a21 = 0d;
			double a22 = 0d;
			double a23 = 0d;
			double a31 = 0d;
			double a32 = 0d;
			double a33 = 0d;
			double ωz_opt = 0d;

			//Параметр оптимизации
			double v_min = 1000000000000d; //Начальное заведомо-большее значение
			while (ωz < 2 * Math.PI) //МНК для поиска значения ωz
			{
				//Коэффициенты матрицы поврота
				a11 = Math.Cos(ωz);
				a12 = Math.Sin(ωz);
				a21 = -Math.Sin(ωz);
				a22 = Math.Cos(ωz);
				//Запись системы уравнений оптимизации

				double vx1 = a11 * dXC1 + a12 * dYC1 + a13 * dZC1 - dXN1;
				double vx2 = a11 * dXC2 + a12 * dYC2 + a13 * dZC2 - dXN2;
				double vx3 = a11 * dXC3 + a12 * dYC3 + a13 * dZC3 - dXN3;
				double vy1 = a21 * dXC1 + a22 * dYC1 + a23 * dZC1 - dYN1;
				double vy2 = a21 * dXC2 + a22 * dYC2 + a23 * dZC2 - dYN2;
				double vy3 = a21 * dXC3 + a22 * dYC3 + a23 * dZC3 - dYN3;
				//Параметр оптимизации
				double v = Math.Pow(vx1, 2) + Math.Pow(vx2, 2) + Math.Pow(vx3, 2) + Math.Pow(vy1, 2) + Math.Pow(vy2, 2) + Math.Pow(vy3, 2);
				if (v < v_min)
				{   //Запись в память потенциального решения и перезадание параметра v_max
					ωz_opt = ωz;
					v_min = v;
				}
				ωz = ωz + 0.000001; //Прибавление значений, радиан
			}
			//Возврат найденного оптимального значения
			ωz = ωz_opt;
			error = v_min;
			//Пересчет матрицы
			a11 = Math.Cos(ωz);
			a12 = Math.Sin(ωz);
			a13 = 0d;
			a21 = -Math.Sin(ωz);
			a22 = Math.Cos(ωz);
			a23 = 0d;
			a31 = 0d;
			a32 = 0d;
			a33 = 1d;
			//var P = CreateMatrix.Dense(3, 3, new double[] { a11, a12, a13, a21, a22, a23, a31, a32, a33 });
			//Члены для матрицы вбивать по колонкам !!!!!!!!!!! 
			var P = CreateMatrix.Dense(3, 3, new double[] { a11, a21, a31, a12, a22, a32, a31, a23, a33 });

			//Перемножаем матрицы для вычисления вспомогательных (без сдвигов) координат
			var mHelp1 = P * mC1;
			double[][] mHelp1_result = mHelp1.ToRowArrays();
			double x1 = mHelp1_result[0][0];
			double y1 = mHelp1_result[1][0];
			double z1 = mHelp1_result[2][0];

			var mHelp2 = P * mC2;
			double[][] mHelp2_result = mHelp2.ToRowArrays();
			double x2 = mHelp2_result[0][0];
			double y2 = mHelp2_result[1][0];
			double z2 = mHelp2_result[2][0];

			var mHelp3 = P * mC3;
			double[][] mHelp3_result = mHelp3.ToRowArrays();
			double x3 = mHelp3_result[0][0];
			double y3 = mHelp3_result[1][0];
			double z3 = mHelp3_result[2][0];

			var H = CreateMatrix.Dense(9, 3, new double[] { 1d, 0d, 0d, 1d, 0d, 0d, 1d, 0d, 0d, 0d, 1d, 0d, 0d, 1d, 0d, 0d, 1d, 0d, 0d, 0d, 1d, 0d, 0d, 1d, 0d, 0d, 1d });
			var dL = CreateMatrix.Dense(9, 1, new double[] { XN1 - x1, YN1 - y1, ZN1 - z1, XN2 - x2, YN2 - y2, ZN2 - z2, XN3 - x3, YN3 - y3, ZN3 - z3 });

			var dXYZ_m = ((H.Transpose() * H).Inverse()) * H.Transpose() * dL;
			double[][] dXYZ = dXYZ_m.ToRowArrays();

			//Округляем значения чтобы не тащить кучу хвостов из точности расчета
			ΔX = Math.Round(dXYZ[0][0], 6);
			ΔY = Math.Round(dXYZ[1][0], 6);
			ΔZ = Math.Round(dXYZ[2][0], 6);
			error = Math.Round(error, 9);
			//ωz = ωz * 180 / Math.PI;
			return new Dictionary<string, object>
			{
				{"Смещение по оси X, м", ΔX },
				{"Смещение по оси Y, м", ΔY },
				{"Смещение по оси Z, м", ΔZ },
				{"Угол поворота, градусы", ωz * 180 / Math.PI },
			};
		}

		private void saveFileDialog2_FileOk(object sender, CancelEventArgs e) //Сохранить результат расчета (параметры трансформации)
		{

		}

		private void openFileDialog4_FileOk(object sender, CancelEventArgs e) //Функция загрузи данных трансформации
		{

		}



	}
}
