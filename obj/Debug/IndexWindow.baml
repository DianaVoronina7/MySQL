   M S B A M L   `   `   `  ����R  NОтдел кадров, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Отдел_кадровОтдел_кадров  5   	   )    #Отдел_кадров.IndexWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Отдел_кадров     5   	     � Title$  Главное меню��5   	   $	��120��6   $	��400��6+    � WindowStartupLocation$ CenterScreen=�67   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $*��$Выберите категорию:��6   $��10q�6/   $��Center=�6;   �� 5   
   -   5         ��Name$ CategoryComboBox��5      $��10q�6-   $��1��69    �� SelectedIndex$ 0��6l   ��6I   �� *
Categories+6l   �� 5   
   -   5         ��Name$ 
OpenButton��5      $��1��6%   $��2��62   $��Открыть��6F   $��10q�6X   {�6d   �� *IsOpenButtonEnabled+6�   5      5      