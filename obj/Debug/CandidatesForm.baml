   M S B A M L   `   `   `  ����R  NОтдел кадров, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Отдел_кадровОтдел_кадров  5      ,    &Отдел_кадров.CandidatesForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      7local%clr-namespace:Отдел_кадров     5        � Title$  Кандидаты��5      $	��300��6   $	��600��6'    � WindowStartupLocation$ CenterScreen=�66   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ UploadButton��5      $��0��6'   $��0��64   $3��-Загрузить данные из базы��6D   $��10q�6g   6s   �� 5   
   -   5        $ 	AddButton��5      $��0��6$   $��1��61   $��Добавить��6A   $��10q�6T   6`   �� 5   
   -   5        $ 
EditButton��5      $��0��6%   $��2��62   $ ��Редактировать��6B   $��10q�6Z   {�6   �� *IsEditButtonEnabled+�� 5   
   -   5        $ DeleteButton��5      $��0��6'   $��3��64   $��Удалить��6D   $��10q�6V   {�6}   �� *IsDeleteButtonEnabled+�� 5   
   -   5         ��Name$ SearchTextBox��5      $��0��6)   $��4��66   $��10q�6F   6R   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CandidatesDataGrid��5      $��1��6/   $��5��6<   $��10q�6P      AutoGenerateColumns .     SelectionMode$ Single=�5       	   CanUserAddRows	 .  
   CanUserDeleteRows
 .  ��5      �� *
Candidates+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *CandidateId+6Q     5$      $ Фамилия��6%   $ * 6S    66   �� *
LastName+6S     5%      $ Имя��6%   $ * 6P    62   �� *	FirstName+6P     5&      $ Отчество��6%   $ * 6V    67   �� *
MiddleName+6V     5'      $2 ,Адрес электронной почты��6%   $ * 6`    6F   �� *Email+6`     5(      $! Номер телефона��6%   $ * 6]    6=   �� *PhoneNumber+6]     5)      $ Опыт работы��6%   $ * 6Y    6:   �� *
Experience+6Y     5*      $ Образование��6%   $ * 6X    6:   �� *	Education+6X     5+      $ Рекомендации��6%   $ * 6_    6;   �� *Recommendations+6_     5,      $ Вакансия��6%   $ * 6S    67   �� *	Vacansy+6S   5.      �� 50   
   -   5         ��Name$ ErrorTextBlock��50      $��2��6,   $��5��69   $��10q�6M   
���  ��$y�	Collapsed=�6j   51      52      