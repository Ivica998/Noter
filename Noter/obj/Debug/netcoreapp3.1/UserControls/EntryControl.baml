   M S B A M L   `   `   `  ����@  <Noter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NoterNoter  5      C&clr-namespace:Noter.Models.AttachmentsNoter.Models.Attachments  5      7 clr-namespace:Noter.UserControlsNoter.UserControls  5      1clr-namespace:Noter.ViewModelNoter.ViewModel  5	      %    Noter.UserControls.EntryControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Noter     5      9attach&clr-namespace:Noter.Models.Attachments     5      /uc clr-namespace:Noter.UserControls     5      ,vmclr-namespace:Noter.ViewModel     5	      -   5        !   Noter.UserControls.BaseConC   Name$	  uc1��5
       !   Noter.UserControls.BaseConC   Loaded$ UserControl_Loaded��5   7   (   "Noter.Models.Attachments.DragDropA   
AllowCDrop$
 True��5         BG_BlueG#��[  5      
�������.��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   #   Noter.Models.Attachments.NavA   PanelNav$
 PASS=�6.   .+�5      �� -   5         ��Name$ cbTag��5       �� 
IsEditable$
 True��6&   $
��Left=�68   $��	10,10,0,0q�6S   $	��Top=�6f   $	��200��6~   $��26��6�    �� DisplayMemberPath$
 Name��5   9   	 �� SelectedValuePath$
	 Name��6R   ��6   �� *	Tags.List+)   #Noter.Models.Attachments.TagManageA
   	TagManage
 6k   �� *TSVM2+ �� ElementName$	 uc1���� 5      -   5          	ImgButton#��[ 5      $��	10,5,5,10q�68   $��30��6K   $��30��6W   $��30(�6b     plusPNG#��[ 6p   6�   �� 5      -   5        #��[ 5      $��	10,5,5,10q�68   $��30��6K   $��30��6W   $��30(�6b     savePNG#��[ 6p   6�   �� 5      -   5         ��Name$ l1��5      ���#FF0055
������ $��10,0,0,0q�6N   $��10(�6`   $
��Left=�6n   $�� ��6�   $��Center=�6�   $
��auto��6�   5      �� 5   
   $��1��6   $
��Auto=�6$   -  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 None=�6I   .��5       � -   5         �Name$ 	TagHolder��5       ���#5555555$      5%      �� 5&   
   -   5        $��2��5&      $
��Auto=�6$   ! �� IsDeferredScrollingEnabled$
 True��6z   $
 TRAP=�6�   .��5'      � -   5        $��2��5'       5(      �� 5)      $
��auto �6$   �� 5*      $
��auto �6$   �� 5+      $
��auto �6$   .+�5-      �� -	   5         ��Name$ ElementsHolder��5-      5.      �� 5/      -
   5        $��1��5/      #��[ 6&   $��Right=�6I   $��10q�6e   $��30��6q   $��30��6}   $��30(�6�   #��[ 6�   6�   �� 50      $��2��6   $	��800��67   ��6&   Z� 67   51      52      53      54      