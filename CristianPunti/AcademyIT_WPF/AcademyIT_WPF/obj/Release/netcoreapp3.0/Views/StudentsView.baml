   M S B A M L   `   `   `  ���� J  FAcademy.App.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Academy.App.WPF.ViewsAcademy.App.WPF.Views  (    "Academy.App.WPF.Views.StudentsView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:Academy.App.WPF.Views     .��� ���	#FFE5E5E5  � RowDefinitions  �� $	��150 ��� $��* �.+�� $��0��.+��� $��30��$��Guardar Estudiante��$��374,95,308,25q����� *AddStudentCommand+�� -    ��Name$ lbDni��$
��Dni:��$
��Left=�$��	51,34,0,0q�$	��Top=��� -   $ lbNombre��$��Nombre:��$
��Left=�$��	51,72,0,0q�$	��Top=��� -   $ lbSilla��$��Silla:��$
��Left=�$��
51,103,0,0q�$	��Top=��� -    ��Name$ tbDni��$
��Left=�$��
120,38,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120���� -   $ tbNombre��$
��Left=�$��
120,76,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ tbSilla��$
��Left=�$��120,107,0,0q�$��0��$
 Wrap=�$	��Top=�$	��120���� -   $ 	lbMensaje��$�� ��$
��Left=�$��
548,60,0,0q�$	��Top=�$	��186��$y�Visible=�� $��1��  �� $��* ��� $��40 �.+�� $��0��.+�&   System.Windows.Controls.DataGrid  $��5q����� *
Students+� $��1��.+��� $��Get Students��$	��100��$��5q�$��Right=����� *GetStudentsCommand+