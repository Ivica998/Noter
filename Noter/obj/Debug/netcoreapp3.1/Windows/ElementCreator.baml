   M S B A M L   `   `   `  ����@  <Noter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Noter.WindowsNoter.Windows  5   	   "    Noter.Windows.ElementCreator   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Noter.Windows     5   	   -   5        $
��this��5        � WindowStartupLocation$  CenterScreen=�5   	    � Title$ ElementCreator��5	   	   $	��160��6    $	��250��6-    � 
ResizeMode$ NoResize=�69      MyDesign#��[  6O    J� InputBindings 5
      �� 5   
   
 �� Key$	 Esc��6G    �� Command 6   ��  �� ElementName$
 this�� �� Path$ ESCCMD�6G   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $
��Left=�6   $	��Top=�6+   $	��150��6C   $��28��6O   .��6[   Choose Element Type6p   �� 5   
   -   5        	 ��Name$	 cbElementChoice��5       $��1��6   $	��220��6:   
 �� 
IsEditable$

 True��5   �   ��6   �� *elementChoices+$
 this��6�   �� 5   
   -   5         ��Name$ l1��5      $��2��6   ���#FF0055$��10(�6>   $��0,0,0,0q�6L   $
��Left=�6^   $�� ��6�   $	��Top=�6�   $��18��6�   � 5   
   $��4��6   .+�5      �� -   5         ��Name$ createButton��5      ���#222222$��3 0 3 0q�6@   $�� Create ��6R   $��Right=�6e   $��	0,0,70,10q�6�   $��Bottom=�6�   6�   �� 5      -   5        ���#222222$��3 0 3 0q�5   *   $�� Cancel ��6<   $��Right=�6O   $��	0,0,10,10q�6k   $��Bottom=�6~   6�   5      5      5      