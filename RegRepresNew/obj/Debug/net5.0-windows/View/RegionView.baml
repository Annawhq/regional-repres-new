   M S B A M L   `   `   `  ����G  CRegRepresNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RegRepresNew.ViewRegRepresNew.View  5   	   "    RegRepresNew.View.RegionView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RegRepresNew.View     5   	     � Title$  Области��5   	   $	��130��6   $	��350��6&    � WindowStartupLocation$ CenterScreen=�62    � WindowStyle$ 
ToolWindow=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��3q�6   $>��8Наименование области или края:��6   $��Right=�6E   $��Center=�6a   �� 5   
   $��1��6   $��5q�6"   $
��Left=�6P   $	��150��6k   $��20��6w   ��6-   �� *Regiondiscription+6w   �� 5   
   $��2��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Right=�6O   .+�5      �� -   5         ��Name$
 btOK��5      $��Подтвердить ��6#   $��5q�6:   $��20��6E    �� 	IsDefault$
 True��6d   �� 5      -   5        $ btConcel��5      $��Отменить��6'   $��5q�6:   $��20��6E    �� IsCancel$
 True��6Q   6a   5      5      5      