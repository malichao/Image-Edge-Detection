# Image Edge Detection
This project is my further study for image edge dection algorithm from [Building a Race Car project](http://lichaoma.com/2015/11/17/self-balancing-smart-car-based-on-freescale-mc9s12x128/).In this project,all the classical image detection algorithms are evaluated,namely Robert,Sobel,Prewiit,Laplacian,and Canny algorithm.Three filters are vailable to reduce the image noise,namely average filter,median value filter,and Gaussian filter.You can also sharpen,undo,binarize,and save the image.  

Program snapshot.It's currently in Chinese but I'll translate the program soon.  
![alt tag](https://github.com/malichao/Image_Edge_Detection/blob/master/snapshot/software.jpg)  

And here are some of the test results.  
**Sobel Algorithm,with Gaussian white noise**
![alt tag](https://github.com/malichao/Image_Edge_Detection/blob/master/snapshot/test4_高斯噪声1.jpg)  
![alt tag](https://github.com/malichao/Image_Edge_Detection/blob/master/snapshot/edge/test4_高斯噪声1_sobel_bool.jpg)   

**Canny Algorithm**
![alt tag](https://github.com/malichao/Image_Edge_Detection/blob/master/snapshot/green-train-4001.jpg)  
![alt tag](https://github.com/malichao/Image_Edge_Detection/blob/master/snapshot/edge/green-train-4001_canny.jpg)  

**Prewitt Algorithm**
![alt tag](https://github.com/malichao/Image_Edge_Detection/blob/master/snapshot/07.jpg)  
![alt tag](https://github.com/malichao/Image_Edge_Detection/blob/master/snapshot/edge/07_prewitt_bool.jpg)  

Also I'm trying to write a post about these algorithms and how I implemented them.Check out my [website](http://lichaoma.com/).

