using System;
using System.IO;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 图像边缘检测
{

    /*
     * 滤波：中值，冒泡排序
     * 
     * 锐化：模板，效果改善
     * 
     * 边缘检测：robert sobel prewitt laplacian
     * 二值化：单阈值
     * 对每个grad进行0-255限幅，而非Abs(),效果改善
     * 
     */



    public partial class Form1 : Form
    {
        private Bitmap image;//原始图像
        private Bitmap image_gray;//原始图像
        private Bitmap image1;//filter,sharpen
        private Bitmap image2;//filter,sharpen

        ////////用于存储边缘检测图像///////////////////
        private Bitmap image_robert;
        private Bitmap image_robert_bool;
        private Bitmap image_sobel;
        private Bitmap image_sobel_bool;
        private Bitmap image_prewitt;
        private Bitmap image_prewitt_bool;
        private Bitmap image_laplacian;
        private Bitmap image_laplacian_bool;
        private Bitmap image_canny ;
        private Bitmap image_canny_bool;

        double[] theta_canny = new double[10000000];
        double[] grad_laplacian = new double[10000000];

        int threshold_edge = 0;//边缘检测二值化阀值

        Boolean new_image_open_flag = true;
        OpenFileDialog of;
        string path;//获取文件路径
        string fileName;//获取文件名

        //byte background_R=255,background_G=255,background_B=255;//white
        byte bgB=255,bgG=255,bgR=255;//gray

        private HiPerfTimer myTimer = new HiPerfTimer();


        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar_fazhi_Scroll(object sender, EventArgs e)
        {
            fazhi.Text = Convert.ToString(trackBar_fazhi.Value);
            threshold_edge = trackBar_fazhi.Value;
        }
        private void enable_buttons()
        {
            button_open.Enabled = true;
            button_filter.Enabled = true;
            button_sharpen.Enabled = true;
            button_undo.Enabled = true;
            button_edge.Enabled = true;
        }
        private void disable_buttons()
        {
            button_open.Enabled = false;
            button_filter.Enabled = false;
            button_sharpen.Enabled = false;
            button_undo.Enabled = false;
            button_edge.Enabled = false;
        }
        private void button_open_Click(object sender, EventArgs e)
        {
            ///////////////////打开文件/////////////////
            groupBox1.Text = "打开文件";
            of = new OpenFileDialog();
            of.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;" +
                "*.tif; *.ico; *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf|" +
                "位图( *.bmp; *.jpg; *.png;...) | *.bmp; *.pcx; *.png; *.jpg; *.gif; *.tif; *.ico|" +
                "矢量图( *.wmf; *.eps; *.emf;...) | *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf"; ;//设置文件类型
            if (of.ShowDialog() == DialogResult.OK)
            {
                disable_buttons();
                path = System.IO.Path.GetDirectoryName(of.FileName);//获取文件路径
                //fileName = System.IO.Path.GetFileName(of.FileName);//获取文件名
                fileName = System.IO.Path.GetFileNameWithoutExtension(of.FileName);//获取文件名 
                
                //显示图像，计算图像大小
                image =new Bitmap(of.FileName);
                of.Dispose();
                pictureBox_Origin.Image = image;
                tab_image.SelectedTab = tab_origin;
                tab_image.Refresh();
                image_dimension.Text = "图像尺寸: " + image.Width + "x" + image.Height; ;
                image_size.Text = "图像大小: " + (image.Width *image.Height*3/1048576.0).ToString("###.##")+"MB" ;

                //显示tab上的文字
                tab_origin.Text = "原图";
                tab_gray.Text = "灰度";
                tab_filter.Text = "滤波";
                tab_sharpen.Text = "锐化";
                tab_robert.Text = "Robert算子";
                tab_sobel.Text = "Sobel算子";
                tab_prewitt.Text = "Prewitt算子";
                tab_laplacian.Text = "Laplacian算子";

                ///////////////灰度处理//////////////////
                myTimer.ClearTimer();
                myTimer.Start();
                groupBox1.Text = "灰度处理中...";
                groupBox1.Refresh();
                int i = 0, j = 0,k;
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
                image1 = image.Clone(rect, image.PixelFormat);//保留原图image
                BitmapData bmpData = image1.LockBits(rect,ImageLockMode.ReadWrite, image1.PixelFormat);
                byte temp = 0;
                unsafe
                {
                    //运用指针来处理图片
                    byte* ptr = (byte*)(bmpData.Scan0);
                    for ( i = 0,k=0; i < bmpData.Height; i++)
                    {
                        for ( j = 0; j < bmpData.Width; j++)
                        {
                            temp = (byte)(0.299 * ptr[2] + 0.587 * ptr[1] + 0.114 * ptr[0]);//灰度化公式，方法大致有三种，这里用的是加权平均法
                            ptr[0] = ptr[1] = ptr[2] = temp;
                            ptr += 3;//这里的4，是指每个像素的字节数
                        }
                        ptr += bmpData.Stride - bmpData.Width * 3;//偏移量
                    }
                }
                image1.UnlockBits(bmpData);
                image_gray = image1.Clone(rect, image1.PixelFormat);//保留灰度图
                
                pictureBox_gray.Image = image1;//灰度图显示在相应Tab中
                //image1 = image.Clone(rect, image.PixelFormat);//image1用于滤波、锐化
                myTimer.Stop();
                tab_gray.Text = myTimer.Duration.ToString("灰度 ####") + "ms";
                groupBox1.Text = "灰度处理完毕";
                groupBox1.Refresh();
                tab_image.SelectedTab = tab_gray;
                tab_image.Refresh();
                ///////////////灰度处理 End //////////////////

                new_image_open_flag = true;
                enable_buttons();
            }
             
        }

        private void button_filter_Click(object sender, EventArgs e)//滤波函数
        {
            disable_buttons();

            groupBox1.Text = "滤波计算...";
            groupBox1.Refresh();
            myTimer.ClearTimer();
            myTimer.Start();
            int i = 0, j = 0,m=0,n=0;
            Rectangle rect1 = new Rectangle(0, 0, image1.Width, image1.Height);
            Rectangle rect2 = new Rectangle(0, 0, image1.Width, image1.Height);
            
            image2= image1.Clone(rect2, image_gray.PixelFormat);
            System.Drawing.Imaging.BitmapData bmpData1, bmpData2;
            unsafe
            {
                bmpData1 = image1.LockBits(rect1, ImageLockMode.ReadWrite, image1.PixelFormat);
                bmpData2 = image2.LockBits(rect2, ImageLockMode.ReadWrite, image2.PixelFormat);
                int sum;
            
                //运用指针来处理图片
                byte* ptr1 = (byte*)(bmpData1.Scan0);
                byte* ptr2 = (byte*)(bmpData2.Scan0);
                
                ptr2 += bmpData2.Stride + 3;//i=1,j=1;
                ptr1 += bmpData2.Stride + 3;//i=1,j=1;

                ////////////均值滤波////////////////////
                if (radio_avr.Checked)
                {
                    for (i = 1; i < bmpData1.Height - 1; i++)
                    {
                        for (j = 1; j < bmpData1.Width - 1; j++)
                        {
                            sum = 0;
                            for (m = -1; m <= 1; m++)
                                for (n = -1; n <= 1; n++)
                                {
                                    sum += ptr1[m * bmpData2.Stride + n * 3];
                                }
                            ptr2[0] = (byte)(sum / 9);
                            ptr2[1] = (byte)(sum / 9);
                            ptr2[2] = (byte)(sum / 9);
                            ptr1 += 3;
                            ptr2 += 3;//这里的3，是指每个像素的字节数

                        }
                        //ptr2 = (byte*)(bmpData2.Scan0) + i * bmpData2.Stride + 3;
                        //ptr1 = (byte*)(bmpData1.Scan0) + i * bmpData1.Stride + 3;
                        ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                        ptr1 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                    }
                }
                ////////////中值滤波////////////////////
                else if (radio_mid.Checked)
                {

                    for (i = 1; i < bmpData1.Height - 1; i++)
                    {
                        for (j = 1; j < bmpData1.Width - 1; j++)
                        {
                            sum = 0;
                            byte[] temp = new byte[9];
                            byte t;
                            int k;
                            for (m = -1, k = 0; m <= 1; m++)
                                for (n = -1; n <= 1; n++, k++)
                                {
                                    temp[k] = ptr1[m * bmpData2.Stride + n * 3];
                                }

                            for (m = 0; m < 9; m++)//冒泡排序
                            {
                                for (n = 0; n < 8 - m; n++)
                                {
                                    if (temp[n] > temp[n + 1])
                                    {
                                        // 交换元素
                                        t = temp[n];
                                        temp[n] = temp[n + 1];
                                        temp[n + 1] = t;
                                    }
                                }
                            }
                            ptr2[0] = temp[4];
                            ptr2[1] = temp[4];
                            ptr2[2] = temp[4];
                            ptr1 += 3;
                            ptr2 += 3;//这里的3，是指每个像素的字节数

                        }
                        ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                        ptr1 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                    }
                }
                ////////////高斯滤波////////////////////
                else if (radio_gauss.Checked)
                {
                    ptr1 = (byte*)(bmpData1.Scan0) + bmpData1.Stride*2 + 6;//i=2,j=2
                    ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride*2 + 6;
                    for (i = 2; i < image1.Height - 2; i++)
                    {
                        for (j = 2; j < image1.Width - 2; j++)
                        {
                            sum = ptr1[-bmpData1.Stride * 2 - 6] * 2 + ptr1[-bmpData1.Stride * 2 - 3] * 4 + ptr1[-bmpData1.Stride * 2] * 5 +
                                ptr1[-bmpData1.Stride * 2 + 3]*4 + ptr1[-bmpData1.Stride * 2 + 6]*2 + ptr1[-bmpData1.Stride - 6]*4 +
                                ptr1[-bmpData1.Stride - 3]*9 + ptr1[-bmpData1.Stride]*12 + ptr1[-bmpData1.Stride + 3]*9 + ptr1[-bmpData1.Stride + 6]*4+
                                ptr1[-6]*5 + ptr1[-3]*12 + ptr1[0]*15 + ptr1[3]*12 + ptr1[6]*5 +ptr1[bmpData1.Stride - 6]*4 +
                                ptr1[bmpData1.Stride - 3]*9 + ptr1[bmpData1.Stride]*12 + ptr1[bmpData1.Stride + 3]*9 + ptr1[bmpData1.Stride + 6]*4+
                                ptr1[bmpData1.Stride * 2 - 6]*2 + ptr1[bmpData1.Stride * 2 - 3]*4 + ptr1[bmpData1.Stride * 2]*5 +
                                ptr1[bmpData1.Stride * 2 + 3]*4 + ptr1[bmpData1.Stride * 2 + 6]*2 ;
                            sum /= 159;
                            ptr2[0] = ptr2[1] = ptr2[2] = (byte)sum;
                            ptr1 += 3;
                            ptr2 += 3;
                        }
                        ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6*2;//偏移量
                        ptr1 += bmpData2.Stride - bmpData2.Width * 3 + 6*2;//偏移量
                    }
                }
                
            }
                 
            image2.UnlockBits(bmpData2);
            image1.UnlockBits(bmpData1);

            image1 = image2.Clone(rect1, image2.PixelFormat);
            pictureBox_filter.Image = image1;//显示滤波之后的图像
            
            myTimer.Stop();
            tab_filter.Text = myTimer.Duration.ToString("滤波 ####") + "ms"; 
            groupBox1.Text = "滤波计算完毕";
            groupBox1.Refresh();
            tab_image.SelectedTab = tab_filter;

            new_image_open_flag = true;
            enable_buttons();
        }

        private void button_sharpen_Click(object sender, EventArgs e)//锐化函数
        {
            disable_buttons();

            groupBox1.Text = "锐化计算中...";
            groupBox1.Refresh();
            myTimer.ClearTimer();
            myTimer.Start();
            int i = 0, j = 0;

            Rectangle rect2 = new Rectangle(0, 0, image1.Width, image1.Height);
            Rectangle rect1 = new Rectangle(0, 0, image1.Width, image1.Height);
            image2 = image1.Clone(rect2, image1.PixelFormat);
            System.Drawing.Imaging.BitmapData bmpData1, bmpData2;
            /*
             
            锐化方法：拉普拉斯锐化
             
            卷积模板：
            
                    |  0,-1, 0|
                 H= | -1, 5,-1|
                    |  0,-1, 0| 
             
             */
            unsafe
            {
                bmpData1 = image1.LockBits(rect1, ImageLockMode.ReadWrite, image1.PixelFormat);
                bmpData2 = image2.LockBits(rect2, ImageLockMode.ReadWrite, image2.PixelFormat);
                int sum;

                //运用指针来处理图片
                byte* ptr1 = (byte*)(bmpData1.Scan0) + bmpData1.Stride + 3;
                byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3; 


                for (i = 1; i < image1.Height - 1; i++)
                {
                    for (j = 1; j < image1.Width - 1; j++)
                    {

                        //sum = (int)(5*ptr1[0] - ptr1[-3]-ptr1[3] - ptr1[-bmpData2.Stride]-ptr1[bmpData2.Stride]);
                        //if (sum > 255) sum = 255;
                        //if (sum < 0) sum = 0;
                        sum = (int)(4*ptr1[0] - ptr1[-3]-ptr1[3] - ptr1[-bmpData2.Stride]-ptr1[bmpData2.Stride]);
                        if (Math.Abs(sum) > 50)
                            sum += ptr1[0];
                        else
                            sum = ptr1[0];
                        if (sum > 255) sum = 255;
                        if (sum < 0) sum = 0;
                        ptr2[0] = (byte)sum;
                        ptr2[1] = (byte)sum;
                        ptr2[2] = (byte)sum;

                        ptr2 += 3;
                        ptr1 += 3;
                    }
                    ptr2 += bmpData2.Stride - bmpData2.Width * 3+6;//偏移量
                    ptr1 += bmpData2.Stride - bmpData2.Width * 3+6;//偏移量
                }
            }
            image2.UnlockBits(bmpData2);
            image1.UnlockBits(bmpData1);
            image1 = image2.Clone(rect2, image1.PixelFormat);
            
            pictureBox3.Image = image1;//显示锐化后图像
            myTimer.Stop();
            tab_sharpen.Text = myTimer.Duration.ToString("锐化 ####") + "ms"; 
            groupBox1.Text = "锐化完毕";
            groupBox1.Refresh();
            tab_image.SelectedTab = tab_sharpen;
            tab_image.Refresh();

            new_image_open_flag = true;
            enable_buttons();
        }

        //////////////////非极大值抑制中的寻找最大值//////////////////
        unsafe private Boolean is_maximum(int theta, byte* bitmap, int stride)
        {
            byte temp1 = 0, temp2 = 0;
            switch (theta)
            {
                case 0:
                case 4:
                case 8:
                    temp1 = bitmap[-3];
                    temp2 = bitmap[3];
                    break;
                case 1:
                case 5:
                    temp1 = bitmap[-stride + 3];
                    temp2 = bitmap[stride - 3];
                    break;
                case 2:
                case 6:
                    temp1 = bitmap[-stride];
                    temp2 = bitmap[stride];
                    break;
                case 3:
                case 7:
                    temp1 = bitmap[-stride - 3];
                    temp2 = bitmap[stride + 3];
                    break;
            }
            if (bitmap[0] < temp1 && bitmap[0] < temp2)
                return true;
            return false;
        }

        private void button_edge1_Click(object sender, EventArgs e)//边缘检测主要函数
        {
            disable_buttons();
            button_save.Enabled = false;

            groupBox1.Text = "开始进行边缘检测";
            groupBox1.Refresh();
            myTimer.ClearTimer();
            myTimer.Start();

            long i = 0, j = 0, k = 0;
            double gradX, gradY, grad;//梯度值

            Rectangle rect = new Rectangle(0, 0, image1.Width, image1.Height);
            
            BitmapData bmpData1 = image1.LockBits(rect,ImageLockMode.ReadWrite, image1.PixelFormat);
            BitmapData bmpData2;

            image2 = image1.Clone(rect, image1.PixelFormat);
            System.Drawing.Imaging.BitmapData bmpData = image2.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, image2.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int graybBytes = image2.Width * image2.Height;
            int rgbBytes = graybBytes * 3;
            int width = image2.Width, height = image2.Height;

            groupBox1.Text = "Robert算子计算中...";
            groupBox1.Refresh();

            ///////////////////////////////robert算子//////////////////////////////////////
            /*
            
            卷积模板：
            
             Gx=| 1, 0|
                | 0 -1|
             
             Gy=|  0, 1|
                | -1, 0|
             
             G[f(x,y)]=sqrt(Gx*Gx+Gy*Gy)
             
             */

            ////卷积运算////
            

            if (new_image_open_flag == true)
            {
                image_robert = image1.Clone(rect, image1.PixelFormat);
                bmpData2 = image_robert.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                unsafe
                {
                    byte* ptr1 = (byte*)(bmpData1.Scan0);
                    byte* ptr2 = (byte*)(bmpData2.Scan0);
                    k = 0;
                    for (i = 0; i < image1.Height - 1; i++)
                    {
                        for (j = 0; j < image1.Width - 1; j++,k++)
                        {
                            gradX = ptr1[0] - ptr1[bmpData1.Stride + 3];
                            gradY = ptr1[3] - ptr1[bmpData1.Stride];
                            grad = Math.Abs(gradX) + Math.Abs(gradY);
                            grad = 255 - grad;
            
                            ptr2[0] = ptr2[1] = ptr2[2] = (byte)grad;
                            ptr1 += 3;
                            ptr2 += 3;
                        }
                        ptr2 += bmpData2.Stride - bmpData2.Width * 3+3;//偏移量
                        ptr1 += bmpData2.Stride - bmpData2.Width * 3+3;//偏移量
                        k += 1;
                    }
                }
                image_robert.UnlockBits(bmpData2);
            }
            ////卷积运算 End ////


            ////图像二值化////
            groupBox1.Text = "Robert算子二值化处理...";
            groupBox1.Refresh();
            unsafe
            {
                image_robert_bool = image1.Clone(rect, image1.PixelFormat);
                BitmapData bmpData3 = image_robert_bool.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                bmpData2 = image_robert.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3;
                byte* ptr3 = (byte*)(bmpData3.Scan0) + bmpData1.Stride + 3;
                k = bmpData2.Stride + 1;

                for (i = 1; i < image1.Height-1; i++)
                {
                    for (j = 1; j < image1.Width-1; j++,k++)
                    {

                        if (ptr2[0] < threshold_edge)//判断梯度值是否小于阈值，小于则是边缘
                        {
                                ptr3[0] = 0;
                                ptr3[1] = 0;
                                ptr3[2] = 0;
                        }
                        else
                        {
                            ptr3[0] = bgB;
                            ptr3[1] = bgG;
                            ptr3[2] = bgR;
                        }
                        ptr3 += 3;
                        ptr2 += 3;
                    }
                    ptr2 += bmpData2.Stride - bmpData2.Width * 3+6;//偏移量
                    ptr3 += bmpData3.Stride - bmpData3.Width * 3+6;//偏移量
                    k += 2;

                }
                image_robert_bool.UnlockBits(bmpData3);
                image_robert.UnlockBits(bmpData2);
            }
            
            if (checkBox_Boolean.Checked)
               pictureBox_robert.Image = image_robert_bool;//显示边缘检测图像
            else////保留原始边缘图////
               pictureBox_robert.Image = image_robert;//显示边缘检测图像
 
            myTimer.Stop();
            tab_robert.Text = myTimer.Duration.ToString("Robert算子 ####") + "ms";
            tab_edge.SelectedTab = tab_robert;
            tab_edge.Refresh();
            ///////////////////////////////robert算子 End //////////////////////////////////////



            ///////////////////////////////sobel算子////////////////////////////////////////////
            /*
            
            卷积模板：
            
                | -1,0,1|
             Gx=| -2,0,2|
                | -1,0,1|
             
                |  1, 2, 1|
             Gy=|  0, 0, 0|
                | -1,-2,-1|
             
             G[f(x,y)]=sqrt(Gx*Gx+Gy*Gy)
             
             */
            groupBox1.Text = "Sobel算子计算中...";
            groupBox1.Refresh();
            myTimer.ClearTimer();
            myTimer.Start();


            ////卷积运算////
           if (new_image_open_flag == true)
            {
                image_sobel = image1.Clone(rect, image1.PixelFormat);
                bmpData2 = image_sobel.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                unsafe
                {
                    byte* ptr1 = (byte*)(bmpData1.Scan0) + bmpData1.Stride + 3;//i=1,j=1
                    byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3;
                    k = bmpData2.Stride + 1;
                    for (i = 1; i < image1.Height - 1; i++)
                    {
                        for (j = 1; j < image1.Width - 1; j++,k++)
                        {
                            gradX = ptr1[-bmpData1.Stride + 3] + 2 * ptr1[3]+ ptr1[bmpData1.Stride + 3] 
                                     - ptr1[-bmpData1.Stride - 3]- 2 * ptr1[-3] - ptr1[bmpData1.Stride - 3];
                            gradY = ptr1[-bmpData1.Stride - 3] + 2 * ptr1[-bmpData1.Stride] + ptr1[-bmpData1.Stride + 3]
                                     - ptr1[bmpData1.Stride - 3] - 2 * ptr1[bmpData1.Stride] - ptr1[bmpData1.Stride + 3];
                            grad = Math.Abs(gradX) + Math.Abs(gradY);
                            grad /= 4;
                            grad = 255 - grad;
                            ptr2[0] = ptr2[1] = ptr2[2] = (byte)grad;
                            ptr1 += 3;
                            ptr2 += 3;
                        }
                        ptr2 += bmpData2.Stride - bmpData2.Width * 3+6;//偏移量
                        ptr1 += bmpData2.Stride - bmpData2.Width * 3+6;//偏移量
                        k += 2;
                    }
                }
                image_sobel.UnlockBits(bmpData2);
            }
           ////卷积运算 End ////


           ////图像二值化////
            groupBox1.Text = "Sobel算子二值化处理...";
            groupBox1.Refresh();
            unsafe
            {
                image_sobel_bool = image1.Clone(rect, image1.PixelFormat);
                BitmapData bmpData3 = image_sobel_bool.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                bmpData2 = image_sobel.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3;
                byte* ptr3 = (byte*)(bmpData3.Scan0) + bmpData1.Stride + 3;
                k = bmpData2.Stride + 1;

                for (i = 1; i < image1.Height - 1; i++)
                {
                    for (j = 1; j < image1.Width - 1; j++, k++)
                    {

                        if (ptr2[0] < threshold_edge)//判断梯度值是否小于阈值，小于则是边缘
                        {
                                ptr3[0] = 0;
                                ptr3[1] = 0;
                                ptr3[2] = 0;
                        }
                        else
                        {
                            ptr3[0] = bgB;
                            ptr3[1] = bgG;
                            ptr3[2] = bgR;
                        }
                        ptr3 += 3;
                        ptr2 += 3;
                    }
                    ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                    ptr3 += bmpData3.Stride - bmpData3.Width * 3 + 6;//偏移量
                    k += 6;

                }
                image_sobel_bool.UnlockBits(bmpData3);
                image_sobel.UnlockBits(bmpData2);
            }
                
             if (checkBox_Boolean.Checked)
               pictureBox_sobel.Image = image_sobel_bool;//显示边缘检测图像
            else////保留原始边缘图////
               pictureBox_sobel.Image = image_sobel;//显示边缘检测图像

            myTimer.Stop();
            tab_sobel.Text = myTimer.Duration.ToString("Sobel算子 ####") + "ms";
            tab_edge.SelectedTab = tab_sobel;
            tab_edge.Refresh();
            ///////////////////////////////sobel算子 End //////////////////////////////////////


            ///////////////////////////////prewitt算子/////////////////////////////////////////
            /*
            
            卷积模板：
            
                | -1,0,1|
             Gx=| -1,0,1|
                | -1,0,1|
             
                |  1, 1, 1|
             Gy=|  0, 0, 0|
                | -1,-1,-1|
             
             G[f(x,y)]=sqrt(Gx*Gx+Gy*Gy)
             
             */
            groupBox1.Text = "Prewitt算子计算中...";
            groupBox1.Refresh();
            myTimer.ClearTimer();
            myTimer.Start();

            ////卷积运算////
            if (new_image_open_flag == true)
            {
                image_prewitt = image1.Clone(rect, image1.PixelFormat);
                bmpData2 = image_prewitt.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                unsafe
                {
                    byte* ptr1 = (byte*)(bmpData1.Scan0) + bmpData1.Stride + 3;//i=1,j=1
                    byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3;
                    k = bmpData2.Stride + 1;
                    for (i = 1; i < image1.Height - 1; i++)
                    {
                        for (j = 1; j < image1.Width - 1; j++,k++)
                        {
                            gradX = ptr1[-bmpData1.Stride + 3] +  ptr1[3] + ptr1[bmpData1.Stride + 3]
                                     - ptr1[-bmpData1.Stride - 3] - ptr1[-3] - ptr1[bmpData1.Stride - 3];
                            gradY = ptr1[-bmpData1.Stride - 3] + ptr1[-bmpData1.Stride] + ptr1[-bmpData1.Stride + 3]
                                     - ptr1[bmpData1.Stride - 3] - ptr1[bmpData1.Stride] - ptr1[bmpData1.Stride + 3];
                            grad = Math.Abs(gradX) + Math.Abs(gradY);
                            grad /= 3;
                            grad = 255 - grad;
                            ptr2[0] = ptr2[1] = ptr2[2] = (byte)grad;
                            ptr1 += 3;
                            ptr2 += 3;
                        }
                        ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                        ptr1 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                        k += 2;
                    }
                }
                image_prewitt.UnlockBits(bmpData2);
            }
            ////卷积运算 End ////


            ////图像二值化////
            groupBox1.Text = "Prewiit算子二值化处理...";
            groupBox1.Refresh();
            unsafe
            {
                image_prewitt_bool = image1.Clone(rect, image1.PixelFormat);
                BitmapData bmpData3 = image_prewitt_bool.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                bmpData2 = image_prewitt.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3;
                byte* ptr3 = (byte*)(bmpData3.Scan0) + bmpData1.Stride + 3;
                k = bmpData2.Stride + 1;

                for (i = 1; i < image1.Height - 1; i++)
                {
                    for (j = 1; j < image1.Width - 1; j++, k++)
                    {

                        if (ptr2[0] < threshold_edge)//判断梯度值是否小于阈值，小于则是边缘
                        {
                                ptr3[0] = 0;
                                ptr3[1] = 0;
                                ptr3[2] = 0;
                        }
                        else
                        {
                            ptr3[0] = bgB;
                            ptr3[1] = bgG;
                            ptr3[2] = bgR;
                        }
                        ptr3 += 3;
                        ptr2 += 3;
                    }
                    ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                    ptr3 += bmpData3.Stride - bmpData3.Width * 3 + 6;//偏移量
                    k += 2;

                }
                image_prewitt_bool.UnlockBits(bmpData3);
                image_prewitt.UnlockBits(bmpData2);
            }
                
            if (checkBox_Boolean.Checked)
               pictureBox_prewitt.Image = image_prewitt_bool;//显示边缘检测图像
            else////保留原始边缘图////
               pictureBox_prewitt.Image = image_prewitt;//显示边缘检测图像

            myTimer.Stop();
            tab_prewitt.Text = myTimer.Duration.ToString("Prewiit算子 ####") + "ms";
            tab_edge.SelectedTab = tab_prewitt;
            tab_edge.Refresh();
            ///////////////////////////////prewitt算子 End //////////////////////////////////////

            ///////////////////////////////laplacian算子/////////////////////////////////////////
            /*
            
            卷积模板：
            
                |  0,-1, 0|
             H= | -1, 4,-1|
                |  0,-1, 0|
             
             */
            groupBox1.Text = "Laplacian算子计算中...";
            groupBox1.Refresh();
            myTimer.ClearTimer();
            myTimer.Start();

            ////卷积运算////
            if (new_image_open_flag == true)
            {
                image_laplacian = image1.Clone(rect, image1.PixelFormat);
                bmpData2 = image_laplacian.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                unsafe
                {
                    byte* ptr1 = (byte*)(bmpData1.Scan0) + bmpData1.Stride + 3;//i=1,j=1
                    byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3;
                    k = bmpData2.Stride + 1;
                    for (i = 1; i < image1.Height - 1; i++)
                    {
                        for (j = 1; j < image1.Width - 1; j++,k++)
                        {
                            //grad =4.0 * ptr1[0]- ptr1[-bmpData1.Stride]- ptr1[-3] - ptr1[3] - ptr1[bmpData1.Stride];
                            /*
                            grad = 4 * ptr1[0] + ptr1[-bmpData1.Stride] + ptr1[-3] + ptr1[3]
                                            + ptr1[bmpData1.Stride] - 2 * ptr1[-bmpData1.Stride - 3] - 2 * ptr1[-bmpData1.Stride + 3]
                                                    - 2 * ptr1[bmpData1.Stride - 3] - 2 * ptr1[bmpData1.Stride + 3];
                             * */
                            grad = 8 * ptr1[0] - ptr1[-bmpData1.Stride] - ptr1[-3] - ptr1[3]
                                            - ptr1[bmpData1.Stride] - ptr1[-bmpData1.Stride - 3] - ptr1[-bmpData1.Stride + 3]
                                                    - ptr1[bmpData1.Stride - 3] - ptr1[bmpData1.Stride + 3];
                            grad_laplacian[k] = grad;
                            /*if (grad > 255) grad = 255;
                            if (grad < 0) grad = 0;
                            grad = 255 - grad;*/
                            if (grad > 0)
                            {
                                ptr2[0] = 255;
                                ptr2[1] = 0;
                                ptr2[2] = 0;
                            }
                            else if (grad < 0)
                            {
                                ptr2[0] = 0;
                                ptr2[1] = 0;
                                ptr2[2] = 255;
                            }
                            else
                            {
                                ptr2[0] = 255;
                                ptr2[1] = 255;
                                ptr2[2] = 255;
                            }
                            ptr1 += 3;
                            ptr2 += 3;
                        }
                        ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                        ptr1 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                        k += 2;
                    }
                }
                image_laplacian.UnlockBits(bmpData2);
            }
            ////卷积运算 End ////

            ////图像二值化////
            groupBox1.Text = "Laplacian算子二值化处理...";
            groupBox1.Refresh();
            unsafe
            {
                image_laplacian_bool = image1.Clone(rect, image1.PixelFormat);
                BitmapData bmpData3 = image_laplacian_bool.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                bmpData2 = image_laplacian.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3;
                byte* ptr3 = (byte*)(bmpData3.Scan0) + bmpData1.Stride + 3;
                k = bmpData2.Stride + 1;
                int laplacian_threshold = 200;
                for (i = 1; i < image1.Height-1; i++)
                {
                    for (j = 1; j < image1.Width - 1; j++, k++)
                    {
                        /*
                         
                        判断二阶导数是否过零点，判断条件：
                        1、(x,y)相邻两点(x-1,y)，(x+1,y)乘积是否小于零
                        2、(x,y)与(x-1,y)乘积是否小于零
                        3、(x,y)与(x+1,y)乘积是否小于零
                        4、y方向同x 1、2、3点
                        
                        */
                        if (((grad_laplacian[k - 1] * grad_laplacian[k + 1] < 0) && (Math.Abs(grad_laplacian[k - 1] * grad_laplacian[k + 1]) > laplacian_threshold))
                            || ((grad_laplacian[k] * grad_laplacian[k + 1] < 0) && (Math.Abs(grad_laplacian[k] * grad_laplacian[k + 1]) > laplacian_threshold))
                            || ((grad_laplacian[k - 1] * grad_laplacian[k] < 0) && (Math.Abs(grad_laplacian[k - 1] * grad_laplacian[k]) > laplacian_threshold))
                            || ((grad_laplacian[k + bmpData2.Stride] * grad_laplacian[k - bmpData2.Stride] < 0) && (Math.Abs(grad_laplacian[k - bmpData2.Stride] * grad_laplacian[k + bmpData2.Stride]) > laplacian_threshold))
                            || ((grad_laplacian[k] * grad_laplacian[k - bmpData2.Stride] < 0) && (Math.Abs(grad_laplacian[k - bmpData2.Stride] * grad_laplacian[k]) > laplacian_threshold))
                            || ((grad_laplacian[k + bmpData2.Stride] * grad_laplacian[k] < 0) && (Math.Abs(grad_laplacian[k] * grad_laplacian[k + bmpData2.Stride]) > laplacian_threshold)))
                        {
                            ptr3[0] = 0;
                            ptr3[1] = 0;
                            ptr3[2] = 0;
                        }
                        else
                        {
                            ptr3[0] = bgB;
                            ptr3[1] = bgG;
                            ptr3[2] = bgR;
                        }
                        ptr3 += 3;
                        ptr2 += 3;
                    }
                    ptr2 += bmpData2.Stride - bmpData2.Width * 3+6;//偏移量
                    ptr3 += bmpData3.Stride - bmpData3.Width * 3+6;//偏移量
                    k += 2;
                }
                image_laplacian_bool.UnlockBits(bmpData3);
                image_laplacian.UnlockBits(bmpData2);
            }
                
            if (checkBox_Boolean.Checked)
                pictureBox_laplacian.Image = image_laplacian_bool;//显示边缘检测图像
            else
                pictureBox_laplacian.Image = image_laplacian;//显示边缘检测图像


            myTimer.Stop();
            tab_laplacian.Text = myTimer.Duration.ToString("Laplacian算子 ####") + "ms";
            tab_edge.SelectedTab = tab_laplacian;
            tab_edge.Refresh();
            ///////////////////////////////laplacian算子 End //////////////////////////////////////

            ///////////////////////////////Canny算子////////////////////////////////////////////
            /*
            
            卷积模板：
            
                | -1,0,1|
             Gx=| -2,0,2|
                | -1,0,1|
             
                |  1, 2, 1|
             Gy=|  0, 0, 0|
                | -1,-2,-1|
             
             G[f(x,y)]=sqrt(Gx*Gx+Gy*Gy)
             
             */
            groupBox1.Text = "Canny算子计算中...";
            groupBox1.Refresh();
            myTimer.ClearTimer();
            myTimer.Start();


            ////Canny算子第一步：高斯模糊运算////
            if (new_image_open_flag == true)
            {
                image_canny = image1.Clone(rect, image1.PixelFormat);
                bmpData2 = image_canny.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                unsafe
                {
                    byte* ptr1 = (byte*)(bmpData1.Scan0) + bmpData1.Stride*2 + 6;//i=2,j=2
                    byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride*2 + 6;
                    k = bmpData2.Stride*2 + 2;
                    for (i = 2; i < image1.Height - 2; i++)
                    {
                        for (j = 2; j < image1.Width - 2; j++, k++)
                        {
                            grad = ptr1[-bmpData1.Stride * 2 - 6]*2 + ptr1[-bmpData1.Stride * 2 - 3]*4 + ptr1[-bmpData1.Stride * 2]*5 +
                                ptr1[-bmpData1.Stride * 2 + 3]*4 + ptr1[-bmpData1.Stride * 2 + 6]*2 + ptr1[-bmpData1.Stride - 6]*4 +
                                ptr1[-bmpData1.Stride - 3]*9 + ptr1[-bmpData1.Stride]*12 + ptr1[-bmpData1.Stride + 3]*9 + ptr1[-bmpData1.Stride + 6]*4+
                                ptr1[-6]*5 + ptr1[-3]*12 + ptr1[0]*15 + ptr1[3]*12 + ptr1[6]*5 +ptr1[bmpData1.Stride - 6]*4 +
                                ptr1[bmpData1.Stride - 3]*9 + ptr1[bmpData1.Stride]*12 + ptr1[bmpData1.Stride + 3]*9 + ptr1[bmpData1.Stride + 6]*4+
                                ptr1[bmpData1.Stride * 2 - 6]*2 + ptr1[bmpData1.Stride * 2 - 3]*4 + ptr1[bmpData1.Stride * 2]*5 +
                                ptr1[bmpData1.Stride * 2 + 3]*4 + ptr1[bmpData1.Stride * 2 + 6]*2 ;
                            grad /= 159;
                            ptr2[0] = ptr2[1] = ptr2[2] = (byte)grad;
                            ptr1 += 3;
                            ptr2 += 3;
                        }
                        ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6*2;//偏移量
                        ptr1 += bmpData2.Stride - bmpData2.Width * 3 + 6*2;//偏移量
                        k += 4;
                    }
            ////高斯模糊运算 End ////

            ////Canny算子第二步：使用Sobel算子计算梯度值////
 
                ptr1 = (byte*)(bmpData1.Scan0) + bmpData1.Stride + 3;//i=1,j=1
                ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3;
                k = bmpData2.Stride + 1;
                for (i = 1; i < image1.Height - 1; i++)
                {
                    for (j = 1; j < image1.Width - 1; j++, k++)
                    {
                        gradX = ptr1[0] - ptr1[bmpData1.Stride + 3];
                        gradY = ptr1[3] - ptr1[bmpData1.Stride];
                        grad = Math.Abs(gradX) + Math.Abs(gradY);
                        //grad /= 3;
                        theta_canny[k] = (Math.Atan2(gradY, gradX) * 180 / 3.14159 + 180 + 22.5) / 45;
                        grad = 255 - grad;
                        ptr2[0] = ptr2[1] = ptr2[2] = (byte)grad;
                        ptr1 += 3;
                        ptr2 += 3;
                    }
                    ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                    ptr1 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                    k += 2;
                }
            }
            image_canny.UnlockBits(bmpData2);
            }
            ////卷积运算 End ////

            ////Canny算子第三步：非极大值抑制////
            groupBox1.Text = "Canny算子二值化处理...";
            groupBox1.Refresh();
            unsafe
            {
                image_canny_bool = image1.Clone(rect, image1.PixelFormat);
                BitmapData bmpData3 = image_canny_bool.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                bmpData2 = image_canny.LockBits(rect, ImageLockMode.ReadWrite, image1.PixelFormat);
                byte* ptr2 = (byte*)(bmpData2.Scan0) + bmpData1.Stride + 3;
                byte* ptr3 = (byte*)(bmpData3.Scan0) + bmpData1.Stride + 3;
                k = bmpData2.Stride + 1;

                for (i = 1; i < image1.Height - 1; i++)
                {
                    for (j = 1; j < image1.Width - 1; j++, k++)
                    {

                        if (ptr2[0] < threshold_edge)
                        {
                            if (is_maximum((int)theta_canny[k], ptr2, bmpData2.Stride))//非极大值抑制
                            {
                                ptr3[0] = 0;
                                ptr3[1] = 0;
                                ptr3[2] = 0;
                            }
                            else
                            {
                                ptr3[0] = bgB;
                                ptr3[1] = bgG;
                                ptr3[2] = bgR;
                            }
                        }
                        else
                        {
                            ptr3[0] = bgB;
                            ptr3[1] = bgG;
                            ptr3[2] = bgR;
                        }
                        ptr3 += 3;
                        ptr2 += 3;
                    }
                    ptr2 += bmpData2.Stride - bmpData2.Width * 3 + 6;//偏移量
                    ptr3 += bmpData3.Stride - bmpData3.Width * 3 + 6;//偏移量
                    k += 6;

                }
                image_canny_bool.UnlockBits(bmpData3);
                image_canny.UnlockBits(bmpData2);
            }

            if (checkBox_Boolean.Checked)
                pictureBox_canny.Image = image_canny_bool;//显示边缘检测图像
            else////保留原始边缘图////
                pictureBox_canny.Image = image_canny;//显示边缘检测图像

            myTimer.Stop();
            tab_canny.Text = myTimer.Duration.ToString("Canny算子 ####") + "ms";
            tab_edge.SelectedTab = tab_canny;
            tab_edge.Refresh();
            ///////////////////////////////canny算子 End //////////////////////////////////////

            image1.UnlockBits(bmpData1);
            groupBox1.Text = "所有算子检测完毕";
            groupBox1.Refresh();
            new_image_open_flag = false;

            enable_buttons();
            button_save.Enabled = true;
        }



        private void button_Undo_Click(object sender, EventArgs e)//撤销滤波、锐化效果
        {
            disable_buttons();

            groupBox1.Text = "撤销滤波与锐化中...";
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            image1 = image_gray.Clone(rect, image.PixelFormat);//保留原图image

            
            pictureBox_gray.Image = image1;
            pictureBox_filter.Image = image1;
            pictureBox3.Image = image1;
            groupBox1.Text = "原图效果";
            tab_origin.Text = "原图";
            //tab_gray.Text = "灰度";
            tab_filter.Text = "滤波";
            tab_sharpen.Text = "锐化";
            tab_robert.Text = "Robert算子";
            tab_sobel.Text = "Sobel算子";
            tab_prewitt.Text = "Prewitt算子";
            tab_laplacian.Text = "Laplacian算子";
            new_image_open_flag = true;

            tab_image.SelectedTab = tab_gray;
            tab_image.Refresh();

            enable_buttons();
        }

        private void Form1_Load(object sender, EventArgs e)//初始化
        {
            
            trackBar_fazhi.Value = 225;
            threshold_edge = trackBar_fazhi.Value;
            fazhi.Text = Convert.ToString(trackBar_fazhi.Value);
            comboBox_save.SelectedItem = "JPG";
            button_filter.Enabled = false;
            button_sharpen.Enabled = false;
            button_undo.Enabled = false;
            button_edge.Enabled = false;
            button_save.Enabled = false;
            groupBox1.Text = "初始化完毕";
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            disable_buttons();
            button_save.Enabled = false;

            groupBox1.Text = "保存图像中...";
            groupBox1.Refresh();
            
            string savePath = path + "\\edge\\";
            if (!File.Exists(savePath))
            {
                System.IO.Directory.CreateDirectory(savePath);
            }
            ImageFormat format= ImageFormat.Jpeg;
            string postfix = ".jpg";
            if (comboBox_save.SelectedItem=="JPG")
            {
                format = ImageFormat.Jpeg;
                postfix = ".jpg";
            }
            else if (comboBox_save.SelectedItem == "BMP")
            {
                format = ImageFormat.Bmp;
                postfix = ".bmp";
            }
            else if (comboBox_save.SelectedItem == "PNG")
            {
                format = ImageFormat.Png;
                 postfix = ".png";
            }

            image1.Save(savePath + fileName + "_edge" + postfix, format);
            image_robert.Save(savePath + fileName + "_robert"+postfix , format);
            image_robert_bool.Save(savePath + fileName + "_robert_bool" + postfix, format);
            image_sobel.Save(savePath + fileName + "_sobel" + postfix, format);
            image_sobel_bool.Save(savePath + fileName + "_sobel_bool" + postfix, format);
            image_prewitt.Save(savePath + fileName + "_prewitt" + postfix, format);
            image_prewitt_bool.Save(savePath + fileName + "_prewitt_bool" + postfix, format);
            image_laplacian.Save(savePath + fileName + "_laplacian" + postfix, format);
            image_laplacian_bool.Save(savePath + fileName + "_laplacian_bool" + postfix, format);
            image_canny.Save(savePath + fileName + "_canny" + postfix, format);
            image_canny_bool.Save(savePath + fileName + "_canny_bool" + postfix, format);

            groupBox1.Text = "图像保存完毕";
            groupBox1.Refresh();

            enable_buttons();
            button_save.Enabled = true;
        }

        private void radio_mid_Click(object sender, EventArgs e)
        {
            radio_avr.Checked = false;
            radio_gauss.Checked = false;
            radio_mid.Checked = true;
        }

        private void radio_avr_Click(object sender, EventArgs e)
        {
            radio_avr.Checked = true;
            radio_gauss.Checked = false;
            radio_mid.Checked = false;
        }

        private void radio_gauss_Click(object sender, EventArgs e)
        {
            radio_avr.Checked = false;
            radio_gauss.Checked = true;
            radio_mid.Checked = false;
        }

        private void comboBox_save_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
