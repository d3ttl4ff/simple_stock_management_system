   M S B A M L   `   `   `  ����"  simple_stock_management_system2    ,simple_stock_management_system.View.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -   5          � Title$  MainView��5   	   $	��915��6   $
��1437��6'    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   
������  � AllowsTransparency .  � 	Resources 5         
MainButton �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� Triggers P� Property P� Value  GraySubtitle��%  &	        &	 �    �� 5   
   " ��6#   .�5      ��  � ��$ 0q�60   �� 5       � �� �#141d2b6+   �� 5       � ��$ 12(�6)   �� 5       � ��$ JetBrains Mono)�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� �#9fef006+   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $	��150��6!   $
 20��6.   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   5      5       5"       5$      P� 5%       �@J�IsMouseOver . . �5&      ��  � �� �#ccff6663   5'      P� 5(       � �� . . �5)      ��  � �� �#7dbb0063   5*      5,      �� 5.   
   " ��6%   .�5/      ��  � �� �#a4b1cd6+   �� 50       � ��$ 11(�6)   �� 51       � ��$ JetBrains Mono)�6+   �� 52       � ��$ Center=�62   �� 53       � ��$	 150��6&   �� 54       � ��$
 Wrap=�6-   �� 55       �@��TextAlignment$ Center=�6.   56      57      .��59      � .+�5:   
   �� $
 12��6   ��5;      �� 5<       �� ImageSource$ /Images/dots2.jpg��6   ._�5?      �� $
 10��6   $��2q�5@       J� Opacity$
 0.90Q�5A      ��5B      �� 5C       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5D      �  � Color$ #9fef00��6'    � Offset$ 0Q�67   � 5E      $ #141d2b��6'   $	 0.5Q�67   � 5F      $ #9fef00��6'   $ 1Q�67   5G      ��5J      �� 5K      $	 0,1&�6*   $	 1,0&�6;   .��5L      � $ #141d2b��6'   $ 0Q�67   � 5M      $ #141d2b��6'   $
 0.75Q�67   5N      ._�5Q      �  � RowDefinitions 5R      �� 5S      $��30 �6(   �� 5T      $	��300 �6(   �� 5U      .+�5X      �  � ColumnDefinitions 5Y      �� 5Z      �� 5[      $��25 �6/   �� 5\      $��25 �6/   �� 5]      $��5 �6/   .+�5`      �� $��STOCK FLOW (Admin)��6$   
�������$��10(�5b   $   $��JetBrains Mono)�5c   $   $��0��5d   $   $��Center=�5e   $   $��10, 0, 0, 0q�5f   $   �� 5i      -   5         ��Name$ BtnMinimize��5i   !   $��0q�5j   !   $��-��5k   !   
�������$��16(�5m   !   $��
Montserrat)�5n   !    � Cursor$
 Hand��5o   !   $��1��5p   !   ��5r      �� 5s   "   " ��6(   .�5t   &   ��  � �� �#0086FF6C    5u   &   P� 5v   *    �@J�IsMouseOver . . �5w   .   ��  � �� �#0070E36]   5x   +   5z   #   ��5}      �� 5~   "   "	 ��62   .R�5   &   �� $��18��6-   $��18��68   $
 9��5�   -   #��z��5�   -   ._�5�   *   �� $��Center=�6;   $��Center=�5�   ;   5�   '   5�   #   5�      �� 5�      -   5        $ BtnClose��5�   !   $��0q�5�   !   $��X��5�   !   
�������$��12(�5�   !   $��
Montserrat)�5�   !   $
 Hand��5�   !   $��2��5�   !   ��5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� �#9f00FF6C    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � �� �#e633336]   5�   +   5�   #   ��5�      �� 5�   "   "	 ��62   .R�5�   &   �� $��18��6-   $��18��68   $
 9��5�   -   #��z��5�   -   ._�5�   *   �� $��Center=�6;   $��Center=�5�   ;   5�   '   5�   #   5�      5�      �� 5�      $	��250��6!   $��1��5�   !    �� Orientation$ Vertical=�5�   !   $��0, 35, 0, 0q�5�   !   .+�5�      �� $��/Images/stockflowlogo.png��6    $	��100��5�       $	��100��6,    �� BitmapScalingMode$ HighQuality=�5�       �� 5�      $��
STOCK FLOW��6$   
�������$��25(�5�   $   $��JetBrains Mono)�5�   $   $��Center=�5�   $   $��0, 10, 0, 0q�5�   $   5�      � 5�      $��2��6   $��Center=�6(    5�      �� 5�      $
��Auto �6,   �� 5�      $��20 �6,   �� 5�      $
��Auto �6,    5�      �� 5�      $
��Auto �6/   �� 5�      $��30 �6/   �� 5�      $
��Auto �6/   �� 5�      $��30 �6/   �� 5�      $
��Auto �6/   .+�5�      �� -   5        $ BtnDashboard��5�   !   $��0��5�   !   $��0��6.   #��[  5�   !   ��5�   !   �� *DashboardCommand+.��5�      �� $ Vertical=�6)   $��20, 10q�6@   .+�5�   "   �� $��/Images/parcel-blue.png��6(   $��30��5�   (   $��30��63   $ HighQuality=�5�   (   �� 5�   "   $��	Dashboard��6,   $��Center=�6=   $��0, 10, 0, 0q�5�   ,   5�      5�      �� 5�      $��2��6$   $��0��61   $!��Add, Remove or Update items��5�   $   #��[ 5�   $   �� 5�      -   5        $ BtnLog��5�   !   $��0��5�   !   $��2��6.   #��[  5�   !   ��5�   !   �� *
LogCommand+.��5�      �� $ Vertical=�6)   $��20, 10q�6@   .+�5�   "   �� $��/Images/list-blue.png��6(   $��30��5�   (   $��30��63   $ HighQuality=�5�   (   �� 5�   "   $��Transaction Log��6,   $��Center=�6C   $��0, 10, 0, 0q�5�   ,   5�      5�      �� 5�      $��2��6$   $��2��61   $&�� View all transaction log entries��5�   $   #��[ 5�   $   �� 5�      -   5        $ BtnStock��5�   !   $��0��5�   !   $��4��6.   #��[  5�   !   ��5�   !   �� *StockCommand+.��5�      �� $ Vertical=�6)   $��20, 10q�6@   .+�5�   "   �� $ ��/Images/warehouse-blue.png��6(   $��30��5�   (   $��30��63   $ HighQuality=�5�   (   �� 5�   "   $��Stock��6,   $��Center=�69   $��0, 10, 0, 0q�5�   ,   5�      5�      �� 5�      $��2��6$   $��4��61   $*��$View all existing stock item records��5�   $   #��[ 5�   $   5�      5      5     5     5     5     