### 热更新操作说明

测试版本为2018.4.13C

1. 先打开Hot.sln解决方案

   ![avatar](http://139.196.233.153/Picture/2.png)

   2.修改需要修改的类和需要替换的方法并重新生成

   ![avatar](http://139.196.233.153/Picture/1.png)

   ![avatar](http://139.196.233.153/Picture/6.png)

3. 打开Addressable的Group并进行打包

   ![avatar](http://139.196.233.153/Picture/12.png)

   ![avatar](http://139.196.233.153/Picture/0.png)

4.将打包好的文件放到服务器

![avatar](http://139.196.233.153/Picture/8.png)

![avatar](http://139.196.233.153/Picture/3.png)

![avatar](http://139.196.233.153/Picture/5.png)

服务器资源存放位置

![avatar](http://139.196.233.153/Picture/4.png)

5.打包工程运行即可

### 备注

#### AddressableAssets的首次使用

1. 将资源文件放入AddressableAssets下

   ![avatar](http://139.196.233.153/Picture/15.png)

2. 打开Group 点击Build里的CreateAuto 他会自动生成对应的AssetGroups 

   ![avatar](http://139.196.233.153/Picture/16.png)

3. 后续更新可以使用增量更新

   ![avatar](http://139.196.233.153/Picture/14.png) 

![avatar](http://139.196.233.153/Picture/13.png)

