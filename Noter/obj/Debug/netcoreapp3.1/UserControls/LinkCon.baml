   M S B A M L   `   `   `  ����@  <Noter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Noter.UserControlsNoter.UserControls  5      C&clr-namespace:Noter.Models.AttachmentsNoter.Models.Attachments  5      A%clr-namespace:Noter.Models.MyControlsNoter.Models.MyControls  5           Noter.UserControls.LinkCon   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Noter.UserControls     5      9attach&clr-namespace:Noter.Models.Attachments     5      4cc%clr-namespace:Noter.Models.MyControls     5      -   5        !   Noter.UserControls.BaseConC   Name$
  this��5	      $��28��5
   :   .��5      � -   5         �Name$
 grid��5      $��Stretch=�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � 5      %   Noter.Models.MyControls.Resizer  5   
   $��1��6      ResizeDirection$ S=�6F      Object 6"   ��  �� ElementName$
 this��6F   �� 5   
   -   5         ��Name$ settings��5         	ImgButton#��[  6#   $��Right=�6F   $	��Top=�6b   $��25��6z   $��25��6�   $��0 0 25 0q�6�     settingsPNG#��[ 6�   6�   �� 5   
   -   5        $ dragger��5      $��False��6"   #��[  64   $��Right=�6W   $	��Top=�6s   $��25��6�   $��25��6�     dragPNG#��[ 6�   (   "Noter.Models.Attachments.DragDropA   
AllowCDrag$
 True��6�   5      5      