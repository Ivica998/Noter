   M S B A M L   `   `   `  ����@  <Noter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NoterNoter  5      C&clr-namespace:Noter.Models.AttachmentsNoter.Models.Attachments  5      7 clr-namespace:Noter.UserControlsNoter.UserControls  5      1clr-namespace:Noter.ViewModelNoter.ViewModel  5	      &     Noter.UserControls.SearchControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Noter     5      9attach&clr-namespace:Noter.Models.Attachments     5      /uc clr-namespace:Noter.UserControls     5      ,vmclr-namespace:Noter.ViewModel     5	      -   5          >�Name$  sc��5
      $
|�True��5   J    J� InputBindings 5       � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � y�$ Visible=�6+   6=    5      P� 5       � ��$  ��6-   . �5      ��  � y�$ 	Collapsed=�63   6G   5      5      5      .��5      � -   5        	 �Name$	 g5��5      $��0��6   $��0��6$   
 � RowDefinitions
 5   
   �� 5      -   5         ��Name$ r5��5   *   $
��auto �6   6*   �� 5      $
��auto �6   �� 5      $��60��6   $
��auto �6+   �� 5      $
��auto �6   �� 5      $��* �6   .+�5!   
   � -   5        $	 g6��5!      $��0��6   $��0��6(   $
|�True��68   #   Noter.Models.Attachments.NavA   PanelNav$
 PASS=�6I    � ColumnDefinitions 5"      �� 5#      $��* �6#   �� 5$      $
��auto �6#   �� 5%      $
��auto �6#   �� 5&      $
��auto �6#   �� 5'      $
��auto �6#   �� 5(      $
��auto �6#   .+�5*      �� -   5         ��Name$ cbTag��5*      $
|�True��6&   -  'System.Windows.Input.KeyboardNavigation   	IsTabStop$
 True��67   $��0��6[    �� 
IsEditable$
 True��6k   $��Stretch=�6}   $	��Top=�6�   $��26��6�    �� DisplayMemberPath$
 Name��5+   A    �� SelectedValuePath$
 Name��6Z   ��6   �� *	Tags.List+)   #Noter.Models.Attachments.TagManageA   	TagManage 6s   �� *TSVM1+�� 5,      -   5        $��1��5,      $��S��6%    � ToolTip$ Search��6F   $��20��6W   ���#FFBBCC$��3q�6x   �� 5-      -   5        $��2��5-      $��E+��6%   $ 	New Entry��6J   �� 5.      -   5        $��3��5.      $��E-��6%   $ Delete Entry��6M   �� 5/      -	   5        $��4��5/      $��T+��6%   $ New Tag��6H   �� 50      -
   5        $��5��50      $��T-��6%   $ 
Delete Tag��6K   51      �� 52   
   -   5         ��Name$ l1��52         
lbErrStyle#��[  6   $
��auto��6@   $��1��6M   �� 53   
   $��2��6   $
��Auto=�6$   $
 PASS=�6u   ��6G   �� *ActualWidth+ �� ElementName$ g6��.��54      � -   5         �Name$	 STH��54      55      �� 56   
   $��3��6   
���   � �� ShowsPreview$
 true��67   $��5��6K   $��Stretch=�6V   $��Center=�6t    �� ResizeDirection$
 Rows=�6�   �� 57   
   $��4��6   $
��Auto=�6$   $
 PASS=�6u   ��6G   �� *ActualWidth+$ g6��.��58      � -   5        $ MH��58      59      5:      5;      