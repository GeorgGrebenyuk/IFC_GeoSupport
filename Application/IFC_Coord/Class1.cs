using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Autodesk.DesignScript.Runtime;

namespace IFC_Coord
{ 
		public class General
	{
		private General() { }
		//[MultiReturn(new[] { "IFC 2x3", "IFC 4", "IFC 4.1" })]
		//public static Dictionary<string, object> WhatIs_IFC_Scpecification()
		//{
		//	return new Dictionary<string, object>
		//	{
		//		{"IFC 2x3", "IFC 2x3" },
		//		{"IFC 4", "IFC 4" },
		//		{"IFC 4.1", "IFC 4.1" },
		//	};
		//}
		//[MultiReturn(new[] { "IFC 2x3", "IFC 4", "IFC 4.1" })]
		//public static Dictionary<string, object> WhatIs_CurrentSoftware()
		//{
		//	return new Dictionary<string, object>
		//	{
		//		{"Renga, ver 4.4", "Renga, ver 4.4" },
		//		{"Aveva Everything 3D", "Aveva Everything 3D" },
		//	};
		//}

		/// <summary>
		/// Node that create a massive of variables to netx calculating
		/// </summary>
		/// <param name="CurrentCS_Point1">First point in current coordinate system of project/file</param>
		/// <param name="CurrentCS_Point2">Second point in current coordinate system of project/file</param>
		/// <param name="CurrentCS_Point3">Third point in current coordinate system of project/file</param>
		/// <param name="FinishCS_Point1">First point in finish coordinate system of project</param>
		/// <param name="FinishCS_Point2">Second point in finish coordinate system of project</param>
		/// <param name="FinishCS_Point3">Second point in finish coordinate system of project</param>
		/// <returns>Massive of elements</returns>
		public static string[] CreateDataMassive(string CurrentCS_Point1, string CurrentCS_Point2, string CurrentCS_Point3, string FinishCS_Point1, string FinishCS_Point2, string FinishCS_Point3)
		{
			NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
			string[] Data = new string[6];
			Data[0] = Convert.ToString(CurrentCS_Point1, nfi);
			Data[1] = Convert.ToString(CurrentCS_Point2, nfi);
			Data[2] = Convert.ToString(CurrentCS_Point3, nfi);
			Data[3] = Convert.ToString(FinishCS_Point1, nfi); 
			Data[4] = Convert.ToString(FinishCS_Point2, nfi);
			Data[5] = Convert.ToString(FinishCS_Point3, nfi);
			return Data;
		}
		
		/// <summary>
		/// Technical process (don't need to use) that write changing IFC to external file
		/// </summary>
		/// <param name="SB">StringBuilder constructor with data</param>
		/// <param name="PathToSaveIFC">Absolute path to saving IFC file</param>
		public static void Save_IFC(StringBuilder SB, string PathToSaveIFC)
		{
			File.AppendAllText(PathToSaveIFC, SB.ToString(), Encoding.UTF8);
			SB.Clear();
		}

	}
	public class Calculates
	{
		private Calculates() { }
		//Массив с координатами
		//public string[] Data = new string[6];

