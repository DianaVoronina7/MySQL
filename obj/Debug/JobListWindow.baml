   M S B A M L   `   `   `  ����R  NОтдел кадров, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Отдел_кадровОтдел_кадров  5      +    %Отдел_кадров.JobListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      7local%clr-namespace:Отдел_кадров     5        � Title$#  Список вакансий��5      $	��400��6   $	��600��6*    � WindowStartupLocation$ CenterScreen=�66   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� -   5         ��Name$ UploadButton��5      $��0��6'   $��0��64   $3��-Загрузить данные из базы��6D   $��10q�6g   6s   �� 5   
   -   5        $ 	AddButton��5      $��0��6$   $��1��61   $��Добавить��6A   $��10q�6T   6`   �� 5   
   -   5        $ 
EditButton��5      $��0��6%   $��2��62   $ ��Редактировать��6B   $��10q�6Z   {�6   �� *IsEditButtonEnabled+�� 5   
   -   5         ��Name$ SearchTextBox��5      $��0��6)   $��4��66   $��10q�6F   ��6R   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�&   System.Windows.Controls.DataGrid  5   
   -   5          Name$ JobDataGrid��5      $��1��6(   $��5��65   $��10q�6I      AutoGenerateColumns .  	   SelectionMode$	 Single=�5      
   CanUserAddRows
 .     CanUserDeleteRows .     
IsReadOnly . ��5      �� *Jobs+ �� SelectedItem 5   *   �� *SelectedJob+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5$      $' !Название вакансии��6%   $ * 6Z    6@   �� *Title+6Z     5%      $' !Описание вакансии��6%   $ * 6`    6@   �� *Description+6`     5&      $0 *Требования к кандидату��6%   $ * 6f    6E   �� *Requirements+6f   5(      5)      5*      