   M S B A M L   `   `   `  ����@  <Noter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Noter.UserControlsNoter.UserControls  5   	   )clr-namespace:Noter.UtilsNoter.Utils  5   	   1clr-namespace:Noter.ViewModelNoter.ViewModel  5   	   clr-namespace:NoterNoter  5	   	   C&clr-namespace:Noter.Models.AttachmentsNoter.Models.Attachments  5
   	   A%clr-namespace:Noter.Models.ConvertersNoter.Models.Converters  5   	       Noter.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /uc clr-namespace:Noter.UserControls     5   	   *utilclr-namespace:Noter.Utils     5   	   ,vmclr-namespace:Noter.ViewModel     5   	   %localclr-namespace:Noter     5	   	   9attach&clr-namespace:Noter.Models.Attachments     5
   	   8conver%clr-namespace:Noter.Models.Converters     5   	   -   5          �Name$
  this��5       � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Noter��5   	   $	��450��6   $	��800��6$    � WindowState$ 	Maximized=�5   	    � SizeToContent$ Manual=�6!    � DataContext 5   	   ��  �� RelativeSource �� *Self+ J� InputBindings 5      �� 5   
   
 �� Key$ E��6F   	 �� 	Modifiers$
	 Ctrlf�6N   
 �� Command
 6   ��  �� ElementName$
 this�� �� Path$ ECCMD� �� CommandParameter 6_   �� $ cbSource��$ SelectedItem��� 5   
   $ E��6F   $	 
Ctrl+Shiftf�6N   
 6   �� $
 this��$ EDCMD� 6e   �� $ cbSource��$ SelectedItem��� 5   
   $ T��6F   $
	 Ctrlf�6N   
 6   �� $
 this��$ TCCMD� 6_   �� $ cbSource��$ SelectedItem��� 5   
   $ T��6F   $	 
Ctrl+Shiftf�6N   
 6   �� $
 this��$ TDCMD� 6e   �� $ cbSource��$ SelectedItem� � 	Resources 5      2   ,Noter.Models.Converters.UGridLengthConverter   UGridLengthConverter �� 	Converter �� ConverterParameter  UGridSplit_C50  UGridSplit_C100  UGridSplit_R25��%*  &	       &	      7   &	 ^     7   &	 �     7     5   
   67   �� 5   
   $ ActualWidth�6   $ g5��6%   8   $ 50��6h   6�   �� 5   
   $ ActualWidth�6   $ g5��6%   8   $	 100��6h   6�   �� 5   
   $ ActualHeigth�6   $ g5��6&   8   $ 25��6i   6�   5       .��5!      � -   5         �Name$ mainGrid��5!        BG_PinkG#��[ 6    � RowDefinitions 5"   
   �� 5#      $
��Auto �6   6,   �� 5$      $��* �6   6)   .+�5(   
   o� -   5        $��ok��5(      $��20��6   $	��Top=�6%   #   Noter.Models.Attachments.NavA   PanelNav$
 SKIP=�6=   .@�5)      m� $
��File��6   .@�5*      �� -   5        $��TestZone��5*      6C   5+      m� 5,      $
��View��6   .@�5-      �� -   5        $��Preferences��5-      6G   5.      m� 5/      $
��Help��6   50      51      `� 52   
   $��0��6   $��Stretch=�6#   $	��Top=�6A   $��0 20 0 0q�6Y   -  'System.Windows.Input.KeyboardNavigation   	IsTabStop$ False��6k   $
 SKIP=�6�   .�53      c�  c� Band$ 0��6    c� 	BandIndex$ 0��6      TabNavigation$ Continue=�6-   .@�54      �� 
���   �$��Regular"�6+   .��6@   	Source:6I   �� 55      -   5         ��Name$ cbSource��55      $	��400��6-    �� DisplayMemberPath$
 Path��6Y   ��69   �� *	Sources+6r   �� 56      -   5        #��[B��56   :    
 H_Dark#��[ 6c   $��5 0 5 0q�6�   .��57      �� .��6!   	_Browse6*   58      5;      5<      �� 5=   
   -   5         ��Name$ sHolder��5=      $��2��6"    6/   �� *SelectedItem+$ cbSource��5>      5?      