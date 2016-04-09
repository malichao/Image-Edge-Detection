# Image Edge Detection
This project is my further study for image edge dection algorithm from [Building a Race Car project](http://lichaoma.com/2015/11/17/self-balancing-smart-car-based-on-freescale-mc9s12x128/).In this project,all the classical image detection algorithms are evaluated,namely Robert,Sobel,Prewiit,Laplacian,and Canny algorithm.Three filters are vailable to reduce the image noise,namely average filter,median value filter,and Gaussian filter.You can also sharpen,undo,binarize,and save the image.  

Program snapshot.It's currently in Chinese but I'll translate the program soon.  
![alt tag](snapshot/software-s.jpg)  

And here are some of the test results.  
**Sobel Algorithm,with Gaussian white noise**
![alt tag](snapshot/test4_高斯噪声1-s.jpg)  
![alt tag](snapshot/edge/test4_高斯噪声1_sobel_bool-s.jpg)   

**Canny Algorithm**
![alt tag](snapshot/green-train-4001-s.jpg)  
![alt tag](snapshot/edge/green-train-4001_canny-s.jpg)  

**Prewitt Algorithm**
![alt tag](snapshot/07-s.jpg)  
![alt tag](snapshot/edge/07_prewitt_bool-s.jpg)  

Also I'm trying to write a post about these algorithms and how I implemented them.Check out my [website](http://lichaoma.com/).