		/// <summary>
		/// Main node that calculate parameters from input strings massive
		/// </summary>
		/// <param name="Data">Massive of elements</param>
		/// <returns>Dictionary with parameters</returns>
		/// 
		[MultiReturn(new[] { "Offset of X-axis, meters", "Offset of Y-axis, meters", "Offset of Z-axis, meters", "Rotation angle, grades", "Rotation angle, radians", "Linear error, meters" })]
		public static Dictionary<string, object> FindParameters(string[] Data) //Получение на вход массива строк (1-6) с основной формы
		{
			//Элементы трансформации и вспомогательные переменные
			double ΔX = 0d;
			double ΔY = 0d;
			double ΔZ = 0d;
			//double ωx = 0d;
			//double ωy = 0d;
			double ωz = 0d;
			//double M = 1.0d;
			double error = 0d;

			NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
			string OldCSPoint1 = Data[0];
			string[] OldCSPoint1_str = OldCSPoint1.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XC1 = Convert.ToDouble(OldCSPoint1_str[0], nfi);
			double YC1 = Convert.ToDouble(OldCSPoint1_str[1], nfi);
			double ZC1 = Convert.ToDouble(OldCSPoint1_str[2], nfi);
			//Создание матрицы mC1 3х1 из исходных данных
			var mC1 = CreateMatrix.Dense(3, 1, new double[] { XC1, YC1, ZC1 });

			string OldCSPoint2 = Data[1];
			string[] OldCSPoint2_str = OldCSPoint2.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XC2 = Convert.ToDouble(OldCSPoint2_str[0], nfi);
			double YC2 = Convert.ToDouble(OldCSPoint2_str[1], nfi);
			double ZC2 = Convert.ToDouble(OldCSPoint2_str[2], nfi);
			//Создание матрицы mC2 3х1 из исходных данных
			var mC2 = CreateMatrix.Dense(3, 1, new double[] { XC2, YC2, ZC2 });

			string OldCSPoint3 = Data[2];
			string[] OldCSPoint3_str = OldCSPoint3.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XC3 = Convert.ToDouble(OldCSPoint3_str[0], nfi);
			double YC3 = Convert.ToDouble(OldCSPoint3_str[1], nfi);
			double ZC3 = Convert.ToDouble(OldCSPoint3_str[2], nfi);
			//Создание матрицы mC3 3х1 из исходных данных
			var mC3 = CreateMatrix.Dense(3, 1, new double[] { XC3, YC3, ZC3 });

			string NewCSPoint1 = Data[3];
			string[] NewCSPoint1_str = NewCSPoint1.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XN1 = Convert.ToDouble(NewCSPoint1_str[0], nfi);
			double YN1 = Convert.ToDouble(NewCSPoint1_str[1], nfi);
			double ZN1 = Convert.ToDouble(NewCSPoint1_str[2], nfi);

			string NewCSPoint2 = Data[4];
			string[] NewCSPoint2_str = NewCSPoint2.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XN2 = Convert.ToDouble(NewCSPoint2_str[0], nfi);
			double YN2 = Convert.ToDouble(NewCSPoint2_str[1], nfi);
			double ZN2 = Convert.ToDouble(NewCSPoint2_str[2], nfi);

			string NewCSPoint3 = Data[5];
			string[] NewCSPoint3_str = NewCSPoint3.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			double XN3 = Convert.ToDouble(NewCSPoint3_str[0], nfi);
			double YN3 = Convert.ToDouble(NewCSPoint3_str[1], nfi);
			double ZN3 = Convert.ToDouble(NewCSPoint3_str[2], nfi);

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
			ΔX = Math.Round(dXYZ[0][0], 8);
			ΔY = Math.Round(dXYZ[1][0], 8);
			ΔZ = Math.Round(dXYZ[2][0], 8);
			error = Math.Round(error, 12);
			//ωz = ωz * 180 / Math.PI;
			return new Dictionary<string, object>
			{
				{"Offset of X-axis, meters", ΔX },
				{"Offset of Y-axis, meters", ΔY },
				{"Offset of Z-axis, meters", ΔZ },
				{"Rotation angle, grades", ωz * 180 / Math.PI },
				{"Rotation angle, radians", ωz },
				{"Linear error, meters", error },
			};
		}

