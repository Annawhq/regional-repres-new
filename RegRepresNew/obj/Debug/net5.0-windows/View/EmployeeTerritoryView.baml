   M S B A M L   `   `   `  ����G  CRegRepresNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RegRepresNew.ViewRegRepresNew.View  5   	   -    'RegRepresNew.View.EmployeeTerritoryView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RegRepresNew.View     5   	     � Title$)  #Область сотрудника��5   	   $	��150��5	   	   $	��400��6    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$ 
ToolWindow=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��3q�6   $��Сотрудник:��6   $��Right=�61   $��Center=�6M   �� 5   
   $��1��6   $��3q�6!   $>��8Наименование области или края:��6,   $��Right=�6R   $��Center=�6n   �� 5   
   $��1��6   $��5q�6#   $��25��6.    �� SelectedValuePath$ Id��5       �� SelectedValue 5      ��  �� Path$ 
EmployeeId� �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=���5      �� 5      .R�5       �� 
 �� Orientation$
 
Horizontal=�6!   .+�5!      �� ��6$   �� $ Lastname��� 5"      $��  ��6$   �� 5#      ��6$   �� $ 	Firstname�5$      5%      5'      �� 5(   
   $��1��6   $��1��6    $��5q�60   $��25��6;   $ Id��5*       5)      �� $ TerritoryId�$ TwoWay=�$	 PropertyChanged=���5+      �� 5,      .R�5-      �� $
 
Horizontal=�6!   .+�5.      �� ��6$   �� $ Discription�5/      50      52      �� 54   
   $��2��6   $��2��6"   $
 
Horizontal=�66   $��Right=�6O   .+�55      �� -   5         ��Name$
 btOK��55      $��Подтвердить ��6#   $��5q�6:   $��20��6E    �� 	IsDefault$
 True��6d   �� 56      -   5        $ btConcel��56      $��Отменить��6'   $��5q�6:   $��20��6E    �� IsCancel$
 True��6Q   6a   57      59      5:      