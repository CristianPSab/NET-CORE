   M S B A M L   `   `   `  ����J  FAcademy.App.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Academy.App.WPF.ViewsAcademy.App.WPF.Views  5      (    "Academy.App.WPF.Views.StudentsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Academy.App.WPF.Views     5      .��5	      � ���	#FFE5E5E5  � RowDefinitions  5   
   �� 5      $	��150 �6   6+   �� 5      $��* �6   6)   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   $��	290,0,0,0q�6M   $	��510��6`   .+�5      �� $��30��6   $��Guardar Estudiante��6%   $	��124��6h   ��6B   �� *AddStudentCommand+6h   �� 5      $��30��6   $��Editar Estudiante��6%   $	��124��6k   ��6A   �� *UpdateStudentCommand+6k   �� 5      $��30��6   $��Eliminar Estudiante��6%   $	��124��6l   ��6C   �� *DeleteStudentCommand+6l   5      �� 5      -   5         ��Name$ lbDni��5      $
��Dni:��6#   $
��Left=�63   $��	51,34,0,0q�6N   $	��Top=�6a   �� 5      -   5        $ lbNombre��5      $��Nombre:��6&   $
��Left=�69   $��	51,72,0,0q�6T   $	��Top=�6g   �� 5      -   5        $ lbSilla��5      $��Silla:��6%   $
��Left=�66   $��
51,103,0,0q�6Q   $	��Top=�6e   �� 5      -   5         ��Name$ tbDni��5      $
��Left=�6:   $��
120,38,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��120��6�   ��6%   �� *Dni+6�   �� 5      -   5        $ tbNombre��5      $
��Left=�6@   $��
120,76,0,0q�6[   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   ��6(   �� *Nombre+6�   �� 5      -   5        $ tbSilla��5      $
��Left=�6@   $��120,107,0,0q�6[   $
 Wrap=�6q   $	��Top=�6�   $	��120��6�   ��6(   �� *Silla+6�   5      � 5   
   $��1��6     5       �� 5!      $��* �6    6-   �� 5"      $��40 �6    6.   .+�5%      � $��0��6    � ColumnDefinitions 5&      �� 5'      $
��111* �6'   .+�5)      &   System.Windows.Controls.DataGrid  $��5,5,5,5q�6d   $��2��6u   ��6   �� *
Students+ �� SelectedItem 6<   �� *CurrentStudent+6u   5*      � 5+      $��1��6   .+�5,      �� $��Obtener estudiantes��6   $	��157��6^   $��	638,5,0,5q�6j   $
��Left=�6}   ��67   �� *GetStudentsCommand+6}   5-      5.      50      51      