   M S B A M L   `   `   `  ����@  <Noter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Noter.WindowsNoter.Windows  5   	   "    Noter.Windows.EntryDestroyer   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Noter.Windows     5   	   -   5          �Name$
  this��5       � WindowStartupLocation$ CenterScreen=�5   	    � Title$ EntryDestroyer��5	   	   $	��180��6    $	��250��6-    � 
ResizeMode$ NoResize=�69    J� InputBindings 5      �� 5   
   
 �� Key$	 Esc��6G    �� Command 6   ��  �� ElementName$
 this�� �� Path$ ESCCMD�6G   .��5      � 	 � RowDefinitions	 5   
   �� 5      $��30 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $
��Left=�6   $	��Top=�68   $	��166��6P   $��28��6\   .��6i   Delete Entry6w   �� 5   
   -   5        
 ��Name$
 cbScheme��5       $��1��6    �� 
IsEditable$
 True��63   $	��220��6E    �� DisplayMemberPath$
 Name��5   <    �� SelectedValuePath$
 Name��6U   ��6   �� *PrevEntries.List+6n   �� 5   
   -   5         ��Name$ reqText��5      $��2��6   ���#222222$��Center=�6E   $	��0,8q�6b   $��20��6o   $�� ��6{    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��220��6�   � 5   
   $��3��6   $	��220��6   .+�5      �� -   5        ���#222222$��50��5   *   $�� Delete ��65   $��Right=�6H   $	��Top=�6d   6|   �� 5      -   5         ��Name$ l1��5      ���#FF0055$��10(�65   $��0,0,0,0q�6C   $	��160��6U   $
��Left=�6a   $�� ��6�   $��Center=�6�   $
��Left=�6�   $��18��6�   5      �� 5   
   -   5        $��4��5      ���#222222$��50��63   $��3 0 3 0q�6>   $��	0,0,15,10q�6P   $�� Exit ��6c   $��Right=�6t   $��Bottom=�6�   6�   5      5       