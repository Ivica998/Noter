   M S B A M L   `   `   `  ����@  <Noter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Noter.UserControlsNoter.UserControls  5      C&clr-namespace:Noter.Models.AttachmentsNoter.Models.Attachments  5      A%clr-namespace:Noter.Models.ConvertersNoter.Models.Converters  5      A%clr-namespace:Noter.Models.MyControlsNoter.Models.MyControls  5	           Noter.UserControls.ColColC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Noter.UserControls     5      9attach&clr-namespace:Noter.Models.Attachments     5      8conver%clr-namespace:Noter.Models.Converters     5      4uc%clr-namespace:Noter.Models.MyControls     5	      -   5        !   Noter.UserControls.BaseConC   Name$
  this��5
      (   "Noter.Models.Attachments.DragDropA   
AllowCDrop$
 True��5      .��5      � -   5         �Name$ g1��5       � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � -   5        $��25��5      $��Stretch=�6   $	��Top=�69   
������  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��60 �6#   �� 5      $��* �6#   �� 5      $��25 �6#   �� 5      $��25 �6#   �� 5      $��25 �6#   .+�5!      �� -   5        
������ ��5!   C   ��  �� ElementName$
 this�� �� Path$ 
Foreground���5"      �� 5#       �� 
TargetType" ��6    �� BasedOn# [B��69   .�5$      �� 	 �� Property	 � ��
 �� Value$
 25��62   �� 5%      	 � ��$
 25��63   �� 5&      	 � ��$
 v��64   �� 5'      	 �@�ToolTip$
 Expand��64   �� 5(      	 � ��
 68   ��  �� Self �� RelativeSource# Z $ 
Foreground��� 5)      	 � ��$
 2q�6<    �� Triggers 5*      �� 5+       �� Binding 6*   �� $ containerHolder��$ 
Visibility� �� Value Visible6j   .a�5,   "   �� 	 � ��$
 ^��6<   �� 5-   "   	 �@�ToolTip$
 Collapse��6<   �� 5.   "   	 � ��   Button_Active_FG#
 [  6?   5/      51      53      �� 54      $��Stretch=�6   $|�False��62   $��1��6D   
������ $��Center=�6�   ��6m   �� $
 this��$ 
Foreground���55      �� 56      " ��6   .�57      �� 	 � ��$
 Expand��64    58      �� 59       6*   �� $ containerHolder��$ 
Visibility� Visible6j   .a�5:   "   �� 	 � ��$
 Collapse��6<   �� 5;   "   	 � ��#
 [  6?   5<      5>      5@      �� 5A      $��2��6M   $|�False��6]   $��Center=�6o   ��6   �� $
 this��$ 
Foreground���6�   �� *Header+$
 this�� �� Mode$ OneWay=��� 5B      -   5        $��3��5B        	ImgButton#��[ 6%   $��Right=�6H   $��25��6d   $��25��6p     plusPNG#��[ 6{   6�   �� 5C      -   5         ��Name$ settings��5C      $��4��6'   #��[ 67   $��Right=�6Z   $��25��6v   $��25��6�     settingsPNG#��[ 6�   6�   �� 5D      -   5        $ dragger��5D      $��5��6&   $��False��66   #��[ 6H   $��Right=�6k   $��25��6�   $��25��6�     dragPNG#��[ 6�      
AllowCDrag$
 True��6�   5E      �� 5F   
   -   5         ��Name$ containerHolder��5F      $��1��60   $
��Auto=�6=   .��5G      �� .+�5H      �� -	   5         ��Name$ 	container��5H      5I      5J      5N      5O      