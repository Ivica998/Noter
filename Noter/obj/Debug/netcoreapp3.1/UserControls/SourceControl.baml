   M S B A M L   `   `   `  ����@  <Noter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Noter.UserControlsNoter.UserControls  5      C&clr-namespace:Noter.Models.AttachmentsNoter.Models.Attachments  5      7 clr-namespace:Noter.UserControlsNoter.UserControls  5      A%clr-namespace:Noter.Models.MyControlsNoter.Models.MyControls  5	      )clr-namespace:Noter.UtilsNoter.Utils  5
      1clr-namespace:Noter.ViewModelNoter.ViewModel  5      &     Noter.UserControls.SourceControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Noter.UserControls     5      9attach&clr-namespace:Noter.Models.Attachments     5      /uc clr-namespace:Noter.UserControls     5      4cc%clr-namespace:Noter.Models.MyControls     5	      *utilclr-namespace:Noter.Utils     5
      ,vmclr-namespace:Noter.ViewModel     5      -   5          >�Name$
  this��5      $
|�True��5   7   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   $	��150��6,   �� 5      $
��auto �6   �� 5      $
��auto �6   $	��100��6,   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   &    Noter.UserControls.SearchControl  -   5          Name$ searchC��5      6/   �� 5   
   $��1��6   
���   � �� ShowsPreview$
 true��6:   $��5��6N   $��Center=�6X   �� 5   
   -   5         ��Name$ openEntries��5      $��2��6*   ���#444444#   Noter.Models.Attachments.NavA   PanelNav$
 PASS=�6O   5      �� 5   
   $��3��6   
���   �$
 true��6:   $��5��6N   $��Center=�6X   �� 5   
   -   5         ��Name$ activeEntryHolder��5   "   $��4��6   y�6>   �� *Entries.Active+ �� TargetNullValue$ Hidden��5      5      