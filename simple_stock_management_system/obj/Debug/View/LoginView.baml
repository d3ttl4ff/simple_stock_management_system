   M S B A M L   `   `   `  ����Y  Usimple_stock_management_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:simple_stock_management_system.ViewModels)simple_stock_management_system.ViewModels  5   	   m;clr-namespace:simple_stock_management_system.CustomControls-simple_stock_management_system.CustomControls  5   	   3    -simple_stock_management_system.View.LoginView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   M	viewModel7clr-namespace:simple_stock_management_system.ViewModels     5   	   VcustomControls;clr-namespace:simple_stock_management_system.CustomControls     5   	   -   5          � Title$  	LoginView��5	   	   $	��550��6   $	��800��6(    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency .  � DataContext 5      >   8simple_stock_management_system.ViewModels.LoginViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��5      �� 
 �� CornerRadius$
 12��6   ��5   
   �� 5       �� ImageSource$ /Images/dots2.jpg��6    �� BitmapScalingMode$ HighQuality=�5       ._�5"   
   �� $
 10��6   $��2q�5#       J� Opacity$
 0.90Q�5$      ��5%      �� 5&       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5'      �  � Color$ #9fef00��6#    � Offset$ 0Q�63   � 5(      $ #141d2b��6#   $	 0.5Q�63   � 5)      $ #9fef00��6#   $ 1Q�63   5*      ��5-      �� 5.      $	 0,1&�6&   $	 1,0&�67   .��5/      � $ #141d2b��6#   $ 0Q�63   � 50      $ #141d2b��6#   $
 0.75Q�63   51      ._�54      �  � RowDefinitions 55      �� 56      $��30 �6$   �� 57      .+�5:      �  � ColumnDefinitions 5;      �� 5<      �� 5=      $��25 �6+   �� 5>      $��25 �6+   �� 5?      $��5 �6+   .+�5B      �� $��LOG IN��6    
�������$��10(�5D       $��JetBrains Mono)�5E       $��0��5F       $��Center=�5G       $��10, 0, 0, 0q�5H       �� 5K      -   5         ��Name$ BtnMinimize��5K      $��0q�5L      $��-��5M      
�������$��16(�5O      $��
Montserrat)�5P       � Cursor$
 Hand��5Q      $��1��5R      ��5T      �� 5U       �� 
TargetType" ��6$   .�5V   "   ��  �� Property � �� �� Value �#0086FF6?    �� Triggers 5W   "   P� 5X   &    P� Property �@J�IsMouseOver P� Value . . �5Y   *   ��  � �� �#0070E36Y   5Z   '   5\      ��5_      �� 5`       �� 
TargetType" ��6.   .R�5a   "   �� $��18��6)   $��18��64   $
 9��5b   )   #��z��5c   )   ._�5d   &   �� $��Center=�67   $��Center=�5e   7   5f   #   5g      5i      �� 5k      -   5        $ BtnClose��5k      $��0q�5l      $��X��5m      
�������$��12(�5o      $��
Montserrat)�5p      $
 Hand��5q      $��2��5r      ��5t      �� 5u      " ��6$   .�5v   "   ��  � �� �#9f00FF6?    5w   "   P� 5x   &    �@J�IsMouseOver . . �5y   *   ��  � �� �#e633336Y   5z   '   5|      ��5      �� 5�      " ��6.   .R�5�   "   �� $��18��6)   $��18��64   $
 9��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      �� 5�      $	��250��6   $��1��5�       �� Orientation$ Vertical=�5�      $��0, 35, 0, 0q�5�      .+�5�      �� $��/Images/stockflowlogo.png��6   $	��100��5�      $	��100��6(   $ HighQuality=�5�      �� 5�      $��
STOCK FLOW��6    
�������$��25(�5�       $��JetBrains Mono)�5�       $��Center=�5�       $��0, 10, 0, 0q�5�       �� 5�      $��	User Name��6    
�������$��12(�5�       $��Light"�5�       $��JetBrains Mono)�5�       $��0, 35, 0, 0q�5�       �� 5�      -   5         ��Name$ TxtUser��5�      $��13(�5�      $��Medium"�5�      $��JetBrains Mono)�5�      
������� �� 
CaretBrush
 �����
�������$��
0, 0, 0, 2q�5�      $��
0, 5, 0, 0q�5�      $��28��5�      $��Center=�5�      $��20,0,0,0q�5�      ��5�      �� *
Username+  �� UpdateSourceTrigger$  PropertyChanged=�.��5�   1   ��5�      �� 5�      $ /Images/user_white.png��6)   ! j� Stretch$! Uniform=�5�   )   " j� 
AlignmentX$
" Left=�5�   )   # j� 
AlignmentY$# Center=�5�   )   $ j� Viewbox$ 5�   "   � 5�   &   % � X$% 0Q�6,   & � Y$& 0Q�62   ' � Width$	' 1.5Q�68   ( � Height$	( 1.5Q�6D   5�      .��5�   .   5�      �� 5�      $��Password��6    
�������$��12(�5�       $��Light"�5�       $��JetBrains Mono)�5�       $��0, 15, 0, 0q�5�       G   Asimple_stock_management_system.CustomControls.BindablePasswordBox  5�      $��
0, 5, 0, 0q�5�   9   $��28��5�   9   )   Pass) 5�   9   �� *
Password+$ TwoWay=�$  PropertyChanged=�5�      �� 5�      -   5        * ��Name$* ErrorMessageBorder��5�       69   �� *ErrorMessageOpacity+._�5�      �� ���#ff3e3e$��12(�5�   $   $��Light"�5�   $   $��JetBrains Mono)�5�   $   $��0, 10, 0, 0q�5�   $   ��5�   $   �� *ErrorMessage+5�   $   5�      �� 5�      -   5        $ BtnLogin��5�      $��0q�5�      $��LOGIN��5�      ���#141d2b$��12(�5�      $��JetBrains Mono)�5�      $
 Hand��5�      $��0, 30, 0, 0q�5�      ��5�      �� *LoginCommand+��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#9fef006?    5�   "   P� 5�   &    �@J�IsMouseOver . . �5�   *   ��  � �� �#ccff666Y   5�   '   P� 5�   &    � �� . . �5�   *   ��  � �� �#7dbb006Y   5�   '   �� 5�   &   + �� Binding+ 62   �� *	ValidData+, �� Value	, False6P   .a�5�   *   ��  � {� .  6F   �� 5�   *    � �� �#a4b1cd6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $
 20��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      5�      5�      5�      5�      