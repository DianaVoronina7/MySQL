   M S B A M L   `   `   `  ����R  NОтдел кадров, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Отдел_кадровОтдел_кадров  5   	   '    !Отдел_кадров.JobWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Отдел_кадров     5   	     � Title$B  <Добавить/Редактировать вакансию��5   	   $	��300��61   $	��300��6>    � WindowStartupLocation$ CenterScreen=�6J   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��5q�6-   $��Название:��68   �� 5   
   -   5        $��Titler��5   :   $��0��6   $��1��6   $��5q�6/   ��6H   �� *	Job.Title+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��1��6   $��0��6   $��5q�6-   $��Описание:��68   �� 5   
   -   5        $
��Desc��5   :   $��1��6   $��1��6   $��5q�6/   ��6F   �� *Job.Description+$ PropertyChanged=��� 5   
   $��2��6   $��0��6   $��5q�6-   $��Требования:��68   �� 5   
   -   5        $	��Req��5   :   $��2��6   $��1��6   $��5q�6/   $	��120��6�   ��6F   �� *Job.Requirements+$ PropertyChanged=�6�   �� 5   
   $��3��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��5q�6g   .+�5      �� -   5         ��Name$ byButton��5      $��Добавить��6'   $��5q�6:    �� 	IsDefault . 6V   5      5      5      