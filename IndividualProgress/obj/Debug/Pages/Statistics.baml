   M S B A M L   `   `   `  ����M  IIndividualProgress, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:IndividualProgress.PagesIndividualProgress.Pages  5      M+clr-namespace:IndividualProgress.ConvertersIndividualProgress.Converters  5      )    #IndividualProgress.Pages.Statistics   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:IndividualProgress.Pages     5      ?Convert+clr-namespace:IndividualProgress.Converters     5        N� Title$  Статистика��5	       � 	Resources 5
      1  +IndividualProgress.Converters.DateConverter 	  Short��%   &	          5   
   6    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��7* �6    �� 5      $��1* �6    .+�5      �� $��20(�6   $(��"Полная статистика:��6&   $��	10,0,0,20q�6@   �� 5      $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��120��6    $��5,0,0,8q�6,   $��Center=�6=    �� TextAlignment$ Right=�6X   $��Период с : ��6n   (  "System.Windows.Controls.DatePicker  5      $	��120��6D   $��0,0,0,5q�6P      SelectedDate 6!   �� *	BeginDate+6P   �� 5      $
��auto��6    $��5,0,5,8q�6-   $��Center=�6>   $ Right=�6Y   $�� по : ��6o     5      $	��120��6B   $��5,0,0,5q�6N    6!   �� *	EndDate+6N   5      �� 5       $ 
Horizontal=�6   $��5,0,5,8q�66   .+�5!      �� $	��120��6    $��Center=�6,   $ Right=�6G   $#��Преподаватель : ��6]   �� 5"      $	��300��6    �� DisplayMemberPath$
 Name��6+   ��6D   �� *
Teachers+ �� SelectedItem 6e   �� *SelectedTeacher+5#      �� 5$      $ 
Horizontal=�6   $��5,0,5,8q�66   .+�5%      �� $	��120��6    $��Center=�6,   $ Right=�6G   $��Сфера : ��6]   �� 5&      $	��300��6   $
 Name��6s   ��6+   �� *	Spheres+ 6K   �� *SelectedSphere+6s   5'      �� 5)      $ 
Horizontal=�6   $��5,0,5,8q�66   .+�5*      �� $	��120��6    $��Center=�6,   $ Right=�6G   $��Масштаб : ��6]   �� 5+      $	��300��6   $
 Name��6q   ��6+   �� *Levels+ 6J   �� *SelectedLevel+6q   5,      �� 5.      	 � DataContext	 6   �� *Stat+.��5/      �� .+�50      �� $ 
Horizontal=�6%   .+�51      �� $	��200��6(   $ Right=�64   $6��0Общее количество участий: ��6J   $��10q�6l   $��15(�6x   �� 52      $��Center=�6(   $��10q�6�   $��15(�6�   ��6C   �� *
CountParts+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   53      �� 54      $ 
Horizontal=�6%   .+�55      �� $	��200��6(   $ Right=�64   $(��"Результативность: ��6J   $��10q�6d   $��15(�6p   �� 56      $��Center=�6(   $��10q�6�   $��15(�6�   ��6C   �� *	AllResult+$
 TwoWay=�$ PropertyChanged=�6�   57      �� 58      $ 
Horizontal=�6%   .+�59      �� $	��200��6(   $ Right=�64   $��Center=�6J   $6��0Количество призовых мест: ��6f   $��
10,10,10,0q�6�   $��15(�6�   �� 5:      $��Center=�6(   $��
10,10,10,0q�6�   $��15(�6�   ��6C   �� *CountPrizePlace+$
 TwoWay=�$ PropertyChanged=�6�   5;      �� 5<      $ 
Horizontal=�6%   .+�5=      �� $	��200��6(   $ Right=�64   $��Первых мест: ��6J   $��	10,3,10,0q�6_   $��15(�6r   �� 5>      $��Center=�6(   $��	10,3,10,0q�6d   $��15(�6w   ��6C   �� *CountFirstPlace+6w   5?      �� 5@      $ 
Horizontal=�6%   .+�5A      �� $	��200��6(   $ Right=�64   $��Вторых мест: ��6J   $��	10,3,10,0q�6_   $��15(�6r   �� 5B      $��Center=�6(   $��	10,3,10,0q�6e   $��15(�6x   ��6C   �� *CountSecondPlace+6x   5C      �� 5D      $ 
Horizontal=�6%   .+�5E      �� $	��200��6(   $ Right=�64   $��Третьих мест: ��6J   $��	10,3,10,0q�6`   $��15(�6s   �� 5F      $��Center=�6(   $��	10,3,10,0q�6d   $��15(�6w   ��6C   �� *CountThirdPlace+6w   5G      �� 5H      $ 
Horizontal=�6%   .+�5I      �� $	��200��6(   $ Right=�64   $!��Среднее место: ��6J   $��10q�6a   $��15(�6m   �� 5J      $��Center=�6(   $��10q�6�   $��15(�6�   ��6C   �� *AveragePlace+$
 TwoWay=�$ PropertyChanged=�6�   5K      5L      5M      5N      �� 5O      $ 
Horizontal=�6   $��2��62   .+�5P      �� -   5        $��	10,5,5,10q�5P      $��30��6,   $	��170��68   .��6V   .,Полный список студентов6o   �� 5Q      -   5        $��	10,5,5,10q�5Q      $��30��6,   $	��170��68   .��6T   20Полный список мероприятий6o   5R      5S      � 5T   
   $��1��6    5U      �� 5V      $��1* �6    �� 5W      $��8* �6    .+�5Y      �� $��20(�6   $"��Список участий:��6&   $��	10,0,0,20q�6=   &   System.Windows.Controls.DataGrid  5Z      $��10q�6   $��1��6#      AutoGenerateColumns .     RowBackground
 �����   AlternatingRowBackground
 �����   CanUserAddRows .     CanUserDeleteRows .     FrozenColumnCount$ 3��5\   D      
IsReadOnly . ��5Z   0   �� *SelectedParts+   Columns 5]      0  *System.Windows.Controls.DataGridTextColumn  5^      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
Event.Name+6Z     5_      $ Студент��6)   $ 1* 6_    6:   �� *Student.FullName+6_     5`      $ 
Место��6)   $
 auto 6R    68   �� *Place+6R     5a      $  Преподаватель��6)   $ 1* 6a    6@   �� *Teacher.Name+6a     5b      $ Дата��6)   $
 auto 6x    67   �� *
Event.Date+ �� 	Converter# [  6x   5d      5f      5g      5h      