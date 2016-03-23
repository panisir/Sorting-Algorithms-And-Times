using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        

        Double[] sayilar;
        Double[] Dizi;
        public Form1()
        {
            InitializeComponent();
           
        }
        
        //dizimizi global tanımlıyoruz
        /**---------------------------MERGE-------------------------------**/
        static void MergeYap(Double[] numbers, int left, int mid, int right)
        {

            Double[] temp = new Double[numbers.Length];
            
            
            int i, left_end, num_elements, tmp_pos;//merge sort iki fonx.'dan oluşuyor. RecursiveMerge bu 
                                                    //bu fonx çağıracak

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                  temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        
        }

        static void MergeSort_Recursive(Double[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort_Recursive(numbers, left, mid);
                MergeSort_Recursive(numbers, (mid + 1), right);

                MergeYap(numbers, left, (mid + 1), right);
            }
        }
        /**--------------------------MERGE----------------------------**/



        /**---------------------Quick------------------------------**/
        static void QuickSort(Double[] x, int first, int last)
        {
            int pivot; int j; Double temp; 
                int i;
            
            if (first < last)
            {
                pivot = first;
                i = first;
                j = last;

                while (i < j)
                {
                    while (x[i] <= x[pivot] && i < last)
                        i++;
                    while (x[j] > x[pivot])
                        j--;
                    if (i < j)
                    {
                        temp = x[i];
                        x[i] = x[j];
                        x[j] = temp;
                    }
                }

                temp = x[pivot];
                x[pivot] = x[j];
                x[j] = temp;
                QuickSort(x, first, j - 1);
                QuickSort(x, j + 1, last);

            }
        }
        /**-------------------------Quick----------------------**/
        
        private void label1_Click(object sender, EventArgs e)//siralama zamani
        {

        }
        void degerata()
        {
            sayilar = new double[Dizi.Length];
            for (int i = 0; i < Dizi.Length; i++)
            {
                sayilar[i] = Dizi[i];
            }
        }

        private void button1_Click(object sender, EventArgs e)//sayi üret
        {
            
            Dizi=new double[(int)numeric1.Value];
            
            Stopwatch sw = new Stopwatch();
            
            int i, k;
            Random rnd = new Random();
            sw.Start();
            listBox1.Items.Clear();
            for (i = 0; i < Dizi.Length; i++)
            {
                k = rnd.Next(1, 100);
                Dizi[i] = k;
            }
            sw.Stop();
            string runningTime = sw.Elapsed.ToString();
            label3.Text = runningTime;

           
            
           
        }

        private void button2_Click(object sender, EventArgs e)//selection sort
        {
            int i;
            int j;
            Double tasinan;
            //Double[] sayilar = new double[(int)numeric1.Value];
            degerata();
            Stopwatch sw = new Stopwatch();

            listBox2.Items.Clear();
            sw.Start();
            for (i = 1; i < sayilar.Length; i++)
            {

                tasinan = sayilar[i];
                j = i;
                while (j > 0 && sayilar[j - 1] > tasinan)
                {
                    sayilar[j] = sayilar[j - 1];
                    j--;
                }
                sayilar[j] = tasinan;
            }
            sw.Stop();
            string runningTime = sw.Elapsed.ToString();
            label4.Text = runningTime;
        }
            
        private void button3_Click(object sender, EventArgs e)//quick sort click
                    {
                        Stopwatch sw = new Stopwatch();
                        listBox2.Items.Clear();
                        degerata();
                        sw.Start();
                        QuickSort(sayilar, 0, sayilar.Length - 1);
                        sw.Stop();
                        string runningTime = sw.Elapsed.ToString();
                        label6.Text = runningTime;
                        
                    }

        

        private void button4_Click(object sender, EventArgs e)//merge sort Click
        {
            Stopwatch sw = new Stopwatch();
            listBox2.Items.Clear();
            degerata();
            sw.Start();
            MergeSort_Recursive(sayilar, 0, sayilar.Length-1);
            sw.Stop();
            string runningTime = sw.Elapsed.ToString();
            label8.Text = runningTime;
        }

        private void button5_Click(object sender, EventArgs e)//yazdir_click
        {
            int i;
            for (i = 0; i < sayilar.Length; i++)
            {
                listBox2.Items.Add(sayilar[i].ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)//random üretme zamani
        {

        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//random üretilen sayilar yazilir
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)//siralanmis sayilar yazilir
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)// random Sayilari listbox 1 e yazdir
        {
            int i;
            for (i = 0; i < Dizi.Length; i++)
            {
                listBox1.Items.Add(Dizi[i].ToString());
            }
        }
    }
}