		/// <summary>
		/// Node that allow save calculating values to external XML-file to future transformations
		/// </summary>
		/// <param name="ΔX">Offset for X-axis, meters</param>
		/// <param name="ΔY">Offset for Y-axis, meters</param>
		/// <param name="ΔZ">Offset for Z-axis, meters</param>
		/// <param name="ωz">Rotation angle, radians</param>
		/// <param name="error">Linear error of calculatings, meters</param>
		/// <param name="SaveFilePath">Absolute path to saving IFC file</param>
		public static void SaveResultsOfCalculating(double ΔX, double ΔY, double ΔZ, double ωz, double error, string SaveFilePath)
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
			SaveResults.Save(Path.GetFullPath(SaveFilePath));
			
		}
		/// <summary>
		/// Node allow load from external XML-file results of previous calculate-session and retuan a Dictionary with values
		/// </summary>
		/// <param name="PathToFile">Absolute system path to XML-file </param>
		/// <returns>Dictionary with values</returns>
		[MultiReturn(new[] { "Offset of X-axis, meters", "Offset of Y-axis, meters", "Offset of Z-axis, meters", "Rotation angle, grades", "Rotation angle, radians", "Linear error, meters" })]
		public static Dictionary <string,object> LoadResultsOfCalculating(string PathToFile)
		{
			double ΔX = 0d;
			double ΔY = 0d;
			double ΔZ = 0d;
			//double ωx = 0d;
			//double ωy = 0d;
			double ωz = 0d;
			//double M = 1.0d;
			double error = 0d;

			XmlDocument LoadResults = new XmlDocument();
			LoadResults.Load(Path.GetFullPath(PathToFile));
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
				else if (Values.Name == "Accuracy")
				{
					error = Convert.ToDouble(Values.InnerText);
				}
			}
			return new Dictionary<string, object>
			{
				{"Offset of X-axis, meters", ΔX },
				{"Offset of Y-axis, meters", ΔY },
				{"Offset of Z-axis, meters", ΔZ },
				{"Rotation angle, grades", ωz * 180 / Math.PI },
				{"Rotation angle, radians", ωz },
				{"Linear error, meters", error },
			};
		}
	}
		public class IFC_2x3
		{
		private IFC_2x3() { }
			//Class for changing IFC 2x3 files

		}
		public class IFC_4
	{
		private IFC_4() { }
		private static StringBuilder ChangingFile = new StringBuilder();
		//Class for changing IFC 4 files
		/// <summary>
		/// Node for changing IFC file from Renga version 4.4 (by 2020 December), IFC 4
		/// </summary>
		/// <param name="PathToInputIFC">Absolute path to input IFC file</param>
		/// <param name="PathToSaveIFC">Absolute path to saving IFC file</param>
		/// <param name="ΔX"></param>
		/// <param name="ΔY"></param>
		/// <param name="ΔZ"></param>
		/// <param name="ωz"></param>
		public static void Renga_44(string PathToInputIFC, string PathToSaveIFC, double ΔX, double ΔY, double ΔZ, double ωz)
		{

			string File_Path = Path.GetFullPath(PathToInputIFC);
			long file_count = 0;

			foreach (string DS in File.ReadAllLines(File_Path))
			{
				file_count++;
			}
			file_count = file_count + 10;

			string data_str2 = null;
			int Counter = 0;
			//Актуально для версии IFC 4
			foreach (string data_str in File.ReadAllLines(File_Path))
			{
				if (data_str.Contains("#10=") == true)
				{
					//Меняем значение базовой точки #10= IFCCARTESIANPOINT((0.,0.,0.)); на #10= IFCCARTESIANPOINT((X,Y,Z));
					data_str2 = $"#10= IFCCARTESIANPOINT(({ΔX * 1000},{ΔY * 1000},{ΔZ * 1000}));" + Environment.NewLine + $"#{file_count + 1}= IFCCARTESIANPOINT((0.,0.,{ΔZ * 1000}));";
					ChangingFile.AppendLine(data_str2);
				}
				else if (data_str.Contains("#12=") == true)
				{
					//Меняем угол поворота #12= IFCDIRECTION((1.,0.,0.)); на #12= IFCDIRECTION((U,V,0.)); индекс i увеличивается на 1, так как в прежнем пункте мы добавили 1 строку 
					data_str2 = $"#12= IFCDIRECTION(({1 * Math.Cos(ωz)},{-1 * Math.Sin(ωz)},0.));";
					ChangingFile.AppendLine(data_str2);
				}
				else if (data_str.Contains("#13=") == true)
				{
					//Вставляем новую строку после #13= IFCAXIS2PLACEMENT3D(#10,#11,#12); - для обозначения вектора выравнивания по высоте
					data_str2 = $"#13= IFCAXIS2PLACEMENT3D(#10,#11,#12);" + Environment.NewLine + $"#{file_count + 2}= IFCAXIS2PLACEMENT3D(#{file_count + 1},$,$);";
					ChangingFile.AppendLine(data_str2);
				}
				else if (data_str.Contains("#14=") == true)
				{
					//Меняем параметр IFCGEOMETRICREPRESENTATIONCONTEXT
					data_str2 = $"#14= IFCGEOMETRICREPRESENTATIONCONTEXT('Model','Model',3,0.000001,#{file_count + 2},#12);";
					ChangingFile.AppendLine(data_str2);
				}
				else if (data_str.Contains("#23=") == true)
				{
					//Меняем параметр IFCLOCALPLACEMENT
					data_str2 = $"#23= IFCLOCALPLACEMENT($,#13);";
					ChangingFile.AppendLine(data_str2);
				}
				else
				{
				ChangingFile.AppendLine(data_str);
				}
				Counter++;
				if (Counter == 500000)
				{
					General.Save_IFC(ChangingFile, PathToSaveIFC);
					ChangingFile.Clear();
					Counter = 0;
				}

			}
			General.Save_IFC(ChangingFile, PathToSaveIFC);
		}
	}
}
