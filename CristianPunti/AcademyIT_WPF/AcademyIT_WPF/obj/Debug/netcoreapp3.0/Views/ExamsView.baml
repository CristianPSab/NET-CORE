   M S B A M L   `   `   `  ����J  FAcademy.App.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Academy.App.WPF.ViewsAcademy.App.WPF.Views  5      %    Academy.App.WPF.Views.ExamsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Academy.App.WPF.Views     5      .��5	      � ���	#FFE5E5E5  � RowDefinitions  5   
   �� 5      $	��150 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   � $��0��6   .+�5      �� $��Title��6   $
��Left=�6$   $��	22,10,0,0q�6?   $	��Top=�6R    J� RenderTransformOrigin$ -0.771,-0.594&�6j   $��78��6�   �� 5      $
��Text��6   $
��Left=�6#   $��	22,40,0,0q�6>   $	��Top=�6Q   $��78��6i   �� 5      $
��Date��6   $
��Left=�6#   $��	22,70,0,0q�6>   $	��Top=�6Q   $ 0.13,-0.391&�6i   $��78��6�   �� 5      $��Subject��6   $
��Left=�6&   $��
22,100,0,0q�6A   $	��Top=�6U   $ 0.13,-0.391&�6m   $��78��6�   �� 5      -   5         ��Name$ 	TitleText��5      $
��Left=�6@   $��23��6[   $��
125,10,0,0q�6g    �� TextWrapping$
 Wrap=�6{   $	��Top=�6�   $	��195��6�   $ 0.292,0.209&�6�   ��6)   �� *Title+6�   �� 5      -   5        $ TextText��5      $
��Left=�6?   $��23��6Z   $��
125,40,0,0q�6f   $
 Wrap=�6z   $	��Top=�6�   $	��195��6�   ��6)   �� *Text+6�   (  "System.Windows.Controls.DatePicker  5      $��125,73,445,54q�6      FirstDayOfWeek$ Monday=�60      SelectedDate 6H   �� *Date+�� 5      -   5         ��Name$ ComboBoxSubjects��5      $
��Left=�62   $��125,100,0,0q�6M   $	��Top=�5      $	��195��6/    �� DisplayMemberPath$
 Name��5   @   ��6   �� *SubjectsNameList+ �� SelectedItem 5      �� *CurrentSubjectEVM+�� 5      $��REFRESH��6   $ 2.496,0.667&�6T   $��342,113,363,15q�6x   ��6'   �� *GetSubjectsNameEVCommand+6x   �� 5      	 �� Orientation$	 
Horizontal=�6   $
��Left=�62   $��	425,0,0,0q�6M   $	��375��6`   .+�5       �� $��30��6   $��Guardar examen��6%   $	��112��6a   ��6>   �� *AddExamCommand+6a   �� 5!      $��30��6   $��Editar examen��6%   $	��124��6c   ��6=   �� *UpdateExamCommand+6c   �� 5"      $��30��6   $��Eliminar examen��6%   $	��124��6e   ��6?   �� *DeleteExamCommand+6e   5#      5%      � 5(   
   $��1��6   
 � ColumnDefinitions
 5*      �� 5+      $��* �6#   �� 5,      $
��Auto �6#   .+�5/      &   System.Windows.Controls.DataGrid  -   5          Name$ ExamsDataGrid��5/      $��0��6.   $��5,5,5,5q�6�      AutoGenerateColumns$ False��6�   ��6>   �� *ExamsListEV+ 6b   �� *CurrentExamEV+   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Title+6U     52      $
 Text��6)    68   �� *Text+6S     53      $
 Date��6)    68   �� *Date+6T     54      $ Subject��6)    6:   �� *Subject.Name+6]     55      $ IdExam��6)    6:   �� *Id+6T   58      5:      � 5;   
   $��2��6   .+�5=      �� $��Obtenir examens��6   $	��100��6S   $��0,5,60,5q�6_   $��Right=�6q   $ 0.9,3.5&�6�   ��6/   �� *GetExamsCommand+6�   5?      5@      5A      