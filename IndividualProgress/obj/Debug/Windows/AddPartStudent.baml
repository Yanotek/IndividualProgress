   M S B A M L   `   `   `  ����M  IIndividualProgress, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:IndividualProgress.WindowsIndividualProgress.Windows  5   	   /    )IndividualProgress.Windows.AddPartStudent   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:IndividualProgress.Windows     5   	     � Title$C  =Добавить информацию об участнике��5   	   $	��180��62   $	��460��6?   .��5	      �� .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��100��6   $��5,0,5,8q�6$    �� TextAlignment$ Right=�65   $��Имя:��6K   �� 5       �� 
IsEditable . $	��300��6)   $��5,0,30,5q�65    �� DisplayMemberPath$ FullName��6G   ��6d   �� *
Students+ �� SelectedItem 6�   �� *SelectedStudent+5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $	��100��6   $��5,0,5,8q�6$   $ Right=�65   $��Место:��6K   �� 5      $	��300��6   $��5,0,30,5q�6"   ��64   �� *
Part.Place+5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $	��100��6   $��5,0,5,8q�6$   $ Right=�65   $��Кол-во баллов:��6K   �� 5      $	��300��6   $��5,0,30,5q�6"   ��64   �� *
Part.Score+5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $	��100��6   $��5,0,5,8q�6$   $ Right=�65   $��Наставник:��6K   �� 5       . $
 Name��6F   $	��300��6_   $��5,0,0,5q�6k   $��Right=�6|    �� Text 6   �� *TeacherName+��6�   �� *
Teachers+ 6�   �� *SelectedTeacher+5      �� 5   
   $ 
Horizontal=�6   .+�5      �� -   5        $��30��5      $��5q�6!   .��6@   Отмена6H   �� 5      -   5        $��30��5      $��5q�6!   .��6=   Добавить6G   5      5      5       