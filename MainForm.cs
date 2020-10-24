using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;


namespace IFC_AddGeolocation_Ver1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBox15.Text = "0.001";
            //Блокировка параметров для базовой точки
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            //Блокировка клавиш управления для базовой точки
            button2.Enabled = false;
            button4.Enabled = false;
            //Блокировка координат начального IFC
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;
            //Блокировка значения допуска
            textBox15.Enabled = false;
            //Блокировка координат в целевой системе для 3х точек
            textBox16.Enabled = false;
            textBox17.Enabled = false;
            textBox18.Enabled = false;
            textBox19.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;
            textBox23.Enabled = false;
            textBox24.Enabled = false;
            //Блокировка клавиш управления для 3-х точек
            button7.Enabled = false;
            button9.Enabled = false;
            //Блокировка экспорта настроек и импорта настроек
            button3.Enabled = false;
            button13.Enabled = false;
            //Блокировка навечно опции изменять исходный файл
            radioButton3.Enabled = false;
            //выбор по умолчанию опции формировать новый файл
            radioButton4.Enabled = true;
            radioButton4.Checked = true;

        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            //Предварительная блокировка всех параметров до выбора параметров расчета
            //if (radioButton1.Checked != true && radioButton2.Checked != true)
            //{
            //    textBox2.Enabled = false;
            //    textBox3.Enabled = false;
            //    textBox4.Enabled = false;
            //    textBox5.Enabled = false;
            //    button2.Enabled = false;
            //    button3.Enabled = false;
            //    button4.Enabled = false;

            //    textBox6.Enabled = false;
            //    textBox7.Enabled = false;
            //    textBox8.Enabled = false;
            //    textBox9.Enabled = false;
            //    textBox10.Enabled = false;
            //    textBox11.Enabled = false;
            //    textBox12.Enabled = false;
            //    textBox13.Enabled = false;
            //    textBox14.Enabled = false;
            //    textBox15.Enabled = false;
            //    button7.Enabled = false;
            //    //button8.Enabled = false;
            //    button9.Enabled = false;
            //}

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = $"Текущая дата: {DateTime.Now}" + Environment.NewLine;
            //textBox1.Text = openFileDialog1.FileName;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Обнуление введенных параметров
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //Решение для случая базовой точки
        {
            textBox1.Text = $"{DateTime.Now} Процесс обработки запущен!";
            //0.0 - Установление путей к файлам, выбранных в окне программы
            //string FilePath_inputIFC = Path.GetFullPath(openFileDialog1.FileName);
            //string FilePath_outputIFC = Path.GetFullPath(saveFileDialog1.FileName);
            string FilePath_inputIFC = openFileDialog1.FileName;
            if (FilePath_inputIFC == null) textBox1.Text = $"{DateTime.Now} Файл не найден!";
            //saveFileDialog1.DefaultExt = "ifc"; не понимаю как оно работает
            string FilePath_outputIFC = saveFileDialog1.FileName;
            if (FilePath_outputIFC == null) textBox1.Text = $"{DateTime.Now} Не выбран файл для сохранения!";

            string writePath = FilePath_outputIFC; //для удобства смены (старый код быс с ней)

            //0.1 - Инициация изменяемых параметров
            double coord_X = Convert.ToDouble(textBox2.Text);
            double coord_Y = Convert.ToDouble(textBox3.Text);
            double coord_Z = Convert.ToDouble(textBox4.Text);
            double coord_Angle = Convert.ToDouble(textBox5.Text);
            double coord_Angle_rad = coord_Angle / 180 * Math.PI;
            //0.2 - Проверка версии IFC
            string[] data_strings = File.ReadAllLines(FilePath_inputIFC);
            string IFC_version = data_strings[4].Substring(14, data_strings[4].Length - 14 - 4);
            //string IFC_Software = data_strings[7].Substring(22, data_strings[7].Length - 22 - 9);

            //0.2 - Объявление вспомогательных переменных
            string data_str = null;
            string data_str2 = null;
            int i = -1;
            int j = 0;

            int file_count = data_strings.Length - 8;
            //Проверка программы-создателя IFC
            if (data_strings[3].Contains ("Renga") == true)
            {
                if (IFC_version == "IFC4")
                {
                    while (i < (data_strings.Length - 1))
                    {
                        i++;
                        data_str = data_strings[i];
                        if (data_str.Contains("#10=") == true)
                        {
                            //Меняем значение базовой точки #10= IFCCARTESIANPOINT((0.,0.,0.)); на #10= IFCCARTESIANPOINT((X,Y,Z));
                            j = 16;
                            i = j;
                            data_str2 = $"#10= IFCCARTESIANPOINT(({coord_X},{coord_Y},{coord_Z}));" + Environment.NewLine + $"#{file_count + 1}= IFCCARTESIANPOINT((0.,0.,{coord_Z}));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#12=") == true)
                        {
                            //Меняем угол поворота #12= IFCDIRECTION((1.,0.,0.)); на #12= IFCDIRECTION((U,V,0.)); индекс i увеличивается на 1, так как в прежнем пункте мы добавили 1 строку 
                            j = 18;
                            i = j;
                            data_str2 = $"#12= IFCDIRECTION(({-1 * Math.Sin(coord_Angle_rad)},{1 * Math.Cos(coord_Angle_rad)},0.));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#13=") == true)
                        {
                            //Вставляем новую строку после #13= IFCAXIS2PLACEMENT3D(#10,#11,#12); - для обозначения вектора выравнивания по высоте
                            j = 19;
                            i = j;
                            data_str2 = $"#13= IFCAXIS2PLACEMENT3D(#10,#11,#12);" + Environment.NewLine + $"#{file_count + 2}= IFCAXIS2PLACEMENT3D(#{file_count + 1},$,$);";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#14=") == true)
                        {
                            //Меняем параметр IFCGEOMETRICREPRESENTATIONCONTEXT для учета параметра выше и угла поворота модели, индекс увеличивается еще на 1 по причине добавления новой строки выше
                            j = 20;
                            i = j;
                            data_str2 = $"#14= IFCGEOMETRICREPRESENTATIONCONTEXT('Model','Model',3,0,#{file_count + 2},#12);" + Environment.NewLine;
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.Write(data_str);
                                    export_file.Close();
                                    export_file.Dispose();

                                }
                            }
                            else continue;
                        }
                        else
                        if (radioButton4.Checked == true)
                        {
                            using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                            {
                                export_file.Write(data_str + Environment.NewLine);
                                export_file.Close();
                                export_file.Dispose();
                            }
                        }
                        else continue;
                    }
                    textBox1.Text = $"{DateTime.Now} Преобразование успешно завершено";
                }
                else if (IFC_version == "IFC2X3")
                {
                    while (i < (data_strings.Length - 1))
                    {
                        i++;
                        data_str = data_strings[i];
                        if (data_str.Contains("#10=") == true)
                        {
                            //Меняем значение базовой точки #10= IFCCARTESIANPOINT((0.,0.,0.)); на #10= IFCCARTESIANPOINT((X,Y,Z));
                            j = 16;
                            i = j;
                            data_str2 = $"#10= IFCCARTESIANPOINT(({coord_X},{coord_Y},{coord_Z}));" + Environment.NewLine + $"#{file_count + 1}= IFCCARTESIANPOINT((0.,0.,0.));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#12=") == true)
                        {
                            //Меняем угол поворота #12= IFCDIRECTION((1.,0.,0.)); на #12= IFCDIRECTION((U,V,0.)); индекс i увеличивается на 1, так как в прежнем пункте мы добавили 1 строку. Также меняем U,V
                            j = 18;
                            i = j;
                            data_str2 = $"#12= IFCDIRECTION(({1 * Math.Cos(coord_Angle_rad)},{-1 * Math.Sin(coord_Angle_rad)},0.));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#13=") == true)
                        {
                            //Вставляем новую строку после #13= IFCAXIS2PLACEMENT3D(#10,#11,#12); - для обозначения вектора выравнивания по высоте
                            j = 19;
                            i = j;
                            data_str2 = $"#13= IFCAXIS2PLACEMENT3D(#10,#11,#12);" + Environment.NewLine + $"#{file_count + 2}= IFCAXIS2PLACEMENT3D(#{file_count + 1},$,$);";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#14=") == true)
                        {
                            //Меняем параметр IFCGEOMETRICREPRESENTATIONCONTEXT для учета параметра выше и угла поворота модели, индекс увеличивается еще на 1 по причине добавления новой строки выше
                            j = 20;
                            i = j;
                            data_str2 = $"#14= IFCGEOMETRICREPRESENTATIONCONTEXT('Model','Model',3,0,#{file_count + 2},#12);" + Environment.NewLine;
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.Write(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#19=") == true)
                        {
                            //Добавляем параметр IFCSITE для учета геоположения с параметрами по умолчанию (ссылка на #19 вроде бы стандартная)
                            j = 25;
                            i = j;
                            data_str2 = $"#19= IFCLOCALPLACEMENT($,#13);" + Environment.NewLine + $"#{file_count + 3}=IFCSITE('3dOuL0xHenG9BlQkI$_Cwt',$,'',$,$,#19,$,$,.ELEMENT.,$,$,$,$,$);" + Environment.NewLine;
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.Write(data_str);
                                    export_file.Close();
                                    export_file.Dispose();

                                }
                            }
                            else continue;
                        }
                        else
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.Write(data_str + Environment.NewLine);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                        else continue;
                    }

                    textBox1.Text = $"{DateTime.Now} Преобразование успешно завершено";
                }
                else textBox1.Text = $"{DateTime.Now} Файл не распознан!";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                button5_Click(sender, e);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                button5_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e) //Проверка условия - выделены ли какие-либо checkbox для разблокировки параметров ввода
        {
            if (radioButton1.Checked == true)
            {
                //Разблокировка ввода координат
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                //Разблокировка кнопок управления базовой точки
                button2.Enabled = true;
                button4.Enabled = true;
                //Блокировка координат начального IFC
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                textBox13.Enabled = false;
                textBox14.Enabled = false;
                //Блокировка значения допуска
                textBox15.Enabled = false;
                //Блокировка координат в целевой системе для 3х точек
                textBox16.Enabled = false;
                textBox17.Enabled = false;
                textBox18.Enabled = false;
                textBox19.Enabled = false;
                textBox20.Enabled = false;
                textBox21.Enabled = false;
                textBox22.Enabled = false;
                textBox23.Enabled = false;
                textBox24.Enabled = false;
                //Блокировка клавиш управления для 3-х точек
                button7.Enabled = false;
                button9.Enabled = false;
                //Разблокировка экспорта настроек и импорта настроек
                button3.Enabled = true;
                button13.Enabled = true;
            }
            else if (radioButton2.Checked == true)
            {
                //Блокировка параметров для базовой точки
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                //Блокировка клавиш управления для базовой точки
                button2.Enabled = false;
                button4.Enabled = false;
                //Разблокировка координат начального IFC
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;
                textBox13.Enabled = true;
                textBox14.Enabled = true;
                //Разблокировка значения допуска
                textBox15.Enabled = true;
                //Разблокировка координат в целевой системе для 3х точек
                textBox16.Enabled = true;
                textBox17.Enabled = true;
                textBox18.Enabled = true;
                textBox19.Enabled = true;
                textBox20.Enabled = true;
                textBox21.Enabled = true;
                textBox22.Enabled = true;
                textBox23.Enabled = true;
                textBox24.Enabled = true;
                //Разблокировка клавиш управления для 3-х точек
                button7.Enabled = true;
                button9.Enabled = true;
                //Разблокировка экспорта настроек и импорта настроек
                button3.Enabled = true;
                button13.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e) //Сброс всех параметров кроме IFC-файла
        {
            //Сброс всех параметров кроме IFC-файла
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;

            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            textBox10.Text = String.Empty;
            textBox11.Text = String.Empty;
            textBox12.Text = String.Empty;
            textBox13.Text = String.Empty;
            textBox14.Text = String.Empty;

            textBox16.Text = String.Empty;
            textBox17.Text = String.Empty;
            textBox18.Text = String.Empty;
            textBox19.Text = String.Empty;
            textBox20.Text = String.Empty;
            textBox21.Text = String.Empty;
            textBox22.Text = String.Empty;
            textBox23.Text = String.Empty;
            textBox24.Text = String.Empty;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button5.PerformClick();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) //Обнуление введенных параметров для случая трех точек
        {
            //Обнуление введенных параметров
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            textBox10.Text = String.Empty;
            textBox11.Text = String.Empty;
            textBox12.Text = String.Empty;
            textBox13.Text = String.Empty;
            textBox14.Text = String.Empty;

            textBox16.Text = String.Empty;
            textBox17.Text = String.Empty;
            textBox18.Text = String.Empty;
            textBox19.Text = String.Empty;
            textBox20.Text = String.Empty;
            textBox21.Text = String.Empty;
            textBox22.Text = String.Empty;
            textBox23.Text = String.Empty;
            textBox24.Text = String.Empty;

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e) //Запуск обработки сценария по 3-м точкам
        {   
            //Поработать с исключениями при невыборе файлов
            //if (openFileDialog1.FileName == null)
            //{
            //    textBox1.Text = $"{DateTime.Now} Файл не найден!";
            //    button5.PerformClick();
            //}
            //else if (saveFileDialog1.FileName == null)
            //{
            //    textBox1.Text = $"{DateTime.Now} Файл для сохранения не выбран!";
            //    button5.PerformClick();
            //}
            //Блок 1 - Вычислительная часть
            //1.1 - Инициация параметров
            //Координаты базового IFC
            double x1_1 = Convert.ToDouble(textBox6.Text);
            double y1_1 = Convert.ToDouble(textBox7.Text);
            double z1_1 = Convert.ToDouble(textBox8.Text);
            double x2_1 = Convert.ToDouble(textBox9.Text);
            double y2_1 = Convert.ToDouble(textBox10.Text);
            double z2_1 = Convert.ToDouble(textBox11.Text);
            double x3_1 = Convert.ToDouble(textBox12.Text);
            double y3_1 = Convert.ToDouble(textBox13.Text);
            double z3_1 = Convert.ToDouble(textBox14.Text);
            double[] x_1_array = new double[] { x1_1, x2_1, x3_1 };
            double[] y_1_array = new double[] { y1_1, y2_1, y3_1 };

            //Координаты целевого ГП (не обязательно целевого IFC)
            double x1_2 = Convert.ToDouble(textBox16.Text);
            double y1_2 = Convert.ToDouble(textBox17.Text);
            double z1_2 = Convert.ToDouble(textBox18.Text);
            double x2_2 = Convert.ToDouble(textBox19.Text);
            double y2_2 = Convert.ToDouble(textBox20.Text);
            double z2_2 = Convert.ToDouble(textBox21.Text);
            double x3_2 = Convert.ToDouble(textBox22.Text);
            double y3_2 = Convert.ToDouble(textBox23.Text);
            double z3_2 = Convert.ToDouble(textBox24.Text);
            double[] x_2_array = new double[] { x1_2, x2_2, x3_2 };
            double[] y_2_array = new double[] { y1_2, y2_2, y3_2 };
            //1.2 - Вспомогательные параметры
            double θ = 0d; //в градусах
            double θ_predv = 0d;
            double X0 = 0;
            double X0_1 = 0;
            double X0_2 = 0;
            double X0_3 = 0;

            double X0_sred = 0d;
            double X0_predv = 1 / 1000000000000;

            double Y0 = 0;
            double Y0_1 = 0;
            double Y0_2 = 0;
            double Y0_3 = 0;

            double Y0_sred = 0d;
            double Y0_predv = 1 / 1000000000000;
            double delta_1 = 0d;
            double delta_2 = 0d;

            double Z0 = 0d;

            delta_1 = Math.Pow(Math.Pow(1 / X0_predv, 2) + Math.Pow(1 / Y0_predv, 2), 0.5);
            double Δθ = 0d; //угол отсчитываемый против часовой стрелки от начального направления оси Ох
            double θ_rad = 0d;
            double dopusk = Convert.ToDouble(textBox15.Text); //1 мм

            do
            {
                Δθ = Δθ + 0.00000001; //условие прибавления новых значений
                //x_1_array
                θ = θ + Δθ; //В положительном направлении против часовой стрелки
                θ_rad = θ * Math.PI / 180;

                X0_1 = x_1_array[0] - x_2_array[0] * Math.Cos(θ_rad) + y_2_array[0] * Math.Sin(θ_rad);
                X0_2 = x_1_array[1] - x_2_array[1] * Math.Cos(θ_rad) + y_2_array[1] * Math.Sin(θ_rad);
                X0_3 = x_1_array[2] - x_2_array[2] * Math.Cos(θ_rad) + y_2_array[2] * Math.Sin(θ_rad);
                X0_sred = (X0_1 + X0_2 + X0_3) / 3;

                Y0_1 = y_1_array[0] - x_2_array[0] * Math.Sin(θ_rad) - y_2_array[0] * Math.Cos(θ_rad);
                Y0_2 = y_1_array[1] - x_2_array[1] * Math.Sin(θ_rad) - y_2_array[1] * Math.Cos(θ_rad);
                Y0_3 = y_1_array[2] - x_2_array[2] * Math.Sin(θ_rad) - y_2_array[2] * Math.Cos(θ_rad);
                Y0_sred = (Y0_1 + Y0_2 + Y0_3) / 3;

                if (Math.Abs(X0_sred - X0_1) < dopusk && Math.Abs(X0_sred - X0_2) < dopusk && Math.Abs(X0_sred - X0_3) < dopusk && Math.Abs(Y0_sred - Y0_1) < dopusk && Math.Abs(Y0_sred - Y0_2) < dopusk && Math.Abs(Y0_sred - Y0_3) < dopusk)
                {
                    θ = θ + Δθ;
                    X0 = X0_sred;
                    Y0 = Y0_sred;
                    delta_2 = Math.Pow(Math.Pow(1 / X0, 2) + Math.Pow(1 / Y0, 2), 0.5);

                    if (delta_1 > delta_2)
                    {
                        θ_predv = θ;
                        X0_predv = X0;
                        Y0_predv = Y0;
                        delta_1 = Math.Pow(Math.Pow(1 / X0_predv, 2) + Math.Pow(1 / Y0_predv, 2), 0.5);
                    }
                    else continue;
                }
                else continue;
            } while (θ < 360);
            θ = θ_predv;
            θ_rad = θ * Math.PI / 180;

            //Рассмотри вывод исключения, которое может произойти при введенном малом допуске. Первый случай - проверим что проекции на ось равны друг другу - значит, поворот отсутствует,
            //тогда необходимо чтобы дельты X,Y,Z были не равны нулю все - тогда системы совместимы. Второй случай -когда проекции не равны друг другу - значит, угол никак не может быть раавным нулю 
            if ((Math.Abs(x1_1 - x2_1) == Math.Abs(x1_2 - x2_2) && (X0 == 0 || Y0 == 0)) || (Math.Abs(x1_1 - x2_1) != Math.Abs(x1_2 - x2_2) && θ == 0))
            { textBox1.Text = "Для данного допуска значений не найдено. Пожалуйста, смените величину допуска на большее значение или вбейте более точные значения координат точек"; }

            //Стадия 2 - вычисление параметров смещения по 3х-параметрическому прреобразованию Молоденского
            //2.1 - Задание исходных матриц координат точек

            //Координаты точек в старой системе требуют пересчета (после уточнения влияния угла поворота на точку)

            //Матрица m1_1 из координат точки 1 в старой СК (после поворота)
            var m1_1 = CreateMatrix.Dense(3, 1, new double[] { x1_1 * Math.Cos(θ_rad) - y1_1 * Math.Sin(θ_rad), x1_1 * Math.Sin(θ_rad) + y1_1 * Math.Cos(θ_rad), z1_1 });
            //Матрица m2_1 из координат точки 2 в старой СК (после поворота)
            var m2_1 = CreateMatrix.Dense(3, 1, new double[] { x2_1 * Math.Cos(θ_rad) - y2_1 * Math.Sin(θ_rad), x2_1 * Math.Sin(θ_rad) + y2_1 * Math.Cos(θ_rad), z2_1 });
            //Матрица m3_1 из координат точки 3 в старой СК (после поворота)
            var m3_1 = CreateMatrix.Dense(3, 1, new double[] { x3_1 * Math.Cos(θ_rad) - y3_1 * Math.Sin(θ_rad), x3_1 * Math.Sin(θ_rad) + y3_1 * Math.Cos(θ_rad), z3_1 });

            //Матрица m1_2 из координат точки 1 в новой СК
            var m1_2 = CreateMatrix.Dense(3, 1, new double[] { x1_2, y1_2, z1_2 });
            //Матрица m2_2 из координат точки 2 в новой СК
            var m2_2 = CreateMatrix.Dense(3, 1, new double[] { x2_2, y2_2, z2_2 });
            //Матрица m3_2 из координат точки 3 в новой СК
            var m3_2 = CreateMatrix.Dense(3, 1, new double[] { x3_2, y3_2, z3_2 });

            //Результат вычитания матриц итоговых значений координат и начальных - для вычисления параметров сдвижки
            double[][] m1_result = (m1_2 - m1_1).ToRowArrays();
            double[][] m2_result = (m2_2 - m2_1).ToRowArrays();
            double[][] m3_result = (m3_2 - m3_1).ToRowArrays();

            //Параметры для самого IFC
            X0 = (m1_result[0][0] + m2_result[0][0] + m3_result[0][0]) * 1000 / 3;
            Y0 = (m1_result[1][0] + m2_result[1][0] + m3_result[1][0]) * 1000 / 3;
            Z0 = (m1_result[2][0] + m2_result[2][0] + m3_result[2][0]) * 1000 / 3;

            double cos_a = Math.Cos(θ_rad);
            double sin_a = Math.Sin(θ_rad);

            //Блок 2 - Часть добавления данных в IFC - файл

            textBox1.Text = "Процесс обработки запущен";
            //0.0 - Установление путей к файлам, выбранных в окне программы

            string FilePath_inputIFC = openFileDialog1.FileName;
            if (FilePath_inputIFC == null) textBox1.Text = $"{DateTime.Now} Файл не найден!";
            string FilePath_outputIFC = saveFileDialog1.FileName;
            if (FilePath_outputIFC == null) textBox1.Text = $"{DateTime.Now} Не выбран файл для сохранения!";
            string writePath = FilePath_outputIFC; //для удобства смены (старый код быс с ней)

            //0.2 - Проверка версии IFC
            string[] data_strings = File.ReadAllLines(FilePath_inputIFC);
            string IFC_version = data_strings[4].Substring(14, data_strings[4].Length - 14 - 4);
            //string IFC_Software = data_strings[7].Substring(22, data_strings[7].Length - 22 - 9);

            //0.2 - Объявление вспомогательных переменных
            string data_str = null;
            string data_str2 = null;
            int i = -1;
            int j = 0;

            int file_count = data_strings.Length - 8;
            //Проверка программы-создателя IFC

            if (data_strings[3].Contains("AVEVA Everything3D Design") == true)
            {
                if (IFC_version == "IFC2X3")
                {
                    while (i < (data_strings.Length - 1))
                    {
                        i++;
                        data_str = data_strings[i];
                        if (data_str.Contains("#17=") == true)
                        {
                            //Меняем значение поворота на север #20 в параметре IFCGEOMETRICREPRESENTATIONCONTEXT и ставим "0" в локальном развороте
                            j = 23;
                            i = j;
                            data_str2 = $"#17= IFCGEOMETRICREPRESENTATIONCONTEXT($,'Model',3,0,#16,#20);";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#19=") == true)
                        {
                            //Меняем значения базовой точки #19= IFCCARTESIANPOINT ((0.0,0.0,0.0)); на  #19= IFCCARTESIANPOINT ((X0,Y0,Z0));
                            j = 25;
                            i = j;
                            data_str2 = $"#19= IFCCARTESIANPOINT(({X0},{Y0},{Z0}));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#20=") == true)
                        {
                            //Меняем параметры далее (обнуляем) углы и точки до вставки параметра IFCSITE
                            j = 26;
                            i = j;
                            data_str2 = $"#20= IFCDIRECTION(({cos_a},{sin_a},0.0));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#21=") == true)
                        {
                            //Меняем параметры далее (обнуляем) углы и точки до вставки параметра IFCSITE
                            j = 27;
                            i = j;
                            data_str2 = $"#21= IFCDIRECTION((0.0,0.0,0.0));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#25=") == true)
                        {
                            //Меняем параметры далее (обнуляем) углы и точки до вставки параметра IFCSITE
                            j = 31;
                            i = j;
                            data_str2 = $"#25= IFCDIRECTION((0.0,0.0,0.0));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#26=") == true)
                        {
                            //Меняем параметры далее (обнуляем) углы и точки до вставки параметра IFCSITE
                            j = 32;
                            i = j;
                            data_str2 = $"#26= IFCDIRECTION((0.0,0.0,0.0));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#30=") == true)
                        {
                            //Меняем параметры далее (обнуляем) углы и точки до вставки параметра IFCSITE
                            j = 36;
                            i = j;
                            data_str2 = $"#30= IFCDIRECTION((0.0,0.0,0.0));";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        else if (data_str.Contains("#31=") == true)
                        {
                            //Меняем параметры далее (обнуляем) углы и точки до вставки параметра IFCSITE + вставляем IFCSITE
                            j = 37;
                            i = j;
                            data_str2 = $"#31= IFCDIRECTION((0.0,0.0,0.0));" + Environment.NewLine + $"#{file_count + 1}= IFCSITE('3dOuL0xHenG9BlQkI$_Cwt',$,'',$,$,#33,$,$,.ELEMENT.,$,$,$,$,$);";
                            data_str = data_str.Replace($"{data_str}", $"{data_str2}");
                            if (radioButton4.Checked == true)
                            {
                                using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                                {
                                    export_file.WriteLine(data_str);
                                    export_file.Close();
                                    export_file.Dispose();
                                }
                            }
                            else continue;
                        }
                        

                        else 
                            if (radioButton4.Checked == true)
                        {
                            using (StreamWriter export_file = new StreamWriter(writePath, true, Encoding.Default))
                            {
                                export_file.Write(data_str + Environment.NewLine);
                                export_file.Close();
                                export_file.Dispose();
                            }
                        }
                        else continue;
                    }
                    textBox1.Text = $"{DateTime.Now} Преобразование успешно завершено";
                }
                
                else textBox1.Text = $"{DateTime.Now} Формат IFC не распознан!";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void textBox15_TextChanged(object sender, EventArgs e)
		{
            //Для допуска
            

        }

		private void button11_Click(object sender, EventArgs e)
		{
            //Справка
		}

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
            //Сохранить файл
		}

		private void button12_Click(object sender, EventArgs e) //Кнопка сохранения файла
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
        }

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void textBox16_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox17_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox18_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox19_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox20_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox21_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox22_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox23_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox24_TextChanged(object sender, EventArgs e)
		{

		}

        private void button3_Click_1(object sender, EventArgs e) //Кнопка импорта параметров ввода данных из файла ??? (csv)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;

            string FilePath_inputConfig = openFileDialog2.FileName;
            string[] data_strings = File.ReadAllLines(openFileDialog2.FileName);
            string[] str_values = data_strings[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (str_values[0] == "Three-points")
            {
                radioButton2.Checked = true;
                //Простановка координат в исходном IFC
                textBox6.Text = str_values[1];
                textBox7.Text = str_values[2];
                textBox8.Text = str_values[3];
                textBox9.Text = str_values[4];
                textBox10.Text = str_values[5];
                textBox11.Text = str_values[6];
                textBox12.Text = str_values[7];
                textBox13.Text = str_values[8];
                textBox14.Text = str_values[9];
                //Простановка координат проекта
                textBox16.Text = str_values[10];
                textBox17.Text = str_values[11];
                textBox18.Text = str_values[12];
                textBox19.Text = str_values[13];
                textBox20.Text = str_values[14];
                textBox21.Text = str_values[15];
                textBox22.Text = str_values[16];
                textBox23.Text = str_values[17];
                textBox24.Text = str_values[18];
                //Простановка значения допуска
                textBox15.Text = str_values[19];

            }

            else if (str_values[0] == "Base-point")
            {
                radioButton1.Checked = true;
                textBox2.Text = str_values[1];
                textBox3.Text = str_values[2];
                textBox4.Text = str_values[3];
                textBox5.Text = str_values[4];

            }
            else textBox1.Text = "Файл не распознан";
        }

        private void button13_Click(object sender, EventArgs e) //Кнопка сохранения параметров ввода данных в ??? (csv)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;

            string FilePath_outputConfig = saveFileDialog2.FileName;
            if (radioButton1.Checked == true) //В случае выбора для базовой точки
            {
                using (StreamWriter export_configs = new StreamWriter(FilePath_outputConfig, true, Encoding.Default))
                {
                    export_configs.WriteLine($"Base-point,{textBox2.Text},{textBox3.Text},{textBox4.Text},{textBox5.Text}");
                    export_configs.Close();
                    export_configs.Dispose();
                }
            }

            if (radioButton2.Checked == true) //В случае выбора для трех точек 6-14, 16-24, 15 (допуск)
            {
                using (StreamWriter export_configs = new StreamWriter(FilePath_outputConfig, true, Encoding.Default))
                {
                    export_configs.WriteLine($"Three-points,{textBox6.Text},{textBox7.Text},{textBox8.Text},{textBox9.Text},{textBox10.Text},{textBox11.Text},{textBox12.Text},{textBox13.Text}," +
                        $"{textBox14.Text},{textBox16.Text},{textBox17.Text},{textBox18.Text},{textBox19.Text},{textBox20.Text},{textBox21.Text},{textBox22.Text},{textBox23.Text}," +
                        $"{textBox24.Text},{textBox15.Text}");
                    export_configs.Close();
                    export_configs.Dispose();
                }
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e) //Для сохранения конфигурации расчета
        {

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e) //Для импорта конфигурации расчета
        {

            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //End?
    }
}
