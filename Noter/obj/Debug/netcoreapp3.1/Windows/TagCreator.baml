   M S B A M L   `   `   `  ����@  <Noter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Noter.WindowsNoter.Windows  5   	       Noter.Windows.TagCreator   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Noter.Windows     5   	   -   5          �Name$
  this��5       � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
TagCreator��5	   	   $	��160��6   $	��250��6)    � 
ResizeMode$ NoResize=�65    J� InputBindings 5
      �� 5   
   
 �� Key$	 Esc��6G    �� Command 6   ��  �� ElementName$
 this�� �� Path$ ESCCMD�6G   .��5      � 	 � RowDefinitions	 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $
��Left=�6   $	��Top=�68   $	��166��6P   $��28��6\   .��6i   Input Tag Name6y   �� 5   
   -   5        
 ��Name$
 objName��5      $��1��6   ���#222222$��Center=�6E   $��	10,0,10,0q�6b   $�� ��6u    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $	��220��6�   6�   �� 5   
   -   5         ��Name$ l1��5      $��2��6      
lbErrStyle#��[  6)   � 5   
   $��4��6   $	��220��6   .+�5      �� -   5        ���#222222$��3 0 3 0q�5   *   $�� Create ��6<   $��Right=�6O   $��	0,0,60,10q�6k   $��Bottom=�6~   6�   �� 5      -   5        ���#222222$��3 0 3 0q�5   *   $�� Cancel ��6<   $��Right=�6O   $��0,0,0,10q�6k   $��Bottom=�6}   6�   5      5      5      