   M S B A M L   `   `   `  ����  
TestWPFApp     TestWPFApp.AdminBaseWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      $	��720��5   	   $
��1080��6     � WindowStartupLocation$  CenterScreen=�6#    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   "    � 	Resources 5
         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      �� -   5         �� CornerRadius$ 30��5      ���#EFF2F7._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5      �� $��1��6   ���#623ED0$ 	0 50 0 30��6;   ._�5      ]� $��0,75,0,0q�6    .+�5!      �� $��80��6!   $��80��6,    �� Padding$ 3q�68   
�������$	 100��6W   $	��Top=�6j   $
��Left=�6   $��
20 -30 0 0q�6�   ._�5"      A� ��5#   "   �� 5$   &    �� ImageSource$' !/Images/icons8-windows-11-100.png��61   5&      5'      �� 5*      -   5        	 ��Name$	 txtHeaderName��5*   $   $��Silvers Club��6;   
�������$��22(�6b   $��SemiBold"�6p   $	��Top=�6�   $��	5 25 0 10q�6�   
 �� TextAlignment$
 Center=�6�   �� 5+      ���#D0BFFF$��14(�69   $��SemiBold"�6G   $	��Top=�6]   $
 Center=�6r   �� 6�   $� ��6�   �� 6�   �� 6�   6�   �� 5-      $��25q�6$   ���#7E5FDC$	��Top=�6E   $	��0.8��6Z   �� 50      $	��Top=�6%   .+�51      ��   
menuButton#��[ 6%   .��52   "   ��  �� Orientation$ 
Horizontal=�6-   .+�53   &   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ HomeVariant=�6<     menuButtonIcon#��[ 6O   �� 54   &   $��	Dashboard��60   55   #   56      �� 57      -   5         ��Name$ 
btnMembers��57   %   #��[ 69   .��58   "   �� $ 
Horizontal=�6-   .+�59   &     $ AccountMultipleOutline=�6<   #��[ 6Z   �� 5:   &   $��Members��60   5;   #   5<      �� 5>      -   5        $ 
btbLibrary��5>   %   #��[ 69   .��5?   "   �� $ 
Horizontal=�6-   .+�5@   &     $ CalendarClock=�6<   #��[ 6Q   �� 5A   &   $��Events��60   5B   #   5C      �� 5G      #��[ 6%   .��5H   "   �� $ 
Horizontal=�6-   .+�5I   &     $ CashMultiple=�6<   #��[ 6P   �� 5J   &   $��Wallet��60   5K   #   5L      �� 5N      #��[ 6%   .��5O   "   �� $ 
Horizontal=�6-   .+�5P   &     $ ForumOutline=�6<   #��[ 6P   �� 5Q   &   $��Messages��60   5R   #   5S      5U      �� 5W      #��[ 6!   $��Bottom=�6E   $��Bottom=�6`   $��
15 0 15 20q�6x   .��5X      �� $ 
Horizontal=�6)   .+�5Y   "     $ Logout=�68   #��[ 6F   �� 5Z   "   $��Logout��6,   5[      5\      5^      5_      5a      � 5d      -   5         �Name$
 grid��5d      $��1��6!   $��30 20 20 20q�61    5e      �� 5f      $
��621* �6'   �� 5g      $
��209* �6'    5i      �� 5j      $
��auto �6$   �� 5k      $
��auto �6$   �� 5l      $
��auto �6$   �� 5m      $
��auto �6$   �� 5n      $
��auto �6$   �� 5o      $��* �6$   �� 5p      $
��auto �6$   .+�5t      � $	��300��6   $
��Left=�6#   $��	0,0,0,622q�6>   $��6��6Q   .+�5u      �� $
��20 0q�6    $��Center=�6.   ���#B0B9C6 J� IsHitTestVisible .   K� ZIndex$ 1��5v      $��Search here ...��6-   y�5w      ��  �� ElementName$ textBoxSearch�� �� Path$ Text.IsEmpty� �� 	Converter# [  �� 5y      -   5        $��textBoxSearch��5y        searchTextbox#��[ 63     5{      $ Magnify=�6,   $��15��6;   $��15��6F   $��Center=�6R   $��0 0 15 0q�6m   ���#B0B9C6$��Right=�6�   5|      �� 5      -   5        $ btnClose��5        	topButton#��[ 6+   $��0,14,20,13.6q�6N   ���#dcdcdc$��1��6�   .��5�        $ Close=�6,   5�      �� 5�      -   5        $ btnMinimize��5�      #��[ 6.   $��0,14,55,13.6q�6Q   $��1��6�   .��5�        $ WindowMinimize=�6,   5�      �� 5�      -	   5         ��Name$ AdminContent��5�   !   $�� ��67   $
��Left=�6B   $��
-3,1.4,0,0q�6]   $��5��6q   $	��Top=�6~   $	��600��6�   $	��800��6�   $��2��6�   5�      5�      5�      5�      