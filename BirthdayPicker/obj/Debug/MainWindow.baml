   M S B A M L   `   `   `  ����I  EBirthdayPicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BirthdayPickerBirthdayPicker  5   	       BirthdayPicker.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BirthdayPicker     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     � Title$#  Birthday computer application��5	   	   $	��500��6/   $	��700��6<   .��5
      � {�6   �� *IsControlEnabled+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� � RowDefinitions 5   
   �� 5      $
��Auto �6   $
��30px��6*   �� 5      $
��35px��6   �� 5      $
��Auto �6   $
��30px��6*   �� 5      $
��35px��6   �� 5      $
��Auto �6   $
��30px��6*   �� 5      $
��35px��6   �� 5      $
��Auto �6   $
��30px��6*   �� 5      $
��Auto �6   $
��40px��6*   �� 5      $
��Auto �6   $
��40px��6*   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"   $
��Left=�63   $��Center=�6O   $
��Bold"�6j   $��14(�6|   $��
First name��6�   �� 5   
   $��1��6   $��5q�6   ��6*   �� *	FirstName+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5   
   $��2��6   $��0��6"   $
��Left=�63   $��Center=�6O   $
��Bold"�6j   $��14(�6|   $��	Last name��6�   �� 5   
   $��3��6   $��5q�6    ��6+   �� *
LastName+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5   
   $��4��6   $��0��6"   $
��Left=�63   $��Center=�6O   $
��Bold"�6j   $��14(�6|   $��Email��6�   �� 5    
   $��5��6   $��5q�6   ��6*   �� *Email+$ OneWayToSource=�$ PropertyChanged=�6}   �� 5!   
   $��6��6   $��0��6"   $
��Left=�62   $��Center=�6N   $
��Bold"�6i   $��14(�6{   $��Birthday date��6�   (  "System.Windows.Controls.DatePicker  5"   
   $��7��6   $��0��6"   $��Stretch=�62   $��Center=�6P   $��10q�6k      FirstDayOfWeek$ Monday=�6w      IsTodayHighlighted .    SelectedDate 6�   �� *Date+$ OneWayToSource=�$ PropertyChanged=��� 5#   
   $��8��6   $��0��6"   $��Stretch=�62   $��Stretch=�6P   $��
20 10 60 0q�6l   $��5q�6�   $��Proceed��6�   ��6�   �� *ProceedCommand+"  FontAwesome.WPF.ImageAwesome  5$   
   $��9��6   $��2��6'      Icon$ Refresh=�6;   $��20q�6J   $��50��6W   $��50��6b   	   Spin	 . y�6z   �� *LoaderVisibility+$ OneWay=�$ PropertyChanged=�6�   �� 5%   
   $��1��6   $��9��6&   $
��Bold"�67   $��Stretch=�6I   $��17(�6e   $��0 10 0 0q�6s   ��6�   �� *
ResultInfo+$ oneWay=�$ PropertyChanged=�6�   5&      5'      