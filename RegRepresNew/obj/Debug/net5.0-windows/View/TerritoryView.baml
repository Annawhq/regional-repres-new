   M S B A M L   `   `   `  ����G  CRegRepresNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RegRepresNew.ViewRegRepresNew.View  5   	   %    RegRepresNew.View.TerritoryView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RegRepresNew.View     5   	     � Title$  Города��5   	   $	��150��6   $	��450��6%    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$ 
ToolWindow=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $��11.771 �6   �� 5      $��178.869 �6   �� 5      .+�5   
   �� $��3,0,0,0q�6   $>��8Наименование области или края:��6%   $
��Left=�6K   $��Center=�6f   $��2��6�   �� 5   
   $��1��6   $��79,0,0,0q�6!   $$��Название города:��63   $
��Left=�6K   $��Center=�6f   $��1��6�   �� 5   
   $��2��6   $��5,8,5,8q�6#   $��25��64    �� SelectedValuePath$ Id��5       �� SelectedValue 5      ��  �� Path$ RegionId� �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=���5      �� 5      .R�5       �� 
 �� Orientation$
 
Horizontal=�6!   .+�5!      �� ��6$   �� $ Regiondiscription�5"      5#      5%      �� 5&   
   $��2��6   $��1��6"   $��	0,10,0,10q�6/   $��Center=�6_   $	��250��6|   $��20��6�   ��6B   �� *Discription+6�   �� 5(   
   $��2��6   $
 
Horizontal=�6"   $
��Left=�6;   $��2��6V   $��	103,0,0,0q�6f   .+�5)      �� -   5         ��Name$
 btOK��5)      $��Подтвердить��6#   $��5q�69   $��20��6D    �� 	IsDefault$
 True��6c   �� 5*      -   5        $ btConcel��5*      $��Отменить��6'   $��5q�6:   $��20��6E    �� IsCancel$
 True��6Q   6a   5+      5-      5.      